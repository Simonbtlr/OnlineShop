﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineShop.Server.Data;

#nullable disable

namespace OnlineShop.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220329211500_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "ProductId", "ProductTypeId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.Category", b =>
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

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("OrderId", "ProductId", "ProductTypeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.Product", b =>
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

                    b.Property<bool>("Featured")
                        .HasColumnType("boolean");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

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
                            Featured = true,
                            ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-4/wc1200/6040304632.jpg",
                            Title = "Рик и Морти. Книга 1 | Горман Зак"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Самые знаменитые мульт-герои современности - теперь и в комиксах!\nПеревод полностью по версии самого Сыендука, а значит вас ждут уже знакомые фразочки и словечки, которые бережно адаптировал на русский язык знаменитый блогер, озвучивающий мультсериал.\nЕсли вы следите за невероятными приключениями бедолаги Морти и его деда-алкоголика, учёного и по совместительству межгалактического преступника Рика Санчеза и устали ждать выхода очередного сезона, то эта книга определенно поможет вам скоротать время в ожидании. Приготовьтесь к новой порции безумия, но теперь уже в комиксах, потому что таких историй вы ещё не слышали и не видели! Сюжет комикса не дублирует мультсериал и не оставит равнодушным ни одного любителя отборного интеллектуально-трешёвого юмора и научной фантастики.",
                            Featured = false,
                            ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-t/wc1200/6100384409.jpg",
                            Title = "Рик и Морти. Нужно больше приключений. Книга 2 | Старкс Кайл"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Сборник афоризмов самого Рика Санчеза. Часто ли герой мультфильма удостаивается собственного цитатника? Вы знаете ответ! Но Рик — случай исключительный! Цитируйте любимого героя сами и дарите книгу друзьям — несите слово Рика в массы, и да пребудет с вами наука! Вабба лабба даб даб!",
                            Featured = false,
                            ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-h/wc1200/6064729421.jpg",
                            Title = "Рик и Морти. Мир глазами Рика | Карсон Мэтт"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Скучающие от безделья клерки пытаются ужиться с безумным боссом. Виртуозный ситком про рабочие будни.",
                            Featured = false,
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/7bbd225f-e6db-4326-b600-1ac294cf9d99/1920x",
                            Title = "Офис"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Гризли, Панда и Белый очень простодушны, но мечтают влиться в мир людей. Трогательные истории с метким юмором.",
                            Featured = true,
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1704946/74925575-feba-41d1-880b-cb0eb2c8bf31/1920x",
                            Title = "Вся правда о медведях"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Группа гиков живет в инкубаторе и двигает мир интернета вперед. Комедийный сериал о внутренней кухне стартапов.",
                            Featured = false,
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/009c26e0-7336-4a70-829b-682bbe119d4d/1920x",
                            Title = "Силиконовая долина"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "Half-Life: Alyx — это возвращение Valve во вселенную Half-Life в виртуальной реальности. Это история невозможной борьбы с жестокой расой пришельцев, известной как Альянс. События происходят между Half-Life и Half-Life 2.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/b/bb/Half-Life_Alyx_Coverart.jpg",
                            Title = "Half-Life: Alyx"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "В Detroit: Become Human в ваших руках окажутся судьбы как человечества, так и андроидов. Каждый сделанный вами выбор повлияет на исход игры, в которой реализован одним из самых замысловатых и разветвленных сюжетов из когда-либо созданных в игровой индустрии.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/e/ee/Detroit_Become_Human.jpg",
                            Title = "Detroit: Become Human"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Игра в жанре выживание, в которой вам предстоит исследовать огромный фэнтезийный мир, пропитанный скандинавской мифологией и культурой викингов.",
                            Featured = false,
                            ImageUrl = "https://elamigosedition.com/uploads/posts/2021-02/1613136021_valheim-cover-download.webp",
                            Title = "Valheim"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Description = "Beat Saber — это VR-ритм-игра, в которой вы режете ритмы адреналиновой музыки, когда они летят к вам, окруженные футуристическим миром.",
                            Featured = true,
                            ImageUrl = "https://i.redd.it/roocnhykls851.png",
                            Title = "Beat Saber"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "Satisfactory — это игра от первого лица в открытом мире, вы которой вам нужно строить заводы, с упором на исследования и бои. Играйте в одиночестве или с друзьями, исследуйте незнакомую планету, возводите многоэтажные заводы и вступите в конвейерный рай!",
                            Featured = false,
                            ImageUrl = "https://cdn.ananasposter.ru/image/cache/catalog/poster/games/80/26094-1000x830.jpg",
                            Title = "Satisfactory"
                        });
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "По умолчанию"
                        },
                        new
                        {
                            Id = 2,
                            Name = "В мягкой обложке"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Электронная книга"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Аудиокнига"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Стрим"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Blu-ray"
                        },
                        new
                        {
                            Id = 7,
                            Name = "VHS"
                        },
                        new
                        {
                            Id = 8,
                            Name = "PC"
                        },
                        new
                        {
                            Id = 9,
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Xbox"
                        });
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 2,
                            OriginalPrice = 1645m,
                            Price = 1565.75m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 3,
                            OriginalPrice = 0m,
                            Price = 1530.85m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 4,
                            OriginalPrice = 1645m,
                            Price = 1480.5m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 2,
                            OriginalPrice = 1830m,
                            Price = 1740.5m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 2,
                            OriginalPrice = 0m,
                            Price = 925.25m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 5,
                            OriginalPrice = 0m,
                            Price = 225.25m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 6,
                            OriginalPrice = 0m,
                            Price = 290m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 7,
                            OriginalPrice = 0m,
                            Price = 149.5m
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 5,
                            OriginalPrice = 0m,
                            Price = 225.25m
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 5,
                            OriginalPrice = 0m,
                            Price = 225.5m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 8,
                            OriginalPrice = 1085m,
                            Price = 920.25m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 9,
                            OriginalPrice = 0m,
                            Price = 1030.75m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 10,
                            OriginalPrice = 1085m,
                            Price = 1009.05m
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 8,
                            OriginalPrice = 1628m,
                            Price = 1383.8m
                        },
                        new
                        {
                            ProductId = 9,
                            ProductTypeId = 8,
                            OriginalPrice = 0m,
                            Price = 369.75m
                        },
                        new
                        {
                            ProductId = 10,
                            ProductTypeId = 1,
                            OriginalPrice = 515m,
                            Price = 360.5m
                        },
                        new
                        {
                            ProductId = 11,
                            ProductTypeId = 1,
                            OriginalPrice = 599m,
                            Price = 419.3m
                        });
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.OrderItem", b =>
                {
                    b.HasOne("OnlineShop.Shared.Models.Shop.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Shared.Models.Shop.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Shared.Models.Shop.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.Product", b =>
                {
                    b.HasOne("OnlineShop.Shared.Models.Shop.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.ProductVariant", b =>
                {
                    b.HasOne("OnlineShop.Shared.Models.Shop.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Shared.Models.Shop.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("OnlineShop.Shared.Models.Shop.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}