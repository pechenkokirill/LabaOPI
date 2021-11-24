using LabaOPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LabaOPI.Services
{
    public class BorrowedBooksRepository : IRepository<PersonBook>
    {
        private bool disposedValue;
        private DataContext dataContext;

        public BorrowedBooksRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(PersonBook item)
        {
            dataContext.BorrowedBooks!.Add(item);
        }

        public PersonBook? Get(Guid id)
        {
            return dataContext.BorrowedBooks!.Find(id);
        }

        public IEnumerable<PersonBook> GetAll()
        {
            return dataContext.BorrowedBooks!.Local.ToObservableCollection();
        }

        public void Load()
        {
            dataContext.BorrowedBooks!
                .Include(op => op.Book)
                .Include(op => op.Person)
                .Load();
        }

        public void Remove(PersonBook item)
        {
            dataContext.BorrowedBooks!.Remove(item);
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
