using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;

namespace BS.RepositoryService
{
    public class ProductService : BaseService<Product>,IProductService
    {
        public ProductService() : base(RepositoryFactory.ProductRepository) { }

        //扩展方法的实现

        public IQueryable<Product> GetList() { return CurrentRepository.FindList(product => product.ID != 0).OrderBy(n => n.ID); }

        public Product FirstOrDefault(int ID)
        {
            return CurrentRepository.Find(t => t.ID == ID);
        }
    }
}
