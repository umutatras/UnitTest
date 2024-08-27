using Microsoft.EntityFrameworkCore;
using UdemyRealWordUnitTest.Web.Models;

namespace UdemyRealWorldUnitTest.Test
{
    public class ProductControllerTest
    {
        protected DbContextOptions<UdemyUnitTestDBContext> _contextOptions { get; private set; }

        public void SetContextOptions(DbContextOptions<UdemyUnitTestDBContext> contextOptions)
        {
            _contextOptions = contextOptions;
            Seed();
        }
        public void Seed()
        {
            using (UdemyUnitTestDBContext context=new UdemyUnitTestDBContext(_contextOptions)) {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Category.Add(new Web.Models.Category()
                {
                    Name = "Kalemler",

                });   context.Category.Add(new Web.Models.Category()
                {
                    Name = "Kalemler2",

                });
                context.SaveChanges();
                context.Product.AddRange(new Product()
                {
                    CategoryId = 1,
                    Name = "Test",
                    Color = "Red",
                    Price = 100,
                    Stock = 100,
                },
                new Product()
                {
                    CategoryId = 1,
                    Name = "Test3",
                    Color = "Red3",
                    Price = 100,
                    Stock = 100,
                },
                new Product()
                {
                    CategoryId = 1,
                    Name = "Test2",
                    Color = "Red2",
                    Price = 100,
                    Stock = 100,
                });
                context.SaveChanges();

            }
        }

    }
}
