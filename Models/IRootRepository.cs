using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCM.Models
{
    public interface IRootRepository
    {
        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}
