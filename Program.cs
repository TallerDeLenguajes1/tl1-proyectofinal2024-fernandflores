// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.Json;
using APIS;
using archivosJson;
using menu;
var servicioAPI= new Api();
var archivoJson= new PersonajeJson();
var argentina= new argentApi();
var menu= new Menu();


if (archivoJson.existenciaDeArchivo("guardadoNuevo.txt"))
{
   Console.WriteLine("existe el archivo");
   argentina= archivoJson.leerPersonajes("guardadoNuevo.txt");
}
else
{
   Console.WriteLine("no existe el archivo");
   argentina= await servicioAPI.GetArgentoAsync();
   argentina.Provincias[0].stats=new Caracteristicas(); // para buenos aires uso constructor 0
   for (int i = 1; i < argentina.Provincias.Count; i++)
   {
      argentina.Provincias[i]= argentina.crearPersonaje(argentina.Provincias[i]); //la funcion retorna la provincia ya creada con el constructor
   }  
   argentina.mostrarProvincias(argentina.Provincias);
   archivoJson.guardarPersonaje(argentina, "guardadoNuevo"); //guardar las clases en archivo json
}
menu.mostrarMenu();
//Console.ReadKey();