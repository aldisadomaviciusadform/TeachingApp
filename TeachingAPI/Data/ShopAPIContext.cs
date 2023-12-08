using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;
using TeachingAPI.Models;

namespace ShopAPI.Data
{
    public class ShopAPIContext : DbContext
    {
        public ShopAPIContext (DbContextOptions<ShopAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ShopAPI.Models.Person> Person { get; set; } = default!;
        public DbSet<TeachingAPI.Models.ShopItem> ShopItem { get; set; } = default!;
    }
}
