using LabaOPI.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LabaOPI.ViewModels
{
    public abstract class CollectionTabBaseViewModel<T> : ObservableObject where T : class, ISearchable
    {
        public ICollectionView Collection { get; set; }
        private readonly IRepository<T> repository;

        protected CollectionTabBaseViewModel()
        {
            this.repository = OnConfigureRepository(Application.Current.IsDesignTime());

            repository.Load();

            Collection = CollectionViewSource.GetDefaultView(new ObservableCollection<T>(repository.GetAll()));
            Collection.Filter = Filter;
            MainViewModel.Inst.OnTextChanged += () => Collection.Refresh();
        }

        protected abstract IRepository<T> OnConfigureRepository(bool isDesignTime);

        protected bool Filter(object v)
        {
            if (v is not ISearchable searchable)
                return false;

            if (string.IsNullOrWhiteSpace(MainViewModel.Inst.SearchWord))
                return true;

            string searchValue = searchable.GetSearchString();

            if (MainViewModel.Inst.SearchWord.Length > searchValue.Length)
            {
                return MainViewModel.Inst.SearchWord.ToUpper().Contains(searchValue.ToUpper());
            }
            else
            {
                return searchValue.ToUpper().Contains(MainViewModel.Inst.SearchWord.ToUpper());
            }
        }
    }
}
