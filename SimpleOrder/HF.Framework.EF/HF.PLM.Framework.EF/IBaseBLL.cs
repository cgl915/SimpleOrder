using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HF.PLM.Pager.Entity;

namespace HF.PLM.Framework.EF
{
	public interface IBaseBLL<T> where T : class
	{
		bool Insert(T t);

        T InsertEx(T t);

		//Task<bool> InsertAsync(T t);

		bool InsertRange(IEnumerable<T> list);

        IEnumerable<T> InsertRangeEx(IEnumerable<T> list);

		//Task<bool> InsertRangeAsync(IEnumerable<T> list);

		bool Update(T t, object key);

        bool UpdateEx(T t, object key, string[] UpdateFieldNames);

		//Task<bool> UpdateAsync(T t, object key);

		bool Delete(object id);

		//Task<bool> DeleteAsync(object id);

		bool Delete(T t);

		//Task<bool> DeleteAsync(T t);

		bool DeleteByExpression(Expression<Func<T, bool>> match);

		//Task<bool> DeleteByExpressionAsync(Expression<Func<T, bool>> match);

		bool DeleteByCondition(string condition);

		//Task<bool> DeleteByConditionAsync(string condition);

		T FindByID(object id);

		//Task<T> FindByIDAsync(object id);

		T FindSingle(Expression<Func<T, bool>> match);

		//Task<T> FindSingleAsync(Expression<Func<T, bool>> match);

		IQueryable<T> GetQueryable();

		IQueryable<T> GetQueryable(Expression<Func<T, bool>> match, string sortPropertyName, bool isDescending = true);

		IQueryable<T> GetQueryable<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);

		IList<T> GetAll();

		//Task<IList<T>> GetAllAsync();

		IList<T> GetAll<TKey>(Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);

		//Task<IList<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);

		IList<T> GetAllWithPager(PagerInfo info);

		//Task<IList<T>> GetAllWithPagerAsync(PagerInfo info);

		IList<T> Find(Expression<Func<T, bool>> match);

		//Task<IList<T>> FindAsync(Expression<Func<T, bool>> match);

        IList<T> Find<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);

        /// <summary>
        /// 通过SQL语句查询实体类集合（SQL语句的查询结果的第一列必须为所查询的实体类的主键字段）
        /// </summary>
        /// <param name="SQLCommandText"></param>
        /// <returns></returns>
        IList<T> FindBySQLCommandText(string SQLCommandText);

		//Task<IList<T>> FindAsync<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);

		IList<T> FindWithPager(Expression<Func<T, bool>> match, PagerInfo info);

		IList<T> FindWithPager<TKey>(Expression<Func<T, bool>> match, PagerInfo info, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);

		int GetRecordCount();

		//Task<int> GetRecordCountAsync();

		int GetRecordCount(Expression<Func<T, bool>> match);

		//Task<int> GetRecordCountAsync(Expression<Func<T, bool>> match);

		bool IsExistRecord(object id);

		//Task<bool> IsExistRecordAsyn(object id);

		bool IsExistRecord(Expression<Func<T, bool>> match);

		//Task<bool> IsExistRecordAsyn(Expression<Func<T, bool>> match);

		int SqlExecute(string sql, params object[] parameters);

		IList<string> SqlValueList(string sql, params object[] parameters);

		DataTable SqlTable(string sql, params object[] parameters);

		DataTable GetFieldTypeList();

		Dictionary<string, string> GetColumnNameAlias();

		IList<string> GetFieldList(string fieldName);

		IList<string> GetFieldList(Expression<Func<T, string>> fieldNameKey);

		DataTable GetReportData(string fieldName, string condition);

        string DataValidate(T t);
	}
}
