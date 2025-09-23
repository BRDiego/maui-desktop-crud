using Data.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.TxtDataAccess
{
    public class TxtFileDataStorage<T> : IDataStorage<T>
    {
        private static string FolderPath = FileSystem.AppDataDirectory;
        private static string FileName = $"{typeof(T).Name}.txt";
        private static string FilePath = Path.Combine(FolderPath, FileName);

        public void delete(T obj)
        {
            throw new NotImplementedException();
        }

        public void get(T obj)
        {
            throw new NotImplementedException();
        }

        public void save(T obj)
        {
            using (var writer = new StreamWriter(FilePath, append: true))
            {
                string json = JsonSerializer.Serialize(obj);
                writer.WriteLine(json);
            }
        }
    }
}
