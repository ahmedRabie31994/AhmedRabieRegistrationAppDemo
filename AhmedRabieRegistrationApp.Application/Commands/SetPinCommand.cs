using AhmedRabieRegistrationApp.Application.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Application.Commands
{
    public class SetPinCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public string Pin { get; set; }
        public static void Validate(SetPinCommand verifyOtpCommand)
        {
            var errors = new List<string>();
            if (verifyOtpCommand.CustomerId <= 0)
            {
                errors.Add("invalid Customer Id");
            }
            if (string.IsNullOrEmpty(verifyOtpCommand.Pin))
            {
                errors.Add("OTP Cann't Be Null or Empty");
            }

            if (verifyOtpCommand.Pin.Length != 6)
            {
                errors.Add("invalid PIN !");
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
