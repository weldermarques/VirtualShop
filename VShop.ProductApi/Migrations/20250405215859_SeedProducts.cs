using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Products\" (\"Name\", \"Price\", \"Description\", \"Stock\", \"ImageUrl\", \"CategoryId\") " +
                                "VALUES ('Track Pants', 25.12, 'Track pants color red', 10, 'track_pants.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO \"Products\" (\"Name\", \"Price\", \"Description\", \"Stock\", \"ImageUrl\", \"CategoryId\") " +
                                "VALUES ('Camelon Pants', 125.12, 'Track pants color blue', 5, 'camelon_pants.jpg', 1)");
            
            migrationBuilder.Sql("INSERT INTO \"Products\" (\"Name\", \"Price\", \"Description\", \"Stock\", \"ImageUrl\", \"CategoryId\") " +
                                "VALUES ('Diamonds Earring', 1225.12, 'Diamonds Earring silver', 10, 'diamond_earring_5531.jpg', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Products\"");
        }
    }
}
