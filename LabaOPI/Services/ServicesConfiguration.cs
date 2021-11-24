using LabaOPI.Data;
using LabaOPI.Stores;
using LabaOPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LabaOPI.Services
{
    public class ServicesConfiguration : IServiceConfigurator
    {
        public void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            //DbContext
            string connectionString = context.Configuration.GetConnectionString("Sqlite");

            if(string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("ConnectionString was empty");
            }

            string path = Regex.Match(connectionString, @"Data Source\s*=\s*([\w/\.]+)").Groups[1].Value;
            string? directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            services.AddDbContext<DataContext>(op => op.UseSqlite(connectionString));
            //Services
            services.AddSingleton<IRepository<Book>, BooksRepository>();
            services.AddSingleton<IRepository<Person>, UsersRepository>();
            services.AddSingleton<IRepository<PersonBook>, BorrowedBooksRepository>();

            //Stores
            services.AddSingleton<SearchStore>();
            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<BooksViewModel>();
            services.AddTransient<UsersViewModel>();
            services.AddTransient<BorrowedBooksViewModel>();
        }
    }
}
