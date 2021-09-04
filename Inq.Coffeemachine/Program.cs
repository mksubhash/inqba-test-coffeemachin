using InQba.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Inq.Coffeemachine
{
    class Program
    {
        private static IServiceProvider container;
        static void Main(string[] args)
        {
            RegisterServices();
            DisposeServices();
        }

        /// <summary>
        /// Register the type to the DI container and set injection
        /// </summary>
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IMachineEventing, MachineEventing>();
            services.AddScoped<ILogger, ConsoleLogger>();
            services.AddScoped<IStockProcess, StockProcess>();
            services.AddScoped<IDrinkProcessor, DrinkProcessor>();
            services.AddSingleton<ConstantConfigValues>(); //This is supposed to be configured (config file/db)
            services.AddSingleton<StockBookContext>();
            services.AddScoped<IStockProcess, StockProcess>();
            services.AddScoped<IDrinkProcessor, DrinkProcessor>();
            services.AddScoped<IMenuOperation, MenuOperation>();
            services.AddScoped<BootstrapMachine>();
            container = services.BuildServiceProvider();
            container.GetService<BootstrapMachine>().Bootstrap();
        }
        /// <summary>
        /// Dispose and free up DI container
        /// </summary>
        private static void DisposeServices()
        {
            if (container == null)
            {
                return;
            }
            if (container is IDisposable)
            {
                ((IDisposable)container).Dispose();
            }
        }


    }
}
