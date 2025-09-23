using System.Text.Json.Serialization;

namespace DesktopMauiCrud.MauiCrud.Core.Entities
{
    public class Client : BaseEntity
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required Address? Adress { get; set; }
        
        [JsonIgnore]
        public short Age => CalculateAge();

        private short CalculateAge()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            int age = today.Year - DateOfBirth.Year;

            if (today < new DateOnly(today.Year, DateOfBirth.Month, DateOfBirth.Day))
                age--;

            return (short)age;
        }


        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Client))
            {
                return false;
            }

            var cli = obj as Client;

            return cli!.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
