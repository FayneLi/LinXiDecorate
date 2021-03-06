﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LinXiDecorate.Authorization.Roles;
using LinXiDecorate.Authorization.Users;
using LinXiDecorate.MultiTenancy;
using LinXiDecorate.Persons;

namespace LinXiDecorate.EntityFrameworkCore
{
    public class LinXiDecorateDbContext : AbpZeroDbContext<Tenant, Role, User, LinXiDecorateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LinXiDecorateDbContext(DbContextOptions<LinXiDecorateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
