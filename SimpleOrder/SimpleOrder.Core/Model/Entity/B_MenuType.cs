using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HF.PLM.Framework.EF;

namespace SimpleOrder.Entity
{
    //菜单类型
    public class B_MenuType : BaseEntity
    {
        public B_MenuType() { }
        public virtual string Name { get; set; }    //  类型名称
    }
}
