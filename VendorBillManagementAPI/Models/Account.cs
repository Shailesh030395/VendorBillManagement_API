namespace VendorBillManagementAPI.Models
{
    public enum AccountType
    {
        Asset,
        Liability,
        Expense
    }

    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public decimal Balance { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
