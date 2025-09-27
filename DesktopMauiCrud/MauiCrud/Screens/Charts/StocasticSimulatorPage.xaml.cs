using DesktopMauiCrud.MauiCrud.ViewModels.Simulation;
using System.Text.RegularExpressions;

namespace DesktopMauiCrud.MauiCrud.Screens.Charts;

public partial class StocasticSimulatorPage : ContentPage
{
    private BrownianSimulationViewModel _vm;
	public StocasticSimulatorPage(BrownianSimulationViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = vm;

        vm.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(vm.LineChart))
            {
                GVLineChart.Invalidate();
            }
        };
    }

    private async void NumericEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            var entry = sender as Entry;

            if (!Regex.IsMatch(entry!.Text, @"^\d*$"))
            {
                entry.Text = Regex.Replace(entry.Text, @"\D", "");
            }
        }
        catch (Exception ex)
        {
            await AppUtils.ErrorAlert(this, ex);
        }
    }
}