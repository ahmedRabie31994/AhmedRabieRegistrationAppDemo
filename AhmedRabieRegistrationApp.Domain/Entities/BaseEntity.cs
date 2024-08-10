using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmedRabieRegistrationApp.Domain.Entities
{
    public  class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string? AddedByUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedByUserId { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
