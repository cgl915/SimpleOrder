using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using HF.PLM.Framework.EF;

namespace SimpleOrder.DTO
{
    public class B_MenuContentInfo : BaseDTO
    {
        #region B_MenuContentInfo
        public B_MenuContentInfo() { }
        #endregion

        #region Properties

        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual double Price { get; set; }
        [DataMember]
        public virtual string MenuType { get; set; }
        [DataMember]
        public virtual string Remark { get; set; }
        [DataMember]
        public virtual string B_Image { get; set; }
        [DataMember]
        public virtual bool OnSale { get; set; }
        [DataMember]
        public virtual double Discount { get; set; }
        [DataMember]
        public virtual DateTime DisCount_S { get; set; }
        [DataMember]
        public virtual DateTime DisCount_E { get; set; }
        [DataMember]
        public virtual string Dis_DataType { get; set; }
        [DataMember]
        public virtual string Dis_Key { get; set; }
        #endregion
    }
}