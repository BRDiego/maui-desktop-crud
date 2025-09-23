using DesktopMauiCrud.MauiCrud.DTO;
using DesktopMauiCrud.MauiCrud.Screens;
using DesktopMauiCrud.MauiCrud.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DesktopMauiCrud.MauiCrud.ViewModels
{
    public class ClientEditViewModel : INotifyPropertyChanged
    {
        private readonly ClientService _service;
        private ClientDTO? _editingRegister;

        private string _name = "";
        private string _lastName = "";
        private DateOnly _dateOfBirth = new DateOnly(DateTime.Now.Year - 18, 1, 1);

        private string _streetName = "";
        private string _zipCode = "";

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string StreetName
        {
            get => _streetName;
            set { _streetName = value; OnPropertyChanged(); }
        }

        public string ZipCode
        {
            get => _zipCode;
            set { _zipCode = value; OnPropertyChanged(); }
        }

        public DateOnly DateOfBirth
        {
            get => _dateOfBirth;
            set { _dateOfBirth = value; OnPropertyChanged();}
        }

        private string _dateOfBirthText = "";
        public string DateOfBirthText
        {
            get => _dateOfBirthText;
            set
            {
                _dateOfBirthText = value;
                OnPropertyChanged();
            }
        }
        private int GetAge()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            int age = today.Year - _dateOfBirth.Year;

            if (today < new DateOnly(today.Year, _dateOfBirth.Month, _dateOfBirth.Day))
                age--;

            return age;
        }

        // Commands
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }
        public Command BackPageCommand { get; }

        public ClientEditViewModel(ClientService ser)
        {
            _service = ser;
            SaveCommand = new Command<Page>(Save);
            DeleteCommand = new Command<Page>(Delete);
            BackPageCommand = new Command(BackPage);
            _editingRegister = null;
        }

        private async void BackPage()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void Save(Page page)
        {
            try
            {

                if (!await ValidateFields(page))
                {
                    return;
                }
                var addressGuid = Guid.Empty;
                var cliGuid = Guid.Empty;

                if (!(_editingRegister is null))
                {
                    cliGuid = _editingRegister.Id;
                    if (!(_editingRegister.Address is null))
                    {
                        addressGuid = _editingRegister.Address.Id;
                    }
                }

                var address = new AddressDTO(addressGuid, _streetName, _zipCode);
                var cli = new ClientDTO(cliGuid, _name, _lastName, _dateOfBirth, address, 0);

                _service.Save(cli);

                await AppUtils.DisplayMessage(page, "Saved successfully!");

                BackPage();
            }
            catch (Exception ex)
            {
                await AppUtils.ErrorAlert(page, ex);
            }
        }

        private async Task<bool> ValidateFields(Page page)
        {
            if (string.IsNullOrEmpty(_name))
            {
                await AppUtils.DisplayMessage(page, "First Name is empty");
                return false;
            }
            
            if (string.IsNullOrEmpty(_lastName))
            {
                await AppUtils.DisplayMessage(page, "Last Name is empty");
                return false;
            }

            var regex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$");
            if (!regex.IsMatch(DateOfBirthText))
            {
                await AppUtils.DisplayMessage(page, "The date must be typed in this format: dd/MM/yyyy");
                return false;
            }
            else
            {
                _dateOfBirth = ParseTextToDateOnly();
            }
            if (GetAge() < 18)
            {
                await AppUtils.DisplayMessage(page, "The minimum age for registering is 18 years old");
                return false;
            }

            if (string.IsNullOrEmpty(_streetName))
            {
                await AppUtils.DisplayMessage(page, "Street name is empty");
                return false;
            }

            if (string.IsNullOrEmpty(_zipCode))
            {
                await AppUtils.DisplayMessage(page, "ZIPCODE is empty");
                return false;
            }

            return true;
        }

        private DateOnly ParseTextToDateOnly()
        {
            var day = int.Parse(DateOfBirthText.Substring(0, 2));
            var month = int.Parse(DateOfBirthText.Substring(3, 2));
            var year = int.Parse(DateOfBirthText.Substring(6, 4));

            return new DateOnly(year, month, day);
        }

        private async void Delete(Page page)
        {
            try
            {
                if (!await ValidateDeletion(page))
                    return;

                _service.Delete(_editingRegister!);

                await AppUtils.DisplayMessage(page, "Register deleted!");
                BackPage();
            }
            catch (Exception ex)
            {
                await AppUtils.ErrorAlert(page, ex);
            }
        }

        private async Task<bool> ValidateDeletion(Page page)
        {
            if (_editingRegister is null)
            {
                return false;
            }

            return await AppUtils.DisplayUserDecision(page, "Delete client");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        internal async void LoadClient(Page page, ClientDTO client)
        {
            try
            {
                if (client is not null)
                {
                    _editingRegister = client;
                    _name = client.Name;
                    _lastName = client.LastName;
                    _dateOfBirth = client.DateOfBirth;
                    _dateOfBirthText = WriteDateToText(client.DateOfBirth);
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(DateOfBirth));

                    if (client.Address is not null)
                    {
                        _streetName = client.Address.StreetName;
                        _zipCode = client.Address.ZipCode;
                        OnPropertyChanged(nameof(StreetName));
                        OnPropertyChanged(nameof(ZipCode));
                    }
                }
            }
            catch (Exception ex)
            {
                await AppUtils.ErrorAlert(page, ex);
            }
        }

        private string WriteDateToText(DateOnly date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }
    }
}
