using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.RepositoryIDAL;
using System.Data.Entity;
using System.Linq.Expressions;
using EntityFramework.Extensions;

namespace BS.RepositoryDAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //数据操作对象
        protected DBContext _dbcontext = ContextFactory.GetCurrentContext();

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回实体对象</returns>
        public T Add(T entity)
        {
            var m = _dbcontext.Set<T>().Add(entity);
            _dbcontext.SaveChanges();
            return m;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>返回添加成功的实体集合</returns>
        public IEnumerable<T> InsertAll(List<T> entities)
        {
            return _dbcontext.Set<T>().AddRange(entities);
        }

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">查询表达式</param>
        /// <returns>记录数</returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbcontext.Set<T>().Count(predicate);
        }

        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public bool Update(T entity)
        {
            _dbcontext.Set<T>().Attach(entity);
            _dbcontext.Entry<T>(entity).State = EntityState.Modified;
            return _dbcontext.SaveChanges() > 0;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="propertie">更新表达式</param>
        /// <param name="updateExpression">需要更新的实体和字段</param>
        /// <returns>返回操作行数</returns>
        public int Update(Expression<Func<T, bool>> propertie, Expression<Func<T, T>> updateExpression)
        {
            return _dbcontext.Set<T>().Where(propertie).Update(updateExpression);
        }

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="propertie">更新表达式</param>
        /// <param name="updateExpression">需要更新的实体和字段</param>
        /// <returns>返回操作行数</returns>
        public Task<int> AsyncUpdate(Expression<Func<T, bool>> propertie, Expression<Func<T, T>> updateExpression)
        {
            return _dbcontext.Set<T>().Where(propertie).UpdateAsync(updateExpression);
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public bool Delete(T entity)
        {
            _dbcontext.Set<T>().Attach(entity);
            _dbcontext.Entry<T>(entity).State = EntityState.Deleted;
            return _dbcontext.SaveChanges() > 0;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity">删除表达式</param>
        /// <returns>返回操作行数</returns>
        public int Delete(Expression<Func<T, bool>> propertie)
        {
            return _dbcontext.Set<T>().Where(propertie).Delete();
        }

        /// <summary>
        /// 对象是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>返回操作状态</returns>
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return _dbcontext.Set<T>().Where(anyLambda).Any();
        }

        /// <summary>
        /// 查找单个对象
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>返回查找对象</returns>
        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = _dbcontext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        /// <summary>
        /// 查询结果集
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <returns>返回查询结果集</returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba)
        {
            var _list = _dbcontext.Set<T>().Where<T>(whereLamdba);
            return _list;
        }

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary> 
        /// <param name="whereLambda"></param>  
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public IQueryable<T> FindPageList(Expression<Func<T, bool>> whereLamdba, Expression<Func<T, bool>> orderByLamdba, int pageIndex, int pageSize, out int recordCount)
        {
            var q = _dbcontext.Set<T>().Where<T>(whereLamdba).OrderByDescending(orderByLamdba);
            var q1 = q.FutureCount();
            var temp = q.Skip(pageSize * (pageIndex - 1)).Take(pageSize); 
            recordCount = q1.Value;
            var list = temp.ToList();
            return list.AsQueryable();
        }
    }
}
