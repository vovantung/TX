using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TX.ViewModels.ProductImages;
using TX.ViewModels.Products;

namespace TX.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
      
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }
        [HttpPost("AddImage")]
        public async Task<IActionResult> AddImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
           var result = await _productService.AddImage(productId, request);
            if (result == 0)
                return BadRequest($"Thêm ảnh vào sản phẩm có id {productId}  không thành công");
            var product = await _productService.GetById(productId, "vi");
            return Ok(product);

        }
        [HttpPut("UpdateImage")]
        public async Task<IActionResult> UpdateImage([FromForm]ProductImageUpdateRequest request)
        {
            var result = await _productService.UpdateImage(request);
            if (result == 0)
               return BadRequest($"Cập nhật thông tin ảnh có id {request.Id} không thành công");
            return Ok($"Cập nhật thông tin ảnh có id {request.Id} thành công");
        }

        [HttpGet("GetListImagesofProduct")]
        public async Task<IActionResult> GetListImagesofProduct(int productId)
        {
            var listImages = await _productService.GetListImagesofProduct(productId);
            if (listImages == null)
                return BadRequest("Không tim thấy hình ảnh nào của sản phẩm có id {productId}");
            return Ok(listImages);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm]ProductUpdateRequest request)
        {
            var result = await _productService.Update(request);
            if (result == 0)
            return BadRequest("Cập nhật sản phẩm không thành công");
            var product = await _productService.GetById(request.Id, "vi");
            return Ok(product);
        }



        [HttpGet("AddViewcount")]
        public async Task<IActionResult> AddViewcount(int productId)
        {
            var result  =  await _productService.AddViewcount(productId);
            if (result)
            {
                var product = await _productService.GetById(productId, "vi");
                return Ok(product);
            }
            return Ok("Thêm lượt xem không thành công");
        }

        [HttpGet("UpdatePrice")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var result = await _productService.UpdatePrice(productId, newPrice);
            if (result)
            {
                var product = await _productService.GetById(productId, "vi");
                return Ok(product);
            }
            return Ok("Cập nhật giá không thành công");
        }
        [HttpGet("UpdateOriginalPrice")]
        public async Task<IActionResult> UpdateOriginalPrice(int productId, decimal newPrice)
        {
            var result = await _productService.UpdateOriginalPrice(productId, newPrice);
            if (result)
            {
                var product = await _productService.GetById(productId, "vi");
                return Ok(product);
            }
            return Ok("Cập nhật giá khuyến  mãi không thành công");

        }

        [HttpGet("UpdateStock")]
        public async Task<IActionResult> UpdateStock(int productId, int additionQuantity)
        {
            var result = await _productService.UpdateStock(productId, additionQuantity);
            if (result)
            {
                var product = await _productService.GetById(productId, "vi");
                return Ok(product);
            }
            return Ok("Thêm  số lượng  sản phẩm vào kho không thành công");
        }


        //http:localhost:port/product/1
        [HttpGet("GetAllPageding")]
        public async Task<IActionResult> GetAllPageding([FromQuery]GetProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int producId, string languageId)
        {
            var product = await _productService.GetById(producId, languageId);
            if (product == null)
                return BadRequest($"Sản phẩm có id:'{producId}' thì không được tìm thấy");
            return Ok(product);
        }


        [HttpPost("Create")]
        //[Consumes("multipart/form-data")]
        //[Authorize]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.LanguageId);

            //return CreatedAtAction(nameof(GetById), new { id = productId }, product);
            return Ok(product);
        }
        [HttpDelete("Delete")]
        //[Authorize]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest($"Không tìm thấy sản phẩm có id: {productId} để xóa");
            return Ok("Đã  xóa sản phẩm thành công");
        }

    }
}
