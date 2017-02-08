using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleOrder.Entity;
using SimpleOrder.IDAL;
using HF.PLM.Framework.EF;

namespace SimpleOrder.DAL
{
    public class D_OrderDetailDAL : BaseDAL<D_OrderDetail>, ID_OrderDetailDAL
    {
        /// <summary>
        /// 数据处理上下文对象
        /// </summary>
        protected EFContext context;

        public D_OrderDetailDAL(EFContext pContext)
            : base(pContext)
        {
            this.context = pContext;
            SortPropertyName = "OID";
            IsDescending = false;
        }
    }
}