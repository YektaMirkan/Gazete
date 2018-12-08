using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazete.Data.Repository
{
    public abstract class WriteRepository<TContext> : IWriteRepository
        where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public abstract void Remove<TItem>(TItem item) where TItem : class, new();

        protected TContext Context { get { return _context; } }

        protected WriteRepository()
        {
            _context = new TContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TItem Update<TItem>(TItem item, bool saveImmediately = true) where TItem : class, new()
        {
            return PerformAction(item, EntityState.Modified, saveImmediately);
        }

        public TItem Insert<TItem>(TItem item, bool saveImmediately = true) where TItem : class, new()
        {
            var entries = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            foreach (var entry in entries)
            {
                entry.Reload();
            }
            return PerformAction(item, EntityState.Added, saveImmediately);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual TItem PerformAction<TItem>(TItem item, EntityState entityState, bool saveImmediately = true) where TItem : class, new()
        {
            _context.Entry(item).State = entityState;
            if (saveImmediately)
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
            return item;
        }
    }
}
