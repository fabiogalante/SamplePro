using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePro.Models
{
    public class AppsContext:DbContext
    {
        public AppsContext(DbContextOptions<AppsContext> options):base(options)
        {

        }

        public DbSet<Post> Post { get; set; }

        public DbSet<Category> Category { get; set; }


    }
}
