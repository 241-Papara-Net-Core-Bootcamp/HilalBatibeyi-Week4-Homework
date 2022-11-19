using Owner.API.Model;
using Owner.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Owner.Business.Abstract
{
    public interface IOwnerService
    {
        Task<List<OwnerDto>> GetAllAsync();

        Task<OwnerDto> GetAsync(int id);
        
        Task AddAsync(OwnerDto ownertDto);
        
        Task Delete(int id);
        
        Task Update(OwnerDto ownertDto, int id);
        
    }
}
