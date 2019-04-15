using BlogTyson.DAL.ORM.Context;
using BlogTyson.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogTyson.BLL.Repository
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private ProjectContext db;
        protected DbSet<T> table;

        public BaseRepository()
        {
            db = new ProjectContext();
            table = db.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public void Add(T item)
        {
            item.Status = BlogTyson.DAL.ORM.Enum.Status.Active;
            table.Add(item);
            Save();
        }
        public void Add(List<T> items)
        {
            table.AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => table.Any(exp);

        public List<T> GetActive()
        {
            return table.Where(x => x.Status == BlogTyson.DAL.ORM.Enum.Status.Active).ToList();
        }
        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).FirstOrDefault();
        }
        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }
        public T GetById(Guid id)
        {
            return table.Find(id);
        }
        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = BlogTyson.DAL.ORM.Enum.Status.Deleted;
            Update(item);
        }
        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = BlogTyson.DAL.ORM.Enum.Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = db.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

    }
}
