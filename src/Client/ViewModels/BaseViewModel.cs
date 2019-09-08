using System.ComponentModel;
using System.Windows;

namespace NiceLabel.Demo.Client.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IErrorMessage
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                if (string.IsNullOrEmpty(_message))
                {
                    MessageVisibility = Visibility.Hidden;
                }
                else
                {
                    MessageVisibility = Visibility.Visible;
                }
                OnPropertyChanged(nameof(Message));
            }
        }

        private Visibility _messageVisibility;
        public Visibility MessageVisibility
        {
            get { return _messageVisibility; }
            set { _messageVisibility = value; OnPropertyChanged(nameof(MessageVisibility)); }
        }
    }
}
