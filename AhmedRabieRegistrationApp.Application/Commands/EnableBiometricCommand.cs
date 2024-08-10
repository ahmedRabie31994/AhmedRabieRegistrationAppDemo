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
    public class EnableBiometricCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public static void Validate(EnableBiometricCommand enableBiometricCommand)
        {
            var errors = new List<string>();
            if (enableBiometricCommand.CustomerId <= 0)
            {
                throw new ValidationException("Invalid Customer Id !");
            }  
        }
    }
}
