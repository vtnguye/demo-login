using AutoMapper;
using Common.Pagination;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("ProductsCors")]
    public class ProductsController : Controller
    {
        private IProductsService _productsservice;
        private IMapper _mapper;
        public ProductsController(IProductsService service, IMapper mapper)
        {
            _productsservice = service;
            _mapper = mapper;
        }
        [HttpGet]
        //[Authorize]
        public IActionResult GetAll([FromQuery] SearchPaginationDTO<ProductDTO> searchPagination)
        {
            var result = _productsservice.Paging(searchPagination);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDTO body)
        {
            var res = _mapper.Map<Product>(body);
            _productsservice.Insert(res);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]

        public IActionResult Get(Guid id)
        {
            var res = _productsservice.Get(id);
            if (res == null)
            {
                return Ok("error");
            }
            return Ok(res);

        }
    }
}
