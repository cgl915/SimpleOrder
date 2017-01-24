using Serialize.Linq.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;
using HF.PLM.Pager.Entity;

namespace HF.PLM.Framework.EF
{
    [ServiceKnownType(typeof(BaseDTO))]
    [ServiceContract]
    public interface IBaseService<DTO, Entity>
        where DTO : class
        where Entity : class
    {
        [FaultContract(typeof(BaseError))]
        [OperationContract(Name = "InsertEx")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DTO InsertEx(DTO dto);

        [FaultContract(typeof(BaseError))]
        [OperationContract(Name = "InsertRangeEx")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IEnumerable<DTO> InsertRangeEx(IEnumerable<DTO> list);

        //[OperationContract(Name = "InsertRangeAsync")]
        //      [TransactionFlow(TransactionFlowOption.Allowed)]
        //      Task<bool> InsertRangeAsync(IEnumerable<DTO> list);

        [FaultContract(typeof(BaseError))]
        [OperationContract(Name = "Update")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Update(DTO dto, object key);

        [OperationContract(Name = "UpdateEx")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool UpdateEx(DTO t, object key, string[] UpdateFieldNames);

        //[OperationContract(Name = "UpdateAsync")]
        //      [TransactionFlow(TransactionFlowOption.Allowed)]
        //      Task<bool> UpdateAsync(DTO dto, object key);

        [FaultContract(typeof(BaseError))]
        [OperationContract(Name = "Delete")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Delete(object id);

        //[OperationContract(Name = "DeleteAsync")]
        //      [TransactionFlow(TransactionFlowOption.Allowed)]
        //      Task<bool> DeleteAsync(object id);

        [OperationContract(Name = "Delete2")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Delete(DTO dto);

        //[OperationContract(Name = "DeleteAsync2")]
        //      [TransactionFlow(TransactionFlowOption.Allowed)]
        //      Task<bool> DeleteAsync(DTO dto);

        [OperationContract(Name = "DeleteByExpression")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteByExpression(ExpressionNode match);

        //[OperationContract(Name = "DeleteByExpressionAsync")]
        //      [TransactionFlow(TransactionFlowOption.Allowed)]
        //      Task<bool> DeleteByExpressionAsync(ExpressionNode match);

        [OperationContract(Name = "DeleteByCondition")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteByCondition(string condition);

        //[OperationContract(Name = "DeleteByConditionAsync")]
        //      [TransactionFlow(TransactionFlowOption.Allowed)]
        //      Task<bool> DeleteByConditionAsync(string condition);

        [OperationContract(Name = "FindByID")]
        DTO FindByID(object id);

        //[OperationContract(Name = "FindByIDAsync")]
        //      Task<DTO> FindByIDAsync(object id);

        [OperationContract(Name = "FindSingle")]
        DTO FindSingle(ExpressionNode match);

        //[OperationContract(Name = "FindSingleAsync")]
        //      Task<DTO> FindSingleAsync(ExpressionNode match);

        [OperationContract(Name = "GetAll")]
        IList<DTO> GetAll();

        //[OperationContract(Name = "GetAllAsync")]
        //      Task<IList<DTO>> GetAllAsync();

        [OperationContract(Name = "GetAllWithPager")]
        IList<DTO> GetAllWithPager(ref PagerInfo info);

        [OperationContract(Name = "Find")]
        IList<DTO> Find(ExpressionNode match);

        /// <summary>
        /// ͨ��SQL����ѯʵ���༯�ϣ�SQL���Ĳ�ѯ����ĵ�һ�б���Ϊ����ѯ��ʵ����������ֶΣ�
        /// </summary>
        /// <param name="SQLCommandText"></param>
        /// <returns></returns>
        [OperationContract(Name = "FindBySQLCommandText")]
        IList<DTO> FindBySQLCommandText(string SQLCommandText);

        //[OperationContract(Name = "FindAsync")]
        //      Task<IList<DTO>> FindAsync(ExpressionNode match);

        [OperationContract(Name = "FindWithPager")]
        IList<DTO> FindWithPager(ExpressionNode match, ref PagerInfo info);

        [OperationContract(Name = "GetRecordCount")]
        int GetRecordCount();

        //[OperationContract(Name = "GetRecordCountAsync")]
        //      Task<int> GetRecordCountAsync();

        [OperationContract(Name = "GetRecordCount2")]
        int GetRecordCount(ExpressionNode match);

        //[OperationContract(Name = "GetRecordCountAsync2")]
        //      Task<int> GetRecordCountAsync(ExpressionNode match);

        [OperationContract(Name = "IsExistRecord")]
        bool IsExistRecord(object id);

        //[OperationContract(Name = "IsExistRecordAsyn")]
        //      Task<bool> IsExistRecordAsyn(object id);

        [OperationContract(Name = "IsExistRecord2")]
        bool IsExistRecord(ExpressionNode match);

        //[OperationContract(Name = "IsExistRecordAsyn2")]
        //      Task<bool> IsExistRecordAsyn(ExpressionNode match);

        [OperationContract(Name = "GetFieldTypeList")]
        DataTable GetFieldTypeList();

        [OperationContract(Name = "GetColumnNameAlias")]
        Dictionary<string, string> GetColumnNameAlias();

        IList<string> GetFieldList(string fieldName);

        [OperationContract(Name = "GetReportData")]
        DataTable GetReportData(string fieldName, string condition);

        [OperationContract(Name = "DataValidate")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string DataValidate(DTO dto);

        #region ��չʵ���÷���
        ////20160812 ZJ ����Ϥ3.0�ܹ��Ĺ����У�Ϊ��֤�Լ�������⣬�Զ�����һЩ��չ�Ĺ��ܻ����ԣ���ʱ��������������У����պ�֤���ܶ�ϵͳ��������������ת�Ƶ���ʽ���������
        ////�����������ڱ�����飬�������ʱ����

        /// <summary>
        /// ������������Ϣ��ɾ������
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [OperationContract(Name = "DeleteWithFeedBack")]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        OperationFeedBack<bool> DeleteWithFeedBack(DTO dto);

        #endregion
    }
}
