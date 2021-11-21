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
        protected IRepository<T> Repository { get; init; }

        protected CollectionTabBaseViewModel()
        {
            Repository = OnConfigureRepository(Application.Current.IsDesignTime());

            Repository.Load();
            Collection = CollectionViewSource.GetDefaultView(Repository.GetAll());
            Collection.Filter = Filter;
            MainViewModel.Inst.OnTextChanged += () => Collection.Refresh();
        }

        protected abstract IRepository<T> OnConfigureRepository(bool isDesignTime);

        private bool Filter(object v)
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
