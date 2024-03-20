using EjercicioCRUDMvvm.ViewModels;

namespace EjercicioCRUDMvvm.Views;

public partial class ProductoMainPage : ContentPage
{
    private ProductoViewModels _viewModel;
    public ProductoMainPage()
	{
        InitializeComponent();
        _viewModel = new ProductoViewModels();
		this.BindingContext = _viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetAll();

    }
}