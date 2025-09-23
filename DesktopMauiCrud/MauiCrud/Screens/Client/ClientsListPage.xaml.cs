using DesktopMauiCrud.MauiCrud.DTO;
using DesktopMauiCrud.MauiCrud.ViewModels;

namespace DesktopMauiCrud.MauiCrud.Screens.Client;

public partial class ClientsListPage : ContentPage
{
	private ClientListViewModel vm;
	public ClientsListPage(ClientListViewModel viewm)
	{
		InitializeComponent();
		BindingContext = viewm;
		vm = viewm;
	}

    protected async override void OnAppearing()
    {
		try
        {
            vm.RefreshList();
        }
		catch (Exception ex)
		{
			await AppUtils.ErrorAlert(this, ex);
		}
    }

    private async void OnClientSelected(object sender, SelectionChangedEventArgs e)
    {

		try
        {
            if (e.CurrentSelection.FirstOrDefault() is ClientDTO selected)
            {
                await Shell.Current.GoToAsync(nameof(ClientEditPage),
                    new Dictionary<string, object>
                    {
                { "Client", selected }
                    });
            }

            // limpa a seleção pra não ficar marcado
            ((CollectionView)sender).SelectedItem = null;
        }
		catch (Exception ex)
		{
			await AppUtils.ErrorAlert(this, ex);
		}
    }
}