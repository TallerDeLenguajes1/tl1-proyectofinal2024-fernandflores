// See https://aka.ms/new-console-template for more information
namespace historialGanador
{
    public class Ganador
    {
        private string nombreGanador;
        private List<string> historialDePj;
        private List<string> historialDeDerrotados;
        private int totalPj;

        public Ganador()
        {
        }

        public Ganador(string nombre, List<string>historialPj, List<string> historialDeDerrotados)
        {
            this.nombreGanador= nombre;
            this.historialDePj= historialPj;
            this.totalPj= historialDePj.Count;
            this.HistorialDeDerrotados= historialDeDerrotados;
        }

        public string NombreGanador { get => nombreGanador; set => nombreGanador = value; }
        public List<string> HistorialDePj { get => historialDePj; set => historialDePj = value; }
        public int TotalPj { get => totalPj;}
        public List<string> HistorialDeDerrotados { get => historialDeDerrotados; set => historialDeDerrotados = value; }

        public void agregarAlHistorial(List<string>historialPj, List<string>historialDerrotados, List<Ganador> historial)
        {
            Console.WriteLine("\n\tvencedor escriba su nombre\n");
            string nombre=Console.ReadLine();
            historial.Add(new Ganador(nombre, historialPj,historialDerrotados));
        }
    }
}