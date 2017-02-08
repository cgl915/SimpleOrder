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
   public  class B_TableListCaller : BaseLocalService<B_TableListInfo, B_TableList>, IB_TableListService
    {
        private IB_TableListBLL bll;

        public B_TableListCaller() : base(IFactory.Instance<IB_TableListBLL>())
        {
            bll = baseBLL as IB_TableListBLL;

            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_TableListInfo, B_TableList>();
            Mapper.CreateMap<B_TableList, B_TableListInfo>();
        }
    }
}