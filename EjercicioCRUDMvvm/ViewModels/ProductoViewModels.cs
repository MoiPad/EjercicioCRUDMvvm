


using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.Services;
using EjercicioCRUDMvvm.Views;
using System.Collections.ObjectModel;


namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class ProductoViewModels : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Producto> productoCollection = new ObservableCollection<Producto>();

        private readonly ProductoServices _productoServices;
        public ProductoViewModels() 
        {
            _productoServices = new ProductoServices();
        }

        public void GetAll()
        {
            var getAll = _productoServices.GetAll();

            if (getAll?.Count > 0) 
            {
                ProductoCollection.Clear();
                foreach (var producto in getAll)
                {
                    ProductoCollection.Add(producto);
                }
            }
        }

        [RelayCommand]
        private async Task GoToAddProductoPage()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddProductoPage());

        }

        [RelayCommand]
        private async Task SelectProducto(Producto producto)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Operación", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await App.Current.MainPage.Navigation.PushAsync(new AddProductoPage(producto));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Empleado", "¿Desea eliminar el producto?", "Si", "No");

                        if (respuesta)
                        {
                            int del = _productoServices.Delete(producto);
                            if (del > 0)
                            {
                                ProductoCollection.Remove(producto);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alerta("Error: ",ex.Message);
            }
        }
        private void Alerta(string Mensaje, string Tipo)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }
    }
}