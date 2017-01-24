using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HF.PLM.Framework.EF
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class BaseEntity
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseEntity()
        {
            this.Oid = Guid.Empty;
            this.Index = 99999;
        }

        [Key]
        public virtual Guid Oid { get; set; }

        /// <summary>
        /// 记录创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建记录的用户
        /// </summary>
        public virtual Guid? CreateUser { get; set; }

        /// <summary>
        /// 执行最后一次修改的用户
        /// </summary>
        public virtual Guid? UpdateUser { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        [Description("索引")]
        public virtual int? Index { get; set; }
    }

}
