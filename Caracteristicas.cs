// See https://aka.ms/new-console-template for more information
public class Caracteristicas
{
    private int transportePublico; // velocidad
    private int inteligencia; //destreza
    private int fuerzasArmada; //fuerza 
    private int calidadDeVida;//nivel
    private int sistemaDeSalud; // armadura
    private int poblacion; // salud

    public Caracteristicas() //constructor 0
    {
        transportePublico=0;
        inteligencia=0;
        fuerzasArmada=0;
        calidadDeVida=0;
        sistemaDeSalud=0;
        poblacion=0;
    }

    public Caracteristicas(int transportePublico, int inteligencia, int fuerzasArmada, int calidadDeVida, int sistemaDeSalud, int poblacion)
    { //constructor
        this.transportePublico=transportePublico;
        this.inteligencia= inteligencia;
        this.fuerzasArmada= fuerzasArmada;
        this.calidadDeVida= calidadDeVida;
        this.sistemaDeSalud= sistemaDeSalud;
        this.poblacion= poblacion;
    }

    public int TransportePublico { get => transportePublico; set => transportePublico = value; }
    public int Inteligencia { get => inteligencia; set => inteligencia = value; }
    public int FuerzasArmada { get => fuerzasArmada; set => fuerzasArmada = value; }
    public int CalidadDeVida { get => calidadDeVida; set => calidadDeVida = value; }
    public int SistemaDeSalud { get => sistemaDeSalud; set => sistemaDeSalud = value; }
    public int Poblacion { get => poblacion; set => poblacion = value; }
}