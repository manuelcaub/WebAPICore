namespace WebAPICore
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using AutoMapper;
    using WebAPICore.Data;
    using WebAPICore.Data.Repositories;
    using WebAPICore.Service;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            using (var client = new DataBaseContext())
            {
                client.Database.EnsureCreated();
            }
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<DataBaseContext>();

            // Add framework services.
            services.AddMvc().AddJsonOptions(jsonOptions => 
            {
                jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            var mapperConfiguration = new MapperConfiguration(cfg => // In Application_Start()
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();
            services.AddAutoMapper();

            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<DataBaseContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseWebSockets();
        }
    }
}
