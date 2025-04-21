using Context;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QuickBooksIntegration.Models;
using System;
using System.Threading.Tasks;
using VendorBillManagementAPI.Models;

namespace QuickBooksIntegration.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly QuickBooksSettings _settings;
        private readonly ILogger<ConnectionService> _logger;
        private readonly AppDbContext _dbContext;

        public ConnectionService(IOptions<QuickBooksSettings> options, ILogger<ConnectionService> logger, AppDbContext dbContext)
        {
            _settings = options.Value;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task SaveQuickBooksAuthDetails(string accessToken, string refreshToken, string realmId)
        {
            try
            {
                var connection = new VendorBillManagementAPI.Models.Connections
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    RealmId = realmId
                  
                };

                _dbContext.Connections.Add(connection);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving QuickBooks authentication details.");
                throw;
            }
        }
    }
}
