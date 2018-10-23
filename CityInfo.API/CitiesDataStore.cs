using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Model;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The city that never sleeps",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Central Park",
                            Description = "Shitty place"},
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "Also a shitty place"
                        },

                    }
                },

                new CityDto()
                {
                    Id = 2,
                    Name = "Aarhus",
                    Description = "The city that has a rainbow",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 3,
                            Name = "AROS",
                            Description = "It is a museum"},
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Risskov skov",
                            Description = "Lovely forrest"

                        },

                    }
                },

                new CityDto()
                {
                    Id = 3,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 5,
                            Name = "´the cathedral",
                            Description = "It is a church"},
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "asdsadsad sasdasdasdkov",
                            Description = "asdsadsad asdasdasd"

                        },

                    }
                }
            };

        }
    }
}
