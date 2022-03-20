namespace OnlineShop.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
                Price = 1645
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
                Price = 1830
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
                Price = 975
            });
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
}