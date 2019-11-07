using System;
using System.Threading.Tasks;
using TryingStuffOut.DependencyInjection;

namespace TryingStuffOut
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new DiServiceCollection();
            
            //services.RegisterSingleton<RandomGuidGenerator>();
            //services.RegisterTransient<RandomGuidGenerator>();

            
            services.RegisterTransient<ISomeService, SomeServiceOne>();
            services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
            services.RegisterSingleton<MainApp>();
            
            
            var container = services.GenerateContainer();

            var serviceFirst = container.GetService<ISomeService>();
            var serviceSecond = container.GetService<ISomeService>();
            
            var mainApp = container.GetService<MainApp>();

            serviceFirst.PrintSomething();
            serviceSecond.PrintSomething();

            //await mainApp.StartAsync();
        }
    }
}