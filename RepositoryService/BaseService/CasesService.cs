using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;

namespace BS.RepositoryService
{
    public class CasesService : BaseService<Cases>, ICasesService
    {
        public CasesService() : base(RepositoryFactory.CasesRepository) { }

        //扩展方法的实现

        public IQueryable<Cases> GetList() { return CurrentRepository.FindList(news => true).OrderBy(n => n.ID); }

        public Cases FirstOrDefault(string ID)
        {
            return CurrentRepository.Find(t => t.ID == ID);
        }
    }
}
