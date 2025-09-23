using DesktopMauiCrud.MauiCrud.Data.Interface;
using System.Text.Json;

namespace DesktopMauiCrud.MauiCrud.Data.Imps
{
    public class JsonDataStorage<T> : IDataStorage<T>
    {
        private static readonly string FolderPath = FileSystem.AppDataDirectory;
        private static readonly string FileName = $"{typeof(T).Name}.json";
        private static readonly string FilePath = Path.Combine(FolderPath, FileName);

        private static HashSet<T> _items;

        static JsonDataStorage()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                _items = JsonSerializer.Deserialize<HashSet<T>>(json) ?? new HashSet<T>();
            }
            else
            {
                _items = new HashSet<T>();
            }
        }

        private static void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_items, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(FilePath, json);
        }

        public void Save(T obj)
        {
            _items.Remove(obj);
            _items.Add(obj);
            SaveChanges();
        }

        public void Delete(T obj)
        {
            _items.Remove(obj);
            SaveChanges();
        }

        public T Get(Func<T, bool> predicate)
        {
            foreach (var item in _items)
            {
                if (predicate(item)) return item;
            }

            throw new Exception("Not Found");
        }

    }
}
