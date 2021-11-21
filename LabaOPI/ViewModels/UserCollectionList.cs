using LabaOPI.Services;
using LabaOPI.Services.Mock;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace LabaOPI.ViewModels
{
    public class UserCollectionList
    {
        public IEnumerable<Person> Users { get; set; }
        private IRepository<Person> userRepository;
        public UserCollectionList()
        {
            if (Application.Current.IsDesignTime())
            {
                this.userRepository = new UsersRepositoryMock();
            }
            else
            {
                this.userRepository = new UsersRepository();
            }

            Users = new ObservableCollection<Person>(userRepository.GetAll());
        }
    }
}
