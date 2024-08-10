using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Infrastructure.Context
{
    internal class RegistrationAppDbContextFactory : IDesignTimeDbContextFactory<RegistrationAppDbContext>
    {
        public RegistrationAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RegistrationAppDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-ARDMBL0;Database=AhmedRabieRegistrationDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new RegistrationAppDbContext(optionsBuilder.Options);
        }
    }
}