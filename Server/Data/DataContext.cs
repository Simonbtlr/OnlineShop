namespace OnlineShop.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductVariant>().HasKey(x => new { x.ProductId, x.ProductTypeId });

        modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 1, Name = "По умолчанию"},
            new ProductType { Id = 2, Name = "В мягкой обложке"},
            new ProductType { Id = 3, Name = "Электронная книга"},
            new ProductType { Id = 4, Name = "Аудиокнига"},
            new ProductType { Id = 5, Name = "Стрим"},
            new ProductType { Id = 6, Name = "Blu-ray"},
            new ProductType { Id = 7, Name = "VHS"},
            new ProductType { Id = 8, Name = "PC"},
            new ProductType { Id = 9, Name = "PlayStation"},
            new ProductType { Id = 10, Name = "Xbox"});
        
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Книги",
                Url = "books"
            },
            new Category
            {
                Id = 2,
                Name = "Фильмы",
                Url = "movies"
            },
            new Category
            {
                Id = 3,
                Name = "Видео Игры",
                Url = "video-games"
            });
        
        modelBuilder.Entity<Product>().HasData(
            new Product 
            {
                Id = 1, 
                Title = "Рик и Морти. Книга 1 | Горман Зак", 
                Description = "Если вы следите за невероятными приключениями бедолаги Морти и его деда-алкоголика, " +
                              "учёного и по совместительству межгалактического преступника Рика Санчеза и устали " +
                              "ждать выхода третьего сезона, то эта книга определенно поможет вам скоротать время в " +
                              "ожидании. Приготовьтесь к новой порции безумия, но теперь уже в комиксах, потому что " +
                              "таких историй вы ещё не слышали и не видели! Сюжет комикса не дублирует мультсериал " +
                              "и не оставит равнодушным ни одного любителя отборного интеллектуально-трешёвого юмора " +
                              "и научной фантастики.\n" +
                              "\n" +
                              "Книга включает в себя выпуски комиксов #1-15, а также дополнительные материалы!",
                ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-4/wc1200/6040304632.jpg",
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Title = "Рик и Морти. Нужно больше приключений. Книга 2 | Старкс Кайл",
                Description = "Самые знаменитые мульт-герои современности - теперь и в комиксах!\n" +
                              "Перевод полностью по версии самого Сыендука, а значит вас ждут уже знакомые фразочки " +
                              "и словечки, которые бережно адаптировал на русский язык знаменитый блогер, " +
                              "озвучивающий мультсериал.\n" +
                              "Если вы следите за невероятными приключениями бедолаги Морти и его деда-алкоголика, " +
                              "учёного и по совместительству межгалактического преступника Рика Санчеза и устали " +
                              "ждать выхода очередного сезона, то эта книга определенно поможет вам скоротать время " +
                              "в ожидании. Приготовьтесь к новой порции безумия, но теперь уже в комиксах, потому " +
                              "что таких историй вы ещё не слышали и не видели! Сюжет комикса не дублирует " +
                              "мультсериал и не оставит равнодушным ни одного любителя отборного " +
                              "интеллектуально-трешёвого юмора и научной фантастики.",
                ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-t/wc1200/6100384409.jpg",
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Title = "Рик и Морти. Мир глазами Рика | Карсон Мэтт",
                Description = "Сборник афоризмов самого Рика Санчеза. Часто ли герой мультфильма удостаивается " +
                              "собственного цитатника? Вы знаете ответ! Но Рик — случай исключительный! Цитируйте " +
                              "любимого героя сами и дарите книгу друзьям — несите слово Рика в массы, и да пребудет " +
                              "с вами наука! Вабба лабба даб даб!",
                ImageUrl = "https://cdn1.ozone.ru/s3/multimedia-h/wc1200/6064729421.jpg",
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Title = "Офис",
                Description = "Скучающие от безделья клерки пытаются ужиться с безумным боссом. Виртуозный ситком " +
                              "про рабочие будни.",
                ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/7bbd225f-e6db-4326-b600-1ac294" +
                           "cf9d99/1920x",
                CategoryId = 2
            },
            new Product
            {
                Id = 5,
                Title = "Вся правда о медведях",
                Description = "Гризли, Панда и Белый очень простодушны, но мечтают влиться в мир людей. Трогательные " +
                              "истории с метким юмором.",
                ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1704946/74925575-feba-41d1-880b-cb0eb2" +
                           "c8bf31/1920x",
                CategoryId = 2
            },
            new Product
            {
                Id = 6,
                Title = "Силиконовая долина",
                Description = "Группа гиков живет в инкубаторе и двигает мир интернета вперед. Комедийный сериал о " +
                              "внутренней кухне стартапов.",
                ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/009c26e0-7336-4a70-829b-682bbe" +
                           "119d4d/1920x",
                CategoryId = 2
            },
            new Product
            {
                Id = 7,
                Title = "Half-Life: Alyx",
                Description = "Half-Life: Alyx — это возвращение Valve во вселенную Half-Life в виртуальной " +
                              "реальности. Это история невозможной борьбы с жестокой расой пришельцев, известной как " +
                              "Альянс. События происходят между Half-Life и Half-Life 2.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/b/bb/Half-Life_Alyx_Coverart.jpg",
                CategoryId = 3
            },
            new Product
            {
                Id = 8,
                Title = "Detroit: Become Human",
                Description = "В Detroit: Become Human в ваших руках окажутся судьбы как человечества, так и " +
                              "андроидов. Каждый сделанный вами выбор повлияет на исход игры, в которой " +
                              "реализован одним из самых замысловатых и разветвленных сюжетов из когда-либо " +
                              "созданных в игровой индустрии.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/e/ee/Detroit_Become_Human.jpg",
                CategoryId = 3
            },
            new Product
            {
                Id = 9,
                Title = "Valheim",
                Description = "Игра в жанре выживание, в которой вам предстоит исследовать огромный фэнтезийный мир, " +
                              "пропитанный скандинавской мифологией и культурой викингов.",
                ImageUrl = "https://elamigosedition.com/uploads/posts/2021-02/1613136021_valheim-cover-download.webp",
                CategoryId = 3
            },
            new Product
            {
                Id = 10,
                Title = "Beat Saber",
                Description = "Beat Saber — это VR-ритм-игра, в которой вы режете ритмы адреналиновой музыки, когда " +
                              "они летят к вам, окруженные футуристическим миром.",
                ImageUrl = "https://i.redd.it/roocnhykls851.png",
                CategoryId = 3
            },
            new Product
            {
                Id = 11,
                Title = "Satisfactory",
                Description = "Satisfactory — это игра от первого лица в открытом мире, вы которой вам нужно строить " +
                              "заводы, с упором на исследования и бои. Играйте в одиночестве или с друзьями, " +
                              "исследуйте незнакомую планету, возводите многоэтажные заводы и вступите в конвейерный " +
                              "рай!",
                ImageUrl = "https://cdn.ananasposter.ru/image/cache/catalog/poster/games/80/26094-1000x830.jpg",
                CategoryId = 3
            });

        modelBuilder.Entity<ProductVariant>().HasData(
            new ProductVariant
            {
                ProductId = 1,
                ProductTypeId = 2,
                Price = 1565.75m,
                OriginalPrice = 1645
            },
            new ProductVariant
            {
                ProductId = 1,
                ProductTypeId = 3,
                Price = 1530.85m
            },
            new ProductVariant
            {
                ProductId = 1,
                ProductTypeId = 4,
                Price = 1480.5m,
                OriginalPrice = 1645
            },
            new ProductVariant
            {
                ProductId = 2,
                ProductTypeId = 2,
                Price = 1740.5m,
                OriginalPrice = 1830
            }, 
            new ProductVariant 
            {
                ProductId = 3, 
                ProductTypeId = 2, 
                Price = 925.25m
            }, 
            new ProductVariant 
            {
                ProductId = 4,
                ProductTypeId = 5,
                Price = 225.25m
            },
            new ProductVariant
            {
                ProductId = 4,
                ProductTypeId = 6,
                Price = 290
            },
            new ProductVariant
            {
                ProductId = 4,
                ProductTypeId = 7,
                Price = 149.5m
            },
            new ProductVariant
            {
                ProductId = 5,
                ProductTypeId = 5,
                Price = 225.25m,
            },
            new ProductVariant
            {
                ProductId = 6,
                ProductTypeId = 5,
                Price = 225.5m
            },
            new ProductVariant
            {
                ProductId = 7,
                ProductTypeId = 8,
                Price = 920.25m,
                OriginalPrice = 1085
            },
            new ProductVariant
            {
                ProductId = 7,
                ProductTypeId = 9,
                Price = 1030.75m
            },
            new ProductVariant
            {
                ProductId = 7,
                ProductTypeId = 10,
                Price = 1009.05m,
                OriginalPrice = 1085
            },
            new ProductVariant
            {
                ProductId = 8,
                ProductTypeId = 8,
                Price = 1383.8m,
                OriginalPrice = 1628,
            },
            new ProductVariant
            {
                ProductId = 9,
                ProductTypeId = 8,
                Price = 369.75m
            },
            new ProductVariant
            {
                ProductId = 10,
                ProductTypeId = 1,
                Price = 360.5m,
                OriginalPrice = 515
            },
            new ProductVariant
            {
                ProductId = 11,
                ProductTypeId = 1,
                Price = 419.3m,
                OriginalPrice = 599
            });
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
}