using LabaOPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOPI.Services
{
    public class UsersRepository : IRepository<Person>
    {
        private bool disposedValue;
        private DataContext dataContext;

        public UsersRepository()
        {
            this.dataContext = new DataContext();
        }

        public void Add(Person book)
        {
            dataContext.Users!.Add(book);
        }

        public Person? Get(Guid id)
        {
            return dataContext.Users!.Find(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return dataContext.Users!.Local;
        }

        public void Remove(Person book)
        {
            dataContext.Users!.Remove(book);
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }

        public void Load()
        {
            dataContext.Users!.Load();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
