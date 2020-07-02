namespace DAL_Clinic.Migrations
{
    using DTO_Clinic;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL_Clinic.SQLServerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DAL_Clinic.SQLServerDBContext";
        }

        protected override void Seed(DAL_Clinic.SQLServerDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.            
            }
    }
}
