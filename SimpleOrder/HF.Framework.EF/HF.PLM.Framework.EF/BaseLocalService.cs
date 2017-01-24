using AutoMapper;
using AutoMapper.QueryableExtensions;
using Serialize.Linq.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HF.PLM.Pager.Entity;
using System.ServiceModel;

namespace HF.PLM.Framework.EF
{
    public class BaseLocalService<DTO, Entity> : IBaseService<DTO, Entity>
        where DTO : class
        where Entity : class
    {
        protected IBaseBLL<Entity> baseBLL = null;

        const bool TransactionScopeRequired = true;
        const bool TransactionAutoComplete = true;

        public BaseLocalService()
        {
        }

        public BaseLocalService(IBaseBLL<Entity> bll)
        {
            this.baseBLL = bll;
        }

        protected Expression<Func<Entity, bool>> ConvertExpression(ExpressionNode match)
        {
            Expression<Func<DTO, bool>> outer = match.ToBooleanExpression<DTO>(null);
            Expression<Func<Entity, DTO>> inner = Extensions.CreateMapExpression<Entity, DTO>(Mapper.Engine, null, new string[0]);
            return outer.Compose(inner);
        }

        [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        public virtual DTO InsertEx(DTO dto)
        {
            Entity t = dto.MapTo<Entity>();
            this.baseBLL.InsertEx(t);
            return t.MapTo<DTO>();
        }

        [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        public virtual IEnumerable<DTO> InsertRangeEx(IEnumerable<DTO> list)
        {
            IEnumerable<Entity> list2 = list.MapToList<Entity>();
            this.baseBLL.InsertRange(list2);

            return list2.MapToList<DTO>();
        }
        //[OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        //      public virtual async Task<bool> InsertRangeAsync(IEnumerable<DTO> list)
        //{
        //	IEnumerable<Entity> list2 = list.MapToList<Entity>();
        //	return await this.baseBLL.InsertRangeAsync(list2);
        //}
        [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        public virtual bool Update(DTO dto, object key)
        {
            Entity t = dto.MapTo<Entity>();
            return this.baseBLL.Update(t, key);
        }


        public bool UpdateEx(DTO t, object key, string[] UpdateFieldNames)
        {
            Entity ent = t.MapTo<Entity>();
            return this.baseBLL.UpdateEx(ent, key, UpdateFieldNames);
        }

        //      [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        //      public virtual async Task<bool> UpdateAsync(DTO dto, object key)
        //{
        //	Entity t = dto.MapTo<Entity>();
        //	return await this.baseBLL.UpdateAsync(t, key);
        //}
        [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        public virtual bool Delete(object id)
        {
            return this.baseBLL.Delete(id);
        }
        //      [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        //      public virtual async Task<bool> DeleteAsync(object id)
        //{
        //	return await this.baseBLL.DeleteAsync(id);
        //}
        [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        public virtual bool Delete(DTO dto)
        {
            Entity t = dto.MapTo<Entity>();
            return this.baseBLL.Delete(t);
        }
        //      [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        //      public virtual async Task<bool> DeleteAsync(DTO dto)
        //{
        //	Entity t = dto.MapTo<Entity>();
        //	return await this.baseBLL.DeleteAsync(t);
        //}
        [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        public virtual bool DeleteByExpression(ExpressionNode match)
        {
            Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
            return this.baseBLL.DeleteByExpression(match2);
        }
        //[OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        //      public virtual async Task<bool> DeleteByExpressionAsync(ExpressionNode match)
        //{
        //	Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
        //	return await this.baseBLL.DeleteByExpressionAsync(match2);
        //}
        [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        public virtual bool DeleteByCondition(string condition)
        {
            return this.baseBLL.DeleteByCondition(condition);
        }
        //      [OperationBehavior(TransactionScopeRequired = TransactionScopeRequired, TransactionAutoComplete = TransactionAutoComplete)]
        //      public virtual async Task<bool> DeleteByConditionAsync(string condition)
        //{
        //	return await this.baseBLL.DeleteByConditionAsync(condition);
        //}

        public virtual DTO FindByID(object id)
        {
            Entity entity = this.baseBLL.FindByID(id);
            return entity.MapTo<DTO>();
        }

        //public virtual async Task<DTO> FindByIDAsync(object id)
        //{
        //    Entity entity = await this.baseBLL.FindByIDAsync(id);
        //    //return await Task.FromResult<DTO>(entity.MapTo<DTO>());
        //    return entity.MapTo<DTO>();
        //}

        public virtual DTO FindSingle(ExpressionNode match)
        {
            Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
            Entity entity = this.baseBLL.FindSingle(match2);
            return entity.MapTo<DTO>();
        }

        //public virtual async Task<DTO> FindSingleAsync(ExpressionNode match)
        //{
        //    Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
        //    Entity entity = await this.baseBLL.FindSingleAsync(match2);
        //    //return await Task.FromResult<DTO>(entity.MapTo<DTO>());
        //    return entity.MapTo<DTO>();
        //}

        public virtual IList<DTO> GetAll()
        {
            IList<Entity> all = this.baseBLL.GetAll();
            return all.MapToList<Entity, DTO>();
        }

        //public virtual async Task<IList<DTO>> GetAllAsync()
        //{
        //    IList<Entity> source = await this.baseBLL.GetAllAsync();
        //    IList<DTO> result = source.MapToList<Entity, DTO>();
        //    //return await Task.FromResult<IList<DTO>>(result);
        //    return source.MapToList<Entity, DTO>();
        //}

        public virtual IList<DTO> GetAllWithPager(ref PagerInfo info)
        {
            IList<Entity> allWithPager = this.baseBLL.GetAllWithPager(info);
            return allWithPager.MapToList<Entity, DTO>();
        }

        public virtual IList<DTO> Find(ExpressionNode match)
        {
            Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
            IList<Entity> source = this.baseBLL.Find(match2);
            return source.MapToList<Entity, DTO>();
        }

        //public virtual async Task<IList<DTO>> FindAsync(ExpressionNode match)
        //{
        //    Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
        //    IList<Entity> source = await this.baseBLL.FindAsync(match2);
        //    IList<DTO> result = source.MapToList<Entity, DTO>();
        //    //return await Task.FromResult<IList<DTO>>(result);
        //    return source.MapToList<Entity, DTO>();
        //}

        public virtual IList<DTO> FindWithPager(ExpressionNode match, ref PagerInfo info)
        {
            Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
            IList<Entity> source = this.baseBLL.FindWithPager(match2, info);
            return source.MapToList<Entity, DTO>();
        }

        public virtual int GetRecordCount()
        {
            return this.baseBLL.GetRecordCount();
        }

        //public virtual async Task<int> GetRecordCountAsync()
        //{
        //    return await this.baseBLL.GetRecordCountAsync();
        //}

        public virtual int GetRecordCount(ExpressionNode match)
        {
            Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
            return this.baseBLL.GetRecordCount(match2);
        }

        //public virtual async Task<int> GetRecordCountAsync(ExpressionNode match)
        //{
        //    Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
        //    return await this.baseBLL.GetRecordCountAsync(match2);
        //}

        public bool IsExistRecord(object id)
        {
            return this.baseBLL.IsExistRecord(id);
        }

        //public virtual async Task<bool> IsExistRecordAsyn(object id)
        //{
        //    return await this.baseBLL.IsExistRecordAsyn(id);
        //}

        public virtual bool IsExistRecord(ExpressionNode match)
        {
            Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
            return this.baseBLL.IsExistRecord(match2);
        }

        //public virtual async Task<bool> IsExistRecordAsyn(ExpressionNode match)
        //{
        //    Expression<Func<Entity, bool>> match2 = this.ConvertExpression(match);
        //    return await this.baseBLL.IsExistRecordAsyn(match2);
        //}

        public virtual DataTable GetFieldTypeList()
        {
            return this.baseBLL.GetFieldTypeList();
        }

        public virtual Dictionary<string, string> GetColumnNameAlias()
        {
            return this.baseBLL.GetColumnNameAlias();
        }

        public virtual IList<string> GetFieldList(string fieldName)
        {
            return this.baseBLL.GetFieldList(fieldName);
        }

        public virtual DataTable GetReportData(string fieldName, string condition)
        {
            return this.baseBLL.GetReportData(fieldName, condition);
        }

        public virtual string DataValidate(DTO dto)
        {
            Entity t = dto.MapTo<Entity>();
            return this.baseBLL.DataValidate(t);
        }

        public OperationFeedBack<bool> DeleteWithFeedBack(DTO dto)
        {
            OperationFeedBack<Boolean> result = new OperationFeedBack<bool>();
            result.OperationResult = false;
            result.InputArguments = "dto = 【" + dto.ToString() + "】";

            Entity t = dto.MapTo<Entity>();

            try
            { result.OperationResult = this.baseBLL.Delete(t); }
            catch (Exception ex)
            {
                result.OperationSuccess = false;
                result.FailReasonDescription = "删除记录过程出现异常。";
                result.ExceptionInst = new OperationException(ex);
                return result;
            }

            result.OperationSuccess = true;
            return result;
        }



        public virtual IList<DTO> FindBySQLCommandText(string SQLCommandText)
        {
            IList<Entity> source = this.baseBLL.FindBySQLCommandText(SQLCommandText);
            return source.MapToList<Entity, DTO>();
        }
    }
}
