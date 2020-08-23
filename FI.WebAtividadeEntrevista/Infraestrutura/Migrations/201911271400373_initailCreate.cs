namespace Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initailCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BENEFICIARIOS",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Cpf = c.String(maxLength: 11),
                        Nome = c.String(maxLength: 30),
                        IDCliente = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.IDCliente, cascadeDelete: true)
                .Index(t => t.IDCliente);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BENEFICIARIOS", "IDCliente", "dbo.Clientes");
            DropIndex("dbo.BENEFICIARIOS", new[] { "IDCliente" });
            DropTable("dbo.BENEFICIARIOS");
        }
    }
}
