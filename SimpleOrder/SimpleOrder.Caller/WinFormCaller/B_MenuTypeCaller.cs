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
   public  class B_MenuTypeCaller : BaseLocalService<B_MenuTypeInfo, B_MenuType>, IB_MenuTypeService
    {
        private IB_MenuTypeBLL bll;

        public B_MenuTypeCaller() : base(IFactory.Instance<IB_MenuTypeBLL>())
        {
            bll = baseBLL as IB_MenuTypeBLL;

            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_MenuTypeInfo, B_MenuType>();
            Mapper.CreateMap<B_MenuType, B_MenuTypeInfo>();
        }
    }
}