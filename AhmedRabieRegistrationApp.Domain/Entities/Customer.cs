using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public string IcNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? Pin { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsMobileVerified { get; set; }
        public bool IsBiometricEnabled { get; set; }
    }
}
