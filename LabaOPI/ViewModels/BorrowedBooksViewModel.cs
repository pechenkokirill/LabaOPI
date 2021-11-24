using LabaOPI.Services;
using LabaOPI.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LabaOPI.ViewModels
{
    public class BorrowedBooksViewModel : CollectionTabBaseViewModel<PersonBook>
    {
        private readonly IRepository<Book> booksRepository;
        private readonly IRepository<Person> usresRepository;
        public IEnumerable<Book> Books => new ObservableCollection<Book>(booksRepository.GetAll());
        public IEnumerable<Person> Users => new ObservableCollection<Person>(usresRepository.GetAll());

        public BorrowedBooksViewModel(IRepository<PersonBook> usersRepository, SearchStore searchStore, IRepository<Book> booksRepository, IRepository<Person> usresRepository) : base(usersRepository, searchStore)
        {
            this.booksRepository = booksRepository;
            this.usresRepository = usresRepository;
        }
    }
}
