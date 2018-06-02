using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppointmentDB
    {
        ReservationDBEntities db;

        public AppointmentDB()
        {
            db = new ReservationDBEntities();
        }

        public IEnumerable<APPOINTMENTS> GetAll()
        {
            return db.APPOINTMENTS.ToList();
        }

        public APPOINTMENTS GetByID(string id)
        {
            return db.APPOINTMENTS.First(x => x.ID == id);
        }

        public void Insert(APPOINTMENTS appointment)
        {
            db.APPOINTMENTS.Add(appointment);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            db.APPOINTMENTS.Remove(GetByID(id));
            db.SaveChanges();
        }

        public void Update(APPOINTMENTS appointment)
        {
            db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
