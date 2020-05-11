﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_BenhNhan : BaseModel
    {
        public int DTO_BenhNhanId { get; set; }
        public string TenBenhNhan
        {
            get => _tenBenhNhan;
            set
            {
                _tenBenhNhan = value;
                OnPropertyChanged();
            }
        }
        public DateTime NgaySinh
        {
            get => _ngaySinh;
            set
            {
                _ngaySinh = value;
                OnPropertyChanged();
            }
        }
        public bool GioiTinh
        {
            get => _gioiTinh;
            set
            {
                _gioiTinh = value;
                OnPropertyChanged();
            }
        }
        public string DiaChi
        {
            get => _diaChi;
            set
            {
                _diaChi = value;
                OnPropertyChanged();
            }
        }
        public string SoDienThoai
        {
            get => _SDT;
            set
            {
                _SDT = value;
                OnPropertyChanged();
            }
        }
        private string _tenBenhNhan;
        private DateTime _ngaySinh;
        private bool _gioiTinh;
        private string _diaChi;
        private string _SDT;
    }
}
