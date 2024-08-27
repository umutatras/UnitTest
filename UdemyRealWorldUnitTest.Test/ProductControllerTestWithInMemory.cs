﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyRealWordUnitTest.Web.Models;
using UdemyRealWorldUnitTest.Web.Controllers;
using Xunit;

namespace UdemyRealWorldUnitTest.Test
{
     public class ProductControllerTestWithInMemory:ProductControllerTest
    {
        public ProductControllerTestWithInMemory()
        {
            SetContextOptions(new DbContextOptionsBuilder<UdemyUnitTestDBContext>().UseInMemoryDatabase("UdemyUnitTestInMemoryDb").Options);
        }

        [Fact]
        public async Task Create_ModelValidProduct_ReturnRedirectoActionWithSaveProduct()
        {
            using(var context=new UdemyUnitTestDBContext(_contextOptions))
            {
                var category = context.Category.First();
                var newProduct=new Product { Name="Kalem30",CategoryId=category.Id,Price=100,Stock=0,Color="Red"};

                var controller=new ProductController(context);

                var result=await controller.Create(newProduct);
                var redirect=Assert.IsType<RedirectToActionResult>(result);

               Assert.Equal("Index",redirect.ActionName);


            }
            using (var context = new UdemyUnitTestDBContext(_contextOptions))
            {
                var product=context.Product.Where(x=>x.Name== "Kalem30").FirstOrDefault();
                Assert.Equal("Kalem30", product.Name);
            }

            }
    }
}
