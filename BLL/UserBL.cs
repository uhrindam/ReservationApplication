using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        /// <summary>
        /// When a user is registrating, I use a helper class to validate the given data. This method get a helper object, 
        /// what I have to transformate to real USERS object.
        /// </summary>
        /// <param name="user"></param>
        public void Insert(UserRegistration user)
        {
            USERS validateduser = new USERS();

            validateduser.EmailAddress = user.EmailAddress;
            validateduser.FullName = user.FullName;
            validateduser.NickName = user.NickName;
            validateduser.Passwd = Hash(user.Passwd);
            validateduser.RegistrationDate = DateTime.Now;
            validateduser.IsAdmin = false;

            objDB.Insert(validateduser);
        }

        public void Delete(string NickName)
        {
            objDB.Delete(NickName);
        }

        public void Update(USERS user)
        {
            objDB.Update(user);
        }

        /// <summary>
        /// This method provide me the encoding of the password. I use this when a user is registrating, and when a user is signing in.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

    }
}
