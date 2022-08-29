using CORE.Models;
using CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Category> GetSignleCategoryByIdWithProductsAsync(int categoryId)
        {
            return _context.Categories.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
