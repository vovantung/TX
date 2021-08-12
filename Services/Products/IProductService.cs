using System.Collections.Generic;
using System.Threading.Tasks;
using TX.ViewModels.Common;
using TX.ViewModels.ProductImages;
using TX.ViewModels.Products;

namespace Services.Products
{
    public interface IProductService
    {

        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductVm> GetById(int productId, string languageId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateOriginalPrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task<bool> AddViewcount(int productId);

        Task<PagedResult<ProductVm>> GetAllPaging(GetProductPagingRequest request);



        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(ProductImageUpdateRequest request);

        //Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImagesofProduct(int productId);

        //Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

        //Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        //Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        //Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
    }
}