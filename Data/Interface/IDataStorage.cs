using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IDataStorage<T>
    {
        void save(T obj);
        void delete(T obj);
        void get(T obj);
    }
}
