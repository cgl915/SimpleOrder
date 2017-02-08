using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using SimpleOrder.Entity;
using SimpleOrder.DTO;
using HF.PLM.Framework.EF;
using Microsoft.Practices.Unity;

namespace SimpleOrder.Facade
{
    /// <summary>
    /// B_MenuContent，统一服务接口层，如需驻留SESSION用：[ServiceContract(SessionMode = SessionMode.Allowed)]
    /// </summary>
    [ServiceContract]
    public interface IB_MenuContentService : IBaseService<B_MenuContentInfo, B_MenuContent>
    {
    }
}