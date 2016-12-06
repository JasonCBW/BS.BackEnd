using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BS.RepositoryIDAL
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IEnumerable<T> InsertAll(List<T> entities);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="propertie">更新表达式</param>
        /// <param name="updateExpression">需要更新的实体和字段</param>
        /// <returns>返回操作行数</returns>
        int Update(Expression<Func<T, bool>> propertie, Expression<Func<T, T>> updateExpression);

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="propertie">更新表达式</param>
        /// <param name="updateExpression">需要更新的实体和字段</param>
        /// <returns>返回操作行数</returns>
        Task<int> AsyncUpdate(Expression<Func<T, bool>> propertie, Expression<Func<T, T>> updateExpression);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity">删除表达式</param>
        /// <returns>返回操作行数</returns>
        int Delete(Expression<Func<T, bool>> propertie);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param> 
        /// <returns></returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba);

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <param name="whereLambda">取得排序的条件</param> 
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="recordCount">总条数</param> 
        /// <returns>返回一个实体类型的IQueryable集合</returns>
        IQueryable<T> FindPageList(Expression<Func<T, bool>> whereLambda, Expression<Func<T, bool>> orderByLamdba, int pageIndex, int pageSize, out int recordCount);
    }
}
