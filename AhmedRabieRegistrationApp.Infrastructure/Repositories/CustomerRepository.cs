using AhmedRabieRegistrationApp.Domain.Entities;
using AhmedRabieRegistrationApp.Domain.Repositories.Interfaces;
using AhmedRabieRegistrationApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RegistrationAppDbContext _context;

        public CustomerRepository(RegistrationAppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<bool> VerifyEmailAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.IsEmailVerified = true;
                customer.UpdatedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> VerifyMobileAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.IsMobileVerified = true;
                customer.UpdatedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> EnableBiometric(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.IsBiometricEnabled = true;
                customer.UpdatedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateCustomerPinAsync(int customerId, string pin)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null && customer.IsEmailVerified && customer.IsMobileVerified)
            {
                customer.Pin = pin;
                customer.UpdatedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
