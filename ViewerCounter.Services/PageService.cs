using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewerCounter.DAL.Entities;
using ViewerCounter.DAL.Interfaces;

namespace ViewerCounter.Services
{
    public class PageService : IPageService
    {
        private readonly IDbRepository _repository;
        
        public PageService(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterView(View view)
        {
            if (view == null || string.IsNullOrEmpty(view.UserId))
            {
                throw new ArgumentException("Incorrect View");
            }

            await _repository.Add(view);
            await _repository.SaveChangesAsync();
        }

        public List<View> GetInfo()
        {
            var result = _repository.GetAll<View>().ToList();
            
            return result;
        }
    }
}