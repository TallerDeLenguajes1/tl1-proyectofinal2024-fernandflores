// See https://aka.ms/new-console-template for more information
namespace asciiArtString
{
   public class Mensajes
   {

      public string menu1=@"     ______   _______  _______  _______  _        _        _______ 
    (____  \ (_______)(_______)(_______)(_)      (_)      (_______)
     ____)  ) _______     _     _______  _        _        _______ 
    |  __  ( |  ___  |   | |   |  ___  || |      | |      |  ___  |
    | |__)  )| |   | |   | |   | |   | || |_____ | |_____ | |   | |
    |______/ |_|   |_|   |_|   |_|   |_||_______)|_______)|_|   |_|";
      public string menu2=@"                         
                                       
                  ,---,         ,---,. 
                .'  .' `\     ,'  .' | 
              ,---.'     \  ,---.'   | 
              |   |  .`\  | |   |   .' 
              :   : |  '  | :   :  |-, 
              |   ' '  ;  : :   |  ;/| 
              '   | ;  .  | |   :   .' 
              |   | :  |  ' |   |  |-, 
              '   : | /  ;  '   :  ;/| 
              |   | '` ,/   |   |    \ 
              ;   :  .'     |   :   .' 
              |   ,.'       |   | ,'   
              '---'         `----'  ";
      public string menu3=@" ______   ______   _______  _     _  _  _______  _______  _  _______   ______ 
(_____ \ (_____ \ (_______)(_)   (_)| |(_______)(_______)| |(_______) / _____)
 _____) ) _____) ) _     _  _     _ | | _     _  _       | | _______ ( (____  
|  ____/ |  __  / | |   | || |   | || || |   | || |      | ||  ___  | \____ \ 
| |      | |  \ \ | |___| | \ \ / / | || |   | || |_____ | || |   | | _____) )
|_|      |_|   |_| \_____/   \___/  |_||_|   |_| \______)|_||_|   |_|(______/ 
                                                                             ";
    
      public string[] itemsPerdedor={"2 kilos de dulce de leche", "1kg de yerba", "media docena de empanadas", "un aire acondicionado", "una compu gamer", "achilata", "2 milas", "comida gratis por un mes en San Telmo", "el gamepass de microsoft", "un samsung galaxy j7"};
            
    public void banderaArgentina()
    {
      int alturaFranja = 5;
      Console.BackgroundColor=ConsoleColor.DarkCyan;
      for (int i = 0; i < alturaFranja; i++)
      {
        Console.WriteLine(new string(' ', 120)); 
      }
      Console.BackgroundColor = ConsoleColor.White;
      for (int i = 0; i < alturaFranja; i++)
      {
        Console.WriteLine(new string(' ', 120)); 
      }
      Console.BackgroundColor = ConsoleColor.DarkCyan;
      for (int i = 0; i < alturaFranja; i++)
      {
        Console.WriteLine(new string(' ', 120)); 
      }
      Console.ResetColor();
    }
    public void mostrarResultadoRound( Provincia player1, Provincia player2, int danioProvocado)
    {
      Console.WriteLine("\n\n\t \t TURNO DE: "+player1.Nombre+"\n");
      Console.Write("\t ATACA "+player1.Nombre+" \tDEFIENDE: "+player2.Nombre+"(poblacion: ");
      Console.ForegroundColor=ConsoleColor.Green;
      Console.Write(player2.stats.Poblacion+danioProvocado);
      Console.ResetColor();
      Console.Write(")\n");
      Console.ForegroundColor=ConsoleColor.Red;
      Console.WriteLine("\t daño provocado por "+player1.Nombre+": "+danioProvocado); 
      Console.ForegroundColor=ConsoleColor.Green;
      Console.WriteLine("\t poblacion restante de "+player2.Nombre+": "+player2.stats.Poblacion);
      Console.ResetColor();
      Console.WriteLine("\n\t\t     FIN DEL TURNO");
    }
    public void mostrarResultadoPelea(Provincia ganador, Provincia perdedor, int rondas, int saludRestante)
    {
      var random= new Random();
      int i= random.Next(0,itemsPerdedor.Length-1);
      Console.WriteLine("\n\t\t>>>>>>>>>>>> PELEA FINALIZADA <<<<<<<<<<<<<<<<<");
      Console.ForegroundColor=ConsoleColor.Blue;
      Console.WriteLine("Gano la provincia de: "+ganador.Nombre+" poblacion restante: "+saludRestante);
      Console.ResetColor();
      Console.ForegroundColor=ConsoleColor.Red;
      Console.WriteLine("La provincia perdedora es: "+perdedor.Nombre);
      Console.ResetColor();
      Console.WriteLine("total de rounds: "+(rondas-1));
      Console.WriteLine("\n");
      Console.WriteLine("Por generosidad de nuestro admin hemos decidido premiar al ganador reviviendo a su poblacion y con una mejora en sus estadisticas.");
      Console.WriteLine("las nuevas estadisticas de la provincia de "+ganador.Nombre+" son:");
      Console.WriteLine("nivel de transporte publico(velocidad): "+ ganador.stats.TransportePublico);
      Console.WriteLine("coeficiente intelectual de la poblacion (destreza): "+ganador.stats.Inteligencia);
      Console.WriteLine("calidad de vida (nivel): "+ganador.stats.CalidadDeVida);
      Console.WriteLine("sistema de salud (armadura): "+ganador.stats.SistemaDeSalud);
      Console.WriteLine("poblacion: (salud)"+ganador.stats.Poblacion);
      Console.WriteLine("\n\t\t>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<");
      Console.WriteLine("\n");
      Console.WriteLine("nuestro admin a decidido que una provincia perdedora no puede formar parte de este gran pais, por lo que "+perdedor.Nombre+" fue vendido a Uruguay por "+itemsPerdedor[i]);
      Console.WriteLine("\n");
    }
    public void mensajePortenio()
    {
      var random= new Random();
      int i= random.Next(0,itemsPerdedor.Length);
      Console.WriteLine("Perdiste por porteño, nada eso...");
    }
    }  
}
           