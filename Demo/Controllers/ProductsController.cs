using AutoMapper;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _productsservice.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDTO body)
        {
            _productsservice.Insert(body);
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult Get( Guid id)
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
