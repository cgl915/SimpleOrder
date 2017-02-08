using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using HF.PLM.Framework.EF;
using SimpleOrder.Entity;

namespace SimpleOrder.DAL
{
    public class EFContext : BaseContext
    {
        public EFContext() : base(Assembly.GetExecutingAssembly())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

		public virtual DbSet<B_MenuContent> B_MenuContents { get; set; }
		public virtual DbSet<B_MenuType> B_MenuTypes { get; set; }
		public virtual DbSet<B_Shop> B_Shops { get; set; }
		public virtual DbSet<B_TableList> B_TableLists { get; set; }
		public virtual DbSet<D_Order> D_Orders { get; set; }
		public virtual DbSet<D_OrderDetail> D_OrderDetails { get; set; }
		public virtual DbSet<D_T_History> D_T_Historys { get; set; }
        //自动添加标记勿删
        //public virtual DbSet<B_MenuContent> B_MenuContents { get; set; }
        //public virtual DbSet<B_MenuType> B_MenuTypes { get; set; }
        //public virtual DbSet<B_Shop> B_Shops { get; set; }
        //public virtual DbSet<B_TableList> B_TableLists { get; set; }
        //public virtual DbSet<D_Order> D_Orders { get; set; }
        //public virtual DbSet<D_OrderDetail> D_OrderDetails { get; set; }
        //public virtual DbSet<D_T_History> D_T_Historys { get; set; }
    }
}
