using System;
using System.Security.Cryptography;
using System.Text;

namespace NiceLabel.Demo.Server.Infrastructure
{
    public static class StringExtensions
    {
        public static string Hash(this string sensitiveValue)
        {
            if (string.IsNullOrEmpty(sensitiveValue ))
            {
                throw new ArgumentNullException(nameof(sensitiveValue));
            }

            using (var sha256 = SHA256.Create())
            {
                sha256.ComputeHash(Encoding.UTF8.GetBytes(sensitiveValue));
                return BitConverter.ToString(sha256.Hash).Replace("-", string.Empty);
            }
        }
    }
}