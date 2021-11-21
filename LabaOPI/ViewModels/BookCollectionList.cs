using LabaOPI.Services;
using LabaOPI.Services.Mock;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace LabaOPI.ViewModels
{
    public class BookCollectionList
    {
        public IEnumerable<Book> Books { get; set; }
        private IRepository<Book> bookRepository;
        public BookCollectionList()
        {
            if(Application.Current.IsDesignTime())
            {
                this.bookRepository = new BooksRepositoryMock();
            }
            else
            {
                this.bookRepository = new BooksRepository();
            }

            Books = new ObservableCollection<Book>(bookRepository.GetAll());
        }
    }
}
