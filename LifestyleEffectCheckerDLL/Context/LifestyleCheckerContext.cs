using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Entity;
using LifestyleEffectCheckerDLL.Entity.Action;
using LifestyleEffectCheckerDLL.Entity.Effect;

namespace LifestyleEffectCheckerDLL.Context
{
    class LifestyleCheckerContext : DbContext
    {
        public LifestyleCheckerContext() : base("name=LifestyleChecker")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Journal> Journals { get; set; }
        public DbSet<ActionPart> ActionParts { get; set; }
        public DbSet<Entity.Action.Action> Actions { get; set; }
        public DbSet<PartInformation> PartInformations { get; set; }
        public DbSet<EffectParameter> EffectParameters { get; set; }
        public DbSet<Effect> Effects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////Orderlist has many-to-many products.
            //modelBuilder.Entity<OrderList>()
            //    .HasMany<Product>(list => list.ItemsList)
            //    .WithMany(product => product.OrderLists);

            ////SchoolEvent has 1 Schedule. Schedule has many SchoolEvents.
            //modelBuilder.Entity<SchoolEvent>()
            //    .HasOptional<Schedule>(schoolEvent => schoolEvent.Schedule)
            //    .WithMany(schedule => schedule.SchoolEvents);

            base.OnModelCreating(modelBuilder);
        }
    }

    class DatabaseInitializer : DropCreateDatabaseAlways<LifestyleCheckerContext>
    {
        protected override void Seed(LifestyleCheckerContext context)
        {
            base.Seed(context);
        }
    }
}
