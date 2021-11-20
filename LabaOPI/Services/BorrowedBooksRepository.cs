using LabaOPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOPI.Services
{
    public class BorrowedBooksRepository : IRepository<PersonBook>
    {
        private bool disposedValue;
        private DataContext dataContext;

        public BorrowedBooksRepository()
        {
            this.dataContext = new DataContext();
        }

        public void Add(PersonBook book)
        {
            dataContext.BorrowedBooks!.Add(book);
        }

        public PersonBook? Get(Guid id)
        {
            return dataContext.BorrowedBooks!.Find(id);
        }

        public IEnumerable<PersonBook> GetAll()
        {
            return dataContext.BorrowedBooks!.Local;
        }

        public void Load()
        {
            dataContext.BorrowedBooks!
                .Include(op => op.Book)
                .Include(op => op.Person)
                .Load();
        }

        public void Remove(PersonBook book)
        {
            dataContext.BorrowedBooks!.Remove(book);
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
    }
}
