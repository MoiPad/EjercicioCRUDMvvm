using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.ViewModels;
namespace EjercicioCRUDMvvm.Views;

public partial class AddProductoPage : ContentPage
{
	public AddProductoPageViewModel _viewModel;
	
	public AddProductoPage()
	{
        InitializeComponent();
		_viewModel = new AddProductoPageViewModel();
		this.BindingContext = _viewModel;
    }

	public AddProductoPage(Producto producto)
	{
        InitializeComponent();
		_viewModel = new AddProductoPageViewModel(producto);
		this.BindingContext = _viewModel;
    }
}