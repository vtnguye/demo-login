using Domain.DTO;
using Domain.DTOs;
using Domain.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Users

{
    public interface IUsersService :IRepository<User>
    {
        GetUserDTO FindById(Guid id);
        List<GetUserDTO> GetAll();

    }
}
