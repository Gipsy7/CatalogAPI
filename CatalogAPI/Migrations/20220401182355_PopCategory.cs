using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    public partial class PopCategory : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categories(Name, Description,ImageUrl) Values('Bebidas','Bebida é um tipo de líquido, o qual é especificamente preparado para consumo humano.','bebidas.jpg')");
            mb.Sql("Insert into Categories(Name, Description,ImageUrl) Values('Lanches','Na cultura ocidental, o lanche é uma refeição composta por pequena porção de alimentos, entre as refeições principais, geralmente entre o almoço e o jantar. Também pode ser chamado de merenda ou café da tarde (Brasil).','lanches.jpg')");
            mb.Sql("Insert into Categories(Name, Description,ImageUrl) Values('Sobremesas','sobremesa significa depois da mesa ou aquilo que sucede a refeição principal. Uma sobremesa pode ser uma fruta qualquer, mas também pode ser uma guloseima. Costuma ser preparada com açúcar, assim apresentando paladar doce. É geralmente servida após a refeição salgada.','sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categories");
        }
    }
}
