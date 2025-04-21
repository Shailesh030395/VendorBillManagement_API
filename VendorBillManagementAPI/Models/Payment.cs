using System;

namespace VendorBillManagementAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string BillReference { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int? BillId { get; set; }
        public Bill Bill { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int PaymentMethodId { get; set; }
   
    }
}
