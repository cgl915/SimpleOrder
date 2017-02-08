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
    /// 基于WCFLibrary的B_MenuContent对象调用类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class B_MenuContentService: BaseLocalService<B_MenuContentInfo, B_MenuContent>, IB_MenuContentService
    {
        private IB_MenuContentBLL bll = null;

        public B_MenuContentService()
            : base(IFactory.Instance<IB_MenuContentBLL>())
        {
            bll = baseBLL as IB_MenuContentBLL;
            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_MenuContentInfo, B_MenuContent>();
            Mapper.CreateMap<B_MenuContent, B_MenuContentInfo>();
        }
    }
}