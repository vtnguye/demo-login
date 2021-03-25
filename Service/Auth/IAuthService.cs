using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Auth
{
    public interface IAuthService
    {
        string LogIn(LoginDTO model);

        bool SignUp(LoginDTO body);
    }
}
