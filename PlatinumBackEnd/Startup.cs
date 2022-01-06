using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PE.BLL.Logic;
using PE.DAL.Data;
using PE.DAL.Interfaces;
using PE.DAL.Repositories;
using PE.DAL.Repository;

namespace PlatinumBackEnd
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

            services.AddControllers();
            services.AddCors(o => o.AddPolicy("CentralPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatinumBackEnd", Version = "v1" });
            });

            // services.AddScoped<IMerchantHelper, MerchantHelper>();
            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            services.AddScoped<IBankDetailRepository, BankDetailRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICoverSheetRepository, CoverSheetRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped< IBankDetailBLL, BankDetailBLL>();
            services.AddScoped<ICompanyBLL, CompanyBLL>();
            services.AddScoped<ICoverSheetBLL, CoverSheetBLL>();
            services.AddScoped<IDepartmentBLL, DepartmentBLL>();
            services.AddScoped<IEmployeeBLL, EmployeeBLL>();
            services.AddScoped<IInvoiceBLL, InvoiceBLL>();
            services.AddScoped<ISupplierBLL, SupplierBLL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatinumBackEnd v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("CentralPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
