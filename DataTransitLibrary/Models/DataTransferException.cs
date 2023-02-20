using System;
namespace DataTransitLibrary.Models
{
    public class DataTransferException : Exception
    {
        public DataTransferException()
        {
        }

        public DataTransferException(string message)
            : base(message)
        {
        }

        public DataTransferException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

