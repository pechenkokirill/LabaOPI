using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LabaOPI.Services
{
    public interface IServiceConfigurator
    {
        void ConfigureServices(HostBuilderContext context,IServiceCollection services);
    }
}
