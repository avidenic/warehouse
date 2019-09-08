using NiceLabel.Demo.Client.Events;

namespace NiceLabel.Demo.Client.Pages
{
    public interface ILoginPage
    {
        event LoginEventHandler OnLoginSuccess;
    }
}