using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AppointmentBL
    {
        private AppointmentDB objDB;

        public AppointmentBL()
        {
            objDB = new AppointmentDB();
        }

        public IEnumerable<APPOINTMENTS> GetAll()
        {
            return objDB.GetAll();
        }

        public APPOINTMENTS GetByID(int id)
        {
            return objDB.GetByID(id);
        }

        public void Insert(APPOINTMENTS appointment)
        {
            objDB.Insert(appointment);
        }

        public void Delete(int id)
        {
            objDB.Delete(id);
        }

        public void Update(APPOINTMENTS appointment)
        {
            objDB.Update(appointment);
        }
    }
}
