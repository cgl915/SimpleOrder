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
    /// 基于WCFLibrary的B_Shop对象调用类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class B_ShopService: BaseLocalService<B_ShopInfo, B_Shop>, IB_ShopService
    {
        private IB_ShopBLL bll = null;

        public B_ShopService()
            : base(IFactory.Instance<IB_ShopBLL>())
        {
            bll = baseBLL as IB_ShopBLL;
            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_ShopInfo, B_Shop>();
            Mapper.CreateMap<B_Shop, B_ShopInfo>();
        }
    }
}