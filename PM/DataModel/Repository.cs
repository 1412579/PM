﻿using DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PM.Models;
namespace DataModel.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private PMContext _context;
        public Repository(PMContext context)
        {
            this._context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Attach(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<TEntity>().Where<TEntity>(predicate);
            }
            return _context.Set<TEntity>().AsQueryable();
        }
    }
}
