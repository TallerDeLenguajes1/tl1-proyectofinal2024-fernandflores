   // See https://aka.ms/new-console-template for more information
namespace FuncionesDelJuego
{
    using System.IO.Compression;
   public class Menu
   {
      public void mostrarMenu()
      {
         var mensaje= new Mensajes();
         mensaje.banderaArgentina();
         Console.WriteLine("\n");
         Console.WriteLine(mensaje.menu1);
         Console.WriteLine(mensaje.menu2);
         Console.WriteLine(mensaje.menu3);
         Console.WriteLine("-------------------MENU--------------------");
         Console.WriteLine("1: Partida Rapida (1 jugador)");
         Console.WriteLine("2: Dos jugadores");
         Console.WriteLine("3: Historoial");
         Console.WriteLine("0: salir");   
         Console.WriteLine("--------------------------------------------\n");   
         Console.WriteLine("\n\t\tseleccione una opcion\n");
      }
   }  
}