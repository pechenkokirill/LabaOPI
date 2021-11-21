using LabaOPI.Data;
using LabaOPI.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace LabaOPI.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public static MainViewModel Inst { get; private set; } = new MainViewModel();
        private string searchWord = "";
        public string SearchWord { get => searchWord; set { searchWord = value; OnTextChanged?.Invoke(); } }
        public event Action? OnTextChanged;
        public RelayCommand SaveCommand { get; set; }

        public MainViewModel()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            DataContext dataContext = DataProvider.GetDataContext();
            dataContext.SaveChanges();
        }
    }
}
