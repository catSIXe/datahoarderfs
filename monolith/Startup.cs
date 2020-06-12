using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Authentication.Cookies;

namespace monolith
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
            });

            services.AddAuthorization();

            services.AddGrpc();
            services.AddSingleton(new monolith.PostgresProvider("Host=10.13.37.81;Username=datahoarderfs;Password=datahoarderfs;Database=datahoarderfs"));
            services.AddSingleton<monolith.Server.NodeRegistry>();
            services.AddSingleton<monolith.Server.FileRegistry>();


            /*services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtBearerOptions => {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    // ValidIssuer = "http://localhost:5001",
                    // ValidAudience = "http://localhost:5001",
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("JustStaticTextIsFine xD"))
                };
            });*/
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();

            // Cookie Policy Middleware enables cookie policy capabilities. 
            // Adding the middleware to the app processing pipeline is order sensitive—it only affects downstream components registered in the pipeline.
            app.UseCookiePolicy(new CookiePolicyOptions {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<NodeRegistryService>();
                endpoints.MapGrpcService<FileRegistryService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
