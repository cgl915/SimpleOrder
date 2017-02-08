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
    /// 基于WCFLibrary的D_Order对象调用类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class D_OrderService: BaseLocalService<D_OrderInfo, D_Order>, ID_OrderService
    {
        private ID_OrderBLL bll = null;

        public D_OrderService()
            : base(IFactory.Instance<ID_OrderBLL>())
        {
            bll = baseBLL as ID_OrderBLL;
            //DTO和Entity模型的相互映射
            Mapper.CreateMap<D_OrderInfo, D_Order>();
            Mapper.CreateMap<D_Order, D_OrderInfo>();
        }
    }
}