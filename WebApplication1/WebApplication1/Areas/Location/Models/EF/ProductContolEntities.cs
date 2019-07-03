namespace WebApplication1.Models
{
    using System.Data.Entity;

    public class ProductContolEntities : DbContext
    {
        // Контекст настроен для использования строки подключения "ProductContolEntities" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WebApplication1.Models.ProductContolEntities" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ProductContolEntities" 
        // в файле конфигурации приложения.
        public ProductContolEntities()
            : base("name=AppData")
        {
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}