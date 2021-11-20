using LabaOPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOPI.Services
{
    public class BooksRepository : IRepository<Book>
    {
        private bool disposedValue;
        private DataContext dataContext;

        public BooksRepository()
        {
            this.dataContext = new DataContext();
        }

        public void Add(Book book)
        {
            dataContext.Books!.Add(book);
        }

        public Book? Get(Guid id)
        {
            return dataContext.Books!.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return dataContext.Books!.Local;
        }

        public void Remove(Book book)
        {
            dataContext.Books!.Remove(book);
        }

        public void Save()
        {
            dataContext.SaveChanges();
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

        public void Load()
        {
            dataContext.Books!.Load();
        }
    }
}
