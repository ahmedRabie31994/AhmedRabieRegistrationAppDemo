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
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            RegisterCustomerCommand.Validate(request);
            var customer = new Customer
            {
                CustomerName = request.CustomerName,
                IcNumber = request.IcNumber,
                MobileNumber = request.MobileNumber,
                EmailAddress = request.EmailAddress,
                IsBiometricEnabled = false,
                IsEmailVerified = false,
                IsMobileVerified = false,
                AddedDate = DateTime.UtcNow,
            };

            var newCustomer = await _customerRepository.AddCustomerAsync(customer);
            return newCustomer;
        } 
    }
}