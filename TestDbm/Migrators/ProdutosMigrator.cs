using FluentMigrator;

namespace TestDbm.Migrators
{
    [Migration(202501291416)]
    public class ProdutosMigrator : Migration
    {
        public override void Up()
        {
            Create.Table("Produtos")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(100).NotNullable().Unique()
                .WithColumn("Descricao").AsString()
                .WithColumn("Preco").AsDecimal().NotNullable()
                .WithColumn("DataCadastro").AsDateTime().WithDefault(SystemMethods.CurrentDateTime);
        }

        public override void Down()
        {
            Delete.Table("Produtos");
        }
    }
}
