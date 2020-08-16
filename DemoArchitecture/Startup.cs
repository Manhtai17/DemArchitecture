using DemoArchitecture.BL;
using DemoArchitecture.BL.Interfaces;
using DemoArchitecture.DL.Database;
using DemoArchitecture.DL.MongoSetting;
using DemoArchitecture.DL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DemoArchitecture
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

			services.AddDbContext<MariaDbContext>(options => options
				.UseMySQL(Configuration.GetSection("MariaDB").GetValue<string>("ConnectionString").ToString()));


			//Bơm từ app setting to class
			services.Configure<MongoSettings>(Configuration.GetSection("MongoDB"));
			//Bơm từ class vào Interface
			services.AddTransient<IDatabaseSetting>(sp =>
				sp.GetRequiredService<IOptions<MongoSettings>>().Value);

			services.AddSingleton<MongoDbContext>();

			services.AddScoped(typeof(IDbContext<>), typeof(MariaConnector<>));
			services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
			services.AddTransient(typeof(IBaseBL<>), typeof(BaseBL<>));

			services.AddControllersWithViews();
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
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
