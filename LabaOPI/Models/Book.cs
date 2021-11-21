using LabaOPI.Services;
using System;

namespace LabaOPI.Models
{
    public class Book : ISearchable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string GetSearchString()
        {
            return Name + Category + Author + Description;
        }
    }
}
