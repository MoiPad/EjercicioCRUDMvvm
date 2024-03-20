using SQLite;

namespace EjercicioCRUDMvvm.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Precio { get; set; }
        public string  Descripcion { get; set; }
    }
}
