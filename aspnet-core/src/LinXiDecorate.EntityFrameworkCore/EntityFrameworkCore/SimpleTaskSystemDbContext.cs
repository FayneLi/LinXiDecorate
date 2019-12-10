using Abp.EntityFrameworkCore;
using LinXiDecorate.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinXiDecorate.EntityFrameworkCore
{
    public class SimpleTaskSystemDbContext : AbpDbContext
    {
        public virtual ISet<Person> People { get; set; }

        public SimpleTaskSystemDbContext(DbContextOptions<LinXiDecorateDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().ToTable("StsPeople");
        }
    }
}
