using LabaOPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOPI.Services
{
    public class DataProvider
    {
        private static DataProvider inst = new DataProvider();
        private DataContext dataContext = new DataContext();

        public static DataContext GetDataContext() => inst.dataContext;
    }
}
