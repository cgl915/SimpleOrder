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
   public  class D_OrderDetailCaller : BaseLocalService<D_OrderDetailInfo, D_OrderDetail>, ID_OrderDetailService
    {
        private ID_OrderDetailBLL bll;

        public D_OrderDetailCaller() : base(IFactory.Instance<ID_OrderDetailBLL>())
        {
            bll = baseBLL as ID_OrderDetailBLL;

            //DTO和Entity模型的相互映射
            Mapper.CreateMap<D_OrderDetailInfo, D_OrderDetail>();
            Mapper.CreateMap<D_OrderDetail, D_OrderDetailInfo>();
        }
    }
}