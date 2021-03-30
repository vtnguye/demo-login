using Common.Pagination;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Products
{
    public interface IProductsService : IRepository<Product>
    {
        public List<GetProductDTO> GetAll();
        public void UploadFile(List<IFormFile> files, String namePath);
        public Pagination<Product> Paging(SearchPaginationDTO<ProductDTO> pagination);
        public ProductDTO Get(Guid id);
    }
}
