namespace DesktopMauiCrud.MauiCrud.Screens.Alerts
{
    public interface IAlertService
    {
        Task ShowMessage(string message, string title = "Info", string cancel = "OK");
        Task<bool> ShowConfirmation(string message, string title = "Confirm", string accept = "Yes", string cancel = "No");
        Task ShowError(string message, string title = "Error");
    }
}
