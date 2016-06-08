using IqmetrixBeerTap.Domain.Model;

namespace IqmetrixBeerTap.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IqmetrixBeerTap.Domain.Model.BeerTapContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IqmetrixBeerTap.Domain.Model.BeerTapContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Offices.AddOrUpdate(o => o.Id,
            new Office() {Id = 1, Name = "Vancouver", Description = "Vancouver Office" },
            new Office() {Id = 2, Name = "Regina", Description = "Regina Office" },
            new Office() {Id = 3, Name = "Winnipeg", Description = "Winnipeg Office" },
            new Office() {Id = 4, Name = "Davidson ", Description = "Davidson  Office" }
            );

            context.Kegs.AddOrUpdate(k => k.Id,
                new Keg() {Id = 1, Name = "Beer A", Container = 100, OfficeId = 1},
                new Keg() {Id = 2, Name = "Beer B", Container = 100, OfficeId = 1 },
                new Keg() {Id = 3, Name = "Beer C", Container = 100, OfficeId = 2 },
                new Keg() {Id = 4, Name = "Beer D", Container = 100, OfficeId = 2 },
                new Keg() {Id = 5, Name = "Beer E", Container = 100, OfficeId = 3 },
                new Keg() {Id = 6, Name = "Beer F", Container = 100, OfficeId = 3 },
                new Keg() {Id = 7, Name = "Beer G", Container = 100, OfficeId = 4 },
                new Keg() {Id = 8, Name = "Beer H", Container = 100, OfficeId = 4 }
                );
        }
    }
}
