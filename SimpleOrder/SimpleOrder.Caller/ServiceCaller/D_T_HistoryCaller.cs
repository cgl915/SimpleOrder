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
    public class D_T_HistoryCaller : BaseWCFService<D_T_HistoryInfo, D_T_History>, ID_T_HistoryService
    {
        public D_T_HistoryCaller()
            : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.D_T_HistoryService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<D_T_HistoryInfo, D_T_History> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ID_T_HistoryService CreateSubClient()
        {
            CustomClientChannel<ID_T_HistoryService> factory = new CustomClientChannel<ID_T_HistoryService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}