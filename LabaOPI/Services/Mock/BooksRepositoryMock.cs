using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LabaOPI.Services.Mock
{
    public class BooksRepositoryMock : IRepository<Book>
    {
        public ObservableCollection<Book> books = new ObservableCollection<Book>();

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void Dispose()
        {

        }

        public Book? Get(Guid id)
        {
            return books.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public void Load()
        {
            books.Add(new Book() { Id = Guid.NewGuid(), Name = "Name", Author = "Author", Category = "Category", Description = "Description" });
        }

        public void Remove(Book book)
        {
            books.Remove(book);
        }

        public void Save()
        {

        }
    }
}
