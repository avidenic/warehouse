using System;
using System.Collections.Generic;

namespace NiceLabel.Demo.Common.Exceptions
{
    [Serializable]
    public class BusinessLogicViolationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }

        public BusinessLogicViolationException() : base()
        {
            Errors = new Dictionary<string, string[]>();
        }

        public BusinessLogicViolationException(string message): base(message)
        {
            Errors = new Dictionary<string, string[]>
            {
                { "Error", new []{ message } }
            };
        }

        public BusinessLogicViolationException(string message, Exception inner): base(message, inner)
        {
            Errors = new Dictionary<string, string[]>
            {
                { "Exception", new []{ message, inner.Message } }
            };
        }

        public BusinessLogicViolationException(Dictionary<string, string[]> validationErrors) : base()
        {
            Errors = validationErrors;
        }
    }
}
