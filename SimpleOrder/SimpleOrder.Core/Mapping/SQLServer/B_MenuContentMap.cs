using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

using SimpleOrder.Entity;

namespace SimpleOrder.Mapping.SqlServer
{
    public class B_MenuContentMap : EntityTypeConfiguration<B_MenuContent>
    {
        public B_MenuContentMap()
        {
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            Property(t => t.CreateUser).HasColumnName("CreateUser");
            Property(t => t.UpdateUser).HasColumnName("UpdateUser");

            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Price).HasColumnName("Price");
            Property(t => t.MenuType).HasColumnName("MenuType");
            Property(t => t.Remark).HasColumnName("Remark");
            Property(t => t.B_Image).HasColumnName("B_Image");
            Property(t => t.OnSale).HasColumnName("OnSale");
            Property(t => t.Discount).HasColumnName("Discount");
            Property(t => t.DisCount_S).HasColumnName("DisCount_S");
            Property(t => t.DisCount_E).HasColumnName("DisCount_E");
            Property(t => t.Dis_DataType).HasColumnName("Dis_DataType");
            Property(t => t.Dis_Key).HasColumnName("Dis_Key");
            ToTable("B_MenuContent");
        }
    }
}