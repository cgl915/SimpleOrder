using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using HF.PLM.Framework.EF;

namespace SimpleOrder.DTO
{
    public class B_TableListInfo : BaseDTO
    {
        #region B_TableListInfo
        public B_TableListInfo() { }
        #endregion

        #region Properties

        [DataMember]
        public virtual string T_No { get; set; }
        [DataMember]
        public virtual int T_Count { get; set; }
        [DataMember]
        public virtual bool IsUsing { get; set; }
        #endregion
    }
}