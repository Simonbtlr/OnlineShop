﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineShop.Server.Data;

#nullable disable

namespace OnlineShop.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Книги",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Фильмы",
                            Url = "movies"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Видео Игры",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("OnlineShop.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Если вы следите за невероятными приключениями бедолаги Морти и его деда-алкоголика, учёного и по совместительству межгалактического преступника Рика Санчеза и устали ждать выхода третьего сезона, то эта книга определенно поможет вам скоротать время в ожидании. Приготовьтесь к новой порции безумия, но теперь уже в комиксах, потому что таких историй вы ещё не слышали и не видели! Сюжет комикса не дублирует мультсериал и не оставит равнодушным ни одного любителя отборного интеллектуально-трешёвого юмора и научной фантастики.\n\nКнига включает в себя выпуски комиксов #1-15, а также дополнительные материалы!",
                            ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-4/wc1200/6040304632.jpg",
                            Price = 1645m,
                            Title = "Рик и Морти. Книга 1 | Горман Зак"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Самые знаменитые мульт-герои современности - теперь и в комиксах!\nПеревод полностью по версии самого Сыендука, а значит вас ждут уже знакомые фразочки и словечки, которые бережно адаптировал на русский язык знаменитый блогер, озвучивающий мультсериал.\nЕсли вы следите за невероятными приключениями бедолаги Морти и его деда-алкоголика, учёного и по совместительству межгалактического преступника Рика Санчеза и устали ждать выхода очередного сезона, то эта книга определенно поможет вам скоротать время в ожидании. Приготовьтесь к новой порции безумия, но теперь уже в комиксах, потому что таких историй вы ещё не слышали и не видели! Сюжет комикса не дублирует мультсериал и не оставит равнодушным ни одного любителя отборного интеллектуально-трешёвого юмора и научной фантастики.",
                            ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-t/wc1200/6100384409.jpg",
                            Price = 1830m,
                            Title = "Рик и Морти. Нужно больше приключений. Книга 2 | Старкс Кайл"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Сборник афоризмов самого Рика Санчеза. Часто ли герой мультфильма удостаивается собственного цитатника? Вы знаете ответ! Но Рик — случай исключительный! Цитируйте любимого героя сами и дарите книгу друзьям — несите слово Рика в массы, и да пребудет с вами наука! Вабба лабба даб даб!",
                            ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-h/wc1200/6064729421.jpg",
                            Price = 975m,
                            Title = "Рик и Морти. Мир глазами Рика | Карсон Мэтт"
                        });
                });

            modelBuilder.Entity("OnlineShop.Shared.Product", b =>
                {
                    b.HasOne("OnlineShop.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
