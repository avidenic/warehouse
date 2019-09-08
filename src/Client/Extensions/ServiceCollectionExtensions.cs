using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NiceLabel.Demo.Client.Configuration;
using System;

namespace NiceLabel.Demo.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.AddConfiguration<Server>(config);
        }
        private static T AddConfiguration<T>(this IServiceCollection services, IConfiguration config) where T : class, new()
        {
            var type = typeof(T);           
            var option = Activator.CreateInstance(type) as T;
            config.GetSection(type.Name).Bind(option, o => o.BindNonPublicProperties = true);

            services.AddSingleton<T>(option);

            return option;
        }
    }
}
