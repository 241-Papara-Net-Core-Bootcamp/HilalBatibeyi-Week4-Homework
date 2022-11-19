using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owner.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(int id);
        
        Task<int> AddAsync(T entity);
        
        Task<int> DeleteAsync(int id);
        
        Task<int> UpdateAsync(T entity);
    }
}
