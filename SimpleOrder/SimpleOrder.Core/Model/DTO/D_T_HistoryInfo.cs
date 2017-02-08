using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using HF.PLM.Framework.EF;

namespace SimpleOrder.DTO
{
    public class D_T_HistoryInfo : BaseDTO
    {
        #region D_T_HistoryInfo
        public D_T_HistoryInfo() { }
        #endregion

        #region Properties

        [DataMember]
        public virtual string T_No { get; set; }
        [DataMember]
        public virtual int T_Count { get; set; }
        [DataMember]
        public virtual DateTime? S_Time { get; set; }
        [DataMember]
        public virtual DateTime? E_Time { get; set; }
        [DataMember]
        public virtual double? Consumption { get; set; }
        #endregion
    }
}