using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProduto.Data;
using ApiProduto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return Ok(product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Product>> Put([FromServices] DataContext context, [FromBody] Product product, Guid Id)
        {
            if (ModelState.IsValid)
            {
                var productUpdate = await context.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();

                if (productUpdate!=null)
                {
                    productUpdate.Name = product.Name;
                    productUpdate.Price = product.Price;
                    productUpdate.Stock = product.Stock;
                    context.Update(productUpdate);
                }
                else
                {
                    context.Add(product);
                }

                await context.SaveChangesAsync();
                return Ok(product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}