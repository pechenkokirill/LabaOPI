using System;
using System.Collections.Generic;
using System.Linq;

namespace LabaOPI.Services.Mock
{
    public class BorrowedBooksRepositoryMock : IRepository<PersonBook>
    {
        private List<PersonBook> personBooks = new List<PersonBook>();
        private IRepository<Book> books = new BooksRepositoryMock();
        private IRepository<Person> users = new UsersRepositoryMock();
        public void Add(PersonBook item)
        {
            personBooks.Add(item);
        }

        public void Dispose()
        {
        }

        public PersonBook? Get(Guid id)
        {
            return personBooks.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<PersonBook> GetAll()
        {
            return personBooks;
        }

        public void Load()
        {
            books.Load();
            users.Load();

            personBooks.Add(new PersonBook() { Id = Guid.NewGuid(), Book = books.GetAll().First(), Person = users.GetAll().First(), BorrowTime = DateTime.Now });
        }

        public void Remove(PersonBook item)
        {
            personBooks.Add(item);
        }

        public void Save()
        {
        }
    }
}
