using DesktopMauiCrud.MauiCrud.Core.Entities;

namespace DesktopMauiCrud.MauiCrud.Data.Interface
{
    public interface IDataStorage<T> where T : BaseEntity
    {
        void Save(T obj);
        T Get(Func<T, bool> predicate);
        void Delete(T obj);
        IEnumerable<T> List(Func<T, bool>? predicate = null);
    }
}
