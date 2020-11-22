using System;
using System.Linq;
using System.Threading.Tasks;
using ViewerCounter.DAL.Entities;

namespace ViewerCounter.DAL.Interfaces
{
    public interface IDbRepository
    {
        IQueryable<T> GetAll<T>() where T : BaseEntity;
        
        Task<Guid> Add<T>(T newEntity) where T: BaseEntity;
        
        Task<int> SaveChangesAsync();
    }
}