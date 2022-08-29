using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSignleCategoryByIdWithProductsAsync(int categoryId);
    }
}
