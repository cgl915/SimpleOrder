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
   public  class B_ShopCaller : BaseLocalService<B_ShopInfo, B_Shop>, IB_ShopService
    {
        private IB_ShopBLL bll;

        public B_ShopCaller() : base(IFactory.Instance<IB_ShopBLL>())
        {
            bll = baseBLL as IB_ShopBLL;

            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_ShopInfo, B_Shop>();
            Mapper.CreateMap<B_Shop, B_ShopInfo>();
        }
    }
}