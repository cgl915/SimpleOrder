using System.Collections.Generic;
using System.ServiceModel;

using HF.PLM.Framework.Commons;
using HF.PLM.Framework.EF;
using SimpleOrder.Facade;
using SimpleOrder.DTO;
using SimpleOrder.Entity;

namespace SimpleOrder.Proxy
{
    public class B_ShopServiceProxy: HF.PLM.Framework.EF.BaseWCFService<B_ShopInfo, B_Shop>, IB_ShopService
    {
        public B_ShopServiceProxy(string endpointConfigurationName, string configurationPath):base()
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected override IBaseService<B_ShopInfo, B_Shop> CreateClient()
        {
            return this.CreateSubClient();
        }

        private IB_ShopService CreateSubClient()
        {
            CustomClientChannel<IB_ShopService> factory = new CustomClientChannel<IB_ShopService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}