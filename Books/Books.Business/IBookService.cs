using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IBookService
    {
        IList<BookListResponse> GetAllBooks();
        IList<BookListResponse> SearchBook(string title);
        int AddBook(AddNewBookRequest request);
        BookListResponse GetBookById(int id);
        BookDetailResponse GetBookDetailById(int id);
        int UpdateBook(EditBookRequest request);
        void DeleteBook(int id);
    }
}
