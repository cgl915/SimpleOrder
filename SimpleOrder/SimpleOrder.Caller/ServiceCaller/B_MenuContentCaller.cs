using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleOrder.Entity;
using SimpleOrder.DTO;
using SimpleOrder.Facade;
using HF.PLM.Framework.EF;

namespace SimpleOrder.ServiceCaller
{
    public class B_MenuContentCaller : BaseWCFService<B_MenuContentInfo, B_MenuContent>, IB_MenuContentService
    {
        public B_MenuContentCaller()
            : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.B_MenuContentService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<B_MenuContentInfo, B_MenuContent> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IB_MenuContentService CreateSubClient()
        {
            CustomClientChannel<IB_MenuContentService> factory = new CustomClientChannel<IB_MenuContentService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}