using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HF.PLM.Framework.EF
{
    /// <summary>
    /// 操作反馈基类
    /// </summary>
    [DataContract]
    public class OperationFeedBackBase
    {
        /// <summary>
        /// 操作执行成功完成
        /// </summary>
        [DataMember]
        public bool OperationSuccess;

        /// <summary>
        /// 操作没有成功的原因描述
        /// </summary>
        [DataMember]
        public string FailReasonDescription;

        /// <summary>
        /// 具体异常信息载体
        /// </summary>
        [DataMember]
        public OperationException ExceptionInst;

        /// <summary>
        /// 输入参数描述
        /// </summary>
        [DataMember]
        public string InputArguments = "未描述";

        /// <summary>
        /// 造成操作没有成功的内部操作的操作反馈对象
        /// </summary>
        [DataMember]
        public OperationFeedBackBase FailReason;
    }

    /// <summary>
    /// 操作反馈
    /// </summary>
    /// <typeparam name="ResultType">操作返回结果的类型</typeparam>
    [DataContract]
    public class OperationFeedBack<ResultType> : OperationFeedBackBase
    {
        /// <summary>
        /// 操作返回结果
        /// </summary>
        [DataMember]
        public ResultType OperationResult;
    }

    /// <summary>
    /// 自定义异常信息载体，代替Exception，为了便于通过WCF的序列化与反序列化机制，在“操作反馈类”对象中传输异常信息而创建
    /// </summary>
    [DataContract]
    public class OperationException
    {
        /// <summary>
        /// 自定义异常信息载体构造函数
        /// </summary>
        /// <param name="ExceptionInst">需要传输的异常类实例</param>
        public OperationException(Exception ExceptionInst)
        {
            if (ExceptionInst != null)
            {
                this.Message = ExceptionInst.Message;
                this.StackTrace = ExceptionInst.StackTrace;

                if (ExceptionInst.InnerException != null)
                {
                    this.InnerOperationException = new OperationException(ExceptionInst.InnerException);
                }
            }
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 异常跟踪栈
        /// </summary>
        [DataMember]
        public string StackTrace { get; set; }

        [DataMember]
        public OperationException InnerOperationException { get; set; }

    }
}
