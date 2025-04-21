using System.Collections.Generic;

namespace VendorBillManagementAPI.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        
    }
}
