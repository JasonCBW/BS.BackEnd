using System;
using System.Linq;
using BS.RepositoryIService;
using BS.RepositoryIDAL;
using System.Linq.Expressions;

namespace BS.RepositoryService
{
    /// <summary>
    /// 服务基类 
    /// </summary>
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepository<T> CurrentRepository { get; set; }

        public BaseService(IBaseRepository<T> currentRepository) { CurrentRepository = currentRepository; }

        public T Add(T entity) { return CurrentRepository.Add(entity); }

        public bool Update(T entity) { return CurrentRepository.Update(entity); }

        public bool Delete(T entity) { return CurrentRepository.Delete(entity); }

        public int Delete(Expression<Func<T, bool>> whereLamdba) { return CurrentRepository.Delete(whereLamdba); }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba)
        {
            return CurrentRepository.FindList(whereLamdba);
        }

        public T Find(Expression<Func<T, bool>> whereLamdba)
        {
            return CurrentRepository.Find(whereLamdba);
        }

        public IQueryable<T> FindPageList(Expression<Func<T, bool>> whereLambda, Expression<Func<T, bool>> orderByLamdba, int pageIndex, int pageSize, out int recordCount)
        {
            return CurrentRepository.FindPageList(whereLambda, orderByLamdba, pageIndex, pageSize, out recordCount);
        }

        public string TestMethod()
        {
            return "Jason";
        }
    }
}
