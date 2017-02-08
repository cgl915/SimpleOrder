using System.Collections.Generic;
using System.ServiceModel;

using HF.PLM.Framework.Commons;
using HF.PLM.Framework.EF;
using SimpleOrder.Facade;
using SimpleOrder.DTO;
using SimpleOrder.Entity;

namespace SimpleOrder.Proxy
{
    public class D_OrderServiceProxy: HF.PLM.Framework.EF.BaseWCFService<D_OrderInfo, D_Order>, ID_OrderService
    {
        public D_OrderServiceProxy(string endpointConfigurationName, string configurationPath):base()
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected override IBaseService<D_OrderInfo, D_Order> CreateClient()
        {
            return this.CreateSubClient();
        }

        private ID_OrderService CreateSubClient()
        {
            CustomClientChannel<ID_OrderService> factory = new CustomClientChannel<ID_OrderService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}