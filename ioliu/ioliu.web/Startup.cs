using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ioliu.data;
using ioliu.domain;
using ioliu.web.Auth;
using ioliu.web.Hubs;
using ioliu.web.Sercers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ioliu.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options=>
            {
                options.EnableEndpointRouting = false;
            }
                );
            #region SignalRCore
            services.AddSignalRCore();
            services.AddSingleton<CountService>();
            #endregion
            services.AddRazorPages();
            
            services.AddDbContext<IoliuContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MSSQL"));
            });

            services.AddScoped<ISystemUserServers<SystemUser>, InSystemUserRepository>();
            services.AddScoped<IWorkServers<Work>, InWorkRepository>();
            services.AddScoped<IImgServers<Img>,InImgRepository>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("仅限管理员", policy => policy.RequireRole("Administrators"));
                options.AddPolicy("编辑信息", policy => policy.RequireClaim("Edit Albums", new List<string> { "123", "456" }));
                options.AddPolicy("编辑信息2", policy => policy.AddRequirements(
                   
                    new QualifiedUserRequirement()
                     ));
           
                });
            services.AddSingleton<IAuthorizationHandler, EmailHandler>();
            services.AddSingleton<IAuthorizationHandler,AdministratorsHandler>();
            services.AddSingleton<IAuthorizationHandler, CanEditAlbumHandler>();

            services.AddDbContext<ApplicationDbContext>(options =>  options.UseSqlServer(Configuration.GetConnectionString("MSSQL"), b => b.MigrationsAssembly("ioliu.data"))) ;

            services.AddIdentity<SystemUser,IdentityRole>(Options =>
            {
                Options.Password.RequireDigit = false;
                Options.Password.RequiredLength = 1;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath="/node_modules",
                FileProvider=new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules"))
            });
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseAuthentication();
            app.UseMvc(route =>
            {
                
                route.MapRoute(
                    name:"default",
                    template: "{controller=Home}/{action=index_v1}/{id?}"
                    );
                
               
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHub<CountHub>("/counthub");
            //});

            

           
        }
    }
}
