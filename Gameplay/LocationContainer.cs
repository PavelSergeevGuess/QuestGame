using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuest
{
    class LocationContainer
    {
        public static Dictionary<string, Location> GetStartLocation()
        {
            return new Dictionary<string, Location>
            {
                { "Таверна", new LocationTavern() },
            };
        }
        public static Dictionary<string, Location> GetLocationPt1()
        {
            return new Dictionary<string, Location>
            {
                { "Дом ведьмы", new LocationWitchhouse() },
            };
        }
    }
}
