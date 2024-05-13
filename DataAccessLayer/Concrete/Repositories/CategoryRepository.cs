using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> _object;

        public void Delete(Category p)
        {
            _object.Remove(p);
            context.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            context.SaveChanges();
        }
            
        public List<Category> List()
        {
            throw new NotImplementedException();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> Listele()
        {
            return _object.ToList(); 
        }

        public void Update(Category p)
        {
            context.SaveChanges();
        }
    }
}
                    /*
                    ToList
                    Add
                    Remove
                    Find
                     */