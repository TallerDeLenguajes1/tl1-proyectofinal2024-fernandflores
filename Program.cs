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
//menu.mostrarMenu();
//Console.ReadKey();
// do{
// //var argentina= await cargarJuego.InicializacionDeJuego();
// batalla.gamePlay(argentina);
// Console.WriteLine("seguir? 0 para salir");
//  opc= int.Parse(Console.ReadLine());
// }while(opc!=0);
//msn.mostrarHistorial(historial);
//Console.ReadKey();
int opc;
bool salir=false;
do
{
   menu.mostrarMenu();
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
            var argentina= await cargarJuego.InicializacionDeJuego();
            batalla.gamePlay(argentina);
          //  Console.WriteLine("\npresione cualquier tecla para volver al menu");
            break;
         case 2:
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
            Console.Clear();
            Console.WriteLine("debe ingresar una opcion valida");
            Thread.Sleep(2000);
            break;

      }
   }
   else
   {
      Console.WriteLine("Opcion erronea");
      Thread.Sleep(2000);
      //Console.WriteLine("presione cualquier tecla para continuar");
   }
} while (!salir);
// public class CargarHistorial
// {
//         public  async Task<List<Ganador>> InicializacionDeHistorial(List<Ganador> hist) // como estamos esperando una repuesta de la api o bien de la lectura de un archivo usamos task
//       {
//          var archivoJson= new ArchivosJson();
//          var historial= new List<Ganador>();
//          if (archivoJson.ExistenciaDeArchivo("guardadoNuevo.txt"))
//          {
//             historial= archivoJson.LeerGanador("guardadoNuevo.txt");
//          }
//          else
//          {
//             archivoJson.GuardarGanador(hist, "historial");
//             historial= hist;
//          }
//          return historial;
//       }
// }