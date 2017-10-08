using System.Web.Http;
using WebActivatorEx;
using QAFoodBank.MobileAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace QAFoodBank.MobileAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                        c.SingleApiVersion("v1", "QAFoodBank.MobileAPI");

                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
