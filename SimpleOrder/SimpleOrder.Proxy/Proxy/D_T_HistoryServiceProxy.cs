using System.Collections.Generic;
using System.ServiceModel;

using HF.PLM.Framework.Commons;
using HF.PLM.Framework.EF;
using SimpleOrder.Facade;
using SimpleOrder.DTO;
using SimpleOrder.Entity;

namespace SimpleOrder.Proxy
{
    public class D_T_HistoryServiceProxy: HF.PLM.Framework.EF.BaseWCFService<D_T_HistoryInfo, D_T_History>, ID_T_HistoryService
    {
        public D_T_HistoryServiceProxy(string endpointConfigurationName, string configurationPath):base()
        {
            this.endpointConfigurationName = endpointConfigurationName;
            this.configurationPath = configurationPath;
        }

        protected override IBaseService<D_T_HistoryInfo, D_T_History> CreateClient()
        {
            return this.CreateSubClient();
        }

        private ID_T_HistoryService CreateSubClient()
        {
            CustomClientChannel<ID_T_HistoryService> factory = new CustomClientChannel<ID_T_HistoryService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}