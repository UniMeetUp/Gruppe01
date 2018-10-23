using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        bool CityExist(int cityid);
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointsOfInterest);

        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);

        PointOfInterest GetPointOfInterest(int cityId, int pointofinterestId);

        bool Save();

        void DeletePointOfInterest(PointOfInterest poi);

    }
}
