// See https://aka.ms/new-console-template for more information
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
   using System.Text.Json.Serialization;
    

    public class Provincia
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        public Caracteristicas stats {get; set;}
        
    }

    public class argentApi
    {
        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }


        [JsonPropertyName("provincias")]
        public List<Provincia> Provincias { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

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
        }
    }