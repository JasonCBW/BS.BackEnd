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
    }
}
