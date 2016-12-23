using System.Linq;
using Entity.Base;

namespace BS.RepositoryIService
{
    public interface INewsClassService : IBaseService<NewsClass>
    {
        IQueryable<NewsClass> GetTopList();

        IQueryable<NewsClass> GetAll();

        NewsClass FirstOrDefault(string ID);
    }
}
