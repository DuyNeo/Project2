using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models;
using Project2.Services;
namespace Project2
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
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ASM")));
            services.AddControllers();
            //services.AddControllersWithViews().AddNewtonsoftJson(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project2", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddTransient<INguoiDung, NguoiDungSvc>();
            services.AddTransient<IGiangVien, GiangVienSvc>();
            services.AddTransient<IDiem, DiemSvc>();
            services.AddTransient<IHocPhi, HocPhiSvc>();
            services.AddTransient<IKhoaHoc, KhoaHocSvc>();
            services.AddTransient<ILoaiDiem, LoaiDiemSvc>();
            services.AddTransient<ILopHoc, LopHocSvc>();
            services.AddTransient<IMonHoc, MonHocSvc>();
            services.AddTransient<IThoiKhoaBieu, ThoiKhoaBieuSvc>();
            services.AddTransient<IToBoMon, ToBoMonSvc>();
            services.AddTransient<IMaHoaHelper, MahoaHelper>();
            services.AddTransient<ILichNghi, LichNghiSvc>();
            services.AddTransient<ILuong, LuongSvc>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
