using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IAuthorService
    {
        IList<AuthorListResponse> GetAllAuthors();
        IList<AuthorListResponse> SearchAuthor(string name);
        AuthorBookListResponse GetBooksByAuthorId(int authorId);
        int AddAuthor(AddNewAuthorRequest request);
        AuthorListResponse GetAuthorById(int id);
        int UpdateAuthor(EditAuthorRequest request);
        void DeleteAuthor(int id);
    }
}
