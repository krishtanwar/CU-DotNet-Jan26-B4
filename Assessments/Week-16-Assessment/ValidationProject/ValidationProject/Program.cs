using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ValidationProject.Data;
using ValidationProject.DTOs;
using ValidationProject.Repositories;
using ValidationProject.Services;
using ValidationProject.Validators;

namespace ValidationProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ValidationProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ValidationProjectContext") ?? throw new InvalidOperationException("Connection string 'ValidationProjectContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<ICourseService, CourseService>();

            // Add FluentValidation
            builder.Services.AddScoped<IValidator<CreateCourseDto>, CreateValidator>();
            
            builder.Services.AddScoped<IValidator<UpdateDto>, UpdateValidator>();

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
