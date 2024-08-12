// See https://aka.ms/new-console-template for more information

namespace FuncionesDelJuego
{
    public class Historial
    {
        private string nombreGanador;
        private List<string> historialDePj;
        private List<string> historialDeDerrotados;


        public Historial()
        {
        }

        public Historial(string nombre, List<string>historialPj, List<string> historialDeDerrotados)
        {
            this.nombreGanador= nombre;
            this.historialDePj= historialPj;
            this.historialDeDerrotados= historialDeDerrotados;
        }

        public string NombreGanador { get => nombreGanador; set => nombreGanador = value; }
        public List<string> HistorialDePj { get => historialDePj; set => historialDePj = value; }
        public List<string> HistorialDeDerrotados { get => historialDeDerrotados; set => historialDeDerrotados = value; }

        public void agregarAlHistorial(List<string>historialPj, List<string>historialDerrotados)
        {
            string nombre;
            string archivo="historial.json";
            var historial= new ArchivosJson();
            Console.WriteLine("\n\tvencedor escriba su nombre con el que sera recordado en el historial de campeones de campeones\n");
            do
            {
                nombre=Console.ReadLine();
                if(nombre=="" || nombre==" " || nombre=="  ") Console.WriteLine("debe ingresar al menos una letra (ponele voluntad)");
            }while(nombre==""|| nombre==" " || nombre=="  ");
            historial.GuardarGanador(new Historial(nombre, historialPj, historialDerrotados), archivo);
        }
    }
}