using Microsoft.Extensions.DependencyInjection;
using NiceLabel.Demo.Client.Pages;
using NiceLabel.Demo.Client.Services;
using NiceLabel.Demo.Client.ViewModels;
using System;
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
            ConfigureServices(_serviceCollection);
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IAuthenticationService, AuthenticationService>();
            services.AddHttpClient<IWarehouseService, WarehouseService>();
            services.AddTransient<ILoginPageViewModel, LoginPageViewModel>();
            services.AddTransient<IProductIncreaseViewModel, ProductIncreaseViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<ILoginPage, LoginPage>();
            services.AddTransient<IProductIncreasePage, ProductIncreasePage>();
        }
    }
}
