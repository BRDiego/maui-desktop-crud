namespace DesktopMauiCrud.MauiCrud.Screens.Alerts
{
    internal class AlertService : IAlertService
    {
        private Page CurrentPage => Shell.Current?.CurrentPage
                                    ?? Application.Current?.MainPage
                                    ?? throw new InvalidOperationException("No page available");

        public Task ShowMessage(string message, string title = "Info", string cancel = "OK") =>
            CurrentPage.DisplayAlert(title, message, cancel);

        public Task<bool> ShowConfirmation(string message, string title = "Confirm", string accept = "Yes", string cancel = "No") =>
            CurrentPage.DisplayAlert(title, message, accept, cancel);

        public Task ShowError(string message, string title = "Error") =>
            CurrentPage.DisplayAlert(title, message, "Close");
    }
}
