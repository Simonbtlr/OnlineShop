namespace OnlineShop.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
                Price = 1645,
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
                Price = 1830,
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
                Price = 975,
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
                Price = 299,
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
                Price = 299,
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
                Price = 299,
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
                Price = 1085,
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
                Price = 1628,
                CategoryId = 3
            },
            new Product
            {
                Id = 9,
                Title = "Valheim",
                Description = "Игра в жанре выживание, в которой вам предстоит исследовать огромный фэнтезийный мир, " +
                              "пропитанный скандинавской мифологией и культурой викингов.",
                ImageUrl = "https://elamigosedition.com/uploads/posts/2021-02/1613136021_valheim-cover-download.webp",
                Price = 435,
                CategoryId = 3
            },
            new Product
            {
                Id = 10,
                Title = "Beat Saber",
                Description = "Beat Saber — это VR-ритм-игра, в которой вы режете ритмы адреналиновой музыки, когда " +
                              "они летят к вам, окруженные футуристическим миром.",
                ImageUrl = "https://i.redd.it/roocnhykls851.png",
                Price = 515,
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
                Price = 599,
                CategoryId = 3
            });
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}