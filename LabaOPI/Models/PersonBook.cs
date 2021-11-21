using LabaOPI.Services;
using System;

namespace LabaOPI.Models
{
    public class PersonBook : ISearchable
    {
        public Guid Id { get; set; }
        public Person? Person { get; set; }
        public Book? Book { get; set; }
        public DateTime BorrowTime { get; set; }

        public string GetSearchString()
        {
            string personSearchValue = Person?.GetSearchString() ?? string.Empty;
            string bookSearchValue = Book?.GetSearchString() ?? string.Empty;

            return personSearchValue + bookSearchValue + BorrowTime.ToString();
        }
    }
}
