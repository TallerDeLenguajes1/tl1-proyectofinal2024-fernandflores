// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace archivosJson
{
    // EN ESTE ARCHIVO TRABAJAMOS LOS ARCHIVOS JSON PARA  CREARLOS Y GUARDARLOS O LEERLOS 
    public class PersonajeJson
    {
        public string CrearArchivoJson(argentApi dato)
        {
            return JsonSerializer.Serialize(dato);
        }
        public void GuardarPersonaje(argentApi dato, string nombreArchivo) //para usar lista solo cambiar List<Provincia> prov en lugar de argentApi y al usar mandar solo la lista como parametro 
        {  //GUARDA EL ARCHIVO JSON.TXT (SERIALIZACION)
            string provstring= CrearArchivoJson(dato);
            FileStream archivo= new FileStream(nombreArchivo+".txt", FileMode.Create);
            using (StreamWriter strwriter= new StreamWriter (archivo))
            {
                strwriter.WriteLine("{0}", provstring);
                strwriter.Close();
            }
        }
        public argentApi LeerPersonajes(string nombreArchivo) //CREA A PARTIR DEL ARCHIVO JSON.TXT LAS CLASES (DESERIALIZACION)
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
        
        public bool ExistenciaDeArchivo(string nombreArchivo)
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