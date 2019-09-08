using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NiceLabel.Demo.Server.Infrastructure;
using NiceLabel.Demo.Server.Services;
using System.Security.Claims;

namespace NiceLabel.Demo.Server
{
    public class Startup
    {
        private const string CorsPolicyName = "AllowCors";

        public Startup()
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var securityService = new SecurityService();
            services.AddSingleton<ISecurityService>(securityService);
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddAuthorization(p =>
            {
                p.AddPolicy(JwtBearerDefaults.AuthenticationScheme, o =>
                {
                    o.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    o.RequireClaim(ClaimTypes.Name);
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityService.SecurityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });

            services.AddCors(o =>
            {
                o.AddPolicy(CorsPolicyName, b =>
                {
                    b.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                });
            });

            services.AddDbContext<WarehouseContext>(o =>
            {
                o.UseSqlite("Data Source=warehouse.db");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsDocker())
            {
                app.UseDeveloperExceptionPage();
                using var scope = app.ApplicationServices.CreateScope();
                var context = scope.ServiceProvider.GetService<WarehouseContext>();
                context.Database.Migrate();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseRouting()
                .UseCors(CorsPolicyName)
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(o =>
                {
                    o.MapControllers();
                });
        }
    }
}
