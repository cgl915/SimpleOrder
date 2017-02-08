using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using HF.PLM.Framework.EF;

namespace SimpleOrder.Entity
{
    //菜单内容
    public class B_MenuContent : BaseEntity
    {
        public B_MenuContent() { }
        public virtual string Name { get; set; }        //菜名
        public virtual double Price { get; set; }       //价格
        public virtual string MenuType { get; set; }    //所属类型
        public virtual string Remark { get; set; }      //介绍
        public virtual string B_Image { get; set; }     //图片
        public virtual bool OnSale { get; set; }        //是否在售
        public virtual double Discount { get; set; }    //折扣价
        public virtual DateTime DisCount_S { get; set; }//折扣开始时间
        public virtual DateTime DisCount_E { get; set; }//折扣结束时间
        public virtual string Dis_DataType { get; set; }//折扣频率
        public virtual string Dis_Key { get; set; }     //折扣关键字
    }
}
