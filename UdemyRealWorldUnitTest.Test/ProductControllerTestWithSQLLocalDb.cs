using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UdemyRealWordUnitTest.Web.Models;
using UdemyRealWorldUnitTest.Web.Controllers;
using Xunit;

namespace UdemyRealWorldUnitTest.Test
{
    public class ProductControllerTestWithSQLLocalDb : ProductControllerTest
    {
        public ProductControllerTestWithSQLLocalDb()
        {
            var sqlCon = @"Server=(localdb)\\MSSQLLocalDb;Database=TestDB,Trusted_Connection=true";
            
            SetContextOptions(new DbContextOptionsBuilder<UdemyUnitTestDBContext>().UseSqlServer(sqlCon).Options);
        }

        [Fact]
        public async Task Create_ModelValidProduct_ReturnRedirectoActionWithSaveProduct()
        {
            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var category = context.Category.First();
                var newProduct = new Product { Name = "Kalem30", CategoryId = category.Id, Price = 100, Stock = 0, Color = "Red" };

                var controller = new ProductController(context);

                var result = await controller.Create(newProduct);
                var redirect = Assert.IsType<RedirectToActionResult>(result);

                Assert.Equal("Index", redirect.ActionName);


            }
            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var product = context.Product.Where(x => x.Name == "Kalem30").FirstOrDefault();
                Assert.Equal("Kalem30", product.Name);
            }

        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteCategory_ExistCategoryId_DeleteAllProducts(int categoryId)
        {
            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var category = await context.Category.FindAsync(categoryId);

                context.Category.Remove(category);
                context.SaveChanges();
            }
            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var product = await context.Product.Where(x => x.CategoryId == categoryId).ToListAsync();
                Assert.Empty(product);
            }
        }
    }
}
