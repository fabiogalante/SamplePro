using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace SamplePro.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {
            
        }
      

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
