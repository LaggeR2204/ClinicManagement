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
            DTO_ThamSo tienKham = new DTO_ThamSo("Tiền khám", 30000);
            DTO_ThamSo soBNToiDa = new DTO_ThamSo("Số bệnh nhân tối đa 1 ngày", 40);
            context.ThamSo.AddOrUpdate(tienKham);
            context.ThamSo.AddOrUpdate(soBNToiDa);
        }
    }
}
