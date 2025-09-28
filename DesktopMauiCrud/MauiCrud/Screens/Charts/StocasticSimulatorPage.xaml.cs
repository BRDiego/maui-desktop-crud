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
            if (e.PropertyName == nameof(vm.SimulationChart))
            {
                GVLineChart.Invalidate();
            }
        };
    }

    private async void InitialPriceTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(e.NewTextValue)) return;
            var entry = sender as Entry;

            var validChars = "0123456789-.";
            var checkedText = string.Concat(e.NewTextValue.AsEnumerable().Where(x => validChars.Contains(x)));

            if (!Regex.IsMatch(checkedText, @"^-?\d+(\.\d+)?$"))
            {
                await PageUtils.DisplayMessage(this, $"The initial price {checkedText} is invalid!");
                entry!.Text = "";
                return;
            }

            entry!.Text = checkedText;
        }
        catch (Exception ex)
        {
            await PageUtils.ErrorAlert(this, ex);
        }
    }

    private async void DaysDurationTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(e.NewTextValue)) return;

            var entry = sender as Entry;

            var validChars = "0123456789";
            var checkedText = string.Concat(e.NewTextValue.AsEnumerable().Where(x => validChars.Contains(x)));

            if (!Regex.IsMatch(checkedText, @"^[0-9]{1,4}$"))
            {
                await PageUtils.DisplayMessage(this, $"The days duration {checkedText} is invalid!");
                entry!.Text = "";
                return;
            }

            entry!.Text = checkedText;
        }
        catch (Exception ex)
        {
            await PageUtils.ErrorAlert(this, ex);
        }
    }
}