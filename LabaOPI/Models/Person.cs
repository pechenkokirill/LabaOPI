using LabaOPI.Services;
using System;

namespace LabaOPI.Models
{
    public class Person : ISearchable
    {
        public Guid Id { get; set; }
        public string SecondName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string GetSearchString()
        {
            return SecondName + FirstName + LastName + PhoneNumber;
        }
    }
}
