using DesktopMauiCrud.MauiCrud.Screens.Charts;
using DesktopMauiCrud.MauiCrud.Screens.Client;

namespace DesktopMauiCrud.MauiCrud.Screens;

public partial class ChooseFeaturePage : ContentPage
{
	public ChooseFeaturePage()
	{
		InitializeComponent();
	}

    private async void OpenSimulationPage(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(StocasticSimulatorPage));
        }
        catch (Exception ex)
        {
            await PageUtils.ErrorAlert(this, ex);
        }
    }
    private async void OpenClientsCrudPage(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(ClientsListPage));
        }
        catch (Exception ex)
        {
            await PageUtils.ErrorAlert(this, ex);
        }
    }
}