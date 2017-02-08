using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleOrder.ServiceCaller
{
    internal class EndPointConfig
    {
        public static string WcfConfig = Path.Combine(GetDLLPath(), "WcfConfig.config");
        private static string GetDLLPath()
        {
            EndPointConfig epc = new EndPointConfig();
            return Path.GetDirectoryName(epc.GetType().Assembly.CodeBase).Replace("file:\\", "");
        }

        public const string B_MenuContentService = "WSHttpBinding_IB_MenuContentService";
        public const string B_MenuTypeService = "WSHttpBinding_IB_MenuTypeService";
        public const string B_ShopService = "WSHttpBinding_IB_ShopService";
        public const string B_TableListService = "WSHttpBinding_IB_TableListService";
        public const string D_OrderService = "WSHttpBinding_ID_OrderService";
        public const string D_OrderDetailService = "WSHttpBinding_ID_OrderDetailService";
        public const string D_T_HistoryService = "WSHttpBinding_ID_T_HistoryService";
        //自动添加标记勿删
    }
}
