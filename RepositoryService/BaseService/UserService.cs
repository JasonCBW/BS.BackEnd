using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;
using BS.Code;
using System;

namespace BS.RepositoryService
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        public UserService() : base(RepositoryFactory.UserRepository) { }

        //扩展方法的实现

        public IQueryable<UserEntity> GetList() { return CurrentRepository.FindList(u => true).OrderByDescending(n => n.ID); }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public UserEntity CheckLogin(string name, string pwd)
        {
            UserEntity user = CurrentRepository.Find(t => t.F_Account == name || t.F_MobilePhone == name || t.F_Email == name);
            if (user != null)
            {
                if (user.F_EnabledMark == true)
                {
                    string dbPassword = Md5.md5(DESEncrypt.Encrypt(pwd.ToLower(), user.F_UserSecretkey).ToLower()).ToLower();
                    if (user.F_UserPassword == dbPassword)
                    {
                        user.F_LastVisitTime = DateTime.Now;
                        user.F_UserOnLine = true;
                        user.F_LogOnCount += 1;
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
