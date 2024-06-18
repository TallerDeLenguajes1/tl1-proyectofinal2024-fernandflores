// See https://aka.ms/new-console-template for more information
public class Caracteristicas
{
    private double transportePublico; // velocidad
    private double inteligencia; //destreza
    private double fuerzasArmada; //fuerza 
    private double calidadDeVida;//nivel
    private double sistemaDeSalud; // armadura
    private double poblacion; // salud

    public Caracteristicas(double transportePublico, double inteligencia, double fuerzasArmada, double calidadDeVida, double sistemaDeSalud, double poblacion)
    {
        this.transportePublico=transportePublico;
        this.inteligencia= inteligencia;
        this.fuerzasArmada= fuerzasArmada;
        this.calidadDeVida= calidadDeVida;
        this.sistemaDeSalud= sistemaDeSalud;
        this.poblacion= poblacion;
    }

    public double TransportePublico { get => transportePublico; set => transportePublico = value; }
    public double Inteligencia { get => inteligencia; set => inteligencia = value; }
    public double FuerzasArmada { get => fuerzasArmada; set => fuerzasArmada = value; }
    public double CalidadDeVida { get => calidadDeVida; set => calidadDeVida = value; }
    public double SistemaDeSalud { get => sistemaDeSalud; set => sistemaDeSalud = value; }
    public double Poblacion { get => poblacion; set => poblacion = value; }
}