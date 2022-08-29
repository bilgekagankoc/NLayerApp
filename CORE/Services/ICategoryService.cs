using CORE.DTOs;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetSignleCategoryByIdWithProductsAsync(int categoryId);
    }
}
