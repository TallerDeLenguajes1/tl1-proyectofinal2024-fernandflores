// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using cargadoDeJuego;
using menu;
using Microsoft.VisualBasic;
var menu= new Menu();
var cargarJuego= new CargarJuego();
var argentina= await cargarJuego.InicializacionDeJuego();




menu.mostrarMenu();
argentina.mostrarProvincias(argentina.Provincias);
