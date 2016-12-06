using System.Linq;
using Entity.Base;

namespace BS.RepositoryIService
{
    public interface ICasesService : IBaseService<Cases>
    {
        //这里的方法只是拓展改模块业务用的，当已有的方法满足不了需求时，在这里添加模块的扩展方法
        IQueryable<Cases> GetList();

        Cases FirstOrDefault(int ID);
    }
}
