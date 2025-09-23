namespace DesktopMauiCrud.MauiCrud.Core.Entities
{
    public abstract class BaseEntity
    {
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set => _id = value == Guid.Empty ? Guid.NewGuid() : value;
        }
    }
}
