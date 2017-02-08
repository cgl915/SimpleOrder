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
    public class D_OrderDetailCaller : BaseWCFService<D_OrderDetailInfo, D_OrderDetail>, ID_OrderDetailService
    {
        public D_OrderDetailCaller()
            : base()
        {
            this.configurationPath = EndPointConfig.WcfConfig; //WCF配置文件
            this.endpointConfigurationName = EndPointConfig.D_OrderDetailService;
        }

        /// <summary>
        /// 子类构造一个IChannel对象转换为基类接口，方便给基类进行调用通用的API
        /// </summary>
        /// <returns></returns>
        protected override IBaseService<D_OrderDetailInfo, D_OrderDetail> CreateClient()
        {
            return CreateSubClient();
        }

        /// <summary>
        /// 创建一个强类型接口对象，供本地调用
        /// </summary>
        /// <returns></returns>
        private ID_OrderDetailService CreateSubClient()
        {
            CustomClientChannel<ID_OrderDetailService> factory = new CustomClientChannel<ID_OrderDetailService>(endpointConfigurationName, configurationPath);
            return factory.CreateChannel();
        }
    }
}