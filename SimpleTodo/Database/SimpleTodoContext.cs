using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SimpleTodo.Models;
using Microsoft.Extensions.Configuration;

namespace SimpleTodo.Database
{
    public class SimpleTodoContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<Todo> Todos;
        public DbSet<Project> Projects;

        public SimpleTodoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("TodoDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Todos)
                .HasForeignKey(t => t.ProjectID);
        }
    }
}
