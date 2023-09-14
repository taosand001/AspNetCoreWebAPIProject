using AspNetCoreWebAPIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const string V = "Product has been deleted";
        public static List<Product> products = new()
        {
            new Product(){ProductId = 001, Description = "This is product one", Name = "Product One", Price = 1000},
            new Product(){ProductId = 002, Description = "This is product two", Name = "Product two", Price = 2000},
            new Product(){ProductId = 003, Description = "This is product three", Name = "Product three", Price = 3000},
            new Product(){ProductId = 004, Description = "This is product four", Name = "Product four", Price = 4000},
        };

        [HttpGet]
        public List<Product> GetProducts()
        {
            return products;
        }

        [HttpPost]
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id) 
        { 
           var myProduct = products.Find(_product => _product.ProductId == id);
            if(myProduct != null) 
            { 
                return myProduct;
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "product id is not found");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product) 
        { 
            var myproduct = products.Find(_product => _product.ProductId == id);

            if(myproduct != null) 
            { 
                myproduct.Description = product.Description;
                myproduct.Name = product.Name;
                myproduct.Price = product.Price;
                myproduct.ProductId = id;
                return StatusCode(StatusCodes.Status200OK, "The product has been updated");
            }else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        { 
            var myProduct = products.Find(_product => _product.ProductId.Equals(id));
            if(myProduct != null) 
            {
                products.Remove(myProduct);
                return StatusCode(StatusCodes.Status204NoContent);
            }else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
