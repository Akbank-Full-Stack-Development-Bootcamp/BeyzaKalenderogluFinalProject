using AutoMapper;
using Books.Business.DataTransferObjects;
using Books.Business.Extensions;
using Books.DataAccess.Repositories;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public class CategoryService : ICategoryService
    {
        // where to get all categories is known by repository
        private ICategoryRepository categoryRepository;
        private IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public int AddCategory(AddNewCategoryRequest request)
        {
            var newCategory = request.ConvertToCategory(mapper);
            categoryRepository.Add(newCategory);
            return newCategory.Id;
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.Delete(id);

        }

        public IList<CategoryListResponse> GetAllCategories()
        {
            var dtoList = categoryRepository.GetAll().ToList();
            var result = dtoList.ConvertToListResponse(mapper);
            return result;
        }

        public CategoryBookListResponse GetBooksByCategoryId(int categoryId)
        {
            Category category =  categoryRepository.GetBookListByCategoryId(categoryId);
            return category.ConvertFromEntityToBookList(mapper);
        }

        public CategoryListResponse GetCategoryById(int id)
        {
            Category category = categoryRepository.GetById(id);
            return category.ConvertFromEntity(mapper);
        }

        public int UpdateCategory(EditCategoryRequest request)
        {
            var category = request.ConvertToEntity(mapper);
            int id = categoryRepository.Update(category).Id;
            return id;
        }
    }
}
