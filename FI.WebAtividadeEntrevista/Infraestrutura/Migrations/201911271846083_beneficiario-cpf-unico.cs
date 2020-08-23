namespace Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beneficiariocpfunico : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BENEFICIARIOS", "Cpf", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.BENEFICIARIOS", new[] { "Cpf" });
        }
    }
}
