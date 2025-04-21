namespace VendorBillManagementAPI.Models
{
    public class BillLineItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public int BillId { get; set; }
    
    }
}
