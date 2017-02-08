﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleOrder.Entity;
using SimpleOrder.IDAL;
using SimpleOrder.IBLL;
using HF.PLM.Framework.EF;
using Microsoft.Practices.Unity;

namespace SimpleOrder.BLL
{
    public class B_ShopBLL : BaseBLL<B_Shop>, IB_ShopBLL
    {
        /// <summary>
        /// 对象的数据访问接口
        /// </summary>
        protected IB_ShopDAL dal;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public B_ShopBLL()
        {
            //由于基类BaseBLL已经初始化了Unity容器，因此直接解析对应的IDAL层就可获得DAL对象。
            dal = container.Resolve<IB_ShopDAL>();
            baseDAL = dal;
        }

        /// <summary>
        /// 参数化构造函数，传入数据访问接口
        /// </summary>
        /// <param name=""dal"">数据访问接口</param>
        public B_ShopBLL(IB_ShopDAL dal)
            : base(dal)
        {
            this.dal = dal;
        }
    }
}