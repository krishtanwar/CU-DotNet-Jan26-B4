using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Car_Management_MVC_Application.Models;

namespace Car_Management_MVC_Application.Data
{
    public class Car_Management_MVC_ApplicationContext : DbContext
    {
        public Car_Management_MVC_ApplicationContext (DbContextOptions<Car_Management_MVC_ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Car_Management_MVC_Application.Models.Car> Car { get; set; } = default!;
    }
}
