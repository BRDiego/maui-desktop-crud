using DesktopMauiCrud.MauiCrud.DTO;
using DesktopMauiCrud.MauiCrud.Screens;
using DesktopMauiCrud.MauiCrud.ViewModels;

namespace DesktopMauiCrud
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private ClientListViewModel vm;
        public MainPage(ClientListViewModel vim)
        {
            InitializeComponent();
            vm = vim;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void RunDummyTest(object sender, EventArgs e)
        {
            try
            {
                var teste = vm.clients.FirstOrDefault();
                var id = Guid.NewGuid();
                if (!(teste is null))
                {
                    id = teste.Id;
                    await AppUtils.DisplayMessage(this, $"Client: {teste.Name} Address: {teste.FullAddress()}");
                }

                var add = new AddressDTO(
                    Guid.NewGuid(),
                    "Narnia",
                    "SemID",
                    "000-0000",
                    "Peaceful"
                );
                var cli = new ClientDTO(
                    id,
                    "Diego",
                    "Rocha",
                    new DateOnly(2001, 5, 24),
                    add,
                    0
                );

                vm.SaveClient(cli);
                vm.RefreshList();

                var doiz = vm.clients.First();
                await AppUtils.DisplayMessage(this, doiz.Name);
            }
            catch (Exception ex)
            {
                await AppUtils.ErrorAlert(this, ex);
            }
        }
    }
}
