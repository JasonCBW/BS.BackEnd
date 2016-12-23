using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;

namespace BS.RepositoryService
{
    public class NewsService : BaseService<News>, INewsService
    {
        public NewsService() : base(RepositoryFactory.NewsRepository) { }

        //扩展方法的实现

        public IQueryable<News> GetList() { return CurrentRepository.FindList(news => true).OrderByDescending(n => n.Sort).OrderByDescending(n => n.ID); }

        public News FirstOrDefault(string ID)
        {
            return CurrentRepository.Find(t => t.ID == ID);
        }
    }
}
