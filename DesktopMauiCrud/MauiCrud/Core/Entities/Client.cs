namespace DesktopMauiCrud.MauiCrud.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required Address Adress { get; set; }
        public short Age => CalculateAge();

        private short CalculateAge()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            int age = today.Year - DateOfBirth.Year;

            if (today < new DateOnly(today.Year, DateOfBirth.Month, DateOfBirth.Day))
                age--;

            return (short)age;
        }

    }
}
