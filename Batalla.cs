// See https://aka.ms/new-console-template for more information

using asciiArtString;

public class Batalla
{
    
    public int generadorDeDanio(Provincia personaje1, Provincia personaje2)
    {
        int constante=500;
        var random= new Random();
        int efectividad= random.Next(1,100);
        Provincia atacante= personaje1;
        Provincia defensor= personaje2;
        int ataque= atacante.stats.Inteligencia*atacante.stats.FuerzasArmada*atacante.stats.CalidadDeVida;
        int defensa= defensor.stats.SistemaDeSalud*defensor.stats.TransportePublico;
        int danioProvocado= ((ataque*efectividad)-defensa)/constante;
        return danioProvocado;
    }
    public void generadorDeRecompensa(Provincia ganador)
    {
        ganador.stats.Poblacion+=8;
        ganador.stats.FuerzasArmada+=2;
        ganador.stats.CalidadDeVida++;
    }
    public Provincia genedaroDePelea(Provincia player, Provincia player2, List<Provincia> provincias)
    {
        var mensaje= new Mensajes();
        int danioProvocado=0;
        int rondas=1;
        int saludRestante=0;
        while (player.stats.Poblacion>0 && player2.stats.Poblacion>0)
        {   
           Console.WriteLine("\n\t ******------*****------RONDA N° "+rondas+" "+player.Nombre+" VS "+player2.Nombre+" -------******------*****");
   //         Console.WriteLine("\t ataca "+player.Nombre+" defiende: "+player2.Nombre);
            danioProvocado=generadorDeDanio(player, player2);          
            player2.stats.Poblacion-=danioProvocado;
            if (player2.stats.Poblacion<0)
            {
                player2.stats.Poblacion=0;
            }
            mensaje.mostrarResultadoRound(player, player2, danioProvocado);
 //           Console.WriteLine("daño provocado: "+danioProvocado);     
//            Console.WriteLine("\t salud restante de "+player2.Nombre+": "+player2.stats.Poblacion);
            if (player2.stats.Poblacion>0)
            {
            //    Console.WriteLine("\t ataca "+player2.Nombre+" defiende: "+player.Nombre);
                danioProvocado= generadorDeDanio(player2, player);
                player.stats.Poblacion-=danioProvocado;
                if (player.stats.Poblacion<0)
                {
                    player.stats.Poblacion=0;
                }
                mensaje.mostrarResultadoRound( player2, player, danioProvocado);
              //  Console.WriteLine("\t daño provocado: "+danioProvocado2);
                //Console.WriteLine("\t salud restante de "+player.Nombre+": "+player.stats.Poblacion);

            }
            
            if (player.stats.Poblacion<0)
            {
                player.stats.Poblacion=0;
            }
            else if(player2.stats.Poblacion<0)
            {
                player2.stats.Poblacion=0;
            }
            Console.WriteLine("\n\t ******------*****------FIN DE LA RONDA "+rondas+"-------******------*****");
            Console.WriteLine("\n presione cualquier tecla para continuar\n");
            rondas++;
            Console.ReadKey();
        }
        if (player.stats.Poblacion<=0 && player2.stats.Poblacion>0) //si perdemos
        {
            player.stats.Poblacion=0; // por si hubiera quedado en num negativo
            saludRestante= player2.stats.Poblacion;
            player2.stats.Poblacion=100;
            generadorDeRecompensa(player2);
            mensaje.mostrarResultadoPelea(player2, player, rondas, saludRestante); 
            provincias.Remove(player);
            return player2;
        }
        else // si ganaramos
        {
            player2.stats.Poblacion=0;
            saludRestante=player.stats.Poblacion;
            player.stats.Poblacion=100;
            generadorDeRecompensa(player);
            mensaje.mostrarResultadoPelea(player, player2, rondas, saludRestante);
            provincias.Remove(player2);
            return player;
        }

    }
    public Provincia seleccionDePersonaje(argentApi arg)
    {
        arg.mostrarProvincias(arg.Provincias);
        Provincia personaje= new Provincia();
        bool bandera= false;
        do
        {
            Console.WriteLine("seleccione personaje (numero de personaje)");
            if (int.TryParse(Console.ReadLine(), out int num) && (num>0 && num<=arg.Provincias.Count))
            {
                bandera= true;
                personaje= arg.Provincias[num-1];     
            }
            else
            {
                Console.WriteLine("debe seleccionar un personaje existente");
            }
        }while (!bandera);
        return personaje;
    }
    public void casoParticular(Provincia p1, Provincia p2, List<Provincia> lista)
    {
        if (p1.Id=="02" && p2.Id!="42")
        {
            Console.WriteLine("Jugador numero 1: Perdiste por porteño, nada eso...");
            lista.Remove(p1);
        }
        else if (p1.Id!="42" && p2.Id=="02")
        {
            Console.WriteLine("jugador numero 2: Perdiste por porteño, nada eso...");
            lista.Remove(p2);
        }
        else if(p1.Id=="42" && p2.Id!="02")
        {
            Console.WriteLine("Jugador 1: perdiste...");
            Console.WriteLine("ERROR 404 PROVINCIA NOT FOUND");
            lista.Remove(p1);
        }
        else if(p1.Id!="02" && p2.Id=="42")
        {
            Console.WriteLine("Jugador 2: perdiste...");
            Console.WriteLine("ERROR 404 PROVINCIA NOT FOUND");
            lista.Remove(p2);
        }
        else if(p1.Id=="02" && p2.Id=="42")
        {
            Console.WriteLine("Jugadores, ambos eligieron las provincias incorrectas. Vuelvan a elegir personajes");
            lista.Remove(p1);
            lista.Remove(p2);
        }
        Console.WriteLine("presione cualquier tecla para continuar");
        Console.ReadKey();
    }
    public void gamePlay(argentApi arg)
    {
        
        var random= new Random();
        Provincia ganador= new Provincia();
        Provincia personaje1= new Provincia();
        Provincia personaje2= new Provincia();;
        while (arg.Provincias.Count>1)
        {
            Console.WriteLine("jugador numero 1, seleccione su personaje\n");
            personaje1= seleccionDePersonaje(arg);
            do
            {
                Console.WriteLine("jugador numero 2, seleccione su personaje\n");
                personaje2= seleccionDePersonaje(arg);
                if(personaje1.Id==personaje2.Id)Console.WriteLine("debe elegir personajes distintos\n");
            } while (personaje1.Id==personaje2.Id);
            if (personaje1.Id=="02" || personaje2.Id=="42" || personaje1.Id=="42" || personaje2.Id=="02")
            {
                casoParticular(personaje1, personaje2, arg.Provincias);
              
            }
            else
            {
                ganador= genedaroDePelea(personaje1, personaje2, arg.Provincias);
            }
            Console.ReadKey();
        }
        if (ganador.Id==personaje1.Id)
        {
            Console.WriteLine("ganaste wacho p1");
        }
        else if(ganador.Id==personaje2.Id)
        {
            Console.WriteLine("ganaste maquina p2");
        }
    }
}
