using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using HF.PLM.Framework.EF;

namespace SimpleOrder.Entity
{
    //桌位清单
    public class B_TableList : BaseEntity
    {
        public B_TableList() {
            this.T_Count = 2;
            this.IsUsing = false;
        }
        public virtual string T_No { get; set; }    //桌号
        public virtual int T_Count { get; set; }    //座位数
        public virtual bool IsUsing { get; set; }   //是否空置
    }
}
