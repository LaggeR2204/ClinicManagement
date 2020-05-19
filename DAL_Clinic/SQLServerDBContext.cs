using DAL_Clinic.BuddyClass;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic
{
    internal class SQLServerDBContext : DbContext
    {
        public SQLServerDBContext() : base("name=connectionStringPMT")
        {
            var initializer = new MigrateDatabaseToLatestVersion<SQLServerDBContext, Migrations.Configuration>();
            Database.SetInitializer(initializer);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BenhNhanMap());
            modelBuilder.Configurations.Add(new PhieuKhamBenhMap());
            modelBuilder.Configurations.Add(new CT_PhieuKhamBenhMap());
            modelBuilder.Configurations.Add(new ThuocMap());
            modelBuilder.Configurations.Add(new BenhMap());
            modelBuilder.Configurations.Add(new CachDungMap());
            modelBuilder.Configurations.Add(new DonViMap());
            modelBuilder.Configurations.Add(new PhieuNhapThuocMap());
            modelBuilder.Configurations.Add(new CT_PhieuNhapThuocMap());
            modelBuilder.Configurations.Add(new BCDoanhThuMap());
            modelBuilder.Configurations.Add(new CT_BCDoanhThuMap());
            modelBuilder.Configurations.Add(new BCSuDungThuocMap());
            modelBuilder.Configurations.Add(new ThamSoMap());
            modelBuilder.Configurations.Add(new HoaDonMap());
        }
        public DbSet<DTO_BenhNhan> BenhNhan { get; set; }
        public DbSet<DTO_PhieuKhamBenh> PhieuKhamBenh { get; set; }
        public DbSet<DTO_Benh> Benh { get; set; }
        public DbSet<DTO_CachDung> CachDung { get; set; }
        public DbSet<DTO_DonVi> DonVi { get; set; }
        public DbSet<DTO_CTPhieuKhamBenh> CTPhieuKhamBenh { get; set; }
        public DbSet<DTO_HoaDon> HoaDon { get; set; }
        public DbSet<DTO_PhieuNhapThuoc> PhieuNhapThuoc { get; set; }
        public DbSet<DTO_CTPhieuNhapThuoc> CTPhieuNhapThuoc { get; set; }
        public DbSet<DTO_Thuoc> Thuoc { get; set; }
        public DbSet<DTO_BCDoanhThu> BaoCaoDoanhThu { get; set; }
        public DbSet<DTO_CTBaoCaoDoanhThu> CT_BaoCaoDoanhThu { get; set; }
        public DbSet<DTO_BCSudungThuoc> BaoCaoSuDungThuoc { get; set; }
        public DbSet<DTO_ThamSo> ThamSo { get; set; }
    }
}
