namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
                 AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataAccessLayer.DBContext context)
        {
            Migrations.Seeds.Regions.Seed(context);
            Migrations.Seeds.Role.Seed(context);
            Migrations.Seeds.User.Seed(context);
            Migrations.Seeds.UserRoles.Seed(context);
            Migrations.Seeds.RoleDetails.Seed(context);
            Migrations.Seeds.Modules.Seed(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
