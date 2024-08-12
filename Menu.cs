   // See https://aka.ms/new-console-template for more information
namespace FuncionesDelJuego
{
    using System.IO.Compression;
   public class Menu
   {
      public void mostrarMenu()
      {
         Console.BackgroundColor=ConsoleColor.DarkCyan;
         Console.Clear();
         Console.ForegroundColor=ConsoleColor.DarkYellow;
         Console.WriteLine("\n\n\n\n\n\n\n\n\n");
         Console.WriteLine("\t\t\t\t\t\t*--*--*--*--*--*--*--MENU--*--*--*--*--*--*");
         Console.ForegroundColor=ConsoleColor.White;
         Console.WriteLine("\t\t\t\t\t\t1: Partida Rapida (1 jugador)");
         Console.WriteLine("\t\t\t\t\t\t2: Dos jugadores");
         Console.WriteLine("\t\t\t\t\t\t3: Historoial");
         Console.WriteLine("\t\t\t\t\t\t0: salir");   
         Console.ForegroundColor=ConsoleColor.DarkYellow;
         Console.WriteLine("\t\t\t\t\t\t*--*--*--*--*--*--*--*--*--*--*--*--*--*--*\n");   
         Console.Write("\n\t\t\t\t\t\tseleccione una opcion: ");
         Console.ResetColor();
      }
   }  
}