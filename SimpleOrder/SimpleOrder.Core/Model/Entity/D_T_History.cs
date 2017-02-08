using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using HF.PLM.Framework.EF;

namespace SimpleOrder.Entity
{
    //入座历史
    public class D_T_History : BaseEntity
    {
        public D_T_History()
        {
            this.T_Count = 2;
        }
        public virtual string T_No { get; set; }            //桌号
        public virtual int T_Count { get; set; }            //入座位数
        public virtual DateTime? S_Time { get; set; }       //入座时间
        public virtual DateTime? E_Time { get; set; }       //离座时间
        public virtual double? Consumption { get; set; }    //消费金额
    }
}
