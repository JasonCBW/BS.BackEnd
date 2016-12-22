using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;

namespace BS.RepositoryService
{
    public class LoginService : BaseService<User>, ILoginService
    {
        public LoginService() : base(RepositoryFactory.LoginRepository) { }

        //扩展方法的实现

        public IQueryable<User> GetList() { return CurrentRepository.FindList(news => true).OrderByDescending(n => n.ID); }

        public User FirstOrDefault(int ID)
        {
            return CurrentRepository.Find(t => t.ID == ID);
        }
    }
}
