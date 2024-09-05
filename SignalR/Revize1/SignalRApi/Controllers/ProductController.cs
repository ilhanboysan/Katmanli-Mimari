using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategories
            {
                ProductDescription = y.ProductDescription,
                CategoryName = y.Category.CategoryName, 
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductImageUrl = y.ProductImageUrl,
                ProductPrice = y.ProductPrice,
                ProductStatus = y.ProductStatus
            });
            return Ok(values.ToList());
        }


        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount()); 
        }
		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}
		[HttpGet("ProductPriceBySteakBurger")]
		public IActionResult ProductPriceBySteakBurger()
		{
			return Ok(_productService.TProductPriceBySteakBurger());
		}
		[HttpGet("TotalPriceByDrinkCategory")]
		public IActionResult TotalPriceByDrinkCategory()
		{
			return Ok(_productService.TTotalPriceByDrinkCategory());
		}
		[HttpGet("TotalPriceBySaladCategory")]
		public IActionResult TotalPriceBySaladCategory()
		{
			return Ok(_productService.TTotalPriceBySaladCategory());
		}
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNamePriceMax());
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNamePriceMin());
		}
		[HttpGet("ProductAvgPriceByHamburger")]
		public IActionResult ProductAvgPriceByHamburger()
		{
			return Ok(_productService.TProductAvgPriceByHamburger());
		}
		[HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                ProductDescription=createProductDto.ProductDescription,
                ProductName=createProductDto.ProductName,
                ProductImageUrl=createProductDto.ProductImageUrl,
                ProductPrice=createProductDto.ProductPrice,
                ProductStatus = createProductDto.ProductStatus,
                CategoryID= createProductDto.CategoryID

            });
            return Ok("Ürün bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {

              ProductDescription = updateProductDto.ProductDescription,
              ProductID=updateProductDto.ProductID,
              ProductStatus=updateProductDto.ProductStatus,
              ProductName=updateProductDto.ProductName,
              ProductImageUrl=updateProductDto.ProductImageUrl,
              ProductPrice = updateProductDto.ProductPrice,
              CategoryID= updateProductDto.CategoryID



            });
            return Ok("Ürün Bilgisi Güncellendi");
        }
    }
}
