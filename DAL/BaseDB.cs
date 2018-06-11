using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class BaseDB
    {
        ReservationDBEntities db;

        public BaseDB()
        {
            db = new ReservationDBEntities();
        }

        public ReservationDBEntities Db { get => db; set => db = value; }
    }
}
