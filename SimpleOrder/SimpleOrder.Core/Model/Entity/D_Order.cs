using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HF.PLM.Framework.EF;

namespace SimpleOrder.Entity
{
    //订单列表
    public class D_Order : BaseEntity
    {
        public D_Order() { }
        public virtual string T_No { get; set; }        //桌号
        public virtual string OrderNo { get; set; }     //订单号
        public virtual DateTime S_Time { get; set; }    //下单时间
        public virtual DateTime E_Time { get; set; }    //上齐时间
        public virtual double Consumption { get; set; } //消费金额

    }
}
