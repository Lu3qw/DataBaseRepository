using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericUnitOfWork
    {
        DbContext context;

        public GenericUnitOfWork(DbContext context)
        { 
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repository = new EFGenericRepository<TEntity>(context);
            repositories.Add(typeof(TEntity), repository);
            return repository;

        }



    }
}
