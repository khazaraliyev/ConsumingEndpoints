using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMediapark.Domain.Entities;

namespace TaskMediapark.Persistence.SQL
{
    public class MediaparkDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Day> Days { get; set; }

        public MediaparkDbContext(DbContextOptions<MediaparkDbContext> options)
        : base(options)
        {

        }
    }
}
