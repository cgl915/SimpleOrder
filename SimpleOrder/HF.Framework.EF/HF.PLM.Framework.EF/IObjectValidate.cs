using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF.PLM.Framework.EF
{
    /// <summary>
    /// 数据校验接口
    /// </summary>
    public interface IObjectValidate<T> where T : class
    {
        /// <summary>
        /// 执行校验
        /// </summary>
        /// <param name="controlType">指示触发数据校验的操作类型</param>
        /// <param name="dal">关联DAL</param>
        void Validate(ValidateTriggerControl controlType, IBaseDAL<T> dal);

    }

    /// <summary>
    /// 触发校验的类型
    /// </summary>
    public enum ValidateTriggerControl
    {
        Insert = 1,
        Update = 2
    }

}
