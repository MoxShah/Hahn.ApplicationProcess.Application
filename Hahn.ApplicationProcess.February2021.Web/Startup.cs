namespace WebApplication1
{
    using System.IO;
    using FluentValidation.AspNetCore;
    using Hahn.ApplicationProcess.February2021.Data;
    using Hahn.ApplicationProcess.February2021.Data.Implementation;
    using Hahn.ApplicationProcess.February2021.Data.Interfaces;
    using Hahn.ApplicationProcess.February2021.Domain.BusinessImplementation;
    using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
    using Hahn.ApplicationProcess.February2021.Domain.Validators;
    using Hahn.ApplicationProcess.February2021.Web.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Start up
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:8080")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                                  });
            });
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var host = new WebHostBuilder().UseConfiguration(config).UseKestrel().UseStartup<Startup>().ConfigureLogging((ctx, builder) => {
                builder.AddFilter("Microsoft", LogLevel.Information);
                builder.AddFilter("System", LogLevel.Error);
            }); ;
            
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AssetValidator>());
            services.AddDbContext<HahnDatabaseContext>(options => options.UseInMemoryDatabase(databaseName: "HahnDB"));
            services.AddTransient<IAssetBusinessInformation, AssetBusinessImplementation>();
            services.AddTransient<IAssetInformation, AssetInformation>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICountryValidator, ValidateCountry>();
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Hahn.ApplicationProcess.February2021.Domain.xml");
                c.IncludeXmlComments(filePath);
                filePath = Path.Combine(System.AppContext.BaseDirectory, "Hahn.ApplicationProcess.February2021.web.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn ApplicationProcess February2021 Web");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseMiddleware<LogMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
