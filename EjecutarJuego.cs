// See https://aka.ms/new-console-template for more information

using cargadoDeJuego;

namespace FuncionesDelJuego
{
   public class EjecutarJuego
   {
      
      public async Task Ejecutar()
      {
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
                        Thread.Sleep(1500);
                     }
                     break;
                  case 4:
                     if (aux.ExistenciaDeArchivo("listadoDeProvincias.json"))
                     {
                        Console.Clear();
                        Console.WriteLine("\n\n\n");
                        argentina.mostrarProvincias(argentina.Provincias);
                        Console.WriteLine("presione cualquier tecla para volver al menu");
                        Console.ReadKey();
                     }
                     else
                     {
                        Console.WriteLine("no hay campeones disponibles, arranque una partida para generar los personajes");
                     }
                     break;
                  case 5: 
                     aux.EliminarArchivoJson("historial.json");
                     msn.historialBorrado();
                     break;
                  case 6:
                     aux.EliminarArchivoJson("historial.json");
                     aux.EliminarArchivoJson("listadoDeProvincias.json");
                     msn.resetGame();
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
      }
   }
}