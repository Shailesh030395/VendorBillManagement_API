using System;
using System.Collections.Generic;

namespace VendorBillManagementAPI.Models
{
    public class Connections
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealmId { get; set; }
        public DateTime? LastSync { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
      
    }
}
