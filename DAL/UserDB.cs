using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDB
    {
        ReservationDBEntities db;

        public UserDB()
        {
            db = new ReservationDBEntities();
        }

        public IEnumerable<USERS> GetAll()
        {
            return db.USERS.ToList();
        }

        public USERS GetByID(string NickName)
        {
            return db.USERS.First(x => x.NickName == NickName);
        }

        public void Insert(USERS user)
        {
            db.USERS.Add(user);
            db.SaveChanges();
        }

        public void Delete(string NickName)
        {
            db.USERS.Remove(GetByID(NickName));
            db.SaveChanges();
        }

        public void Update(USERS user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
