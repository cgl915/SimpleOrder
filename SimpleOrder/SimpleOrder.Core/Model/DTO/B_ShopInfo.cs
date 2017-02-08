using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using HF.PLM.Framework.EF;

namespace SimpleOrder.DTO
{
    public class B_ShopInfo : BaseDTO
    {
        #region B_ShopInfo
        public B_ShopInfo() { }
        #endregion

        #region Properties

        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string Code { get; set; }
        #endregion
    }
}