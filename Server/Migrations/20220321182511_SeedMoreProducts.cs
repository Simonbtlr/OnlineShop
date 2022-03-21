using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Server.Migrations
{
    public partial class SeedMoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, 2, "Скучающие от безделья клерки пытаются ужиться с безумным боссом. Виртуозный ситком про рабочие будни.", "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/7bbd225f-e6db-4326-b600-1ac294cf9d99/1920x", 299m, "Офис" },
                    { 5, 2, "Гризли, Панда и Белый очень простодушны, но мечтают влиться в мир людей. Трогательные истории с метким юмором.", "https://avatars.mds.yandex.net/get-kinopoisk-image/1704946/74925575-feba-41d1-880b-cb0eb2c8bf31/1920x", 299m, "Вся правда о медведях" },
                    { 6, 2, "Группа гиков живет в инкубаторе и двигает мир интернета вперед. Комедийный сериал о внутренней кухне стартапов.", "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/009c26e0-7336-4a70-829b-682bbe119d4d/1920x", 299m, "Силиконовая долина" },
                    { 7, 3, "Half-Life: Alyx — это возвращение Valve во вселенную Half-Life в виртуальной реальности. Это история невозможной борьбы с жестокой расой пришельцев, известной как Альянс. События происходят между Half-Life и Half-Life 2.", "https://cdn.akamai.steamstatic.com/steam/apps/546560/header.jpg?t=1641577012", 1085m, "Half-Life: Alyx" },
                    { 8, 3, "В Detroit: Become Human в ваших руках окажутся судьбы как человечества, так и андроидов. Каждый сделанный вами выбор повлияет на исход игры, в которой реализован одним из самых замысловатых и разветвленных сюжетов из когда-либо созданных в игровой индустрии.", "https://cdn.akamai.steamstatic.com/steam/apps/1222140/header.jpg?t=1625648054", 1628m, "Detroit: Become Human" },
                    { 9, 3, "Игра в жанре выживание, в которой вам предстоит исследовать огромный фэнтезийный мир, пропитанный скандинавской мифологией и культурой викингов.", "https://cdn.akamai.steamstatic.com/steam/apps/892970/header.jpg?t=1647419457", 435m, "Valheim" },
                    { 10, 3, "Beat Saber — это VR-ритм-игра, в которой вы режете ритмы адреналиновой музыки, когда они летят к вам, окруженные футуристическим миром.", "https://cdn.akamai.steamstatic.com/steam/apps/620980/header.jpg?t=1622461922", 515m, "Beat Saber" },
                    { 11, 3, "Satisfactory — это игра от первого лица в открытом мире, вы которой вам нужно строить заводы, с упором на исследования и бои. Играйте в одиночестве или с друзьями, исследуйте незнакомую планету, возводите многоэтажные заводы и вступите в конвейерный рай!", "https://cdn.akamai.steamstatic.com/steam/apps/526870/header.jpg?t=1637686926", 599m, "Satisfactory" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
