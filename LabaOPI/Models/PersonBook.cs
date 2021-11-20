using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOPI.Models
{
    public class PersonBook
    {
        public Guid Id { get; set; }
        public Person? Person { get; set; }
        public Book? Book { get; set; }
        public DateTime BorrowTime { get; set; }
    }
}
