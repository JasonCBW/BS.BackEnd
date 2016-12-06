using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;

namespace BS.RepositoryService
{
    public class NewsClassService : BaseService<NewsClass>, INewsClassService
    {
        public NewsClassService() : base(RepositoryFactory.NewsClassRepository) { }

        //获取所有顶级分类
        public IQueryable<NewsClass> GetTopList() { return CurrentRepository.FindList(news => news.ParentID == 0).OrderBy(n => n.ID); }

        //获取所有分类
        public IQueryable<NewsClass> GetAll() { return CurrentRepository.FindList(news => true).OrderByDescending(n => n.ID); }

        public NewsClass FirstOrDefault(int ID)
        {
            return CurrentRepository.Find(t => t.ID == ID);
        }
    }
}
