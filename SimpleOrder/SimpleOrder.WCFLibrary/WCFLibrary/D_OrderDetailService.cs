using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;

using AutoMapper;
using SimpleOrder.Entity;
using SimpleOrder.DTO;
using SimpleOrder.Facade;
using SimpleOrder.IBLL;
using HF.PLM.Framework.EF;
using Microsoft.Practices.Unity;

namespace SimpleOrder.WCFLibrary
{
    /// <summary>
    /// 基于WCFLibrary的D_OrderDetail对象调用类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class D_OrderDetailService: BaseLocalService<D_OrderDetailInfo, D_OrderDetail>, ID_OrderDetailService
    {
        private ID_OrderDetailBLL bll = null;

        public D_OrderDetailService()
            : base(IFactory.Instance<ID_OrderDetailBLL>())
        {
            bll = baseBLL as ID_OrderDetailBLL;
            //DTO和Entity模型的相互映射
            Mapper.CreateMap<D_OrderDetailInfo, D_OrderDetail>();
            Mapper.CreateMap<D_OrderDetail, D_OrderDetailInfo>();
        }
    }
}