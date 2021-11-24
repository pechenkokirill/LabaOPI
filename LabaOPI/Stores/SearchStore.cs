using System;

namespace LabaOPI.Stores
{
    public class SearchStore
    {
        private string searchWord = string.Empty;

        public string SearchWord { get => searchWord; set { searchWord = value; OnSearchWordChanged?.Invoke(searchWord); } }
        public event Action<string>? OnSearchWordChanged;
    }
}
