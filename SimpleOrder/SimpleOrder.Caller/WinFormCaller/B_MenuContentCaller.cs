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
   public  class B_MenuContentCaller : BaseLocalService<B_MenuContentInfo, B_MenuContent>, IB_MenuContentService
    {
        private IB_MenuContentBLL bll;

        public B_MenuContentCaller() : base(IFactory.Instance<IB_MenuContentBLL>())
        {
            bll = baseBLL as IB_MenuContentBLL;

            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_MenuContentInfo, B_MenuContent>();
            Mapper.CreateMap<B_MenuContent, B_MenuContentInfo>();
        }
    }
}