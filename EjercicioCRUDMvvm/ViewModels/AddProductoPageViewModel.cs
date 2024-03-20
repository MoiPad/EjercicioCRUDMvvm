using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.Services;


namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class AddProductoPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string marca;

        [ObservableProperty]
        private string modelo;

        [ObservableProperty]
        private int precio;

        [ObservableProperty]
        private string descripcion;

        private readonly ProductoServices _productoServices;

        public AddProductoPageViewModel()
        {
            _productoServices = new ProductoServices(); 
        }

        public AddProductoPageViewModel(Producto producto)
        {
            Nombre = producto.Nombre;
            Marca = producto.Marca; 
            Modelo = producto.Modelo;
            Precio = producto.Precio;
            Descripcion = producto.Descripcion;
            Id = producto.Id;
            _productoServices = new ProductoServices();

        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Producto producto = new Producto
                {
                    Nombre = Nombre,
                    Marca = Marca,  
                    Modelo = Modelo,    
                    Precio = Precio,
                    Descripcion = Descripcion,
                    Id = Id
                };

                if(Validar(producto))
                {
                    if(Id == 0)
                    {
                        _productoServices.Insert(producto);
                    }
                    else
                    {
                        _productoServices.Update(producto);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }

        private bool Validar(Producto producto)
        {
            try
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    Alerta("Atención", "Escriba el nombre del producto");
                    return false;
                }
                else if(string.IsNullOrEmpty(Marca))
                {
                    Alerta("Atención", "Escriba la marca del producto");
                    return false;
                }
                else if (string.IsNullOrEmpty(Modelo))
                {
                    Alerta("Atención", "Escriba el modelo del producto");
                    return false;
                }
                else if (string.IsNullOrEmpty(Descripcion))
                {
                    Alerta("Atención", "Escriba la descripción del producto");
                    return false;
                }
                else
                {
                    return true;
                }
            }catch (Exception ex)
            { 
                Alerta("Error", ex.Message);
                return false;
            }
        }

        private void Alerta(string Mensaje, string Tipo)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }
    }
}