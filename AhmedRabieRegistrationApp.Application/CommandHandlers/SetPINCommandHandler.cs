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
    public class SetPINCommandHandler : IRequestHandler<SetPinCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public SetPINCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(SetPinCommand request, CancellationToken cancellationToken)
        {
            SetPinCommand.Validate(request);
            var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new Exception($"no customer found with id {request.CustomerId} ");
            }
            bool result = false;

            result = await _customerRepository.UpdateCustomerPinAsync(request.CustomerId,request.Pin);


            return result;
        }
    }
}
