using DesktopMauiCrud.MauiCrud.Core.Exceptions;

namespace DesktopMauiCrud.MauiCrud.Screens
{
    public class PageUtils
    {
        public async static Task<bool> DisplayUserDecision(Page screen, string actionToConfirm)
        {
            return await screen.DisplayAlert("Confirmation", $"Do you really want to perform this action?{
                Environment.NewLine}{Environment.NewLine}{actionToConfirm}",
                "Yes", "No");
        }

        public async static Task DisplayMessage(Page screen, string message)
        {
            await screen.DisplayAlert("Info", message, "OK");
        }

        public async static Task ValidationAlert(Page screen, CustomException ex)
        {
            await screen.DisplayAlert("Alert", ex.Message, "Close");
        }

        public async static Task ErrorAlert(Page screen, Exception ex)
        {
            await screen.DisplayAlert("Error", "There was an error during app execution: " + ex.Message, "Close");
        }
    }
}
