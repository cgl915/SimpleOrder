using System.Collections.Generic;
using System.ServiceModel;

using HF.PLM.Framework.Commons;
using HF.PLM.Framework.EF;
using SimpleOrder.Facade;
using SimpleOrder.DTO;
using SimpleOrder.Entity;

namespace SimpleOrder.Proxy
{
    public class B_MenuTypeServiceProxy: HF.PLM.Framework.EF.BaseWCFService<B_MenuTypeInfo, B_MenuType>, IB_MenuTypeService
    {
        public B_MenuTypeServiceProxy(string endpointConfigurationName, string configurationPath):base()
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected override IBaseService<B_MenuTypeInfo, B_MenuType> CreateClient()
        {
            return this.CreateSubClient();
        }

        private IB_MenuTypeService CreateSubClient()
        {
            CustomClientChannel<IB_MenuTypeService> factory = new CustomClientChannel<IB_MenuTypeService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}