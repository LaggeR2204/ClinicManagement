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
        private static SQLServerDBContext _instant;
        public static SQLServerDBContext Instant
        {
            get
            {
                if (_instant != null)
                    return _instant;
                return new SQLServerDBContext();
            }
            private set => _instant = value;
        }
        public SQLServerDBContext() : base("name=connectionStringPMT")
        {

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
    }
}
