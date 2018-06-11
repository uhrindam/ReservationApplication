using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDB : BaseDB
    {
        public IEnumerable<USERS> GetAll()
        {
            return Db.USERS.ToList();
        }

        public USERS GetByID(string NickName)
        {
            try
            {
                return Db.USERS.First(x => x.NickName == NickName);
            }
            catch (Exception)
            {
                while (Db.Database.Connection.State != System.Data.ConnectionState.Closed) { }
                Db = new ReservationDBEntities();
                return Db.USERS.First(x => x.NickName == NickName);
            }
        }

        public void Insert(USERS user)
        {
            Db.USERS.Add(user);
            Db.SaveChanges();
        }

        public void Delete(string NickName)
        {
            Db.USERS.Remove(GetByID(NickName));
            Db.SaveChanges();
        }

        public void Update(USERS user)
        {
            Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
