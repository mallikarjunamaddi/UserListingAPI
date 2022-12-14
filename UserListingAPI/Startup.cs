using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UserListingAPI.DataModel.DBContext;

namespace UserListingAPI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			// Register UserDBContext and Configure sqlserver, connection string thru options.
			services.AddDbContextPool<UserDBContext>(options =>
				     options.UseSqlServer(Configuration.GetConnectionString("UserDBConnection")));

			services.AddControllers();

			// Register Swagger 
			services.AddSwaggerGen(c =>
			   c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "User Listing API", Version = "V1" })
		   );

			// Registering the application specific services.
			Bootstrap.Register(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Add Swagger UI
			app.UseSwagger();
			app.UseSwaggerUI(c =>
				c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "User Listing API Version 1")
			);

			// Enabling Cors
			app.UseCors(x =>
				 x.AllowAnyOrigin()
				 .AllowAnyHeader()
				 .AllowAnyMethod()
			 );

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
