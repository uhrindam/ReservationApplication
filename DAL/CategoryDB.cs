using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDB
    {
        ReservationDBEntities db;

        public CategoryDB()
        {
            db = new ReservationDBEntities();
        }

        public IEnumerable<CATEGORIES> GetAll()
        {
            return db.CATEGORIES.ToList();
        }

        public CATEGORIES GetByID(string CategoryName)
        {
            return db.CATEGORIES.First(x => x.CategoryName == CategoryName);
        }

        public void Insert(CATEGORIES category)
        {
            db.CATEGORIES.Add(category);
            db.SaveChanges();
        }

        public void Delete(string CategoryName)
        {
            db.CATEGORIES.Remove(GetByID(CategoryName));
            db.SaveChanges();
        }

        public void Update(CATEGORIES category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
