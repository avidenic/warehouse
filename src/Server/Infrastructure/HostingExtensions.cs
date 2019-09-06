using Microsoft.Extensions.Hosting;

namespace NiceLabel.Demo.Server.Infrastructure
{
    public static class HostingExtensions
    {
        public static bool IsDocker(this IHostEnvironment hostEnvironment)
        {
            return hostEnvironment.IsEnvironment("Docker");
        }
    }
}