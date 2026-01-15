using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace GaraApp.DAL
{
    public static class DbContextFactory
    {
        public static GaraDbContext Create()
        {
            var conn = ConfigurationManager.ConnectionStrings["GaraDb"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(conn))
                throw new ConfigurationErrorsException("Missing connection string 'GaraDb' in App.config");

            var options = new DbContextOptionsBuilder<GaraDbContext>()
                .UseSqlServer(conn)
                .Options;

            return new GaraDbContext(options);
        }
    }
}
