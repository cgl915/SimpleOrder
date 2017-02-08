using System.Collections.Generic;
using System.ServiceModel;

using HF.PLM.Framework.Commons;
using HF.PLM.Framework.EF;
using SimpleOrder.Facade;
using SimpleOrder.DTO;
using SimpleOrder.Entity;

namespace SimpleOrder.Proxy
{
    public class B_MenuContentServiceProxy: HF.PLM.Framework.EF.BaseWCFService<B_MenuContentInfo, B_MenuContent>, IB_MenuContentService
    {
        public B_MenuContentServiceProxy(string endpointConfigurationName, string configurationPath):base()
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected override IBaseService<B_MenuContentInfo, B_MenuContent> CreateClient()
        {
            return this.CreateSubClient();
        }

        private IB_MenuContentService CreateSubClient()
        {
            CustomClientChannel<IB_MenuContentService> factory = new CustomClientChannel<IB_MenuContentService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}