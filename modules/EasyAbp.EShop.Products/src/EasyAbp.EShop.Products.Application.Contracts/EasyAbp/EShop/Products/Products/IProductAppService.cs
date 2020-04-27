using System;
using System.Threading.Tasks;
using EasyAbp.EShop.Products.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.EShop.Products.Products
{
    public interface IProductAppService :
        ICrudAppService< 
            ProductDto, 
            Guid, 
            GetProductListDto,
            CreateUpdateProductDto,
            CreateUpdateProductDto>
    {
        Task DeleteAsync(Guid id, Guid storeId);
    }
}