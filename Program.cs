// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using asciiArtString;
using cargadoDeJuego;
using menu;
using Microsoft.VisualBasic;
var menu= new Menu();
var cargarJuego= new CargarJuego();
var argentina= await cargarJuego.InicializacionDeJuego();
var batalla= new Batalla();
menu.mostrarMenu();

Console.ReadKey();
Console.Clear();

batalla.gamePlay(argentina);
Console.ReadKey();
