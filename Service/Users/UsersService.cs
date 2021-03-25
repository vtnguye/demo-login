using AutoMapper;
using Data;
using Domain;
using Domain.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Service.Users
{
    public class UsersService : IUsersService
    {
        private IMapper _mapper;
        private ShopDbContext _db;

        public UsersService(IMapper mapper, ShopDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public List<GetUserDTO> GetAll()
        {


            return _mapper.Map<List<User>, List<GetUserDTO>>(_db.Users.ToList());

        }

        public bool LogIn(LoginDTO model)
        {
            return _db.Users.Any(t => t.Username == model.Username && t.Password == model.Password);
        }

        public bool SignUp(LoginDTO body)
        {
            var map = _mapper.Map<User>(body);
            _db.Users.Add(map);
            return _db.SaveChanges() > 0;

        }
    }
}
