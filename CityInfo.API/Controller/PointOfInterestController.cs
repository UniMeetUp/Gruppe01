using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Model;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace CityInfo.API.Controller
{
    [Route("api/cities/")]
    public class PointOfInterestController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ILogger<PointOfInterestController> _logger;
        private ICityInfoRepository _cityInfoRepository;

        public PointOfInterestController(ILogger<PointOfInterestController> logger,
            ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
            _logger = logger;
            
        }

        [HttpGet("{cityId}/pointofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {

            try
            {

                if (!_cityInfoRepository.CityExist(cityId))
                {
                    _logger.LogInformation($"City with id {cityId} wasnt found when accessing points of interest");
                    return NotFound();
                }

                var pointsOfInterestForCity = _cityInfoRepository.GetPointsOfInterestForCity(cityId);

                var pointsOfInterestForCityResults =
                    Mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity);

                //foreach (var pointOfInterest in pointsOfInterestForCity)
                //{
                //    pointsOfInterestForCityResults.Add(new PointOfInterestDto()
                //    {
                //        Description = pointOfInterest.Description,
                //        Id = pointOfInterest.Id,
                //        Name = pointOfInterest.Name
                //    });
                //}

                return Ok(pointsOfInterestForCityResults);
                //var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                //if (city == null)
                //{
                //    _logger.LogInformation($"City with id: {cityId} wasnt found in the database when trying to access point of interest.");
                //    return NotFound();
                //}
                //return Ok(city.PointsOfInterest);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Exception while getting points ofinterest for city with id {cityId}.", e);
                return StatusCode(500, " A Problem happened while handling your request");
            }



            
        }

        [HttpGet("{cityId}/pointofinterest/{PoiId}", Name = "getPointOfInterest")]
        public IActionResult getPointOfInterest(int cityId, int PoiId)
        {
            if (!_cityInfoRepository.CityExist(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetPointOfInterest(cityId, PoiId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            var pointOfInterestResult = Mapper.Map<PointOfInterestDto>(pointOfInterest);
            //    new PointOfInterestDto()
            //{
            //    Id = pointOfInterest.Id,
            //    Description = pointOfInterest.Description,
            //    Name = pointOfInterest.Name
            //};
            return Ok(pointOfInterestResult);

            //var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            //if (city == null)
            //{
            //    return NotFound();
            //}

            //var PointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == PoiId);
            //if (PointOfInterest == null)
            //{
            //    return NotFound();
            //}

            //return Ok(PointOfInterest);
        }



        [HttpPost("{cityId}/pointofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
             [FromBody] PointOfInterestForCreatingDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Name == pointOfInterest.Description)
            {
                ModelState.AddModelError("Description", "Name and description can not be the same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_cityInfoRepository.CityExist(cityId))
            {
                return NotFound();
            }


            var finalPointOfInterest = Mapper.Map<Entities.PointOfInterest>(pointOfInterest);

            _cityInfoRepository.AddPointOfInterestForCity(cityId, finalPointOfInterest);
            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            var createdPointOfInterestToReturn = Mapper.Map<Model.PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute("getPointOfInterest", new
            {
                cityId = cityId,
                PoiId = finalPointOfInterest.Id }, createdPointOfInterestToReturn);
        }

        [HttpPut("{cityId}/pointofinterest/{Id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int Id,
             [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Name == pointOfInterest.Description)
            {
                ModelState.AddModelError("Description", "Name and description can not be the same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            if (!_cityInfoRepository.CityExist(cityId))
            {
                return NotFound();
            }


            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterest(cityId, Id);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(pointOfInterest, pointOfInterestEntity);

            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }

       [HttpPatch("{cityId}/pointofinterest/{Id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int Id, 
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                BadRequest();
            }

            if (!_cityInfoRepository.CityExist(cityId))
            {
                return NotFound();
            }


            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterest(cityId, Id);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = Mapper.Map<PointOfInterestForUpdateDto>(pointOfInterestEntity);

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pointOfInterestToPatch.Name == pointOfInterestToPatch.Description)
            {
                ModelState.AddModelError("Description", "Name and description can not be the same");
            }

            TryValidateModel(pointOfInterestToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);
            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }

        [HttpDelete("{cityId}/pointofinterest/{Id}")]
        public IActionResult DeletePointOfInterest(int cityId, int Id)
        {
            if (!_cityInfoRepository.CityExist(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetPointOfInterest(cityId, Id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(pointOfInterest);
            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }
    }

    
    
}
