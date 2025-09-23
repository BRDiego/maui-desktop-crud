namespace DesktopMauiCrud.MauiCrud.Core.Entities
{
    public class Address : BaseEntity
    {
        public required string StreetName { get; set; }
        public required string ZipCode { get; set; }
    }
}
