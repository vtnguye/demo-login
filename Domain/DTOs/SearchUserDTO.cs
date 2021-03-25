using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class SearchUserDTO
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public int Take
        {
            get
            {
                return PageIndex * PageSize;
            }
        }
    }
}
