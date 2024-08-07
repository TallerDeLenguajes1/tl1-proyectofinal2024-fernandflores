   // See https://aka.ms/new-console-template for more information
namespace menu
{
    using System.IO.Compression;
    using asciiArtString;
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
         Console.WriteLine("1: Partida Rapida");
         Console.WriteLine("2: elegir y pelear (cuidado si sos porteño...)");
         Console.WriteLine("2: mural de heroes");   
         Console.WriteLine("--------------------------------------------\n");   
      }
   }  
}