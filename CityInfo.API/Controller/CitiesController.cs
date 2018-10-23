using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Model;
using CityInfo.API.Services;


namespace CityInfo.API.Controller
{
    [Route("api/cities")]
    public class CitiesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities =  _cityInfoRepository.GetCities();

            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            return Ok(results);
            //var results = new List<CityWithoutPointsOfInterestDto>();

            //foreach (var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointsOfInterestDto()
            //    {
            //        Id =  cityEntity.Id,
            //        Description = cityEntity.Description,
            //        Name = cityEntity.Name
            //    });
            //}



        }

        [HttpGet("{Id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {

            var cityEntity = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (cityEntity == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = Mapper.Map<CityDto>(cityEntity);

                return Ok(cityResult);
            }

            var cityResultWithoutPointsOfInterestDto = Mapper.Map<CityWithoutPointsOfInterestDto>(cityEntity);

            return Ok(cityResultWithoutPointsOfInterestDto);




        }
    }
}
