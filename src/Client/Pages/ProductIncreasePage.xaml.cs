using NiceLabel.Demo.Client.ViewModels;
using NiceLabel.Demo.Common.Models;
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

        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            ViewModel.Token = e.ExtraData as Token;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.LoadCompleted += NavigationService_LoadCompleted;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!await ViewModel.IncreaseQuantity())
            {

            }
            else
            {

            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ViewModel.IsValidQuantityInput(e.Text);
        }

        private void TextBox_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.Handled = e.Command == ApplicationCommands.Paste;
        }
    }
}
