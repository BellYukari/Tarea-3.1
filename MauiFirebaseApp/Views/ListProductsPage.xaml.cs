using MauiFirebaseApp.Helpers;
using MauiFirebaseApp.Models;

namespace MauiFirebaseApp.Views;

public partial class ListProductsPage : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	public ListProductsPage()
	{
		InitializeComponent();

		LoadProducts();
	}

	private async void LoadProducts()
	{
		var productos = await firebaseHelper.GetAllProductos();
		ProductsListView.ItemsSource = productos;
	}

	private async void OnEditProductClicked(object sender, EventArgs e)
	{
		var button = sender as Button;	
		var producto = button?.BindingContext as Producto;

		if (producto != null )
		{
			await Navigation.PushAsync(new EditProductPage(producto));
		}
	}

	private async void OnDeleteProductClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var producto = button?.BindingContext as Producto;
		if (producto != null  && !string.IsNullOrEmpty(producto.Id))
		{
			await firebaseHelper.DeleteProducto(producto.Id);
			await DisplayAlert("Exito", "Producto Eliminado", "ok");
			LoadProducts();
		}
		else
		{
			await DisplayAlert("Error", "No se pudo encontrar el producto para eliminiar", "ok");
		}
	}
} 