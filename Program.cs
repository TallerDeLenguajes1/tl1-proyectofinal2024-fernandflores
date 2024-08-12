// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Emit;
using cargadoDeJuego;
using Microsoft.VisualBasic;
using FuncionesDelJuego;
var cargarJuego= new CargarJuego();
var batalla= new Batalla();
var menu= new Menu();
var msn = new Mensajes();
var historial= new List<Historial>();
var aux= new ArchivosJson();
int opc;
bool salir=false;
msn.presentacion();
Console.Clear();
do
{
   menu.mostrarMenu();
    var argentina= await cargarJuego.InicializacionDeJuego();
   if (int.TryParse(Console.ReadLine(), out opc))
   {
      switch (opc)
      {
         case 0: 
            Console.Clear();
            Console.WriteLine("hasta luego, gracias por jugar, presione cualquier tecla para decir adios");
            Thread.Sleep(2000);
            salir=true;
            break;
         case 1:
            Console.Clear();
            batalla.gamePlay1(argentina);
            break;
           
         case 2:
            Console.Clear();
            batalla.gamePlay(argentina);
            break;
         case 3:
            Console.Clear();
            string archivo="historial.json";
            if (aux.ExistenciaDeArchivo(archivo))
            {
               historial= aux.LeerHistorial(archivo);
               msn.mostrarHistorial(historial);
               Console.WriteLine("\npresione cualquier tecla para volver al menu");
               Console.ReadKey();
            }
            else
            {
               Console.WriteLine("\n\t\tNO EXISTEN CAMPEONES");
               Thread.Sleep(2000);
            }
            break;
         default:
            Console.ForegroundColor= ConsoleColor.Red;
            Console.Write("\t\t\t\t\t\t\t\tdebe ingresar una opcion valida");
            Console.ResetColor();
            Thread.Sleep(1000);
            break;

      }
   }
   else
   {
      Console.ForegroundColor=ConsoleColor.Red;
      Console.Write("\t\t\t\t\t\t\t\tOpcion erronea");
      Console.ResetColor();
      Thread.Sleep(1000);
   }
} while (!salir);
