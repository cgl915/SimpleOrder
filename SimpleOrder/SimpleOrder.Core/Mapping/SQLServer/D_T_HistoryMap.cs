using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

using SimpleOrder.Entity;

namespace SimpleOrder.Mapping.SqlServer
{
    public class D_T_HistoryMap : EntityTypeConfiguration<D_T_History>
    {
        public D_T_HistoryMap()
        {
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            Property(t => t.CreateUser).HasColumnName("CreateUser");
            Property(t => t.UpdateUser).HasColumnName("UpdateUser");

            Property(t => t.T_No).HasColumnName("T_No");
            Property(t => t.T_Count).HasColumnName("T_Count");
            Property(t => t.S_Time).HasColumnName("S_Time");
            Property(t => t.E_Time).HasColumnName("E_Time");
            Property(t => t.Consumption).HasColumnName("Consumption");
            ToTable("D_T_History");
        }
    }
}