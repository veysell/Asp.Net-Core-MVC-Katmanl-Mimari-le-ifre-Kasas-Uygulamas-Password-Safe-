using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        DataContext db = new DataContext();
        DbSet<T> data;

        public GenericRepository()
        {
            data = db.Set<T>();
        }
        public void Delete(T p)
        {
            data.Remove(p);
            db.SaveChanges();
        }

        public T GetById(int id)
        {
            return data.Find(id);
        }
       
        public void Insert(T p)
        {
            data.Add(p);
            db.SaveChanges();
        }
        
        public List<T> List()
        {
            return data.ToList();
        }

        public void Update(T p)
        {
            db.Entry<T>(p).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<T> PassList(Expression<Func<T, bool>> id)
        {
            return data.Where(id).ToList();
        }
    }
}
