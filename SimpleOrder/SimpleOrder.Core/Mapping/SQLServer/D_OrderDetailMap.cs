using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

using SimpleOrder.Entity;

namespace SimpleOrder.Mapping.SqlServer
{
    public class D_OrderDetailMap : EntityTypeConfiguration<D_OrderDetail>
    {
        public D_OrderDetailMap()
        {
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            Property(t => t.CreateUser).HasColumnName("CreateUser");
            Property(t => t.UpdateUser).HasColumnName("UpdateUser");

            Property(t => t.OrderID).HasColumnName("OrderID");
            Property(t => t.MenuContentID).HasColumnName("MenuContentID");
            Property(t => t.Count).HasColumnName("Count");
            ToTable("D_OrderDetail");
        }
    }
}