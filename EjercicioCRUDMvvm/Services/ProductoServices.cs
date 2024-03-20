
using EjercicioCRUDMvvm.Models;
using SQLite;

namespace EjercicioCRUDMvvm.Services
{
    public class ProductoServices
    {
        private readonly SQLiteConnection _dbConnection;
        public ProductoServices()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Producto.db3");
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<Producto>();
        }

        public List<Producto> GetAll()
        {
            var res = _dbConnection.Table<Producto>().ToList();
            return res;
        }

        public int Insert(Producto producto)
        {
            return _dbConnection.Insert(producto);
        }

        public int Update(Producto producto)
        {
            return _dbConnection.Update(producto);
        }

        public int Delete(Producto producto)
        {
            return _dbConnection.Delete(producto);
        }
    }
}
