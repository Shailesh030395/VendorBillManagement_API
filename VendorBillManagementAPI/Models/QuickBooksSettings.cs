namespace VendorBillManagementAPI.Models
{
    public class QuickBooksSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrl { get; set; }
        public string BaseUrl { get; set; }
    }
}
