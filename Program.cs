// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.Json;
using APIS;
using juego;
var servicioAPI= new Api();
var argentina= await servicioAPI.GetArgentoAsync();
Console.WriteLine("-------------------MENU--------------------");
Console.WriteLine("1: jugar");
Console.WriteLine("2: guardar listado de personajes");

argentina.Provincias[0].stats=new Caracteristicas(); // para buenos aires uso constructor 0
for (int i = 1; i < argentina.Provincias.Count; i++)
{
        argentina.Provincias[i]= argentina.crearPersonaje(argentina.Provincias[i]); //la funcion retorna la provincia ya creada con el constructor
}
argentina.mostrarProvincias(argentina.Provincias);
var arch= new PersonajeJson();
string buff= arch.crearArchivoJson(argentina);
arch.guardarPersonaje(argentina, "guardadoNuevo"); 
var prueba= new argentApi();
prueba= arch.leerPersonajes("guardadoNuevo.txt");
Console.WriteLine("PROBANDO LEER");
    foreach (var item in prueba.Provincias)
    {
        Console.WriteLine(item.Nombre);
        Console.WriteLine("calidad de vida: "+item.stats.CalidadDeVida);
        Console.WriteLine("fuerza: "+item.stats.FuerzasArmada);
        Console.WriteLine("destreza: "+item.stats.Inteligencia);
        Console.WriteLine("vida: "+item.stats.Poblacion);
        Console.WriteLine("Sistema de salud: "+item.stats.SistemaDeSalud);
        Console.WriteLine("transporte publico: "+item.stats.TransportePublico);
    }
//List<argJson> ciudades= await leerPersonajes("guardado2.txt");
// foreach (var item in ciudades)
// {
//     Console.WriteLine(item.Nombre);
//     Console.WriteLine(item.Id);
//     Console.WriteLine(item.Stats.CalidadDeVida);
//     Console.WriteLine(item.Stats.FuerzasArmada);
//     Console.WriteLine(item.Stats.Inteligencia);
//     Console.WriteLine(item.Stats.Poblacion);
    
    
// }
