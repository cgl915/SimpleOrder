using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

using SimpleOrder.Entity;

namespace SimpleOrder.Mapping.SqlServer
{
    public class B_TableListMap : EntityTypeConfiguration<B_TableList>
    {
        public B_TableListMap()
        {
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            Property(t => t.CreateUser).HasColumnName("CreateUser");
            Property(t => t.UpdateUser).HasColumnName("UpdateUser");

            Property(t => t.T_No).HasColumnName("T_No");
            Property(t => t.T_Count).HasColumnName("T_Count");
            Property(t => t.IsUsing).HasColumnName("IsUsing");
            ToTable("B_TableList");
        }
    }
}