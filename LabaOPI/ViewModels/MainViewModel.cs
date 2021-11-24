using LabaOPI.Data;
using LabaOPI.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace LabaOPI.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly SearchStore searchStore;
        private readonly DataContext dataContext;

        public BooksViewModel BooksViewModel { get; init; }
        public UsersViewModel UsersViewModel { get; init; }
        public BorrowedBooksViewModel BorrowedBooksViewModel { get; init; }
        public string SearchWord { get => searchStore.SearchWord; set => searchStore.SearchWord = value; }
        public RelayCommand SaveCommand { get; set; }

        public MainViewModel(SearchStore searchStore, DataContext dataContext, BooksViewModel booksViewModel, UsersViewModel usersViewModel, BorrowedBooksViewModel borrowedBooksViewModel)
        {
            this.searchStore = searchStore;
            this.dataContext = dataContext;
            BooksViewModel = booksViewModel;
            UsersViewModel = usersViewModel;
            BorrowedBooksViewModel = borrowedBooksViewModel;

            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
