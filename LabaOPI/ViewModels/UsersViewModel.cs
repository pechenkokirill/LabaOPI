using LabaOPI.Services;
using LabaOPI.Stores;

namespace LabaOPI.ViewModels
{
    public class UsersViewModel : CollectionTabBaseViewModel<Person>
    {
        public UsersViewModel(IRepository<Person> repository, SearchStore searchStore) : base(repository, searchStore)
        {
        }
    }
}
