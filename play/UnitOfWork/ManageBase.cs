using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace play.UnitOfWork
{
    public abstract class ManageBase<T> where T : class
    {
        protected Models.SchoolContext _context;
        public ManageBase(Models.SchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 插入
        /// </summary>
        public abstract T Insert(T entity,bool save=true);
        /// <summary>
        /// 更新
        /// </summary>
        public abstract T Update(T entity, bool save = true);
        /// <summary>
        /// 删除
        /// </summary>
        public abstract T Delete(T entity, bool save = true);
        /// <summary>
        /// 如果不存在则插入，否则返回已存在的实体
        /// </summary>
        /// <param name="entity">如果不存在时插入的实体</param>
        /// <param name="predicate">筛选条件（where条件）</param>
        /// <returns></returns>
        public T CreateIfNotExist(T entity, System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = Items.Where(predicate).FirstOrDefault();
            if (result == null)
            {
                return Insert(entity);
            }
            return result;
        }
        public DbSet<T> Items
        {
            get
            {
                return _context.Set<T>();
            }
        }
    }
}