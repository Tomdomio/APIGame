using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
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
              services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<ILoaiRepository, LoaiRepository>();
            services.AddTransient<ILoaiBusiness, LoaiBusiness>();//một bên là interface, môt bên là class tương ứng
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<ISliderBusiness, SliderBusiness>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IDichVuRepository, DichVuRepository>();
            services.AddTransient<IDichVuBusiness, DichVuBusiness>();
            services.AddTransient<ITheCaoRepository, TheCaoRepository>();
            services.AddTransient<ITheCaoBusiness, TheCaoBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseApiMiddleware();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
