// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
   using System.Text.Json.Serialization;
namespace juego{
public class PersonajeJson
{
    public string crearArchivoJson(argentApi prov)
    {
        return JsonSerializer.Serialize(prov);
    }
    public void guardarPersonaje(argentApi prov, string nombreArchivo) //para usar lista solo cambiar List<Provincia> prov en lugar de argentApi y al usar mandar solo la lista como parametro 
    {
        string provstring= crearArchivoJson(prov);
        FileStream archivo= new FileStream(nombreArchivo+".txt", FileMode.Create);
        using (StreamWriter strwriter= new StreamWriter (archivo))
        {
            strwriter.WriteLine("{0}", provstring);
            strwriter.Close();
        }
    }
    public argentApi leerPersonajes(string nombreArchivo)
    {
        string cadenaPersonajes;
        string ruta= nombreArchivo;
        using (var archivoOpnen = new FileStream(ruta, FileMode.Open))
        {
            using (var aux= new StreamReader(archivoOpnen))
            {
                cadenaPersonajes= aux.ReadToEnd();
                archivoOpnen.Close();
            }
        }
        var listadoProvincias= JsonSerializer.Deserialize<argentApi>(cadenaPersonajes);
        return listadoProvincias;
    }
}

// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
    public class argJson
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("stats")]
        public provJson Stats { get; set; }
    }

    public class provJson
    {
        [JsonPropertyName("TransportePublico")]
        public int TransportePublico { get; set; }

        [JsonPropertyName("Inteligencia")]
        public int Inteligencia { get; set; }

        [JsonPropertyName("FuerzasArmada")]
        public int FuerzasArmada { get; set; }

        [JsonPropertyName("CalidadDeVida")]
        public int CalidadDeVida { get; set; }

        [JsonPropertyName("SistemaDeSalud")]
        public int SistemaDeSalud { get; set; }

        [JsonPropertyName("Poblacion")]
        public int Poblacion { get; set; }
    }

}