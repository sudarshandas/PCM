using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace PCM.Models
{
    public class SQLRepository : IRootRepository
    {
        private AppDbContext _context;
        public SQLRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Insert<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            bool blnSave = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    blnSave = await _context.SaveChangesAsync() > 0;
                    transaction.Commit();
                    return blnSave;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
