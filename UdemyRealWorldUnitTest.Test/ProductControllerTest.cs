﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UdemyRealWordUnitTest.Web.Controllers;
using UdemyRealWordUnitTest.Web.Models;
using UdemyRealWordUnitTest.Web.Repository;
using Xunit;

namespace UdemyRealWorldUnitTest.Test
{

    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepo;
        private readonly ProductsController _controller;
        private List<Product> products;
        public ProductControllerTest()
        {
            _mockRepo = new Mock<IRepository<Product>>();
            _controller = new ProductsController(_mockRepo.Object);
            products = new List<Product>() { new Product { Id = 1, Name = "Kalem", Price = 100, Stock = 50, Color = "Kırmızı" },
                new Product { Id = 2, Name = "Kalem2", Price = 150, Stock = 250, Color = "Mavi" } };
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnView()
        {
            var result=await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnProductList()
        {
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(products);
            var result=await _controller.Index();
            var viewResult=Assert.IsType<ViewResult>(result);

            var productList=Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);

            Assert.Equal<int>(2,productList.Count());
        }

        [Fact]
        public async void Details_IdIsNull_ReturnRedirectToIndexAction()
        {
            var result = await _controller.Details(null);
            var redirect=Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index",redirect.ActionName);
        }

        [Fact]
        public async void Details_IdInvalid_ReturnNotFound()
        {
            Product product=null;
            _mockRepo.Setup(x => x.GetById(0)).ReturnsAsync(product);
            var result = await _controller.Details(0);
            var redirect=Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, redirect.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public async void Details_ValidId_ReturnProduct(int productId)
        {
            Product product=products.First(x=>x.Id==productId); 
            _mockRepo.Setup(s=>s.GetById(productId)).ReturnsAsync(product);
            var result=await _controller.Details(productId);
            var viewResult=Assert.IsType<ViewResult>(result);
            var resultProduct=Assert.IsAssignableFrom<Product>(viewResult.Model);

            Assert.Equal(product.Id, resultProduct.Id); 
            Assert.Equal(product.Name,resultProduct.Name);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnView()
        {
            var result=_controller.Create();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void Create_InValidModelState_ReturnView()
        {
            _controller.ModelState.AddModelError("Name", "Name alanı gereklidir");
            var result=await _controller.Create(null);
            var viewResult=Assert.IsType<ViewResult>(result);

            Assert.IsType<Product>(viewResult.Model);
        }
    }
}
