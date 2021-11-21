using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace LabaOPI.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private string searchWord = "";
        public string SearchWord { get => searchWord; set { searchWord = value; OnTextChanged?.Invoke(); } }
        public event Action? OnTextChanged;
        public static MainViewModel Inst { get; private set; } = new MainViewModel(); 
    }
}
