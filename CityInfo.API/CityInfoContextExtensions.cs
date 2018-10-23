using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using CityInfo.API.Model;

namespace CityInfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            var Cities = new List<City>()
            {
                new City()
                {
                    Name = "New York City",
                    Description = "The city that never sleeps",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest(){
                            Name = "Central Park",
                            Description = "Shitty place"},
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "Also a shitty place"
                        },

                    }
                },

                new City()
                {
                    Name = "Aarhus",
                    Description = "The city that has a rainbow",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest(){
                            Name = "AROS",
                            Description = "It is a museum"},
                        new PointOfInterest()
                        {
                            Name = "Risskov skov",
                            Description = "Lovely forrest"

                        },

                    }
                },

                new City()
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest(){
                            Name = "´the cathedral",
                            Description = "It is a church"},
                        new PointOfInterest()
                        {
                            Name = "asdsadsad sasdasdasdkov",
                            Description = "asdsadsad asdasdasd"

                        },

                    }
                }
            };
            context.Cities.AddRange(Cities);
            context.SaveChanges();
        }
    }
}
