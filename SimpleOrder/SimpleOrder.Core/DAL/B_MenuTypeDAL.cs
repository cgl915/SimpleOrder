using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleOrder.Entity;
using SimpleOrder.IDAL;
using HF.PLM.Framework.EF;

namespace SimpleOrder.DAL
{
    public class B_MenuTypeDAL : BaseDAL<B_MenuType>, IB_MenuTypeDAL
    {
        /// <summary>
        /// 数据处理上下文对象
        /// </summary>
        protected EFContext context;

        public B_MenuTypeDAL(EFContext pContext)
            : base(pContext)
        {
            this.context = pContext;
            SortPropertyName = "OID";
            IsDescending = false;
        }
    }
}