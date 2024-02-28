﻿using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        
        IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
            
        }
        [HttpPost]
        public IActionResult Add(CreateBrandRequest createBrandRequest)
        {

            CreateBrandResponse createBrandResponse =_brandService.Add(createBrandRequest);
            return Ok(createBrandResponse);

        }
        [HttpGet]
        public IActionResult Get()
        {
           return Ok(_brandService.GetAll());
        }
    }
}
