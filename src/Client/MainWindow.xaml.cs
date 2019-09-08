using NiceLabel.Demo.Client.Events;
using NiceLabel.Demo.Client.Pages;
using System;
using System.ComponentModel;
using System.Windows;

namespace NiceLabel.Demo.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILoginPage _loginPage;
        private readonly IProductIncreasePage _productIncreasePage;
        public MainWindow(ILoginPage loginPage, IProductIncreasePage productIncreasePage)
        {
            _loginPage = loginPage;
            _productIncreasePage = productIncreasePage;
            _loginPage.OnLoginSuccess += OnLoginSuccess;
            InitializeComponent();
        }

        private void OnLoginSuccess(object sender, LoginEventArgs args)
        {
            _productIncreasePage.SetToken(args.Token);
            _frame.Navigate(_productIncreasePage);
        }

        protected override void OnInitialized(EventArgs e)
        {
            _frame.Navigate(_loginPage);
            base.OnInitialized(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // cleanup
            _loginPage.OnLoginSuccess -= OnLoginSuccess;
            base.OnClosing(e);
        }
    }
}
