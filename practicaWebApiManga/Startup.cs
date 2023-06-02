using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace practicaWebApiManga
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Esto es para evitar los clicos y las serializaciones ciclicas NOTA en este caso no las usamos porque estamos usando los DTOs
            //services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).AddNewtonsoftJson();
            //services.AddControllers()
            //   .AddNewtonsoftJson(options =>
            //   {
            //       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //   });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            
            services.AddControllers();
            services.AddResponseCaching();

           

           
            // c.SwaggerDoc("v1",  esta primera parte esta "v1" lo que esta haciendo es estableciendo el nombre de la version de nuestra api
            // eso tiene que ser unico haci evitamos errores en un futuro
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",

                /*new OpenApiInfo 
            
                    { Title = "aaaaa", Version = "v1" });  en esta parte ya lo qye estamos haciendo es agregandole informacion extra
                    tambien aqui Title = "aaaaa" esta parte lo que esta haciendo es cambiarle el nombre en la interface(esto es de la parte estetica)
                     Version = "v1" y esta parte tambien es de la interface(tambien es de la parte extetica) esa "v1" no tiene que coinsider exactamente con la "v1"
                    que tenemos mas arriba 
                 */
                new OpenApiInfo

                { Title = "Swagger Manga", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
               

            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApia v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpints =>
            {
                endpints.MapControllers();
            });


        }

    }
}
