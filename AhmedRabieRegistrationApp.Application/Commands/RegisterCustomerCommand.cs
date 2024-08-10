using AhmedRabieRegistrationApp.Application.Extensions;
using AhmedRabieRegistrationApp.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AhmedRabieRegistrationApp.Application.Commands
{
    public class RegisterCustomerCommand : IRequest<Customer>
    {
        public string CustomerName { get; set; }
        public string IcNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; } 

        public static void Validate(RegisterCustomerCommand registerCustomerCommand)
        {
            var errors = new List<string>();
            if (registerCustomerCommand == null)
            {
                throw new ArgumentNullException(nameof(registerCustomerCommand));   
            }
            if (string.IsNullOrEmpty(registerCustomerCommand.CustomerName))
            {
                errors.Add("Customer Name Cann't be null or empty");
            }
            if (string.IsNullOrEmpty(registerCustomerCommand.IcNumber))
            {
                errors.Add("IcNumber Cann't be null or empty");
            }

            if (string.IsNullOrEmpty(registerCustomerCommand.EmailAddress))
            {
                errors.Add("Email Address Cann't be null or empty");
            }
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(registerCustomerCommand.EmailAddress, emailPattern))
            {
                errors.Add("Not Valid Email Format");
            }
            if (errors.Any())
            {
                if (errors.Count() > 1)
                    throw new CustomListException(errors);
                else
                    throw new ValidationException(errors.First());
            }
        }
        
    }
}