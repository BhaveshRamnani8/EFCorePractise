using EFCorePractise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractise.Manager
{
    internal class ContextManager : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Country{ get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TGS142\SQLEXPRESS;Database=EFCoreDbFinal;Trusted_Connection=true; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }        
    }
}
