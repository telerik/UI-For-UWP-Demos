using System;
using System.Linq;

namespace QSF.Infrastructure.Exceptions
{
    public class ExampleNotLoadedException : Exception
    {
        public ExampleNotLoadedException() : base()
        {
        }

        public ExampleNotLoadedException(string message) : base(message)
        {
        }

        public ExampleNotLoadedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}