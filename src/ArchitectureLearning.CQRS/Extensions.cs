using System.Linq;
using System.Text;
using System.Text.Json;
using ArchitectureLearning.CQRS.Persistence.DbContext;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArchitectureLearning.CQRS
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ArchitectureCqrsContext>(options =>
                    options.UseInMemoryDatabase(nameof(ArchitectureCqrsContext)));
            }
            else
            {
                services.AddDbContext<ArchitectureCqrsContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString(nameof(ArchitectureCqrsContext)),
                        b => b.MigrationsAssembly(typeof(ArchitectureCqrsContext).Assembly.FullName)));
            }

            return services;
        }

        // public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        // {
        //     app.UseExceptionHandler(x =>
        //     {
        //         x.Run(async context =>
        //         {
        //             var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
        //             var exception = errorFeature.Error;
        //
        //             if (!(exception is ValidationException validationException))
        //             {
        //                 throw exception;
        //             }
        //
        //             var errors = validationException.Errors.Select(err => new ValidationFailure(err.PropertyName, err.ErrorMessage));
        //             var errorText = JsonSerializer.Serialize(errors);
        //             context.Response.StatusCode = 400;
        //             context.Response.ContentType = "application/json";
        //             await context.Response.WriteAsync(errorText, Encoding.UTF8);
        //         });
        //     });
        // }
    }
}