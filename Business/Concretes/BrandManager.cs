using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    IBrandDal _branddal;
    public BrandManager(IBrandDal brandDal)
    {
        _branddal = brandDal;
        
    }

    CreateBrandResponse IBrandService.Add(CreateBrandRequest createBrandRequest)
    {
        Brand brand = new();
        brand.Name=createBrandRequest.Name; 
        brand.CreatedDate=DateTime.Now;
        _branddal.Add(brand);

        CreateBrandResponse createBrandResponse = new CreateBrandResponse();
        createBrandResponse.Name = brand.Name;
        createBrandResponse.Id = 4;
        createBrandResponse.CreatedDate=brand.CreatedDate;
        return createBrandResponse;
    }

    List<GetAllBrandResponse> IBrandService.GetAll()
    {
        List<Brand> brands = _branddal.GetAll();
        List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();

        foreach (var brand in brands)
        {
            GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
            getAllBrandResponse.Name = brand.Name;
            getAllBrandResponse.Id = brand.Id;
            getAllBrandResponse.CreatedDate =brand.CreatedDate;

            getAllBrandResponses.Add(getAllBrandResponse);
        }
        return getAllBrandResponses;

    }
}
