using CRUD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace CRUD
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD", Version = "v1" });
            });

            NotenService.ConnectionName = Configuration.GetConnectionString("ConnectionName");
            NotenService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            NotenService.CollectionNoten = Configuration.GetConnectionString("CollectionNoten");
            NotenService.JsonFile = Configuration.GetConnectionString("JsonFile");

            ChordService.ConnectionChord = Configuration.GetConnectionString("ConnectionChord");
            ChordService.ConnectionArtless = Configuration.GetConnectionString("ConnectionArtless");
            ChordService.ConnectionRecipe = Configuration.GetConnectionString("ConnectionRecipe");
            ChordService.DatabaseName = Configuration.GetConnectionString("DatabaseName");
            ChordService.CollectionChord = Configuration.GetConnectionString("CollectionChord");
            ChordService.JsonFile = Configuration.GetConnectionString("JsonFile");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
