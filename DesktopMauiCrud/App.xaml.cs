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
            var win = new Window(new AppShell());
            win.Height = win.MaximumHeight;
            win.Width = win.MaximumWidth;
            win.X = -10;
            win.Y = -10;
            return win;
        }

    }
}