using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Application.Extensions
{
    internal class CustomListException : Exception
    {
        public List<string> ErrorMessages { get; }

        public CustomListException(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public override string ToString()
        {
            return string.Join("; ", ErrorMessages);
        }
    }
}
