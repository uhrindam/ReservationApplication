using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppointmentDB : BaseDB
    {
        public IEnumerable<APPOINTMENTS> GetAll()
        {
            return Db.APPOINTMENTS.ToList();
        }

        public APPOINTMENTS GetByID(string id)
        {
            return Db.APPOINTMENTS.First(x => x.ID == id);
        }

        public void Insert(APPOINTMENTS appointment)
        {
            Db.APPOINTMENTS.Add(appointment);
            Db.SaveChanges();
        }

        public void Delete(string id)
        {
            Db.APPOINTMENTS.Remove(GetByID(id));
            Db.SaveChanges();
        }

        public void Update(APPOINTMENTS appointment)
        {
            Db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
