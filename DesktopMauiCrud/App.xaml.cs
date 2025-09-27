using Microsoft.Maui.Storage;

namespace DesktopMauiCrud
{
    public partial class App : Application
    {
        public static string AppFolderPath = FileSystem.AppDataDirectory;
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

    }
}