using DesktopMauiCrud.MauiCrud.Screens.Charts;
using DesktopMauiCrud.MauiCrud.Screens.Client;

namespace DesktopMauiCrud
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ClientEditPage), typeof(ClientEditPage));
            Routing.RegisterRoute(nameof(ClientsListPage), typeof(ClientsListPage));
            Routing.RegisterRoute(nameof(StocasticSimulatorPage), typeof(StocasticSimulatorPage));
        }
    }
}
