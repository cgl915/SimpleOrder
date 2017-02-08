using System.Collections.Generic;
using System.ServiceModel;

using HF.PLM.Framework.Commons;
using HF.PLM.Framework.EF;
using SimpleOrder.Facade;
using SimpleOrder.DTO;
using SimpleOrder.Entity;

namespace SimpleOrder.Proxy
{
    public class D_OrderDetailServiceProxy: HF.PLM.Framework.EF.BaseWCFService<D_OrderDetailInfo, D_OrderDetail>, ID_OrderDetailService
    {
        public D_OrderDetailServiceProxy(string endpointConfigurationName, string configurationPath):base()
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected override IBaseService<D_OrderDetailInfo, D_OrderDetail> CreateClient()
        {
            return this.CreateSubClient();
        }

        private ID_OrderDetailService CreateSubClient()
        {
            CustomClientChannel<ID_OrderDetailService> factory = new CustomClientChannel<ID_OrderDetailService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}