using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using SimpleOrder.Entity;
using SimpleOrder.DTO;
using SimpleOrder.Facade;
using SimpleOrder.IBLL;
using HF.PLM.Framework.EF;

namespace SimpleOrder.WinformCaller
{
   public  class D_OrderCaller : BaseLocalService<D_OrderInfo, D_Order>, ID_OrderService
    {
        private ID_OrderBLL bll;

        public D_OrderCaller() : base(IFactory.Instance<ID_OrderBLL>())
        {
            bll = baseBLL as ID_OrderBLL;

            //DTO和Entity模型的相互映射
            Mapper.CreateMap<D_OrderInfo, D_Order>();
            Mapper.CreateMap<D_Order, D_OrderInfo>();
        }
    }
}