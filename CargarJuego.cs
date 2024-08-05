// See https://aka.ms/new-console-template for more information

using APIS;
using archivosJson;
//Console.ReadKey();
namespace cargadoDeJuego
   {
   public class CargarJuego
   {
      public  async Task<argentApi> InicializacionDeJuego() // como estamos esperando una repuesta de la api o bien de la lectura de un archivo usamos task
      {
         var servicioAPI= new Api();
         var archivoJson= new PersonajeJson();
         var argentina= new argentApi();
         if (archivoJson.ExistenciaDeArchivo("guardadoNuevo.txt"))
         {
            Console.WriteLine("existe el archivo");
            argentina= archivoJson.LeerPersonajes("guardadoNuevo.txt");
         }
         else
         {
            Console.WriteLine("no existe el archivo");
            argentina= await servicioAPI.GetArgentoAsync();
            argentina.crearPersonajesAleatorios(argentina.Provincias);
            archivoJson.GuardarPersonaje(argentina, "guardadoNuevo"); //guardar las clases en archivo json
         }
         return argentina;
      }
   }
}