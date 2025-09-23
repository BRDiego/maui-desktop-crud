using DesktopMauiCrud.MauiCrud.Core.Entities;

namespace DesktopMauiCrud.MauiCrud.DTO.Mappers
{
    public static class AddressDTOMapper
    {
        public static AddressDTO ToDto(this Address entity)
        {
            if (entity is null) return null!;

            return new AddressDTO(
                entity.Id,
                entity.StreetName,
                entity.ZipCode
            );
        }

        public static Address ToEntity(this AddressDTO dto)
        {
            if (dto is null) return null!;

            return new Address
            {
                Id = dto.Id,
                StreetName = dto.StreetName,
                ZipCode = dto.ZipCode
            };
        }
    }
}
