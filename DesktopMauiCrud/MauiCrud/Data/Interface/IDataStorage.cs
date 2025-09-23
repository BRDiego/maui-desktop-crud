namespace DesktopMauiCrud.MauiCrud.Data.Interface
{
    public interface IDataStorage<T>
    {
        void Save(T obj);
        T Get(Func<T, bool> predicate);
        void Delete(T obj);
    }
}
