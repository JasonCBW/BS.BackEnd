using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;
using BS.Code;
using System;

namespace BS.RepositoryService
{
    public class LogService : BaseService<LogEntity>, ILogService
    {
        public LogService() : base(RepositoryFactory.LogRepository) { } 

        //扩展方法的实现

        public IQueryable<LogEntity> GetList() { return CurrentRepository.FindList(u => true).OrderByDescending(n => n.ID); }
    }
}
