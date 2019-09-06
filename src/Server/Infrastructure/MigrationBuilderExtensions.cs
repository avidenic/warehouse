using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace NiceLabel.Demo.Server.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed<T>(this ModelBuilder builder, int count) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var data = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var instance = Activator.CreateInstance(type) as T;
                foreach (var prop in properties)
                {
                    switch (prop)
                    {
                        case var password when Attribute.IsDefined(prop, typeof(PasswordAttribute)):
                            prop.SetValue(instance, $"{prop.Name}{i}".Hash());
                            break;
                        case var text when text.PropertyType == typeof(string):
                            prop.SetValue(instance, $"{prop.Name}{i}");
                            break;
                        case var number when number.PropertyType == typeof(long):
                            prop.SetValue(instance, Convert.ToInt64(i));
                            break;
                    }
                }
                data.Add(instance);
            }

            builder.Entity<T>().HasData(data.ToArray());
        }
    }
}