// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
   using System.Text.Json.Serialization;
namespace archivosJson
{
    public class PersonajeJson
    {
        public string crearArchivoJson(argentApi dato)
        {
            return JsonSerializer.Serialize(dato);
        }
        public void guardarPersonaje(argentApi dato, string nombreArchivo) //para usar lista solo cambiar List<Provincia> prov en lugar de argentApi y al usar mandar solo la lista como parametro 
        {  //GUARDA EL ARCHIVO JSON.TXT (SERIALIZACION)
            string provstring= crearArchivoJson(dato);
            FileStream archivo= new FileStream(nombreArchivo+".txt", FileMode.Create);
            using (StreamWriter strwriter= new StreamWriter (archivo))
            {
                strwriter.WriteLine("{0}", provstring);
                strwriter.Close();
            }
        }
        public argentApi leerPersonajes(string nombreArchivo) //CREA A PARTIR DEL ARCHIVO JSON.TXT LAS CLASES (DESERIALIZACION)
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
            var listadoProvincias= JsonSerializer.Deserialize<argentApi>(cadenaPersonajes); // mando argentApi ya que el archivo json debe coincidir estructuralmente con la clase (en este caso nuestra clase es ArgenApi)
            return listadoProvincias;
        }
        
        public bool existenciaDeArchivo(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

 

}