using DesktopMauiCrud.MauiCrud.Core.Entities;

namespace DesktopMauiCrud.MauiCrud.DTO.Mappers
{
    public static class ClientDTOMapper
    {
        public static ClientDTO ToDto(this Client entity)
        {
            if (entity is null) return null!;

            return new ClientDTO(
                entity.Id,
                entity.Name,
                entity.LastName,
                entity.DateOfBirth,
                entity.Adress?.ToDto(),
                entity.Age
            );
        }

        public static Client ToEntity(this ClientDTO dto)
        {
            if (dto is null) return null!;

            return new Client
            {
                Id = dto.Id,
                Name = dto.Name,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Adress = dto.Address?.ToEntity()
            };
        }
    }
}
