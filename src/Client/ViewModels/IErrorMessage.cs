using System.Windows;

namespace NiceLabel.Demo.Client.ViewModels
{
    public interface IErrorMessage
    {
        string Message { get; set; }

        Visibility MessageVisibility { get; set; }
    }
}
