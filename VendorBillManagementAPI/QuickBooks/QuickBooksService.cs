using Microsoft.Extensions.Options;
using VendorBillManagementAPI.Models;

public class QuickBooksService
{
    private readonly QuickBooksSettings _settings;

    public QuickBooksService(IOptions<QuickBooksSettings> options)
    {
        _settings = options.Value;
    }

    public void Authenticate()
    {
        // Use _settings.ClientId, _settings.ClientSecret, etc.
    }
}
