using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public abstract class BaseDAL
    {
        protected virtual void SaveChanges()
        {
            SQLServerDBContext.Instant.SaveChanges();
        }
    }
}
