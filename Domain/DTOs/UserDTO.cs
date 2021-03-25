using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
  
   public  class UserDTO
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }

    }

    public class LoginDTO
    {

        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class GetUserDTO
    {
        public string Username { get; set; }
        public Guid Id { get; set; }

    }
}
