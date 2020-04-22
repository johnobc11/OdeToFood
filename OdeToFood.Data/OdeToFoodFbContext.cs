using Microsoft.EntityFrameworkCore;
using OneToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodFbContext : DbContext
    {
        public OdeToFoodFbContext(DbContextOptions<OdeToFoodFbContext> options)
            :base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
