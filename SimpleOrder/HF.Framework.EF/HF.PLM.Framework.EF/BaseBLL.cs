using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HF.PLM.Pager.Entity;

namespace HF.PLM.Framework.EF
{
	public abstract class BaseBLL<T> : IBaseBLL<T> where T : class
	{
		private static readonly object object_0 = new object();

		[CompilerGenerated]
		private IBaseDAL<T> ibaseDAL_0;

		[CompilerGenerated]
		private IUnityContainer iunityContainer_0;

		protected IBaseDAL<T> baseDAL
		{
			get;
			set;
		}

		protected IUnityContainer container
		{
			get;
			set;
		}

		public BaseBLL()
		{
			lock (BaseBLL<T>.object_0)
			{
				Assembly assembly = typeof(T).Assembly;
				Class2 @class = Class2.smethod_0(assembly);
				this.container = @class.method_0();
				if (this.container == null)
				{
					throw new ArgumentNullException("container", "container没有初始化");
				}
			}
		}

		public BaseBLL(IBaseDAL<T> dal)
		{
			this.baseDAL = dal;
		}

		public virtual bool Insert(T t)
		{
			return this.baseDAL.Insert(t);
		}

        public virtual T InsertEx(T t)
        {
            this.baseDAL.Insert(t);
            return t;
        }

		//public virtual async Task<bool> InsertAsync(T t)
		//{
		//	return await this.baseDAL.InsertAsync(t);
		//}

		public virtual bool InsertRange(IEnumerable<T> list)
		{
			return this.baseDAL.InsertRange(list);
		}

        public virtual IEnumerable<T> InsertRangeEx(IEnumerable<T> list)
        {
            this.baseDAL.InsertRange(list);
            return list;
        }

		//public virtual async Task<bool> InsertRangeAsync(IEnumerable<T> list)
		//{
		//	return await this.baseDAL.InsertRangeAsync(list);
		//}

		public virtual bool Update(T t, object key)
		{
			return this.baseDAL.Update(t, key);
		}

        public bool UpdateEx(T t, object key, string[] UpdateFieldNames)
        {
            return this.baseDAL.UpdateEx(t, key, UpdateFieldNames);
        }

		//public virtual async Task<bool> UpdateAsync(T t, object key)
		//{
		//	return await this.baseDAL.UpdateAsync(t, key);
		//}

		public virtual bool Delete(object id)
		{
			return this.baseDAL.Delete(id);
		}

		//public virtual async Task<bool> DeleteAsync(object id)
		//{
		//	return await this.baseDAL.DeleteAsync(id);
		//}

		public virtual bool Delete(T t)
		{
			return this.baseDAL.Delete(t);
		}

		//public virtual async Task<bool> DeleteAsync(T t)
		//{
		//	return await this.baseDAL.DeleteAsync(t);
		//}

		public virtual bool DeleteByExpression(Expression<Func<T, bool>> match)
		{
			return this.baseDAL.DeleteByExpression(match);
		}

		//public virtual async Task<bool> DeleteByExpressionAsync(Expression<Func<T, bool>> match)
		//{
		//	return await this.baseDAL.DeleteByExpressionAsync(match);
		//}

		public virtual bool DeleteByCondition(string condition)
		{
			return this.baseDAL.DeleteByCondition(condition);
		}

		//public virtual async Task<bool> DeleteByConditionAsync(string condition)
		//{
		//	return await this.baseDAL.DeleteByConditionAsync(condition);
		//}

		public virtual T FindByID(object id)
		{
			return this.baseDAL.FindByID(id);
		}

		//public virtual async Task<T> FindByIDAsync(object id)
		//{
		//	return await this.baseDAL.FindByIDAsync(id);
		//}

		public virtual T FindSingle(Expression<Func<T, bool>> match)
		{
			return this.baseDAL.FindSingle(match);
		}

		//public virtual async Task<T> FindSingleAsync(Expression<Func<T, bool>> match)
		//{
		//	return await this.baseDAL.FindSingleAsync(match);
		//}

		public virtual IQueryable<T> GetQueryable()
		{
			return this.baseDAL.GetQueryable();
		}

		public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> match, string sortPropertyName, bool isDescending = true)
		{
			return this.baseDAL.GetQueryable(match, sortPropertyName, isDescending);
		}

		public virtual IQueryable<T> GetQueryable<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
		{
			return this.baseDAL.GetQueryable<TKey>(match, orderByProperty, isDescending);
		}

		public virtual IList<T> GetAll()
		{
			return this.baseDAL.GetAll();
		}

		//public virtual async Task<IList<T>> GetAllAsync()
		//{
		//	return await this.baseDAL.GetAllAsync();
		//}

		public virtual IList<T> GetAll<TKey>(Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
		{
			return this.baseDAL.GetAll<TKey>(orderByProperty, isDescending);
		}

		//public virtual async Task<IList<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
		//{
		//	return await this.baseDAL.GetAllAsync<TKey>(orderByProperty, isDescending);
		//}

		public virtual IList<T> GetAllWithPager(PagerInfo info)
		{
			return this.baseDAL.GetAllWithPager(info);
		}

		//public virtual async Task<IList<T>> GetAllWithPagerAsync(PagerInfo info)
		//{
		//	return await this.baseDAL.GetAllWithPagerAsync(info);
		//}

		public virtual IList<T> Find(Expression<Func<T, bool>> match)
		{
			return this.baseDAL.Find(match);
		}

		//public virtual async Task<IList<T>> FindAsync(Expression<Func<T, bool>> match)
		//{
		//	return await this.baseDAL.FindAsync(match);
		//}

		public virtual IList<T> Find<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
		{
			return this.baseDAL.Find<TKey>(match, orderByProperty, isDescending);
		}

		//public virtual async Task<IList<T>> FindAsync<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
		//{
		//	return await this.baseDAL.FindAsync<TKey>(match, orderByProperty, isDescending);
		//}

		public virtual IList<T> FindWithPager(Expression<Func<T, bool>> match, PagerInfo info)
		{
			return this.baseDAL.FindWithPager(match, info);
		}

		//public virtual async Task<IList<T>> FindWithPagerAsync(Expression<Func<T, bool>> match, PagerInfo info)
		//{
		//	return await this.baseDAL.FindWithPagerAsync(match, info);
		//}

		public virtual IList<T> FindWithPager<TKey>(Expression<Func<T, bool>> match, PagerInfo info, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
		{
			return this.baseDAL.FindWithPager<TKey>(match, info, orderByProperty, isDescending);
		}

		public virtual int GetRecordCount()
		{
			return this.baseDAL.GetRecordCount();
		}

		//public virtual async Task<int> GetRecordCountAsync()
		//{
		//	return await this.baseDAL.GetRecordCountAsync();
		//}

		public virtual int GetRecordCount(Expression<Func<T, bool>> match)
		{
			return this.baseDAL.GetRecordCount(match);
		}

		//public virtual async Task<int> GetRecordCountAsync(Expression<Func<T, bool>> match)
		//{
		//	return await this.baseDAL.GetRecordCountAsync(match);
		//}

		public bool IsExistRecord(object id)
		{
			return this.baseDAL.IsExistRecord(id);
		}

		//public virtual async Task<bool> IsExistRecordAsyn(object id)
		//{
		//	return await this.baseDAL.IsExistRecordAsyn(id);
		//}

		public virtual bool IsExistRecord(Expression<Func<T, bool>> match)
		{
			return this.baseDAL.IsExistRecord(match);
		}

		//public virtual async Task<bool> IsExistRecordAsyn(Expression<Func<T, bool>> match)
		//{
		//	return await this.baseDAL.IsExistRecordAsyn(match);
		//}

		public virtual int SqlExecute(string sql, params object[] parameters)
		{
			return this.baseDAL.SqlExecute(sql, parameters);
		}

		public virtual IList<string> SqlValueList(string sql, params object[] parameters)
		{
			return this.baseDAL.SqlValueList(sql, parameters);
		}

		public virtual DataTable SqlTable(string sql, params object[] parameters)
		{
			return this.baseDAL.SqlTable(sql, parameters);
		}

		public virtual DataTable GetFieldTypeList()
		{
			return this.baseDAL.GetFieldTypeList();
		}

		public virtual Dictionary<string, string> GetColumnNameAlias()
		{
			return this.baseDAL.GetColumnNameAlias();
		}

		public virtual IList<string> GetFieldList(string fieldName)
		{
			return this.baseDAL.GetFieldList(fieldName);
		}

		public virtual IList<string> GetFieldList(Expression<Func<T, string>> fieldNameKey)
		{
			return this.baseDAL.GetFieldList(fieldNameKey);
		}

		public virtual DataTable GetReportData(string fieldName, string condition)
		{
			return this.baseDAL.GetReportData(fieldName, condition);
		}

        public virtual string GetDataError(T t)
        {
            return "";
        }

        /// <summary>
        /// 通过SQL语句查询实体类集合（SQL语句的查询结果的第一列必须为所查询的实体类的主键字段）
        /// </summary>
        /// <param name="SQLCommandText"></param>
        /// <returns></returns>
        public IList<T> FindBySQLCommandText(string SQLCommandText)
        {
            return this.baseDAL.FindBySQLCommandText(SQLCommandText);
        }


        public string DataValidate(T t)
        {
            return this.baseDAL.DataValidate(ValidateTriggerControl.Update, t);
        }
    }
}
