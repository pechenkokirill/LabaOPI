using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LabaOPI.Services.Mock
{
    public class UsersRepositoryMock : IRepository<Person>
    {
        private ObservableCollection<Person> users = new ObservableCollection<Person>();
        public void Add(Person person)
        {
            users.Add(person);
        }

        public void Dispose()
        {
        }

        public Person? Get(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return users;
        }

        public void Load()
        {
            users.Add(new Person() { Id = Guid.NewGuid(), SecondName = "SecondName", FirstName = "FirstName", LastName = "LastName", PhoneNumber = "+375 (33) 381-54-78" });
        }

        public void Remove(Person person)
        {
            users.Remove(person);
        }

        public void Save()
        {

        }
    }
}
