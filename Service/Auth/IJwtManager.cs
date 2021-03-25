using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Service.Auth
{
    public interface IJwtManager
    {
        string GenerateJSONWebToken(UserDTO model);
    }
}