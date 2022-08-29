using AutoMapper;
using CORE.DTOs;
using CORE.Models;
using CORE.Repositories;
using CORE.Services;
using CORE.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public ICategoryRepository _categoryRepository { get; set; }
        public IMapper _mapper { get; set; }
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSignleCategoryByIdWithProductsAsync(int categoryId)
        {
            var categoryWithProducts = await _categoryRepository.GetSignleCategoryByIdWithProductsAsync(categoryId);
            var categoryWithProductsDto = _mapper.Map<CategoryWithProductsDto>(categoryWithProducts);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryWithProductsDto);
        }
    }
}
