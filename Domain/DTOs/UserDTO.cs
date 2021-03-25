using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class SearchPagingDTO
    {
        public int TotalItem { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPage
        {
            get
            {
                if(PageSize <= 0)
                {
                    return 1;
                }
                return (int)Math.Ceiling((decimal)TotalItem / PageSize);
            }
        }
    }
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
