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
    public class B_ShopCaller : BaseWCFService<B_ShopInfo, B_Shop>, IB_ShopService
    {
        public B_ShopCaller()
            : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.B_ShopService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<B_ShopInfo, B_Shop> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private IB_ShopService CreateSubClient()
        {
            CustomClientChannel<IB_ShopService> factory = new CustomClientChannel<IB_ShopService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}