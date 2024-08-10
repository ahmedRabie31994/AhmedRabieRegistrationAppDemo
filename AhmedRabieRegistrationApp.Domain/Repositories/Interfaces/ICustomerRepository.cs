using AhmedRabieRegistrationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Domain.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<bool> VerifyEmailAsync(int customerId);
        Task<bool> VerifyMobileAsync(int customerId);
        Task<bool> UpdateCustomerPinAsync(int customerId, string pin);
        Task UpdateCustomerAsync(Customer customer);
        Task<bool> EnableBiometric(int customerId);
    }
}
