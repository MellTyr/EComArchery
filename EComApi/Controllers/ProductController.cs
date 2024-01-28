using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComApi.Database;
using EComApi.Database.Models;
using EComApi.Services.ProductManager;
using EComApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EComApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManagerService productManagerService;

        public ProductController(IProductManagerService productManagerService)
        {
            this.productManagerService = productManagerService;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            return Ok(productManagerService.GetProducts());
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct(ProductVM product)
        {
            return Ok(productManagerService.CreateProduct(product));
        }
    }
}
