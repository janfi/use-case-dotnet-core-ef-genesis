using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rest_api.business;
using rest_api.dal;
using rest_api.Filters;
using rest_api.Filters.Models;
using rest_api.ibusiness;
using rest_api.idal;
using rest_api.models;

namespace rest_api
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
            //
            // DB Context
            //
            services.AddDbContext<DbCtx>(options => options.UseSqlite("Data Source=blog.db", b => b.MigrationsAssembly("rest-api")));

            //
            // DAL
            //
            services.AddScoped<IEntrepriseDAL, EntrepriseDAL>();
            services.AddScoped<IContactDAL, ContactDAL>();

            //
            // BL
            //
            services.AddScoped<IEntrepriseBL, EntrepriseBL>();
            services.AddScoped<IContactBL, ContactBL>();

            //
            //MVC
            //
            services.AddMvc(
               config => {
                   config.Filters.Add(typeof(GlobalExceptionFilter));
                   config.Filters.Add(typeof(FormatResultFilter));
                   
               }
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var message = String.Join(", ", context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList());
                   
                    var result = new MsgException
                    {
                        status = System.Net.HttpStatusCode.BadRequest,

                        message = message,

                        code = 00009,

                        type = "Validation errors",
                    };

                    return new ObjectResult(new MsgResult { exception = result });
                };
            });
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
