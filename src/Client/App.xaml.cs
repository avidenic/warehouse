using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NiceLabel.Demo.Client.Extensions;
using NiceLabel.Demo.Client.Pages;
using NiceLabel.Demo.Client.Services;
using NiceLabel.Demo.Client.ViewModels;
using System;
using System.IO;
using System.Windows;

namespace NiceLabel.Demo.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile($"appsettings.json", optional: false)
                           .Build();

            ConfigureServices(_serviceCollection, config);
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }

        private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IAuthenticationService, AuthenticationService>();
            services.AddHttpClient<IWarehouseService, WarehouseService>();
            services.AddTransient<ILoginPageViewModel, LoginPageViewModel>();
            services.AddTransient<IProductIncreaseViewModel, ProductIncreaseViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<ILoginPage, LoginPage>();
            services.AddTransient<IProductIncreasePage, ProductIncreasePage>();
            services.AddConfigurations(configuration);
        }
    }
}
