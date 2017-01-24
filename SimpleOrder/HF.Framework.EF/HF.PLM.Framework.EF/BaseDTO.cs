using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace HF.PLM.Framework.EF
{
    /// <summary>
    /// 数据契约基础类
    /// </summary>
    [DataContract]
    public class BaseDTO
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseDTO()
        {
            this.InitProperty();
            this.Oid = Guid.Empty;
            this.Index = 999999;
        }

        /// <summary>
        /// 对象唯一标示
        /// </summary>
        [DataMember]
        public virtual Guid Oid { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建人标识
        /// </summary>
        [DataMember]
        public virtual Guid? CreateUser { get; set; }

        /// <summary>
        /// 修改人标识
        /// </summary>
        [DataMember]
        public virtual Guid? UpdateUser { get; set; }

        /// <summary>
        /// 被修改属性列表
        /// </summary>
        [DataMember]
        public List<string> ModifiedList;

        /// <summary>
        /// 索引
        /// </summary>
        [Description("索引")]
        [DataMember]
        public virtual int? Index { get; set; }


        /// <summary>
        /// 初始化属性(数字默认为0)
        /// </summary>
        protected void InitProperty()
        {
            foreach (PropertyInfo pInfo in this.GetType().GetProperties())
            {
                SetProperty(pInfo.PropertyType,pInfo);
            }
        }


        void SetProperty(Type pType, PropertyInfo pPropertyInfo)
        {
            string typeName = pType.Name;
            if (typeName.StartsWith("Nullable"))
            {
                SetProperty(pType.GetGenericArguments()[0],pPropertyInfo);
            }
            else
            {
                switch (typeName)
                {
                    case "Int32":
                        pPropertyInfo.SetValue(this, 0, null);
                        break;
                    case "Double":
                        pPropertyInfo.SetValue(this, Convert.ToDouble(0), null);
                        break;
                    case "Decimal":
                        pPropertyInfo.SetValue(this, Convert.ToDecimal(0), null);
                        break;
                }
            }

        }

    }
}
