using AhmedRabieRegistrationApp.Application.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Application.Commands
{
    public class VerifyOtpCommand :IRequest<bool>
    {
        public int CustomerId { get; set; }
        public string OTP { get; set; }
        public VerificationType VerificationType { get; set; }

        public static void Validate(VerifyOtpCommand verifyOtpCommand)
        {
            var errors = new List<string>();
            if (verifyOtpCommand.CustomerId <=0)
            {
                errors.Add("invalid Customer Id");
            }
            if (string.IsNullOrEmpty(verifyOtpCommand.OTP))
            {
                errors.Add("OTP Cann't Be Null or Empty");
            }

            if (verifyOtpCommand.OTP.Length !=4)
            {
                errors.Add("invalid OTP !");
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
    public enum VerificationType
    {
        Email,
        MobileNumber
    }
}
