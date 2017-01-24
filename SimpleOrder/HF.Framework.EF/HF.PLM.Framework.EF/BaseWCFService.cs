using AutoMapper;
using AutoMapper.QueryableExtensions;
using Serialize.Linq.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Threading.Tasks;
using HF.PLM.Framework.Commons;
using HF.PLM.Pager.Entity;
using System.Transactions;

namespace HF.PLM.Framework.EF
{
    public class BaseWCFService<DTO, Entity> : IBaseService<DTO, Entity>
        where DTO : class
        where Entity : class
    {
        private AppConfig appConfig_0 = new AppConfig();

        protected string configurationPath = "WcfConfig.config";

        protected string endpointConfigurationName = "";

        public BaseWCFService()
        {
        }

        public BaseWCFService(string endpointConfigurationName, string configurationPath)
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected virtual IBaseService<DTO, Entity> CreateClient()
        {
            return null;
        }

        protected Expression<Func<Entity, bool>> ConvertExpression(ExpressionNode match)
        {
            Expression<Func<DTO, bool>> outer = match.ToBooleanExpression<DTO>(null);
            Expression<Func<Entity, DTO>> inner = Mapper.Engine.CreateMapExpression<Entity, DTO>(null, new string[0]);
            return outer.Compose(inner);
        }

        public virtual DTO InsertEx(DTO dto)
        {
            DTO result = null;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            //string dataerror = service.GetDataError(dto);
            //if ((dataerror != null) && (dataerror != "")) { throw new FaultException<BaseError>(new BaseError(dataerror), new FaultReason(dataerror)); }
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.InsertEx(dto);
            });
            return result;

        }





        /// <summary>
        /// 插入复数条数据记录
        /// </summary>
        /// <param name="list">新记录集合</param>
        /// <returns>插入后的数据记录集合</returns>
        /// <remarks>
        /// ★使用该方法的时候需要注意，请保证list中的所有对象相互都是数据合法的
        /// 例如，假设合法性校验需要保证【名称】属性不重复，则不能在参数list的中出现多个对象具有相同的【名称】。
        /// 该方法无法阻止这类数据的存储，请开发者自行在调用本方法前进行数据校验
        /// </remarks>
        public virtual IEnumerable<DTO> InsertRangeEx(IEnumerable<DTO> list)
        {
            IEnumerable<DTO> result = null;
            IBaseService<DTO, Entity> service = this.CreateClient();
            //foreach (DTO dto in list)
            //{
            //    string dataerror = service.GetDataError(dto);
            //    if ((dataerror != null) && (dataerror != "")) { throw new Exception(dataerror); }
            //}
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.InsertRangeEx(list);
            });
            return result;
        }

        //public virtual async Task<bool> InsertRangeAsync(IEnumerable<DTO> list)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //        service.InsertRangeAsync(list);
        //    });
        //    return false;
        //}

        public virtual bool Update(DTO dto, object key)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            //string dataerror = service.GetDataError(dto);
            //if ((dataerror != null) && (dataerror != "")) { throw new FaultException<BaseError>(new BaseError(dataerror), new FaultReason(dataerror)); }
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.Update(dto, key);
            });
            return result;
        }


        public bool UpdateEx(DTO t, object key, string[] UpdateFieldNames)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.UpdateEx(t, key, UpdateFieldNames);
            });
            return result;
        }

        //public virtual async Task<bool> UpdateAsync(DTO dto, object key)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //         service.UpdateAsync(dto, key);
        //    });
        //    return false;
        //}

        public virtual bool Delete(object id)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.Delete(id);
            });
            return result;
        }

        //public virtual async Task<bool> DeleteAsync(object id)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //         service.DeleteAsync(id);
        //    });
        //    return false;
        //}

        public virtual bool Delete(DTO dto)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.Delete(dto);
            });
            return result;
        }

        //public virtual async Task<bool> DeleteAsync(DTO dto)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //        service.DeleteAsync(dto);
        //    });
        //    return false;
        //}

        public virtual bool DeleteByExpression(ExpressionNode match)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.DeleteByExpression(match);
            });
            return result;
        }

        //public virtual async Task<bool> DeleteByExpressionAsync(ExpressionNode match)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //          service.DeleteByExpressionAsync(match);
        //    });
        //    return false;
        //}

        public virtual bool DeleteByCondition(string condition)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.DeleteByCondition(condition);
            });
            return result;
        }

        //public virtual async Task<bool> DeleteByConditionAsync(string condition)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //         service.DeleteByConditionAsync(condition);
        //    });
        //    return false;
        //}

        public virtual DTO FindByID(object id)
        {
            DTO result = default(DTO);
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.FindByID(id);
            });
            return result;
        }

        //public virtual async Task<DTO> FindByIDAsync(object id)
        //{
        //    Task<DTO> result = null;
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //        result = service.FindByIDAsync(id);
        //    });
        //    return await result;
        //}

        public virtual DTO FindSingle(ExpressionNode match)
        {
            DTO result = default(DTO);
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.FindSingle(match);
            });
            return result;
        }

        //public virtual async Task<DTO> FindSingleAsync(ExpressionNode match)
        //{
        //    Task<DTO> result = null;
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //        result = service.FindSingleAsync(match);
        //    });
        //    return await result;
        //}

        public virtual IList<DTO> GetAll()
        {
            IList<DTO> result = null;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetAll();
            });
            return result;
        }

        //public virtual async Task<IList<DTO>> GetAllAsync()
        //{
        //    Task<IList<DTO>> result = null;
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //        result = service.GetAllAsync();
        //    });
        //    return await result;
        //}

        public virtual IList<DTO> GetAllWithPager(ref PagerInfo info)
        {
            IList<DTO> result = null;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            PagerInfo pagerInfo = info;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetAllWithPager(ref pagerInfo);
            });
            info.RecordCount = (pagerInfo.RecordCount);
            return result;
        }

        public virtual IList<DTO> Find(ExpressionNode match)
        {
            IList<DTO> result = null;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.Find(match);
            });
            return result;
        }

        //public virtual async Task<IList<DTO>> FindAsync(ExpressionNode match)
        //{
        //    Task<IList<DTO>> result = null;
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //        result = service.FindAsync(match);
        //    });
        //    return await result;
        //}

        public virtual IList<DTO> FindWithPager(ExpressionNode match, ref PagerInfo info)
        {
            IList<DTO> result = null;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            PagerInfo pagerInfo = info;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.FindWithPager(match, ref pagerInfo);
            });
            info.RecordCount = (pagerInfo.RecordCount);
            return result;
        }

        public virtual int GetRecordCount()
        {
            int result = 0;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetRecordCount();
            });
            return result;
        }

        //public virtual async Task<int> GetRecordCountAsync()
        //{
        //    //Task<int> result = Task.FromResult<int>(0);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //          service.GetRecordCountAsync();
        //    });
        //    return 0;
        //}

        public virtual int GetRecordCount(ExpressionNode match)
        {
            int result = 0;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetRecordCount(match);
            });
            return result;
        }

        //public virtual async Task<int> GetRecordCountAsync(ExpressionNode match)
        //{
        //    //Task<int> result = Task.FromResult<int>(0);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //         service.GetRecordCountAsync(match);
        //    });
        //    return 0;
        //}

        public bool IsExistRecord(object id)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.IsExistRecord(id);
            });
            return result;
        }

        //public virtual async Task<bool> IsExistRecordAsyn(object id)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //         service.IsExistRecordAsyn(id);
        //    });
        //    return false;
        //}

        public virtual bool IsExistRecord(ExpressionNode match)
        {
            bool result = false;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.IsExistRecord(match);
            });
            return result;
        }

        //public virtual async Task<bool> IsExistRecordAsyn(ExpressionNode match)
        //{
        //    //Task<bool> result = Task.FromResult<bool>(false);
        //    IBaseService<DTO, Entity> service = this.CreateClient();
        //    ICommunicationObject communicationObject = service as ICommunicationObject;
        //    ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate (ICommunicationObject client)
        //    {
        //          service.IsExistRecordAsyn(match);
        //    });
        //    return false;
        //}

        public virtual DataTable GetFieldTypeList()
        {
            DataTable result = new DataTable();
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetFieldTypeList();
            });
            return result;
        }

        public virtual Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetColumnNameAlias();
            });
            return result;
        }

        public virtual IList<string> GetFieldList(string fieldName)
        {
            IList<string> result = new List<string>();
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetFieldList(fieldName);
            });
            return result;
        }

        public virtual DataTable GetReportData(string fieldName, string condition)
        {
            DataTable result = new DataTable();
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.GetReportData(fieldName, condition);
            });
            return result;
        }

        /// <summary>
        /// 返回数据校验结果
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>若返回结果为有内容的字符串，则其内容为数据校验不通过的原因</returns>
        public virtual string DataValidate(DTO dto)
        {
            string result = "";
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.DataValidate(dto);
            });
            return result;
        }

        #region 扩展实验用方法
        public OperationFeedBack<bool> DeleteWithFeedBack(DTO dto)
        {
            OperationFeedBack<Boolean> result = null;

            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.DeleteWithFeedBack(dto); 
            });

            return result;
        }
        #endregion


        public virtual IList<DTO> FindBySQLCommandText(string SQLCommandText)
        {
            IList<DTO> result = null;
            IBaseService<DTO, Entity> service = this.CreateClient();
            ICommunicationObject communicationObject = service as ICommunicationObject;
            ExtensionMethod.UsingEx<ICommunicationObject>(communicationObject, delegate(ICommunicationObject client)
            {
                result = service.FindBySQLCommandText(SQLCommandText);
            });
            return result;
        }


    }
}
