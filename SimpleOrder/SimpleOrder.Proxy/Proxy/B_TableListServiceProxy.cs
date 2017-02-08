using System.Collections.Generic;
using System.ServiceModel;

using HF.PLM.Framework.Commons;
using HF.PLM.Framework.EF;
using SimpleOrder.Facade;
using SimpleOrder.DTO;
using SimpleOrder.Entity;

namespace SimpleOrder.Proxy
{
    public class B_TableListServiceProxy: HF.PLM.Framework.EF.BaseWCFService<B_TableListInfo, B_TableList>, IB_TableListService
    {
        public B_TableListServiceProxy(string endpointConfigurationName, string configurationPath):base()
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected override IBaseService<B_TableListInfo, B_TableList> CreateClient()
        {
            return this.CreateSubClient();
        }

        private IB_TableListService CreateSubClient()
        {
            CustomClientChannel<IB_TableListService> factory = new CustomClientChannel<IB_TableListService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}