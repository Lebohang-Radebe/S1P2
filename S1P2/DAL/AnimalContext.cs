using Microsoft.EntityFrameworkCore;
using S1P2.BL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1P2.DAL
{
    public class AnimalContext : DbContext
    {
        public DbSet<Cow> Cows { get; set; }
        public DbSet<Chicken> Chickens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=Animals.db");
        }
    }

}
