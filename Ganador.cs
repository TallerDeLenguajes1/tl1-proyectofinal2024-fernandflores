// See https://aka.ms/new-console-template for more information

namespace FuncionesDelJuego
{
    public class Historial
    {
        private string nombreGanador;
        private List<string> historialDePj;
        private List<string> historialDeDerrotados;
        private int totalPj;

        public Historial()
        {
        }

        public Historial(string nombre, List<string>historialPj, List<string> historialDeDerrotados)
        {
            this.nombreGanador= nombre;
            this.historialDePj= historialPj;
            this.totalPj= historialDePj.Count;
            this.historialDeDerrotados= historialDeDerrotados;
        }

        public string NombreGanador { get => nombreGanador; set => nombreGanador = value; }
        public List<string> HistorialDePj { get => historialDePj; set => historialDePj = value; }
        public int TotalPj { get => totalPj;}
        public List<string> HistorialDeDerrotados { get => historialDeDerrotados; set => historialDeDerrotados = value; }

        public void agregarAlHistorial(List<string>historialPj, List<string>historialDerrotados)
        {
            string archivo="historial.json";
            var historial= new ArchivosJson();
            Console.WriteLine("\n\tvencedor escriba su nombre\n");
            string nombre=Console.ReadLine();
            historial.GuardarGanador(new Historial(nombre, historialPj, historialDerrotados), archivo);
        }
    }
}