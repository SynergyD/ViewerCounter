using System;
using System.Linq;
using System.Threading.Tasks;
using ViewerCounter.DAL.Entities;
using ViewerCounter.DAL.Interfaces;

namespace ViewerCounter.DAL
{
    public class DbRepository : IDbRepository
    {
        private readonly DataContext _context;

        public DbRepository(DataContext context)
        {
            _context = context;
        }
        
        public IQueryable<T> GetAll<T>() where T: BaseEntity
        {
            return _context.Set<T>().AsQueryable();
        }
        
        public async Task<Guid> Add<T>(T newEntity) where T: BaseEntity
        {
            var entity = await _context.Set<T>().AddAsync(newEntity);
            
            return entity.Entity.Id;
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}