using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IqmetrixBeerTap.Domain.Model
{
    public class BeerTapContext : DbContext
    {
        public BeerTapContext() : base("BeerTap")
        {
            
        }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Keg> Kegs { get; set; }
    }
}
