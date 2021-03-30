using AutoMapper;
using Common.Pagination;
using Data;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Service.Products
{
    public class ProductsService : Repository<Product>, IProductsService
    {
        private ShopDbContext _db;
        private IMapper _mapper;
        public ProductsService(ShopDbContext db, IMapper mapper) : base(db)
        {
            _db = db;
            _mapper = mapper;
        }
        public ProductDTO Get(Guid Id)
        {
            return _mapper.Map<ProductDTO>(base.Find(Id));
        }

        public List<GetProductDTO> GetAll()
        {
            var res = _mapper.Map<List<Product>, List<GetProductDTO>>(_db.Products.ToList());
            return res;
        }

        public bool Insert(ProductDTO model)
        {
            var insert = _mapper.Map<ProductDTO, Product>(model);
            insert.Id = Guid.NewGuid();
            var result = base.Insert(insert);
            return !(result == null);

        }

        public Pagination<Product> Paging(SearchPaginationDTO<ProductDTO> pagination)
        {
            if (pagination == null)
            {
                return new Pagination<Product>();
            }

            var data = _db.Products.Where(t =>

                pagination.Search == null ||
                (t.Id.Equals(pagination.Search.Id) &&
                t.Name.Contains(pagination.Search.Name))
                ).OrderBy(t => t.Name).ThenBy(t => t.Id).ThenBy(t => t.Quantity);

            var result = _mapper.Map<SearchPaginationDTO<ProductDTO>, Pagination<Product>>(pagination);
            var productdtos = data.Take(pagination.Take).Skip(pagination.Skip).ToList();

            result.InputData(totalItems: data.Count(), data: productdtos);
            return result;
        }

        public void Update(ProductDTO model)
        {
            var update = _mapper.Map<ProductDTO, Product>(model);
            base.Update(update);
        }

        public async void UploadFile(List<IFormFile> files, String namePath)
        {
            var filePath = Directory.GetCurrentDirectory() + @"\wwwroot\Images\Products\" + namePath;
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }
            if (files != null && files.Count > 0)
            {
                Directory.CreateDirectory(filePath);
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = File.Create(filePath + @"\" + formFile.FileName))
                        {
                            //stream.Write();
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
            }

        }
    }
}
