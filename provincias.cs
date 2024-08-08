// See https://aka.ms/new-console-template for more information
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
   using System.Text.Json.Serialization;
    
//SERIA FABRICADEPERSONAJES.CS CREAMOS LA CLASE PARA SABER QUE ES LO QUE QUEREMOS TRAER DE LA API Y COMO TRANSFORMAMOS DEL LEER LOS ITEMS DEL ARCHIVO A ESTA CLASE
    public class Provincia
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        public Caracteristicas stats {get; set;}
        
    }

    public class argentApi //fabrica de personajes (CLASE PRINCIPAL)
    {
        [JsonPropertyName("provincias")]
        public List<Provincia> Provincias { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        public Provincia crearCaracteristicasPersonaje(Provincia personaje)
        {
            Random random= new Random();
            
            int transporte= random.Next(1,11);
            int inteligencia= random.Next(1,6);
            int fuerza= random.Next(1,11);
            int calidadVida= random.Next(1,11);
            int sistemaSalud= random.Next(1,11);
            personaje.stats= new Caracteristicas(transporte, inteligencia, fuerza, calidadVida, sistemaSalud,100);
            return personaje;
        }
        public void crearPersonajesAleatorios(List<Provincia> lista)
        {
            lista[0].stats= new Caracteristicas();//para buenos aires uso el constructor 0
            lista[22].stats= new Caracteristicas(); // para la pampa tambien uso el constructor 0
            Random IndiceRandom = new Random();
            List<string> ids= ["58","74","82","46","10","90","22","34","78","26","50","30","70","38","86","62","18","54","66","14","06","94"]; //lista con todos los id
            List<string> idACrear=new List<string>();// lista con id a crear, incializo con 42 y 02 porque son las que quiero que vayan si o si
            List<string> idEliminar= ["58","74","82","46","10","90","22","34","78","26","50","30","70","38","86","62","18","54","66","14","06","94"]; // lista para poner los id a remover (la api retorna la lista completa y solo queremos 10)
            List<int> indices= new List<int>(); // lista para guardar los indices aleatorios unicos para usar luego como indices en las otras listas
            do
            {
                int random= IndiceRandom.Next(0,21);
                if (!indices.Contains(random)) //como el indice es un int voy a usar una lista de int (indices)
                {
                    idACrear.Add(ids[random]); //guarda los id random
                    indices.Add(random);
                }
            } while (idACrear.Count<8);
            foreach (var id in idACrear)   // elimina los id a crear de la lista id a eliminar
            {
               idEliminar.Remove(id);
            }
            for (int i = lista.Count-1; i>=0; i--) //comenzamos desde el indice mas alto, cosa que al modificar la lista no haya un error de posiciones, ya que siempre estariamos eliminando el ultimo elemento (en caso de eliminarlo)
            {
               if (idEliminar.Contains(lista[i].Id))
               {
                    lista.Remove(lista[i]);
               }
               else if (idACrear.Contains(lista[i].Id))
               {
                    lista[i]=crearCaracteristicasPersonaje(lista[i]);
               }
                
            }
        }
        public void mostrarProvincias(List<Provincia> lista)
        {     
            int i=0;
            foreach (var item in lista)
            {
                i++;
                Console.WriteLine("personaje n°: "+i);
                Console.WriteLine("nombre: "+item.Nombre);
                Console.WriteLine("nivel de transporte publico: "+ item.stats.TransportePublico);
                Console.WriteLine("coeficiente intelectual de la poblacion: "+item.stats.Inteligencia);
                Console.WriteLine("calidad de vida: "+item.stats.CalidadDeVida);
                Console.WriteLine("sistema de salud: "+item.stats.SistemaDeSalud);
                Console.WriteLine("poblacion: "+item.stats.Poblacion);
                Console.WriteLine("------------------\n");
             }
        }
      
    }
    