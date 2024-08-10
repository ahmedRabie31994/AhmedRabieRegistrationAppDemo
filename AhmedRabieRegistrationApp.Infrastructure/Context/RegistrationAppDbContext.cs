using AhmedRabieRegistrationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Infrastructure.Context
{
    public class RegistrationAppDbContext : DbContext
    {
        public RegistrationAppDbContext(DbContextOptions<RegistrationAppDbContext> options) : base(options)
        {
        } 
        public RegistrationAppDbContext()
        {
            
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IcNumber).IsRequired().HasMaxLength(12);
                entity.Property(e => e.MobileNumber).IsRequired().HasMaxLength(15);
                entity.Property(e => e.EmailAddress).IsRequired().HasMaxLength(50); 
                
            });
        }
    }
}