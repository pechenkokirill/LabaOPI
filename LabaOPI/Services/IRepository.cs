using System;
using System.Collections.Generic;

namespace LabaOPI.Services
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T? Get(Guid id);
        void Add(T item);
        void Remove(T item);
        void Save();
        void Load();
    }
}
