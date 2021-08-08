using AutoMapper;
using Books.DataAccess.Repositories;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public IList<User> GetAllUsers()
        {
            return userRepository.GetAll().ToList();
            
        }

        public User GetUser(string userName, string password)
        {
            return userRepository.GetWithCriteria(x => x.Username == userName && x.Password == password).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(User request)
        {
            throw new NotImplementedException();
        }
    }
}
