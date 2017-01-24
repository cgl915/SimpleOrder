using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HF.PLM.Framework.EF
{
    [DataContract]
    public class BaseError
    {
        public string errorMessage;
        public BaseError(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }
}
