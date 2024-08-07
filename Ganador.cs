// See https://aka.ms/new-console-template for more information
namespace historialGanador
{
    public class Ganador
    {
        private string nombreGanador;
        private List<historialDePersonajes> historialDePj;
        private int totalPj;

        public Ganador(string nombre, List<historialDePersonajes>historialPj)
        {
            this.nombreGanador= nombre;
            this.historialDePj= historialPj;
            this.totalPj= historialDePj.Count;
        }

        public string NombreGanador { get => nombreGanador; set => nombreGanador = value; }
        public List<historialDePersonajes> HistorialDePj { get => historialDePj; set => historialDePj = value; }
        public int TotalPj { get => totalPj;}

        public void agregarAlHistorialDePj(historialDePersonajes pj, List<historialDePersonajes>historialPj)
        {
            if(!HistorialDePj.Contains(pj))
            {
                historialPj.Add(pj);
            }
        }
    
    }
    public class historialDePersonajes
    {
        public string nombrePJ;

    }
}