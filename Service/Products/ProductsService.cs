using AutoMapper;
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
        public ProductsService(ShopDbContext db, IMapper mapper):base(db)
        {
            _db = db;
            _mapper = mapper;
        }
        public ProductDTO Get(Guid Id)
        {
            return _mapper.Map<ProductDTO>(base.Find(Id));
        }

        public List<ProductDTO> GetAll()
        {
            return _mapper.Map<List<ProductDTO>>(_db.Products.ToList());
        }

        public bool Insert(ProductDTO model)
        {
            var insert = _mapper.Map<ProductDTO,Product>(model);
            insert.Id = Guid.NewGuid();
            var result = base.Insert(insert);
            return !(result == null);
            
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
