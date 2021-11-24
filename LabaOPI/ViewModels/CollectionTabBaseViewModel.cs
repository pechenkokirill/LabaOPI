using LabaOPI.Services;
using LabaOPI.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows.Data;

namespace LabaOPI.ViewModels
{
    public abstract class CollectionTabBaseViewModel<T> : ObservableObject where T : class, ISearchable
    {
        private readonly SearchStore searchStore;
        public ICollectionView Collection { get; set; }
        protected IRepository<T> Repository { get; init; }

        public CollectionTabBaseViewModel(IRepository<T> repository, SearchStore searchStore)
        {
            Repository = repository;
            this.searchStore = searchStore;

            Repository.Load();
            Collection = CollectionViewSource.GetDefaultView(Repository.GetAll());
            Collection.Filter = Filter;
            searchStore.OnSearchWordChanged += (s) => Collection.Refresh();
        }

        private bool Filter(object v)
        {
            if (v is not ISearchable searchable)
                return false;

            if (string.IsNullOrWhiteSpace(searchStore.SearchWord))
                return true;

            string searchValue = searchable.GetSearchString();

            if (searchStore.SearchWord.Length > searchValue.Length)
            {
                return searchStore.SearchWord.ToUpper().Contains(searchValue.ToUpper());
            }
            else
            {
                return searchValue.ToUpper().Contains(searchStore.SearchWord.ToUpper());
            }
        }
    }
}
