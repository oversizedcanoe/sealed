using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using Sealed.Application.Interfaces;
using Sealed.Application.Services;
using Sealed.Database;
using System.Threading.RateLimiting;

namespace Sealed.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("development", builder =>
                {
                    // Todo 
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<DatabaseContext>();
            builder.Services.AddScoped<DatabaseContext>();

            builder.Services.AddScoped<IKeyService, KeyService>();
            builder.Services.AddScoped<IUserEntryService, UserEntryService>();

            builder.Services.AddRateLimiter(options =>
            {

                options.OnRejected = (context, cancellationToken) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    return new ValueTask();
                };

                options.AddPolicy("IPAddressFixedWindowPolicy", context =>
                {
                    string ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "";
                    string partitionKey = ipAddress + context.Request.Path;

                    // User can hit a specific endpoint 10 tiems
                    return RateLimitPartition.GetFixedWindowLimiter(partitionKey: partitionKey,
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 10,
                            QueueLimit = 0,
                            Window = TimeSpan.FromHours(24)
                        });
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("development");

            app.MapControllers();
            
            app.UseRateLimiter();

            app.Run();
        }
    }
}