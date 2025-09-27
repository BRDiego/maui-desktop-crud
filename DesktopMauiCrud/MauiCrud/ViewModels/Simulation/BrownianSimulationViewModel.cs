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

        [ObservableProperty]
        private LineChartDraw lineChart = new LineChartDraw([]);

        [ObservableProperty]
        private string initialPriceText;

        [ObservableProperty]
        private string volatilityText;

        [ObservableProperty]
        private string averageReturnText;

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
                VolatilityText = string.Empty;
                AverageReturnText = string.Empty;
                DaysDurationText = string.Empty;
                UpdateChartData([]);
            }
            catch (Exception ex)
            {
                await _alerts.ShowError(ex.Message);
            }
        }

        [RelayCommand]
        public async Task Simulate()
        {
            try
            {
                if (!await ValidInputs())
                    return;

                var ini = double.Parse(InitialPriceText);
                var vol = double.Parse(VolatilityText) / 100;
                var ave = double.Parse(AverageReturnText) / 100;
                var dur = int.Parse(DaysDurationText);

                UpdateChartData(_calculator.GenerateBrownianMotion(vol, ave, ini, dur));
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

        private async Task<bool> ValidInputs()
        {
            var doubleHelper = 0.0;
            if (!double.TryParse(InitialPriceText, out doubleHelper))
            {
                await _alerts.ShowMessage("Initial price is invalid");
                return false;
            }
            
            if (!double.TryParse(VolatilityText, out doubleHelper))
            {
                await _alerts.ShowMessage("Volatility is invalid");
                return false;
            }
            
            if (!double.TryParse(AverageReturnText, out doubleHelper))
            {
                await _alerts.ShowMessage("Average return is invalid");
                return false;
            }
            
            if (!int.TryParse(DaysDurationText, out var helper))
            {
                await _alerts.ShowMessage("Days duration is invalid");
                return false;
            }

            return true;
        }
    }
}
