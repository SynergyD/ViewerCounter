using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViewerCounter.DAL.Entities;

namespace ViewerCounter.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<View> Views { get; set; }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}