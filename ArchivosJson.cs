// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace FuncionesDelJuego
{
    // EN ESTE ARCHIVO TRABAJAMOS LOS ARCHIVOS JSON PARA  CREARLOS Y GUARDARLOS O LEERLOS 
    public class ArchivosJson
    {
        public string CrearArchivoJson(argentApi dato)
        {
            return JsonSerializer.Serialize(dato);
        }
        public void GuardarPersonaje(argentApi dato, string nombreArchivo) //para usar lista solo cambiar List<Provincia> prov en lugar de argentApi y al usar mandar solo la lista como parametro 
        {  //GUARDA EL ARCHIVO JSON.TXT (SERIALIZACION)
            string ruta= "archivos_json/"+nombreArchivo;
            string provstring= CrearArchivoJson(dato);
            FileStream archivo= new FileStream(ruta, FileMode.Create);
            using (StreamWriter strwriter= new StreamWriter (archivo))
            {
                strwriter.WriteLine("{0}", provstring);
                strwriter.Close();
            }
        }
        public argentApi LeerPersonajes(string nombreArchivo) //CREA A PARTIR DEL ARCHIVO JSON.TXT LAS CLASES (DESERIALIZACION)
        {
            string cadenaPersonajes;
            string ruta= "archivos_json/"+nombreArchivo;
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
        public string CrearArchivoHistorialJson(List<Historial> dato)
        {
            return JsonSerializer.Serialize(dato);
        }
        public void GuardarGanador(Historial datoGanador, string nombreArchivo)
        {
            string ruta= "archivos_json/"+nombreArchivo;
            var historial= new List<Historial>();
            if (ExistenciaDeArchivo(nombreArchivo))
            {
                historial=LeerHistorial(nombreArchivo);
            }
            historial.Add(datoGanador);
            string historialString= CrearArchivoHistorialJson(historial);
            FileStream archivo= new FileStream(ruta, FileMode.OpenOrCreate);
            using (StreamWriter strwriter= new StreamWriter(archivo))
            {
                strwriter.WriteLine("{0}", historialString);
                strwriter.Close();
            }
        }
        public List<Historial> LeerHistorial(string nombreArchivo)
        {
            string cadena;
            string ruta="archivos_json/"+nombreArchivo;
            List<Historial> historial;
            using (var archivoOpnen= new FileStream(ruta, FileMode.Open))
            {
                using (var aux= new StreamReader(archivoOpnen))
                {
                    cadena= aux.ReadToEnd();
                    archivoOpnen.Close();
                }
            }
            historial= JsonSerializer.Deserialize<List<Historial>>(cadena);
            return historial;
        }
        public bool ExistenciaDeArchivo(string nombreArchivo)
        {
            string ruta= "archivos_json/"+nombreArchivo;
            if (File.Exists(ruta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EliminarArchivoJson(string archivo)
        {
            string ruta="archivos_json//";
            File.Delete(ruta+archivo);
        }
    }

 

}