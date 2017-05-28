using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Entity;

namespace LifestyleEffectCheckerDLL.Context
{
    class LifestyleCheckerContext : DbContext
    {
        public LifestyleCheckerContext() : base("name=LifestyleChecker")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Journal> Journals { get; set; }
        public DbSet<PartInformation> PartInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////Orderlist has many-to-many products.
            //modelBuilder.Entity<OrderList>()
            //    .HasMany<Product>(list => list.ItemsList)
            //    .WithMany(product => product.OrderLists);

            ////SchoolEvent has 1 Schedule. Schedule has many SchoolEvents.
            modelBuilder.Entity<PartInformation>()
                .HasOptional<Journal>(partInformation => partInformation.Journal)
                .WithMany(journal => journal.PartInformations);

            base.OnModelCreating(modelBuilder);
        }
    }

    class DatabaseInitializer : DropCreateDatabaseAlways<LifestyleCheckerContext>
    {
        protected override void Seed(LifestyleCheckerContext context)
        {
            Journal journal1 = context.Journals.Add(new Journal { Name = "McMenu" });
            var partInformations1 = context.PartInformations.Add(new PartInformation { Name = "Burger", Journal = journal1, MeasuringMethod = MeasuringMethod.Number });
            partInformations1.SetValue(5);
            var partInformations2 = context.PartInformations.Add(new PartInformation { Name = "Salat", Journal = journal1, MeasuringMethod = MeasuringMethod.Text });
            partInformations2.SetValue("Smagte for sødt");

            Journal journal2 = context.Journals.Add(new Journal { Name = "Motion" });
            context.PartInformations.Add(new PartInformation { Name = "Løb", Journal = journal1 });
            context.PartInformations.Add(new PartInformation { Name = "Spring", Journal = journal1 });


            base.Seed(context);
        }
    }
}
