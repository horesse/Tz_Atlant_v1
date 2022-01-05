using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TZ_ver2.Data.Models;

namespace TZ_ver2.Data
{
    public class AppDBcontent : DbContext
    {
        public AppDBcontent(DbContextOptions<AppDBcontent> options) : base(options)
        {

        }

        public DbSet<Details> Details { get; set; }
        public DbSet<Skeeper> Skeeper { get; set; }
    }
}
