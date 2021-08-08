using AutoMapper;
using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.Extensions
{
    public static class Converters
    {
        public static List<CategoryListResponse> ConvertToListResponse(this List<Category> categories, IMapper mapper)
        {
            //var result = new List<CategoryListResponse>();
            //categories.ForEach(x => result.Add(new CategoryListResponse 
            //{
            //    Id = x.Id,
            //    Name = x.Name 
            //}));

            //return result;

            //Converts categories to CategoryListResponse
            return mapper.Map<List<CategoryListResponse>>(categories);
        }

        public static List<AuthorListResponse> ConvertToListResponse(this List<Author> authors, IMapper mapper)
        {
            return mapper.Map<List<AuthorListResponse>>(authors);
        }

        public static List<BookListResponse> ConvertToListResponse(this List<Book> books, IMapper mapper)
        {
            return mapper.Map<List<BookListResponse>>(books);
        }

        public static List<PublisherListResponse> ConvertToListResponse(this List<Publisher> publishers, IMapper mapper)
        {
            return mapper.Map<List<PublisherListResponse>>(publishers);
        }
        public static Category ConvertToCategory(this AddNewCategoryRequest request, IMapper mapper)
        {
            // gets the request and convert to category
            return mapper.Map<Category>(request);
        }

        public static Book ConvertToBook(this AddNewBookRequest request, IMapper mapper)
        {
            // gets the request and convert to category
            return mapper.Map<Book>(request);
        }

        public static Publisher ConvertToPublisher(this AddNewPublisherRequest request, IMapper mapper)
        {
            // gets the request and convert to category
            return mapper.Map<Publisher>(request);
        }
        public static Author ConvertToAuthor(this AddNewAuthorRequest request, IMapper mapper)
        {
            // gets the request and convert to author
            return mapper.Map<Author>(request);
        }
        public static CategoryListResponse ConvertFromEntity(this Category category, IMapper mapper)
        {
            //gets the category and converts to response
            return mapper.Map<CategoryListResponse>(category);
        }

        public static BookDetailResponse ConvertBookFromEntity(this Book book, IMapper mapper)
        {
            //gets the category and converts to response
            return mapper.Map<BookDetailResponse>(book);
        }
        public static CategoryBookListResponse ConvertFromEntityToBookList(this Category category, IMapper mapper)
        {
            //gets the category and converts to response
            return mapper.Map<CategoryBookListResponse>(category);
        }

        public static PublisherBookListResponse ConvertFromEntityToBookList(this Publisher publisher, IMapper mapper)
        {
            return mapper.Map<PublisherBookListResponse>(publisher);
        }

        public static AuthorBookListResponse ConvertFromEntityToBookList(this Author author, IMapper mapper)
        {
            //gets the category and converts to response
            return mapper.Map<AuthorBookListResponse>(author);
        }


        public static AuthorListResponse ConvertFromEntity(this Author author, IMapper mapper)
        {
            //gets the author and converts to response
            return mapper.Map<AuthorListResponse>(author);
        }

        public static BookListResponse ConvertFromEntity(this Book book, IMapper mapper)
        {
            //gets the book and converts to response
            return mapper.Map<BookListResponse>(book);
        }


        public static PublisherListResponse ConvertFromEntity(this Publisher publisher, IMapper mapper)
        {
            //gets the category and converts to response
            return mapper.Map<PublisherListResponse>(publisher);
        }

        public static Category ConvertToEntity(this EditCategoryRequest request, IMapper mapper)
        {
            //coverts request to Category
            return mapper.Map<Category>(request);
        }

        public static Author ConvertToEntity(this EditAuthorRequest request, IMapper mapper)
        {
            //converts request to Author
            return mapper.Map<Author>(request);
        }
        public static Book ConvertToEntity(this EditBookRequest request, IMapper mapper)
        {
            //converts request to Book
            return mapper.Map<Book>(request);
        }
        public static Publisher ConvertToEntity(this EditPublisherRequest request, IMapper mapper)
        {
            //converts request to Publisher
            return mapper.Map<Publisher>(request);
        }
    }
}
