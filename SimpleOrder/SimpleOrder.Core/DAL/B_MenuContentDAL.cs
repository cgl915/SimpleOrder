using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleOrder.Entity;
using SimpleOrder.IDAL;
using HF.PLM.Framework.EF;

namespace SimpleOrder.DAL
{
    public class B_MenuContentDAL : BaseDAL<B_MenuContent>, IB_MenuContentDAL
    {
        /// <summary>
        /// 数据处理上下文对象
        /// </summary>
        protected EFContext context;

        public B_MenuContentDAL(EFContext pContext)
            : base(pContext)
        {
            this.context = pContext;
            SortPropertyName = "OID";
            IsDescending = false;
        }
    }
}