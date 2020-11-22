using System.Collections.Generic;
using System.Threading.Tasks;
using ViewerCounter.DAL.Entities;
 
namespace ViewerCounter.Services
{
    public interface IPageService
    {
        public Task RegisterView(View view);

        public List<View> GetInfo();
    }
}