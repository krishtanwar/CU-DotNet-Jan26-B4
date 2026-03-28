
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrackingService.Data;
using TrackingService.Repositeries;
using TrackingService.Services;

namespace TrackingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TrackingServiceContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("TrackingServiceContext") ?? throw new InvalidOperationException("Connection string 'TrackingServiceContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();
            builder.Services.AddScoped<ITrackingService, TrackingServices>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidIssuer = "LogiTrack.Identity",
                 ValidAudience = "LogiTrack.Tracking",
                 IssuerSigningKey = new SymmetricSecurityKey(
                     Encoding.UTF8.GetBytes("A_Very_Long_And_Secure_Secret_Key_123456"))
             };
         });

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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
