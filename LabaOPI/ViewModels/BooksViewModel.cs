using LabaOPI.Services;
using LabaOPI.Stores;

namespace LabaOPI.ViewModels
{
    public class BooksViewModel : CollectionTabBaseViewModel<Book>
    {
        public BooksViewModel(IRepository<Book> repository, SearchStore searchStore) : base(repository, searchStore)
        {
        }
    }
}
