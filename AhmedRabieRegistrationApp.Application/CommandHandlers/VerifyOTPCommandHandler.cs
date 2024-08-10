using AhmedRabieRegistrationApp.Application.Commands;
using AhmedRabieRegistrationApp.Domain.Entities;
using AhmedRabieRegistrationApp.Domain.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Application.CommandHandlers
{
    public class VerifyOTPCommandHandler : IRequestHandler<VerifyOtpCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public VerifyOTPCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            VerifyOtpCommand.Validate(request);
            var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new Exception($"no customer found with id {request.CustomerId} ");
            }
            bool result = false;
            if (request.VerificationType == VerificationType.Email)
            {
                result = await _customerRepository.VerifyEmailAsync(request.CustomerId);
            }
            else if (request.VerificationType == VerificationType.MobileNumber)
            { 
                result = await _customerRepository.VerifyMobileAsync(request.CustomerId);
            }

            return result; 
        }
    }
}