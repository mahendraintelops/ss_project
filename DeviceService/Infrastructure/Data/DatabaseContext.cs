﻿using Microsoft.EntityFrameworkCore;
using Core.Common;
using Core.Entities;


namespace Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    
        public DbSet<Device> Device { get; set; }
    
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {           
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
