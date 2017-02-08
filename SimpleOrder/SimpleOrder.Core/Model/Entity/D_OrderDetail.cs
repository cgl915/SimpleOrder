using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HF.PLM.Framework.EF;

namespace SimpleOrder.Entity
{
    //订单明细
    public class D_OrderDetail : BaseEntity
    {
        public D_OrderDetail() { }
        public virtual Guid OrderID { get; set; }       //订单ID
        public virtual Guid MenuContentID { get; set; } //菜品ID
        public virtual int Count { get; set; }          //份数
    }
}
