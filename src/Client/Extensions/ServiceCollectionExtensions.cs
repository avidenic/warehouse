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
        private static T AddConfiguration<T>(this IServiceCollection services, IConfiguration config, string configSestionName = null) where T : class, new()
        {
            var type = typeof(T);
            if (string.IsNullOrEmpty(configSestionName))
            {
                configSestionName = type.Name;
            }
            var option = Activator.CreateInstance(type) as T;
            config.GetSection(configSestionName).Bind(option, o => o.BindNonPublicProperties = true);

            services.AddSingleton<T>(option);

            return option;
        }
    }
}
