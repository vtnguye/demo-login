using AutoMapper;
using Data;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Products
{
    public class ProductsService : IProductsService
    {
        private ShopDbContext _db;
        private IMapper _mapper;
        public ProductsService(ShopDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public ProductDTO Get(Guid Id)
        {
            return _mapper.Map<ProductDTO>(_db.Products.Find(Id));
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public bool Insert(ProductDTO model)
        {
            var insert = _mapper.Map<ProductDTO,Product>(model);
            insert.Id = Guid.NewGuid();
            _db.Products.Add(insert);
            return _db.SaveChanges() > 0;
            
        }

        public bool Update(ProductDTO model)
        {
            var update = _mapper.Map<ProductDTO, Product>(model);
            var result = _db.Products.Update(update);
            return _db.SaveChanges() > 0;
        }

        public string UploadFile(ProductDTO model)
        {
            //var files = model.File;
            //long size = files.Sum(f => f.Length);

            //foreach (var formFile in files)
            //{
            //    if (formFile.Length > 0)
            //    {
            //        var filePath = Path.GetTempFileName();

            //        using (var stream = System.IO.File.Create(filePath))
            //        {
            //            await formFile.CopyToAsync(stream);
            //        }
            //    }
            //}

            return "a";
        }
    }
}
