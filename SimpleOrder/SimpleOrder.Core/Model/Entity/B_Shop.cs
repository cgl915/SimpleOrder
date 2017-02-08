using HF.PLM.Framework.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleOrder.Entity
{
    //门店
    public class B_Shop : BaseEntity
    {
        public B_Shop() { }
        public virtual string Name { get; set; }    //名称
        public virtual string Code { get; set; }    //编码
    }
    ///
    /// enable-migrations
    /// add-migration name
    /// add-migration -force name
    /// update-database
    /// update-database -targetmigration
    ///
}
