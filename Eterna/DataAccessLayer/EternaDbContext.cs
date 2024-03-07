﻿using Eterna.Models;
using Microsoft.EntityFrameworkCore;

namespace Eterna.DataAccessLayer
{
    public class EternaDbContext : DbContext
    {
        public EternaDbContext(DbContextOptions<EternaDbContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}