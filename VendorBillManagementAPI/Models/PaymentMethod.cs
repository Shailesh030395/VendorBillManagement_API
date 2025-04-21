using System.Collections.Generic;

namespace VendorBillManagementAPI.Models
{
    public enum PaymentMethodType
    {
        CreditCard,
        BankAccount,
        ElectronicTransfer,
        OnlinePayment
    }

    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PaymentMethodType Type { get; set; }
        public string Details { get; set; }
        public bool IsDefault { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
