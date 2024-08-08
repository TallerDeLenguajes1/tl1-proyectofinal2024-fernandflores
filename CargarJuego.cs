// See https://aka.ms/new-console-template for more information

using APIS;
using FuncionesDelJuego;
//Console.ReadKey();
namespace cargadoDeJuego
   {
   public class CargarJuego
   {
      public  async Task<argentApi> InicializacionDeJuego() // como estamos esperando una repuesta de la api o bien de la lectura de un archivo usamos task
      {
         var servicioAPI= new Api();
         var archivoJson= new ArchivosJson();
         var argentina= new argentApi();
         string nombreArchivo="listadoDeProvincias.json";
         if (archivoJson.ExistenciaDeArchivo(nombreArchivo))
         {
            argentina= archivoJson.LeerPersonajes(nombreArchivo);
         }
         else
         {
            argentina= await servicioAPI.GetArgentoAsync();
            argentina.crearPersonajesAleatorios(argentina.Provincias);
            archivoJson.GuardarPersonaje(argentina, nombreArchivo); //guardar las clases en archivo json
         }
         return argentina;
      }
   }
}