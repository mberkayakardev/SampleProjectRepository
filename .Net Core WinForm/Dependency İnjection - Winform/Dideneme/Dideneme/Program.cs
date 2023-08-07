using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Dideneme
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            Application.Run(new Form1());

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger, Logger>();

        }

        public static IServiceProvider ServiceProvider => _serviceProvider;
        private static IServiceProvider _serviceProvider;
    }
}