using Domain.DTO;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Users

{
    public interface IUsersService
    {
        bool LogIn(LoginDTO model);

        bool SignUp(LoginDTO body);
        List<GetUserDTO> GetAll();


    }
}
