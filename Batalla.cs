// See https://aka.ms/new-console-template for more information


using System.Drawing;
namespace FuncionesDelJuego{

    public class Batalla
    {
        
        public int generadorDeDanio(Provincia personaje1, Provincia personaje2)
        {
            int constante=500;
            var random= new Random();
            int efectividad= random.Next(40,100);
            Provincia atacante= personaje1;
            Provincia defensor= personaje2;
            int ataque= atacante.stats.Inteligencia*atacante.stats.FuerzasArmada*atacante.stats.CalidadDeVida;
            int defensa= defensor.stats.SistemaDeSalud*defensor.stats.TransportePublico;
            int danioProvocado= ((ataque*efectividad)-defensa)/constante;
            return danioProvocado;
        }
        public void generadorDeRecompensa(Provincia ganador)
        {
            ganador.stats.Poblacion+=4;
            ganador.stats.FuerzasArmada++;
            
        }

        public Provincia genedaroDePelea(Provincia player, Provincia player2, List<Provincia> provincias)
        {
            var mensaje= new Mensajes();
            int danioProvocado, rondas=1, poblacionPlayer1=player.stats.Poblacion, poblacionPlayer2=player2.stats.Poblacion;
            player.stats.danioProvocado=0;
            player.stats.danioRecibido=0;
            player2.stats.danioProvocado=0;
            player2.stats.danioRecibido=0;
            while (player.stats.Poblacion>0 && player2.stats.Poblacion>0)
            {   
                Console.WriteLine("\n\t ******------*****------RONDA N° "+rondas+" "+player.Nombre+" VS "+player2.Nombre+" -------******------*****");
                danioProvocado=generadorDeDanio(player, player2);          
                player.stats.danioProvocado+= danioProvocado; //sumamos al campo danio provocado los daños totales
                player2.stats.Poblacion-=danioProvocado;
                player2.stats.danioRecibido+=danioProvocado; //sdas
                if (player2.stats.Poblacion<0)
                {
                    player2.stats.Poblacion=0;
                }
                mensaje.mostrarResultadoRound(player, player2, danioProvocado);
                if (player2.stats.Poblacion>0)
                {
                    danioProvocado= generadorDeDanio(player2, player);
                    player2.stats.danioProvocado+=danioProvocado;
                    player.stats.danioRecibido+=danioProvocado;
                    player.stats.Poblacion-=danioProvocado;
                    if (player.stats.Poblacion<0)
                    {
                        player.stats.Poblacion=0;
                    }
                    mensaje.mostrarResultadoRound( player2, player, danioProvocado);
                }
                Console.WriteLine("\n\t ******------*****------FIN DE LA RONDA "+rondas+"-------******------*****");
                Console.WriteLine("\n presione cualquier tecla para continuar\n");
                rondas++;
                Console.ReadKey();
            }
            if (player.stats.Poblacion<=0 && player2.stats.Poblacion>0) //si gana player2
            {
                player2.stats.Poblacion=poblacionPlayer2;
                return player2;
            }
            else // si gana player 1
            {
                player.stats.Poblacion=poblacionPlayer1;
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
                Console.WriteLine("\nJugador numero 1: Perdiste por porteño, nada eso...");
                lista.Remove(p1);
            }
            else if (p1.Id!="42" && p2.Id=="02")
            {
                Console.WriteLine("\njugador numero 2: Perdiste por porteño, nada eso...\n");
                lista.Remove(p2);
            }
            else if(p1.Id=="42" && p2.Id!="02")
            {
                Console.WriteLine("\nJugador 1: perdiste...");
                Console.WriteLine("\nERROR 404 PROVINCIA NOT FOUND\n");
                lista.Remove(p1);
            }
            else if(p1.Id!="02" && p2.Id=="42")
            {
                Console.WriteLine("\nJugador 2: perdiste...");
                Console.WriteLine("\nERROR 404 PROVINCIA NOT FOUND\n");
                lista.Remove(p2);
            }
            else if(p1.Id=="02" && p2.Id=="42")
            {
                Console.WriteLine("\nJugadores, ambos eligieron las provincias incorrectas. Vuelvan a elegir personajes");
                lista.Remove(p1);
                lista.Remove(p2);
            }
            Console.WriteLine("\npresione cualquier tecla para continuar");
            Console.ReadKey();
        }
        public void gamePlay1(argentApi arg)
        {
            var historialPlayer= new List<string>();
            var historialCPU= new List<string>();
            var mensaje= new Mensajes();
            Provincia ganador= new Provincia();
            Provincia player= new Provincia();
            Provincia cpu= new Provincia();
            var random= new Random();
            var historial= new Historial();
            Console.WriteLine("\n\njugador elija su personaje\n");
            player=seleccionDePersonaje(arg);
            historialPlayer.Add(player.Nombre);
            player.stats.FuerzasArmada+=1;
            bool vivo= true;
            while (arg.Provincias.Count>1 && vivo)
            {
                do
                {
                    int indice= random.Next(0,(arg.Provincias.Count));
                    cpu= arg.Provincias[indice];
                }while(cpu.Id==player.Id);
                if(!historialCPU.Contains(cpu.Nombre))historialCPU.Add(cpu.Nombre);

                if (player.Id=="02" || cpu.Id=="02" || player.Id=="42" || cpu.Id=="42")
                {
                    casoParticular(player, cpu, arg.Provincias);
                    if (player.Id=="02" || player.Id=="42")
                    {
                        vivo=false;
                    }
    
                }
                else
                {
                    ganador=genedaroDePelea(player, cpu, arg.Provincias);
                    generadorDeRecompensa(ganador);
                    if (ganador.Id==player.Id)
                    {
                        mensaje.mostrarResultadoPelea(ganador, cpu);
                        arg.Provincias.Remove(cpu);
                        Console.WriteLine("\n\t\tPersonajes Restantes: \n");
                        arg.mostrarProvincias(arg.Provincias);
                        Console.WriteLine("presione cualquier tecla para continuar");
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                    else
                    {
                        mensaje.mostrarResultadoPelea(ganador, player);
                        arg.Provincias.Remove(player);
                        vivo= false;
                        mensaje.mensajeDerrotaSolo(cpu);
                        
                    }
                }
            }
            if(vivo)
            {
                Console.WriteLine("Jugador usted ha ganado\n");
                mensaje.mensajeVictoria("Jugador");
                Console.ReadKey();
                historial.agregarAlHistorial(historialPlayer,historialCPU);
            }
        }
        public void gamePlay(argentApi arg)
        {

            var historialPlayer1= new List<string>();
            var historialPlayer2= new List<string>();
            var historial= new Historial();
            var mensaje= new Mensajes();
            Provincia ganador= new Provincia();
            Provincia personaje1= new Provincia();
            Provincia personaje2= new Provincia();
            while (arg.Provincias.Count>1)
            {
                Console.WriteLine("\n\njugador numero 1, seleccione su personaje\n");
                personaje1= seleccionDePersonaje(arg);
                if(!historialPlayer1.Contains(personaje1.Nombre))historialPlayer1.Add(personaje1.Nombre);
                do
                {
                    Console.WriteLine("\n\njugador numero 2, seleccione su personaje\n");
                    personaje2= seleccionDePersonaje(arg);
                    if(!historialPlayer2.Contains(personaje2.Nombre))historialPlayer2.Add(personaje2.Nombre);
                    if(personaje1.Id==personaje2.Id)Console.WriteLine("debe elegir personajes distintos\n");
                } while (personaje1.Id==personaje2.Id);
                if (personaje1.Id=="02" || personaje2.Id=="42" || personaje1.Id=="42" || personaje2.Id=="02")
                {
                    casoParticular(personaje1, personaje2, arg.Provincias);
                }
                else
                {
                    ganador= genedaroDePelea(personaje1, personaje2, arg.Provincias);
                // saludRestante= ganador.stats.Poblacion;
                    generadorDeRecompensa(ganador);
                    if (ganador.Id==personaje1.Id)
                    {
                        mensaje.mostrarResultadoPelea(ganador, personaje2);
                        arg.Provincias.Remove(personaje2);
                    }
                    else
                    {
                        mensaje.mostrarResultadoPelea(ganador, personaje1);
                        arg.Provincias.Remove(personaje1);
                    }
                }
            }
            if (ganador.Id==personaje1.Id)
            {
                mensaje.mensajeVictoria("Jugador 1");
                historial.agregarAlHistorial(historialPlayer1,historialPlayer2);
            }
            else if(ganador.Id==personaje2.Id)
            {
                mensaje.mensajeVictoria("Jugador 2");
                historial.agregarAlHistorial(historialPlayer2,historialPlayer1);
            }
        }
    }
}