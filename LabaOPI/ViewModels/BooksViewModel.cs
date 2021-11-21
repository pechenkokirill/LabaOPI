using LabaOPI.Data;
using LabaOPI.Services;
using LabaOPI.Services.Mock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace LabaOPI.ViewModels
{
    public class BooksViewModel : CollectionTabBaseViewModel<Book>
    {
        protected override IRepository<Book> OnConfigureRepository(bool isDesignTime)
        {
#if DEBUG
            if (isDesignTime)
            {
                return new BooksRepositoryMock();
            } 
#endif

            return new BooksRepository();
        }
    }
}
