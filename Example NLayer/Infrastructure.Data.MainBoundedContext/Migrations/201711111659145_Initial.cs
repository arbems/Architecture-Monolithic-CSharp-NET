namespace Microsoft.Samples.NLayerApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccount",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankAccountNumber_OfficeNumber = c.String(),
                        BankAccountNumber_NationalBankCode = c.String(),
                        BankAccountNumber_AccountNumber = c.String(),
                        BankAccountNumber_CheckDigits = c.String(),
                        Iban = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 14, scale: 2),
                        Locked = c.Boolean(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.BankAccountActivity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankAccountId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivityDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccount", t => t.BankAccountId, cascadeDelete: true)
                .Index(t => t.BankAccountId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(),
                        Telephone = c.String(maxLength: 25),
                        Company = c.String(maxLength: 200),
                        Address_City = c.String(),
                        Address_ZipCode = c.String(),
                        Address_AddressLine1 = c.String(),
                        Address_AddressLine2 = c.String(),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsEnabled = c.Boolean(nullable: false),
                        CountryId = c.Guid(nullable: false),
                        RawPhoto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryName = c.String(nullable: false, maxLength: 50),
                        CountryISOCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(),
                        IsDelivered = c.Boolean(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        SequenceNumberOrder = c.Int(nullable: false, identity: true),
                        ShippingInformation_ShippingName = c.String(),
                        ShippingInformation_ShippingAddress = c.String(),
                        ShippingInformation_ShippingCity = c.String(),
                        ShippingInformation_ShippingZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderLine",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Amount = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 10, scale: 2),
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Title = c.String(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 10, scale: 2),
                        AmountInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Softwares",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LicenseCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Publisher = c.String(nullable: false),
                        ISBN = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Id", "dbo.Products");
            DropForeignKey("dbo.Softwares", "Id", "dbo.Products");
            DropForeignKey("dbo.OrderLine", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderLine", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BankAccount", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CountryId", "dbo.Country");
            DropForeignKey("dbo.BankAccountActivity", "BankAccountId", "dbo.BankAccount");
            DropIndex("dbo.Books", new[] { "Id" });
            DropIndex("dbo.Softwares", new[] { "Id" });
            DropIndex("dbo.OrderLine", new[] { "ProductId" });
            DropIndex("dbo.OrderLine", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "CountryId" });
            DropIndex("dbo.BankAccountActivity", new[] { "BankAccountId" });
            DropIndex("dbo.BankAccount", new[] { "CustomerId" });
            DropTable("dbo.Books");
            DropTable("dbo.Softwares");
            DropTable("dbo.Products");
            DropTable("dbo.OrderLine");
            DropTable("dbo.Order");
            DropTable("dbo.Country");
            DropTable("dbo.Customers");
            DropTable("dbo.BankAccountActivity");
            DropTable("dbo.BankAccount");
        }
    }
}
