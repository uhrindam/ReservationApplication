using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// This is a base class for the other DB classes. (In this way, easier to handle the database connection.)
    /// </summary>
    public abstract class BaseDB
    {
        ReservationAPPModel db;

        public BaseDB()
        {
            db = new ReservationAPPModel();
        }

        public ReservationAPPModel Db { get => db; set => db = value; }
    }
}
