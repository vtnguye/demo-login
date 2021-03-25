using AutoMapper;
using Data;
using Domain;
using Domain.DTO;
using Domain.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Users
{
    public class UsersService : Repository<User>, IUsersService
    {
        private IMapper _mapper;
        private ShopDbContext _db;

        public UsersService(IMapper mapper, ShopDbContext db) : base(db)
        {
            _mapper = mapper;
            _db = db;
        }
        public  GetUserDTO FindById(Guid Id)
        {
            var result = _mapper.Map<GetUserDTO>(base.Find(Id));
            return result;
        }
        public List<GetUserDTO> GetAll()
        {
            return _mapper.Map<List<User>, List<GetUserDTO>>(_db.Users.ToList());
        }

    }
}
