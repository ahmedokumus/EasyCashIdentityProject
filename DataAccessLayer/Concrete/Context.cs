﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class Context : IdentityDbContext<AppUser, AppRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;initial catalog=EasyCashDb; integrated Security=true");
    }

    public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
}