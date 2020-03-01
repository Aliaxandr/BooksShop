using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Book_bookid",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "bookid",
                table: "CartItems",
                newName: "bookID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_bookid",
                table: "CartItems",
                newName: "IX_CartItems_bookID");

            migrationBuilder.AlterColumn<int>(
                name: "bookID",
                table: "CartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Book_bookID",
                table: "CartItems",
                column: "bookID",
                principalTable: "Book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Book_bookID",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "bookID",
                table: "CartItems",
                newName: "bookid");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_bookID",
                table: "CartItems",
                newName: "IX_CartItems_bookid");

            migrationBuilder.AlterColumn<int>(
                name: "bookid",
                table: "CartItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Book_bookid",
                table: "CartItems",
                column: "bookid",
                principalTable: "Book",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
