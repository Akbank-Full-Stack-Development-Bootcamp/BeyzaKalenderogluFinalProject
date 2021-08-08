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
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository publisherRepository;
        private IMapper mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper )
        {
            this.publisherRepository = publisherRepository;
            this.mapper = mapper;
        }

        public int AddPublisher(AddNewPublisherRequest request)
        {
            var newPublisher = request.ConvertToPublisher(mapper);
            publisherRepository.Add(newPublisher);
            return newPublisher.Id;
        }

        public void DeletePublisher(int id)
        {
            publisherRepository.Delete(id);
        }

        public IList<PublisherListResponse> GetAllPublishers()
        {
            var dtoList = publisherRepository.GetAll().ToList();
            var result = dtoList.ConvertToListResponse(mapper);
            return result;
        }

        public IList<BookListResponse> GetBooksByPublisherId(int publisherId)
        {
            var dtoList = publisherRepository.GetBookListByPublisherId(publisherId).ToList();
            return dtoList.ConvertToListResponse(mapper);
        }

        public PublisherListResponse GetPublisherById(int id)
        {
            Publisher publisher = publisherRepository.GetById(id);
            return publisher.ConvertFromEntity(mapper);
        }

        public IList<PublisherListResponse> SearchPublisher(string name)
        {
            var dtoList = publisherRepository.Search(name).ToList();
            return dtoList.ConvertToListResponse(mapper);
        }

        public int UpdatePublisher(EditPublisherRequest request)
        {
            var publisher = request.ConvertToEntity(mapper);
            int id = publisherRepository.Update(publisher).Id;
            return id;
        }
    }
}
