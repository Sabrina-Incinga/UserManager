﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace UserManager.DataAccess;
public class UserManagerContext : DbContext
{
    public UserManagerContext()
    {
    }

    public UserManagerContext(DbContextOptions<UserManagerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        LoadConfigurations(modelBuilder);
    }

    private void LoadConfigurations(ModelBuilder builder)
    {
        var currentAssembly = Assembly.GetAssembly(GetType()) ?? throw new Exception("Unable to retrieve assembly");

        builder.ApplyConfigurationsFromAssembly(currentAssembly);
    }
}

