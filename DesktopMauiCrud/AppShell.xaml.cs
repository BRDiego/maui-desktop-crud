using DesktopMauiCrud.MauiCrud.Screens.Client;

namespace DesktopMauiCrud
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ClientEditPage), typeof(ClientEditPage));
        }
    }
}
