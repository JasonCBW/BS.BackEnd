using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;
using BS.Code;
using System;

namespace BS.RepositoryService
{
    public class UserLogOnService : BaseService<UserLogOnEntity>, IUserLogOnService
    {
        public UserLogOnService() : base(RepositoryFactory.UserLogOnRepository) { }

        //扩展方法的实现

        public IQueryable<UserLogOnEntity> GetList() { return CurrentRepository.FindList(u => true).OrderByDescending(n => n.F_Id); }
         
    }
}
