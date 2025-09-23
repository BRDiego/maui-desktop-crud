namespace DesktopMauiCrud.MauiCrud.DTO
{
    public record AddressDTO(
        Guid Id,
        string StreetName,
        string IdentificationNumber,
        string ZipCode,
        string Complement
    );
}
