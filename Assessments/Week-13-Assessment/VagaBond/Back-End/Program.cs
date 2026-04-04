using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Back_End.Data;
using Back_End.Repositories;

namespace Back_End
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Back_EndContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Back_EndContext") ?? throw new InvalidOperationException("Connection string 'Back_EndContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
