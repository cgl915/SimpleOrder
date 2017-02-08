using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

using SimpleOrder.Entity;

namespace SimpleOrder.Mapping.SqlServer
{
    public class B_MenuTypeMap : EntityTypeConfiguration<B_MenuType>
    {
        public B_MenuTypeMap()
        {
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            Property(t => t.CreateUser).HasColumnName("CreateUser");
            Property(t => t.UpdateUser).HasColumnName("UpdateUser");

            Property(t => t.Name).HasColumnName("Name");
            ToTable("B_MenuType");
        }
    }
}