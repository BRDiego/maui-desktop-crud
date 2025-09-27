using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopMauiCrud.MauiCrud.Core;
using DesktopMauiCrud.MauiCrud.Screens.Alerts;
using DesktopMauiCrud.MauiCrud.Screens.GraphicDrawing;

namespace DesktopMauiCrud.MauiCrud.ViewModels.Simulation
{
    public partial class BrownianSimulationViewModel : ObservableObject
    {
        private IAlertService _alerts;
        private BrownianMotionCalculator _calculator;

        [ObservableProperty] private LineChartDraw lineChart = new LineChartDraw([]);

        [ObservableProperty] private string initialPriceText;

        [ObservableProperty] private double volatility = 0.0;

        [ObservableProperty] private double averageReturn = 0.0;

        [ObservableProperty]
        private string daysDurationText;

        public BrownianSimulationViewModel(BrownianMotionCalculator calc, IAlertService alerts)
        {
            _alerts = alerts;
            _calculator = calc;
        }

        [RelayCommand]
        public async Task Reset()
        {
            try
            {
                if (!await _alerts.ShowConfirmation("Do you want to reset the simulation?"))
                    return;

                InitialPriceText = string.Empty;
                DaysDurationText = string.Empty;
                Volatility = 0.0;
                AverageReturn = 0.0;
                UpdateChartData([]);
            }
            catch (Exception ex)
            {
                await _alerts.ShowError(ex.Message);
            }
        }

        private void UpdateChartData(double[] result)
        {
            LineChart.UpdateData(result);
            OnPropertyChanged(nameof(LineChart));
        }

        [RelayCommand]
        public async Task Simulate()
        {
            try
            {
                if (!await ValidInputs())
                    return;

                var ini = double.Parse(InitialPriceText);
                var vol = Volatility / 100;
                var ave = AverageReturn / 100;
                var dur = int.Parse(DaysDurationText);

                UpdateChartData(_calculator.GenerateBrownianMotion(vol, ave, ini, dur));
            }
            catch (Exception ex)
            {
                await _alerts.ShowError(ex.Message);
            }
        }


        private async Task<bool> ValidInputs()
        {
            if (!double.TryParse(InitialPriceText, out var dRes))
            {
                await _alerts.ShowMessage($"Initial price is invalid ({dRes})");
                return false;
            }
            
            if (!int.TryParse(DaysDurationText, out var iRes) || iRes < 1)
            {
                await _alerts.ShowMessage($"Days duration {iRes} is invalid");
                return false;
            }


            return true;
        }
    }
}
