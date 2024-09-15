using Sealed.Application.Interfaces;
using Sealed.Application.Services;
using Sealed.Database;

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

            app.Run();
        }
    }
}