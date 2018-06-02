using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBL
    {
        private UserDB objDB;

        public UserBL()
        {
            objDB = new UserDB();
        }

        public IEnumerable<USERS> GetAll()
        {
            return objDB.GetAll();
        }

        public USERS GetByID(string NickName)
        {
            return objDB.GetByID(NickName);
        }

        public void Insert(USERS user)
        {
            objDB.Insert(user);
        }

        public void Delete(string NickName)
        {
            objDB.Delete(NickName);
        }

        public void Update(USERS user)
        {
            objDB.Update(user);
        }
    }
}
