using AutoMapper;
using Common.Pagination;
using Data;
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
        public GetUserDTO FindById(Guid Id)
        {
            var result = _mapper.Map<GetUserDTO>(base.Find(Id));
            return result;
        }
        public List<GetUserDTO> GetAll()
        {
            return _mapper.Map<List<User>, List<GetUserDTO>>(_db.Users.ToList());
        }

        public Pagination<UserDTO> GetPagination(SearchPaginationDTO<UserDTO> pagination)
        {
            if (pagination == null)
            {
                return new Pagination<UserDTO>();
            }

            var result = _mapper.Map<SearchPaginationDTO<UserDTO>, Pagination<UserDTO>>(pagination);
            var matchUsers = _db.Users
                .Where(it => pagination.Search == null || it.Username.Contains(pagination.Search.Username))
                .OrderBy(it => it.Role)
                .ThenBy(it => it.Username);
            var userDTOs = _mapper.Map<List<User>, List<UserDTO>>(
                matchUsers
                .Take(pagination.Take)
                .Skip(pagination.Skip)
                .ToList()
            );
            result.InputData(totalItems: matchUsers.Count(), data: userDTOs);

            return result;
        }
    }
}
