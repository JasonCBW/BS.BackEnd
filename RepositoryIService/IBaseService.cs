using System;
using System.Linq;
using System.Linq.Expressions;

namespace BS.RepositoryIService
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        //bool Delete(T entity);

        T Find(Expression<Func<T, bool>> whereLamdba);

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param> 
        /// <returns></returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity">删除表达式</param>
        /// <returns>返回操作行数</returns>
        int Delete(Expression<Func<T, bool>> whereLamdba);

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <param name="whereLambda">取得排序的条件</param> 
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="recordCount">总条数</param> 
        /// <returns>返回一个实体类型的IQueryable集合</returns>
        IQueryable<T> FindPageList(Expression<Func<T, bool>> whereLambda, Expression<Func<T, bool>> orderByLamdba, int pageIndex, int pageSize, out int recordCount);

        /// <summary>
        /// 测试方法
        /// </summary>
        /// <returns></returns>
        string TestMethod();
    }
}
