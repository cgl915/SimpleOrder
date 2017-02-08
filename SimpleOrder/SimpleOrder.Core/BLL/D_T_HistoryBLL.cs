using System;
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
    public class D_T_HistoryBLL : BaseBLL<D_T_History>, ID_T_HistoryBLL
    {
        /// <summary>
        /// 对象的数据访问接口
        /// </summary>
        protected ID_T_HistoryDAL dal;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public D_T_HistoryBLL()
        {
            //由于基类BaseBLL已经初始化了Unity容器，因此直接解析对应的IDAL层就可获得DAL对象。
            dal = container.Resolve<ID_T_HistoryDAL>();
            baseDAL = dal;
        }

        /// <summary>
        /// 参数化构造函数，传入数据访问接口
        /// </summary>
        /// <param name=""dal"">数据访问接口</param>
        public D_T_HistoryBLL(ID_T_HistoryDAL dal)
            : base(dal)
        {
            this.dal = dal;
        }
    }
}