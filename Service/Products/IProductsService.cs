using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Products
{
    public interface IProductsService
    {
        public bool Insert(ProductDTO model);

        public bool Update(ProductDTO model);
        public ProductDTO Get(Guid Id);
        public List<Product> GetAll();
        public string UploadFile(ProductDTO model);
       
    }
}
