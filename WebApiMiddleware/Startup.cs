using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
//using System.Net;
using WebApiMiddleware.Filtros;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApiExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

            services.AddMvc().AddXmlSerializerFormatters();   //Servicio de MVC sin filtro de excepción

            services.AddMvc(Options =>                          //Servicio de MVC con filtro de excepción
            {
                Options.Filters.Add(new FiltroExcepcion());
            }).AddXmlSerializerFormatters();
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
