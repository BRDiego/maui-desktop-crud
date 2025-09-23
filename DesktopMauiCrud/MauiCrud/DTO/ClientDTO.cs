namespace DesktopMauiCrud.MauiCrud.DTO
{
    public record ClientDTO(
        Guid Id,
        string Name,
        string LastName,
        DateOnly DateOfBirth,
        AddressDTO? Address,
        short Age
    )
    {
        public string FullAddress()
        {
            if (Address is null)
                return "No address!";
            
            return $"{Address.StreetName}" +
                $"{Environment.NewLine}{Address.IdentificationNumber}" +
                $"{Environment.NewLine}{Address.Complement}" +
                $"{Environment.NewLine}{Address.ZipCode}";
        }
    }
}
