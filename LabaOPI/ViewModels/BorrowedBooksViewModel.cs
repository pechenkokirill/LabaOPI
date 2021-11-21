﻿using LabaOPI.Services;
using LabaOPI.Services.Mock;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LabaOPI.ViewModels
{
    public class BorrowedBooksViewModel : CollectionTabBaseViewModel<PersonBook>
    {
        protected override IRepository<PersonBook> OnConfigureRepository(bool isDesignTime)
        {
#if DEBUG
            if (isDesignTime)
            {
                return new BorrowedBooksRepositoryMock();
            } 
#endif

            return new BorrowedBooksRepository();
        }
    }
}
