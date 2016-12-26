using BS.RepositoryIDAL;

namespace BS.RepositoryDAL
{
    public static class RepositoryFactory
    {
        /// <summary>
        /// 新闻仓储
        /// </summary>
        public static INewsRepository NewsRepository { get { return new NewsRepositoty(); } }

        /// <summary>
        /// 新闻分类仓储
        /// </summary>
        public static INewsClassRepository NewsClassRepository { get { return new NewsClassRepository(); } }

        /// <summary>
        /// 产品仓储
        /// </summary>
        public static IProductRepository ProductRepository { get { return new ProductRepositoty(); } }

        /// <summary>
        /// 案例仓储
        /// </summary>
        public static ICasesRepository CasesRepository { get { return new CasesRepository(); } }

        /// <summary>
        /// 图片仓储
        /// </summary>
        public static IPictureRepository PictureRepository { get { return new PictureRepository(); } }

        /// <summary>
        /// 用户仓储
        /// </summary>
        public static IUserRepository UserRepository { get { return new UserRepository(); } }

        /// <summary>
        /// 用户信息仓储
        /// </summary>
        public static IUserLogOnRepository UserLogOnRepository { get { return new UserLogOnRepository(); } }

        /// <summary>
        /// 日志仓储
        /// </summary>
        public static ILogRepository LogRepository { get { return new LogRepository(); } }
    }
}
