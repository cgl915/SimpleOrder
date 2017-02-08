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
    /// 基于WCFLibrary的B_MenuType对象调用类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class B_MenuTypeService: BaseLocalService<B_MenuTypeInfo, B_MenuType>, IB_MenuTypeService
    {
        private IB_MenuTypeBLL bll = null;

        public B_MenuTypeService()
            : base(IFactory.Instance<IB_MenuTypeBLL>())
        {
            bll = baseBLL as IB_MenuTypeBLL;
            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_MenuTypeInfo, B_MenuType>();
            Mapper.CreateMap<B_MenuType, B_MenuTypeInfo>();
        }
    }
}