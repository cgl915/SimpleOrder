using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using HF.PLM.Framework.EF;

namespace SimpleOrder.DTO
{
    public class D_OrderDetailInfo : BaseDTO
    {
        #region D_OrderDetailInfo
        public D_OrderDetailInfo() { }
        #endregion

        #region Properties

        [DataMember]
        public virtual Guid OrderID { get; set; }
        [DataMember]
        public virtual Guid MenuContentID { get; set; }
        [DataMember]
        public virtual int Count { get; set; }
        #endregion
    }
}