using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Image
        {
            get
            {
                var result = "";
                if (File != null)
                {
                    for (int i = 0; i < File.Count; i++)
                    {
                        if (i == 0)
                        {
                            result += File[i].FileName;
                            continue;
                        }
                        result += ";" + File[i].FileName;
                    }
                }
                return result;
            }
        }
        public List<IFormFile> File { get; set; }

    }
    public class GetProductDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }


    }
}
