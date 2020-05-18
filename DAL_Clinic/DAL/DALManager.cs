using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public static class DALManager
    {
        private static DAL_BenhNhan _benhNhanDAL;

        public static DAL_BenhNhan BenhNhanDAL 
        { 
            get
            {
                if (_benhNhanDAL == null)
                    _benhNhanDAL = new DAL_BenhNhan();
                return _benhNhanDAL;
            }
        }
    }
}
