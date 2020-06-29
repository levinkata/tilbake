using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Exceptions
{
    public class DatabaseAccessException : Exception
    {
        public DatabaseAccessException(string message) : base(message)
        {
        }

        public DatabaseAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DatabaseAccessException()
        {
        }
    }
}
