namespace SimpleOrder.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tables01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.B_MenuContent",
                c => new
                    {
                        Oid = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        MenuType = c.String(),
                        Remark = c.String(),
                        B_Image = c.String(),
                        OnSale = c.Boolean(nullable: false),
                        Discount = c.Double(nullable: false),
                        DisCount_S = c.DateTime(nullable: false),
                        DisCount_E = c.DateTime(nullable: false),
                        Dis_DataType = c.String(),
                        Dis_Key = c.String(),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        CreateUser = c.Guid(),
                        UpdateUser = c.Guid(),
                        Index = c.Int(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.B_MenuType",
                c => new
                    {
                        Oid = c.Guid(nullable: false),
                        Name = c.String(),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        CreateUser = c.Guid(),
                        UpdateUser = c.Guid(),
                        Index = c.Int(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.B_Shop",
                c => new
                    {
                        Oid = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        CreateUser = c.Guid(),
                        UpdateUser = c.Guid(),
                        Index = c.Int(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.B_TableList",
                c => new
                    {
                        Oid = c.Guid(nullable: false),
                        T_No = c.String(),
                        T_Count = c.Int(nullable: false),
                        IsUsing = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        CreateUser = c.Guid(),
                        UpdateUser = c.Guid(),
                        Index = c.Int(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.D_OrderDetail",
                c => new
                    {
                        Oid = c.Guid(nullable: false),
                        OrderID = c.Guid(nullable: false),
                        MenuContentID = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        CreateUser = c.Guid(),
                        UpdateUser = c.Guid(),
                        Index = c.Int(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.D_Order",
                c => new
                    {
                        Oid = c.Guid(nullable: false),
                        T_No = c.String(),
                        OrderNo = c.String(),
                        S_Time = c.DateTime(nullable: false),
                        E_Time = c.DateTime(nullable: false),
                        Consumption = c.Double(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        CreateUser = c.Guid(),
                        UpdateUser = c.Guid(),
                        Index = c.Int(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.D_T_History",
                c => new
                    {
                        Oid = c.Guid(nullable: false),
                        T_No = c.String(),
                        T_Count = c.Int(nullable: false),
                        S_Time = c.DateTime(),
                        E_Time = c.DateTime(),
                        Consumption = c.Double(),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        CreateUser = c.Guid(),
                        UpdateUser = c.Guid(),
                        Index = c.Int(),
                    })
                .PrimaryKey(t => t.Oid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.D_T_History");
            DropTable("dbo.D_Order");
            DropTable("dbo.D_OrderDetail");
            DropTable("dbo.B_TableList");
            DropTable("dbo.B_Shop");
            DropTable("dbo.B_MenuType");
            DropTable("dbo.B_MenuContent");
        }
    }
}
