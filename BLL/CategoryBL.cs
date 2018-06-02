using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBL
    {
        private CategoryDB objDB;

        public CategoryBL()
        {
            objDB = new CategoryDB();
        }

        public IEnumerable<CATEGORIES> GetAll()
        {
            return objDB.GetAll();
        }

        public CATEGORIES GetByID(string CategoryName)
        {
            return objDB.GetByID(CategoryName);
        }

        public void Insert(CATEGORIES category)
        {
            objDB.Insert(category);
        }

        public void Delete(string CategoryName)
        {
            objDB.Delete(CategoryName);
        }

        public void Update(CATEGORIES category)
        {
            objDB.Update(category);
        }
    }
}
