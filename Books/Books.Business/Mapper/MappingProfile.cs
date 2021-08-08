
using AutoMapper;
using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // if Category is given get the CategoryListResponse
            // if CategoryListResponse is given get the Category(ReverseMap)
            CreateMap<Category, CategoryListResponse>().ReverseMap();
            CreateMap<Category, AddNewCategoryRequest>().ReverseMap();
            CreateMap<Category, EditCategoryRequest>().ReverseMap();
            CreateMap<Category, CategoryBookListResponse>().ReverseMap();

            CreateMap<Author, AuthorListResponse>().ReverseMap();
            CreateMap<Author, AddNewAuthorRequest>().ReverseMap();
            CreateMap<Author, EditAuthorRequest>().ReverseMap();
            CreateMap<Author, AuthorBookListResponse>().ReverseMap();

            CreateMap<Book, BookListResponse>().ReverseMap();
            CreateMap<Book, BookDetailResponse>().ReverseMap();
            CreateMap<Book, AddNewBookRequest>().ReverseMap();
            CreateMap<Book, EditBookRequest>().ReverseMap();

            CreateMap<Publisher, PublisherListResponse>().ReverseMap();
            CreateMap<Publisher, AddNewPublisherRequest>().ReverseMap();
            CreateMap<Publisher, EditPublisherRequest>().ReverseMap();
            CreateMap<Publisher, PublisherBookListResponse>().ReverseMap();
        }
    }
}
