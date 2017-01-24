using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HF.PLM.Framework.Commons;
using HF.PLM.Pager.Entity;

namespace HF.PLM.Framework.EF
{
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : class
    {
        protected DbContext baseContext;

        protected DbSet<T> objectSet;

        [CompilerGenerated]
        private bool bool_0;

        [CompilerGenerated]
        private string OpydhLblw;

        public bool IsDescending
        {
            get;
            set;
        }

        public string SortPropertyName
        {
            get;
            set;
        }

        public virtual string DataValidate(ValidateTriggerControl controlType, T t)
        {
            if (t is IObjectValidate<T>)
                ((IObjectValidate<T>)t).Validate(controlType, this);
            return "";
        }

        protected void DataValidate(ValidateTriggerControl controlType, IEnumerable<T> t)
        {
            foreach (var s in t)
                DataValidate(controlType, s);
        }

        public virtual void BeforeDelete(T t)
        { }


        public BaseDAL(DbContext context)
        {
            this.baseContext = context;
            this.objectSet = this.baseContext.Set<T>();
            this.IsDescending = true;
            this.SortPropertyName = "ID";
        }


        public DbContext GetCurrentContext()
        {
            return baseContext;
        }

        public virtual bool Insert(T t)
        {
            Class1.smethod_1(t, "传入的对象t为空");
            string errorMessage = DataValidate(ValidateTriggerControl.Insert, t);
            if (errorMessage != null && errorMessage.Trim() != "") { throw new Exception(errorMessage); }
            BaseEntity be = t as BaseEntity;
            if (be != null)
            { 
                be.CreateTime = DateTime.Now;
                be.Oid = Guid.NewGuid();
            }
            this.objectSet.Add(t);
            return this.baseContext.SaveChanges() > 0;
        }

        public virtual T InsertEx(T t)
        {
            Class1.smethod_1(t, "传入的对象t为空");
            string errorMessage = DataValidate(ValidateTriggerControl.Insert, t);
            if (errorMessage != null && errorMessage.Trim() != "") { throw new Exception(errorMessage); }
            BaseEntity be = t as BaseEntity;
            if (be != null)
            { 
                be.CreateTime = DateTime.Now;
                be.Oid = Guid.NewGuid();
            }
            this.objectSet.Add(t);
            int sucessed = this.baseContext.SaveChanges();
            if (sucessed > 0)
            {
                return t;
            }
            else
            {
                return null;
            }
            //return this.baseContext.SaveChanges() > 0;
        }

        //public virtual async Task<bool> InsertAsync(T t)
        //{
        //	Class1.smethod_1(t, "传入的对象t为空");
        //	this.objectSet.Add(t);
        //          //return await this.baseContext.SaveChangesAsync() > 0;
        //          return false;
        //}

        public virtual bool InsertRange(IEnumerable<T> list)
        {
            Class1.smethod_1(list, "传入的对象list为空");
            DataValidate(ValidateTriggerControl.Insert, list);
            foreach (T eachRecord in list)
            {
                BaseEntity be = eachRecord as BaseEntity;
                if (be != null)
                { be.CreateTime = DateTime.Now; }
            }
            this.objectSet.AddRange(list);
            return this.baseContext.SaveChanges() > 0;
        }

        public virtual IEnumerable<T> InsertRangeEx(IEnumerable<T> list)
        {
            Class1.smethod_1(list, "传入的对象list为空");
            DataValidate(ValidateTriggerControl.Insert, list);
            foreach (T eachRecord in list)
            {
                BaseEntity be = eachRecord as BaseEntity;
                if (be != null)
                { be.CreateTime = DateTime.Now; }
            }
            this.objectSet.AddRange(list);
            int sucessed = this.baseContext.SaveChanges();
            if (sucessed > 0)
            {
                return list;
            }
            else
            {
                return null;
            }
            //return this.baseContext.SaveChanges() > 0;
        }

        //public virtual async Task<bool> InsertRangeAsync(IEnumerable<T> list)
        //{
        //	Class1.smethod_1(list, "传入的对象list为空");
        //	this.objectSet.AddRange(list);
        //          //return await this.baseContext.SaveChangesAsync() > 0;
        //          return false;
        //}

        public virtual bool Update(T t, object key)
        {
            Class1.smethod_1(t, "传入的对象t为空");
            string errorMessage = DataValidate(ValidateTriggerControl.Update, t);
            if (errorMessage != null && errorMessage.Trim() != "") { throw new Exception(errorMessage); }
            bool result = false;
            T t2 = this.objectSet.Find(new object[]
			{
				key
			});
            if (t2 != null)
            {
                this.baseContext.Entry<T>(t2).CurrentValues.SetValues(t);
                BaseEntity be = t2 as BaseEntity;
                if (be != null)
                { be.UpdateTime = DateTime.Now; }
                result = (this.baseContext.SaveChanges() > 0);
            }
            return result;
        }

        public virtual bool UpdateEx(T t, object key, string[] UpdateFieldNames)
        {
            Class1.smethod_1(t, "传入的对象t为空");
            Class1.smethod_1(UpdateFieldNames, "传入的对象UpdateFieldNames为空");
            if (UpdateFieldNames.Count() == 0) throw new ArgumentException("UpdateFieldNames至少要有一个成员");
            string errorMessage = DataValidate(ValidateTriggerControl.Update, t);
            if (errorMessage != null && errorMessage.Trim() != "") { throw new Exception(errorMessage); }

            bool result = false;
            T t2 = this.objectSet.Find(new object[]
            {
                key
            });
            if (t2 != null)
            {
                foreach (var field in UpdateFieldNames)
                {
                    this.baseContext.Entry<T>(t2).Property(field).CurrentValue = t.GetType().GetProperty(field).GetValue(t, null);
                }
                BaseEntity be = t2 as BaseEntity;
                if (be != null)
                { be.UpdateTime = DateTime.Now; }

                result = (this.baseContext.SaveChanges() > 0);
            }
            return result;
        }

        //public virtual async Task<bool> UpdateAsync(T t, object key)
        //{
        //	//Class1.smethod_1(t, "传入的对象t为空");
        //	//bool result = false;
        //	//T t2 = await this.objectSet.FindAsync(new object[]
        //	//{
        //	//	key
        //	//});
        //	//if (t2 != null)
        //	//{
        //	//	this.baseContext.Entry<T>(t2).CurrentValues.SetValues(t);
        //	//	result = (await this.baseContext.SaveChangesAsync() > 0);
        //	//}
        //	return false;
        //}

        public virtual bool Delete(object id)
        {
            T t = this.objectSet.Find(new object[]
			{
				id
			});
            BeforeDelete(t);
            this.objectSet.Remove(t);
            return this.baseContext.SaveChanges() > 0;
        }

        //public virtual async Task<bool> DeleteAsync(object id)
        //{
        //	T t = this.objectSet.Find(new object[]
        //	{
        //		id
        //	});
        //	this.objectSet.Remove(t);
        //	//return await this.baseContext.SaveChangesAsync() > 0;
        //          return false;
        //}

        public virtual bool Delete(T t)
        {
            Class1.smethod_1(t, "传入的对象t为空");
            BeforeDelete(t);

            if (this.baseContext.Entry<T>(t).State == EntityState.Detached)
            {
                this.objectSet.Attach(t);
            }
            this.objectSet.Remove(t);
            return this.baseContext.SaveChanges() > 0;
        }

        //public virtual async Task<bool> DeleteAsync(T t)
        //{
        //	this.objectSet.Remove(t);
        //          //return await this.baseContext.SaveChangesAsync() > 0;
        //          return false;
        //}

        public virtual bool DeleteByExpression(Expression<Func<T, bool>> match)
        {
            this.objectSet.Where(match).ToList<T>().ForEach(new Action<T>(this.method_2));
            return this.baseContext.SaveChanges() > 0;
        }

        //public virtual async Task<bool> DeleteByExpressionAsync(Expression<Func<T, bool>> match)
        //{
        //	this.objectSet.Where(match).ToList<T>().ForEach(new Action<T>(this.method_3));
        //	//return await this.baseContext.SaveChangesAsync() > 0;
        //          return false;
        //}

        public virtual bool DeleteByCondition(string condition)
        {
            string tableName = this.baseContext.GetTableName<T>();
            string text = string.Format("DELETE FROM {0} WHERE {1} ", tableName, condition);
            return this.baseContext.Database.ExecuteSqlCommand(text, new object[0]) > 0;
        }

        //public virtual async Task<bool> DeleteByConditionAsync(string condition)
        //{
        //    bool result = this.DeleteByCondition(condition);
        //    //return await Task.FromResult<bool>(result);
        //    return false;
        //}

        public virtual T FindByID(object id)
        {
            return this.objectSet.Find(new object[]
			{
				id
			});
        }

        //public virtual async Task<T> FindByIDAsync(object id)
        //{
        //          //return await this.objectSet.FindAsync(new object[]
        //          //{
        //          //    id
        //          //});
        //          return null;
        //}

        public virtual T FindSingle(Expression<Func<T, bool>> match)
        {
            return this.objectSet.FirstOrDefault(match);
        }

        //public virtual async Task<T> FindSingleAsync(Expression<Func<T, bool>> match)
        //{
        //	//return await QueryableExtensions.FirstOrDefaultAsync<T>(this.objectSet, match);
        //          return null;
        //}

        public virtual IQueryable<T> GetQueryable()
        {
            return this.GetQueryable(null, this.SortPropertyName, this.IsDescending);
        }

        public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> match, string sortPropertyName, bool isDescending = true)
        {
            IQueryable<T> source = this.objectSet;
            if (match != null)
            {
                source = source.Where(match);
            }
            return source.OrderBy(sortPropertyName, isDescending);
        }

        public virtual IQueryable<T> GetQueryable<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        {
            IQueryable<T> queryable = this.objectSet;
            if (match != null)
            {
                queryable = queryable.Where(match);
            }
            if (orderByProperty != null)
            {
                queryable = (isDescending ? queryable.OrderByDescending(orderByProperty) : queryable.OrderBy(orderByProperty));
            }
            else
            {
                queryable = queryable.OrderBy(this.SortPropertyName, isDescending);
            }
            return queryable;
        }

        public virtual IList<T> GetAll()
        {
            return this.GetQueryable().ToList<T>();
        }

        //public virtual async Task<IList<T>> GetAllAsync()
        //{
        //	//return await QueryableExtensions.ToListAsync<T>(this.GetQueryable());
        //          return new List<T>();
        //}

        public virtual IList<T> GetAll<TKey>(Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        {
            return this.GetQueryable<TKey>(null, orderByProperty, isDescending).ToList<T>();
        }

        //public virtual async Task<IList<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        //{
        //          //return await QueryableExtensions.ToListAsync<T>(this.GetQueryable<TKey>(null, orderByProperty, isDescending));

        //          return new List<T>();
        //}

        public virtual IList<T> GetAllWithPager(PagerInfo info)
        {
            int num = (info.CurrenetPageIndex < 1) ? 1 : info.CurrenetPageIndex;
            int num2 = (info.PageSize <= 0) ? 20 : info.PageSize;
            int count = (num - 1) * num2;
            IQueryable<T> queryable = this.GetQueryable();
            info.RecordCount = (queryable.Count<T>());
            return queryable.Skip(count).Take(num2).ToList<T>();
        }

        //public virtual async Task<IList<T>> GetAllWithPagerAsync(PagerInfo info)
        //{
        //    IList<T> allWithPager = this.GetAllWithPager(info);
        //    //return await Task.FromResult<IList<T>>(allWithPager);
        //    return new List<T>();
        //}

        public virtual IList<T> Find(Expression<Func<T, bool>> match)
        {
            IQueryable<T> source = this.GetQueryable().Where(match);
            return source.ToList<T>();
        }

        //public virtual async Task<IList<T>> FindAsync(Expression<Func<T, bool>> match)
        //{
        //	//return await QueryableExtensions.ToListAsync<T>(this.GetQueryable().Where(match));
        //          return new List<T>();
        //}

        public virtual IList<T> Find<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        {
            return this.GetQueryable<TKey>(null, orderByProperty, isDescending).Where(match).ToList<T>();
        }

        //public virtual async Task<IList<T>> FindAsync<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        //{
        //	//return await QueryableExtensions.ToListAsync<T>(this.GetQueryable<TKey>(null, orderByProperty, isDescending).Where(match));
        //          return new List<T>();
        //      }

        public virtual IList<T> FindWithPager(Expression<Func<T, bool>> match, PagerInfo info)
        {
            int num = (info.CurrenetPageIndex < 1) ? 1 : info.CurrenetPageIndex;
            int num2 = (info.PageSize <= 0) ? 20 : info.PageSize;
            int count = (num - 1) * num2;
            IQueryable<T> source = this.GetQueryable().Where(match);
            info.RecordCount = (source.Count<T>());
            return source.Skip(count).Take(num2).ToList<T>();
        }

        //public virtual async Task<IList<T>> FindWithPagerAsync(Expression<Func<T, bool>> match, PagerInfo info)
        //{
        //    IList<T> result = this.FindWithPager(match, info);
        //    //return await Task.FromResult<IList<T>>(result);
        //    return new List<T>();
        //}

        public virtual IList<T> FindWithPager<TKey>(Expression<Func<T, bool>> match, PagerInfo info, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        {
            int num = (info.CurrenetPageIndex < 1) ? 1 : info.CurrenetPageIndex;
            int num2 = (info.PageSize <= 0) ? 20 : info.PageSize;
            int count = (num - 1) * num2;
            IQueryable<T> source = this.objectSet.Where(match);
            info.RecordCount = (source.Count<T>());
            if (orderByProperty != null)
            {
                source = (isDescending ? source.OrderByDescending(orderByProperty) : source.OrderBy(orderByProperty));
            }
            return source.Skip(count).Take(num2).ToList<T>();
        }

        public virtual int GetRecordCount()
        {
            return this.objectSet.Count<T>();
        }

        //public virtual async Task<int> GetRecordCountAsync()
        //{
        //	//return await QueryableExtensions.CountAsync<T>(this.objectSet);
        //          return 0;
        //}

        public virtual int GetRecordCount(Expression<Func<T, bool>> match)
        {
            return this.objectSet.Where(match).Count<T>();
        }

        //public virtual async Task<int> GetRecordCountAsync(Expression<Func<T, bool>> match)
        //{
        //	//return await QueryableExtensions.CountAsync<T>(this.objectSet.Where(match));
        //          return 0;
        //}

        public bool IsExistRecord(object id)
        {
            T t = this.objectSet.Find(new object[]
			{
				id
			});
            return t != null;
        }

        //public virtual async Task<bool> IsExistRecordAsyn(object id)
        //{
        //    //Task<T> task = this.objectSet.FindAsync(new object[]
        //    //{
        //    //    id
        //    //});
        //    //return await Task.FromResult<bool>(task != null);
        //    return false;
        //}

        public virtual bool IsExistRecord(Expression<Func<T, bool>> match)
        {
            return this.objectSet.Where(match).Count<T>() > 0;
        }

        //public virtual async Task<bool> IsExistRecordAsyn(Expression<Func<T, bool>> match)
        //{
        //          //return await QueryableExtensions.CountAsync<T>(this.objectSet.Where(match)) > 0;
        //          return false;
        //}

        public virtual Dictionary<string, string> GetColumnNameAlias()
        {
            return new Dictionary<string, string>();
        }

        public virtual IList<string> GetFieldList(string fieldName)
        {
            string tableName = this.baseContext.GetTableName<T>();
            string sql = string.Format("Select distinct {0} from {1} order by {2} {3} ", new object[]
			{
				fieldName,
				tableName,
				this.SortPropertyName,
				this.IsDescending ? "desc" : "asc"
			});
            return this.SqlValueList(sql, new object[0]);
        }

        public virtual IList<string> GetFieldList(Expression<Func<T, string>> fieldNameKey)
        {
            return this.GetQueryable().Select(fieldNameKey).ToList<string>();
        }

        public virtual int SqlExecute(string sql, params object[] parameters)
        {
            return this.baseContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public virtual IList<string> SqlValueList(string sql, params object[] parameters)
        {
            if (this.HasInjectionData(sql))
            {
                LogTextHelper.Error(string.Format("检测出SQL注入的恶意数据, {0}", sql));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            DbRawSqlQuery<string> source = this.baseContext.Database.SqlQuery<string>(sql, parameters);
            return source.ToList<string>();
        }

        public virtual DataTable SqlTable(string sql, params object[] parameters)
        {
            if (this.HasInjectionData(sql))
            {
                LogTextHelper.Error(string.Format("检测出SQL注入的恶意数据, {0}", sql));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            DataTable dataTable = new DataTable();
            try
            {
                DbConnection connection = this.baseContext.Database.Connection;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (DbCommand dbCommand = connection.CreateCommand())
                {
                    dbCommand.CommandText = sql;
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.Parameters.AddRange(parameters);
                    using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                    {
                        dataTable.Load(dbDataReader);
                    }
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                throw ex;
            }
            return dataTable;
        }

        public virtual DataTable GetFieldTypeList()
        {
            string tableName = this.baseContext.GetTableName<T>();
            DataTable dataTable = DataTableHelper.CreateTable("ColumnName,DataType");
            DataTable dataTable2 = this.method_0(tableName);
            if (dataTable2 != null)
            {
                foreach (DataRow dataRow in dataTable2.Rows)
                {
                    string value = dataRow["ColumnName"].ToString().ToUpper();
                    string value2 = dataRow["DataType"].ToString().ToLower();
                    DataRow dataRow2 = dataTable.NewRow();
                    dataRow2["ColumnName"] = value;
                    dataRow2["DataType"] = value2;
                    dataTable.Rows.Add(dataRow2);
                }
            }
            if (dataTable != null)
            {
                dataTable.TableName = "tableName";
            }
            return dataTable;
        }

        private DataTable method_0(string string_0)
        {
            DataTable result = null;
            string commandText = string.Format("Select * FROM {0}", string_0);
            try
            {
                DbConnection connection = this.baseContext.Database.Connection;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (DbCommand dbCommand = connection.CreateCommand())
                {
                    dbCommand.CommandText = commandText;
                    dbCommand.CommandType = CommandType.Text;
                    using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                    {
                        result = dbDataReader.GetSchemaTable();
                    }
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
            }
            return result;
        }

        public virtual DataTable GetReportData(string fieldName, string condition)
        {
            string tableName = this.baseContext.GetTableName<T>();
            string arg = "";
            if (!string.IsNullOrEmpty(condition))
            {
                arg = string.Format("Where {0}", condition);
            }
            string sql = string.Format("select {0} as argument, count(*) as datavalue from {1} {2} group by {0} order by count(*) desc", fieldName, tableName, arg);
            return this.SqlTable(sql, new object[0]);
        }

        public virtual bool HasInjectionData(string inputData)
        {
            return !string.IsNullOrEmpty(inputData) && Regex.IsMatch(inputData.ToLower(), this.method_1());
        }

        private string method_1()
        {
            string[] array = new string[]
			{
				" insert\\s",
				" delete\\s",
				" update\\s",
				" drop\\s",
				" truncate\\s",
				" exec\\s",
				" declare\\s",
				" mid\\(",
				" char\\(",
				" net user",
				" xp_cmdshell",
				" /add\\s",
				" exec master.dbo.xp_cmdshell",
				" net localgroup administrators"
			};
            string str = ".*(";
            for (int i = 0; i < array.Length - 1; i++)
            {
                str = str + array[i] + "|";
            }
            return str + array[array.Length - 1] + ").*";
        }

        [CompilerGenerated]
        private void method_2(T d)
        {
            this.baseContext.Entry<T>(d).State = EntityState.Deleted;
        }

        [CompilerGenerated]
        private void method_3(T d)
        {
            this.baseContext.Entry<T>(d).State = EntityState.Deleted;
        }

        /// <summary>
        /// 通过SQL语句查询实体类集合（SQL语句的查询结果的第一列必须为所查询的实体类的主键字段）
        /// </summary>
        /// <param name="SQLCommandText"></param>
        /// <returns></returns>
        public IList<T> FindBySQLCommandText(string SQLCommandText)
        {
            List<int> idList = new List<int>();
            try
            {
                DbConnection connection = this.baseContext.Database.Connection;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (DbCommand dbCommand = connection.CreateCommand())
                {
                    dbCommand.CommandText = SQLCommandText;
                    dbCommand.CommandType = CommandType.Text;
                    using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                    {
                        if (dbDataReader.FieldCount > 0)
                        {
                            bool TypeValidJudged = false;
                            bool TypeValid = false;
                            while (dbDataReader.Read())
                            {
                                if (!TypeValidJudged)
                                {
                                    TypeValid = (dbDataReader.GetFieldType(0) == typeof(int));
                                    TypeValidJudged = true;
                                }

                                if (!TypeValid) { break; }
                                if (dbDataReader.IsDBNull(0)) { continue; }

                                int eachID = dbDataReader.GetInt32(0);
                                idList.Add(eachID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                throw ex;
            }

            List<T> result = new List<T>();
            for (int i = 0; i < idList.Count; i++)
            {
                T eachobj = this.FindByID(idList[i]);
                result.Add(eachobj);
            }

            return result;
        }
    }
}
