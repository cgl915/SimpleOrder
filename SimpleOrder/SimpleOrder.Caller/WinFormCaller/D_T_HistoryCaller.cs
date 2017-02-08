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
   public  class D_T_HistoryCaller : BaseLocalService<D_T_HistoryInfo, D_T_History>, ID_T_HistoryService
    {
        private ID_T_HistoryBLL bll;

        public D_T_HistoryCaller() : base(IFactory.Instance<ID_T_HistoryBLL>())
        {
            bll = baseBLL as ID_T_HistoryBLL;

            //DTO和Entity模型的相互映射
            Mapper.CreateMap<D_T_HistoryInfo, D_T_History>();
            Mapper.CreateMap<D_T_History, D_T_HistoryInfo>();
        }
    }
}