namespace NiceLabel.Demo.Common.Models
{
    public class Token
    {
        public Token() { }

        public Token(string token, string username)
        {
            Value = token;
            Username = username;
        }
        public string Value { get; set; }

        public string Username { get; set; }
    }
}
