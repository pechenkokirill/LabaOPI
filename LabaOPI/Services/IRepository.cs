using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOPI.Services
{
    public interface IRepository<T> : IDisposable where T : class 
    { 
        IEnumerable<T> GetAll();
        T? Get(Guid id);
        void Add(T book);
        void Remove(T book);
        void Save();
        void Load();
    }
}
