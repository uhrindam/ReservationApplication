using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDB : BaseDB
    {
        public IEnumerable<CATEGORIES> GetAll()
        {
            return Db.CATEGORIES.ToList();
        }

        public CATEGORIES GetByID(string CategoryName)
        {
            return Db.CATEGORIES.First(x => x.CategoryName == CategoryName);
        }

        public void Insert(CATEGORIES category)
        {
            Db.CATEGORIES.Add(category);
            Db.SaveChanges();
        }

        public void Delete(string CategoryName)
        {
            Db.CATEGORIES.Remove(GetByID(CategoryName));
            Db.SaveChanges();
        }

        public void Update(CATEGORIES category)
        {
            Db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }

        public List<string> GetCategoryNames()
        {
            return Db.CATEGORIES.Select(x=>x.CategoryName).ToList();
        }
    }
}
