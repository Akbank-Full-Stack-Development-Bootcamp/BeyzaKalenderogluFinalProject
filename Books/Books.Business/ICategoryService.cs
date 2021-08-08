using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface ICategoryService
    {
        IList<CategoryListResponse> GetAllCategories();
        CategoryBookListResponse GetBooksByCategoryId(int categoryId);

        //returns lastly added category entity id:
        int AddCategory(AddNewCategoryRequest request);
        CategoryListResponse GetCategoryById(int id);
        int UpdateCategory(EditCategoryRequest request);
        void DeleteCategory(int id);
    }
}
