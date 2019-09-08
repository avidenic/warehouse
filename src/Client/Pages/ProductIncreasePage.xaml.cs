using NiceLabel.Demo.Client.ViewModels;
using NiceLabel.Demo.Common.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace NiceLabel.Demo.Client.Pages
{
    /// <summary>
    /// Interaction logic for ProductIncreasePage.xaml
    /// </summary>
    public partial class ProductIncreasePage : Page, IProductIncreasePage
    {
        private IProductIncreaseViewModel ViewModel => DataContext as IProductIncreaseViewModel;
        public ProductIncreasePage(IProductIncreaseViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.IncreaseQuantity();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ViewModel.IsValidQuantityInput(e.Text);
        }

        private void TextBox_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = e.Command == ApplicationCommands.Paste;
        }

        public void SetToken(Token token)
        {
            ViewModel.Token = token;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => ViewModel.Message = string.Empty;
    }
}
