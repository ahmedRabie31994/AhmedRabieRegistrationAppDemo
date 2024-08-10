using AhmedRabieRegistrationApp.Application.Commands;
using AhmedRabieRegistrationApp.Domain.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Application.CommandHandlers
{
    public  class EnableBiometricCommandHandler : IRequestHandler<EnableBiometricCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

    public EnableBiometricCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(EnableBiometricCommand request, CancellationToken cancellationToken)
    {
            EnableBiometricCommand.Validate(request);
        var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);
        if (customer == null)
        {
            throw new Exception($"no customer found with id {request.CustomerId} ");
        }
        bool result = false;

        result = await _customerRepository.EnableBiometric(request.CustomerId); 
        return result;
    }
}
}
