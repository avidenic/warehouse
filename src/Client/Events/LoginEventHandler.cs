using NiceLabel.Demo.Common.Models;
using System;

namespace NiceLabel.Demo.Client.Events
{
    public delegate void LoginEventHandler(object sender, LoginEventArgs args);

    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(Token token)
        {
            Token = token;
        }
        public Token Token { get; }
    }
}
