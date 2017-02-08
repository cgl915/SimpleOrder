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
    /// 基于WCFLibrary的B_TableList对象调用类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class B_TableListService: BaseLocalService<B_TableListInfo, B_TableList>, IB_TableListService
    {
        private IB_TableListBLL bll = null;

        public B_TableListService()
            : base(IFactory.Instance<IB_TableListBLL>())
        {
            bll = baseBLL as IB_TableListBLL;
            //DTO和Entity模型的相互映射
            Mapper.CreateMap<B_TableListInfo, B_TableList>();
            Mapper.CreateMap<B_TableList, B_TableListInfo>();
        }
    }
}