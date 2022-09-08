
using Microsoft.AspNetCore.Builder;

namespace ProjectAcronym.DomainName.ServiceHost
{
    public static class Program
    {
        private const ushort httpPortNumber = 40080;
        private const ushort httpsPortNumber = 40443;

        public static void Main(string[] args)
        {
            var baseUrls = new[] {
                $"http://*:{httpPortNumber}",
                $"https://*:{httpsPortNumber}"
            };

            WebApplication.CreateBuilder(args)
                .AddServices(baseUrls)
                .Build()
                .AddMiddleware()
                .Run();
        }
    }
}