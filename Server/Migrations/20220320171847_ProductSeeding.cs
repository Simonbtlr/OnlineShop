﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Server.Migrations
{
    public partial class ProductSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Если вы следите за невероятными приключениями бедолаги Морти и его деда-алкоголика, учёного и по совместительству межгалактического преступника Рика Санчеза и устали ждать выхода третьего сезона, то эта книга определенно поможет вам скоротать время в ожидании. Приготовьтесь к новой порции безумия, но теперь уже в комиксах, потому что таких историй вы ещё не слышали и не видели! Сюжет комикса не дублирует мультсериал и не оставит равнодушным ни одного любителя отборного интеллектуально-трешёвого юмора и научной фантастики.\n\nКнига включает в себя выпуски комиксов #1-15, а также дополнительные материалы!", "https://cdn1.ozone.ru/s3/multimedia-4/wc1200/6040304632.jpg", 1645m, "Рик и Морти. Книга 1 | Горман Зак" },
                    { 2, "Самые знаменитые мульт-герои современности - теперь и в комиксах!\nПеревод полностью по версии самого Сыендука, а значит вас ждут уже знакомые фразочки и словечки, которые бережно адаптировал на русский язык знаменитый блогер, озвучивающий мультсериал.\nЕсли вы следите за невероятными приключениями бедолаги Морти и его деда-алкоголика, учёного и по совместительству межгалактического преступника Рика Санчеза и устали ждать выхода очередного сезона, то эта книга определенно поможет вам скоротать время в ожидании. Приготовьтесь к новой порции безумия, но теперь уже в комиксах, потому что таких историй вы ещё не слышали и не видели! Сюжет комикса не дублирует мультсериал и не оставит равнодушным ни одного любителя отборного интеллектуально-трешёвого юмора и научной фантастики.", "https://cdn1.ozone.ru/s3/multimedia-t/wc1200/6100384409.jpg", 1830m, "Рик и Морти. Нужно больше приключений. Книга 2 | Старкс Кайл" },
                    { 3, "Сборник афоризмов самого Рика Санчеза. Часто ли герой мультфильма удостаивается собственного цитатника? Вы знаете ответ! Но Рик — случай исключительный! Цитируйте любимого героя сами и дарите книгу друзьям — несите слово Рика в массы, и да пребудет с вами наука! Вабба лабба даб даб!", "https://cdn1.ozone.ru/s3/multimedia-h/wc1200/6064729421.jpg", 975m, "Рик и Морти. Мир глазами Рика | Карсон Мэтт" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
