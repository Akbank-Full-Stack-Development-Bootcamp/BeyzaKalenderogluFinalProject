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
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository authorRepository;
        private IMapper mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public int AddAuthor(AddNewAuthorRequest request)
        {
            var newAuthor = request.ConvertToAuthor(mapper);
            authorRepository.Add(newAuthor);
            return newAuthor.Id;
        }

        public void DeleteAuthor(int id)
        {
            authorRepository.Delete(id);
        }

        public IList<AuthorListResponse> GetAllAuthors()
        {
            var dtoList = authorRepository.GetAll().ToList();
            var result = dtoList.ConvertToListResponse(mapper);
            return result;
        }

        public AuthorListResponse GetAuthorById(int id)
        {
            Author author = authorRepository.GetById(id);
            return author.ConvertFromEntity(mapper);
        }

        public AuthorBookListResponse GetBooksByAuthorId(int authorId)
        {
            Author author = authorRepository.GetBookListByAuthorId(authorId);
            return author.ConvertFromEntityToBookList(mapper);
        }

        public IList<AuthorListResponse> SearchAuthor(string name)
        {
            var dtoList = authorRepository.Search(name).ToList();
            return dtoList.ConvertToListResponse(mapper);
        }

        public int UpdateAuthor(EditAuthorRequest request)
        {
            var author = request.ConvertToEntity(mapper);
            int id = authorRepository.Update(author).Id;
            return id;
        }
    }
}
