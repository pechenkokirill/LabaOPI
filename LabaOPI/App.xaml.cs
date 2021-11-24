using LabaOPI.Data;
using LabaOPI.Services;
using LabaOPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace LabaOPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            IServiceConfigurator configurator = new ServicesConfiguration();

            host = Host.CreateDefaultBuilder()
                .ConfigureServices((h, s) => configurator.ConfigureServices(h, s))
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();

            host.Services.GetRequiredService<DataContext>().Database.Migrate();

            MainWindow = new MainWindow()
            {
                DataContext = host.Services.GetRequiredService<MainViewModel>()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.Dispose();

            base.OnExit(e);
        }
    }
}
