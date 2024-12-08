using MauiFirebaseApp.Helpers;
using MauiFirebaseApp.Models;
namespace MauiFirebaseApp.Views;

public partial class SearchProductPage : ContentPage
{

	FirebaseHelper firebaseHelper = new FirebaseHelper();	
	public SearchProductPage()
	{
		InitializeComponent();
	}

	private async void OnSearchProductClicked (object sender, EventArgs e)
	{
		string searchTerm = SearchEntry.Text;
		var productos = await firebaseHelper.GetAllProductos();
		var filteredProductos = productos.Where(p => p.Nombre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

		ResultsListView.ItemsSource = filteredProductos;
	}
}