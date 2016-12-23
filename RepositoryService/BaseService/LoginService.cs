using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;
using BS.Code;
using System;

namespace BS.RepositoryService
{
    public class LoginService : BaseService<User>, ILoginService
    {
        public LoginService() : base(RepositoryFactory.LoginRepository) { }

        //扩展方法的实现

        public IQueryable<User> GetList() { return CurrentRepository.FindList(u => true).OrderByDescending(n => n.ID); }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public User FirstOrDefault(string name, string pwd)
        {
            User user = CurrentRepository.Find(t => t.LoginName == name);
            if (user != null)
            {
                if (user.Status)
                {
                    string dbPassword = Md5.md5(DESEncrypt.Encrypt(pwd.ToLower(), user.UserSecretkey).ToLower()).ToLower();
                    if (user.LoginPassword == dbPassword)
                    {
                        user.LastVisitTime = DateTime.Now;
                        CurrentRepository.Update(user);
                        return user;
                    }
                    else
                    {
                        throw new Exception("密码不正确，请重新输入");
                    }
                }
                else
                {
                    throw new Exception("账户被系统锁定,请联系管理员");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }
    }
}
