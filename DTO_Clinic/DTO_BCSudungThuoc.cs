using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_BCSudungThuoc:BaseModel
    {
        private int _thang;
        private int _nam;
        private int _soLanDung;
        private int _soLuongDung;
        private bool _isDeleted;
        public int Thang { get => _thang; set { _thang = value; OnPropertyChanged(); } }
        public int Nam { get => _nam; set { _nam = value; OnPropertyChanged(); } }
        public int SoLanDung { get => _soLanDung; set { _soLanDung = value; OnPropertyChanged(); } }
        public int SoLuongDung { get => _soLuongDung; set { _soLuongDung = value; OnPropertyChanged(); } }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public int MaThuoc { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
    }
}
