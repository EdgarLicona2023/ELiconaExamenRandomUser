namespace ML
{
    public class Cine
    {
        public List<object> Objects;

        public int id { set; get; }
        public string Descripcion { set; get; }
        public string NombreCine { set; get; }
        public decimal Ventas { set; get; } 
        public string Imagen { set; get; }
        public ML.Zona Zona { set; get; }
        public List<object> Cines { get; set; }
    }
}