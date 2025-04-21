using System;
using System.Collections.Generic;

namespace VendorBillManagementAPI.Models
{
    public enum BillStatus
    {
        Due,
        Overdue,
        Paid
    }

    public class Bill
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public BillStatus Status { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int VendorId { get; set; }
        public string Vendor { get; set; }

        public string PaymentsType { get; set; }
    }
}
