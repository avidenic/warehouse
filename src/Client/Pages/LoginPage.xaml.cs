using NiceLabel.Demo.Client.Events;
using NiceLabel.Demo.Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace NiceLabel.Demo.Client.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginPage : Page, ILoginPage
    {
        public ILoginPageViewModel ViewModel => DataContext as ILoginPageViewModel;

        public event LoginEventHandler OnLoginSuccess;

        public LoginPage(ILoginPageViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (await ViewModel.Login(Password.Password))
            {
                OnLoginSuccess?.Invoke(this, new LoginEventArgs(ViewModel.Token));
            }
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.Message = string.Empty;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => ViewModel.Message = string.Empty;
    }
}
