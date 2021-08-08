using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IPublisherService
    {
        IList<PublisherListResponse> GetAllPublishers();
        IList<PublisherListResponse> SearchPublisher(string name);
        IList<BookListResponse> GetBooksByPublisherId(int publisherId);
        int AddPublisher(AddNewPublisherRequest request);
        PublisherListResponse GetPublisherById(int id);
        int UpdatePublisher(EditPublisherRequest request);
        void DeletePublisher(int id);
    }
}
