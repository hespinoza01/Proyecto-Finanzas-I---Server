using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Financecalc_Server.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Financecalc_Server.Models;
using Financecalc_Server.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Financecalc_Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FinancecalcDBContext>(
                options => options.UseNpgsql(this.Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.Use(async (context, next) =>
            {
                if (!context.Request.Path.Equals("/api/acceso/acceder"))
                {
                    if (context.Request.Headers.ContainsKey("Authorization") &&
                        context.Request.Headers.ContainsKey("User"))
                    {
                        string auth = context.Request.Headers["Authorization"];
                        string usr = context.Request.Headers["User"];

                        IServiceScope scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                        FinancecalcDBContext _db = scope.ServiceProvider.GetService<FinancecalcDBContext>();

                        Usuario _user = _db.Usuario.Find(new Guid(usr));

                        UserToken _realTkn = new UserToken(_user);

                        if (!auth.Equals(_realTkn._token))
                        {
                            context.Abort();
                        }
                    }
                    else
                    {
                        context.Abort();
                    }
                }

                await next.Invoke();
            });
            app.UseMvc();

            // Initialization of tables values
            new InitValues(app.ApplicationServices)
                .ClasificacionValues()
                .SubclasificacionValues();
        }
    }
}