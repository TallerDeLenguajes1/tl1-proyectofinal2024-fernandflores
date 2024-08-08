// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Emit;
using asciiArtString;
using cargadoDeJuego;
using historialGanador;
using menu;
using Microsoft.VisualBasic;
var menu= new Menu();
var cargarJuego= new CargarJuego();

var batalla= new Batalla();
var historial= new List<Ganador>();
var msn= new Mensajes();
menu.mostrarMenu();

Console.ReadKey();
Console.Clear();
int opc=0;
do{
var argentina= await cargarJuego.InicializacionDeJuego();
batalla.gamePlay(argentina, historial);
Console.WriteLine("seguir? 0 para salir");
 opc= int.Parse(Console.ReadLine());
}while(opc!=0);
msn.mostrarHistorial(historial);
Console.ReadKey();