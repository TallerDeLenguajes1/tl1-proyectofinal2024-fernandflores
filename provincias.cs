// See https://aka.ms/new-console-template for more information
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
   using System.Text.Json.Serialization;
    
//SERIA FABRICADEPERSONAJES.CS
    public class Provincia
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        public Caracteristicas stats {get; set;}
        
    }

    public class argentApi //fabrica de personajes 
    {
        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }


        [JsonPropertyName("provincias")]
        public List<Provincia> Provincias { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
/*
       public void incializarJuego()
        {
            Random ramdon= new Random();
             
            Provincias[0].stats= new Caracteristicas(0,0,0,0,0,0);
            for (int i = 1; i < Provincias.Count; i++)
            {
                int transporte= ramdon.Next(1,11);
                int inteligencia= ramdon.Next(1,6);
                int fuerza= ramdon.Next(1,11);
                int calidadVida= ramdon.Next(1,11);
                int sistemaSalud= ramdon.Next(1,11);
                Provincias[i].stats= new Caracteristicas(transporte, inteligencia, fuerza, calidadVida, sistemaSalud,100);
            }
        }*/
        public Provincia crearPersonaje(Provincia personaje)
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
        public void mostrarProvincias(List<Provincia> lista)
        {
            foreach (var item in lista)
            {
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
    