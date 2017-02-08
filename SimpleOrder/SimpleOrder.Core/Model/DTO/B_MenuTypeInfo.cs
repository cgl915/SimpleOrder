using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using HF.PLM.Framework.EF;

namespace SimpleOrder.DTO
{
    public class B_MenuTypeInfo : BaseDTO
    {
        #region B_MenuTypeInfo
        public B_MenuTypeInfo() { }
        #endregion

        #region Properties

        [DataMember]
        public virtual string Name { get; set; }
        #endregion
    }
}