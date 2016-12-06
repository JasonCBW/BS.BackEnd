using System.Runtime.Remoting.Messaging;

namespace BS.RepositoryDAL
{
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static DBContext GetCurrentContext()
        {
            DBContext _dbContext = CallContext.GetData("DBContext") as DBContext;
            if (_dbContext == null)
            {
                _dbContext = new DBContext();
                CallContext.SetData("DBContext", _dbContext);
            }
            return _dbContext;
        }
    }
}
