using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuest
{
    class LocationWitchhouse
        : Location
    {

        public LocationWitchhouse()
        {
            this.locationOptions = new Dictionary<string, Action>();
            this.characters = new List<Character>();
            this.action = new GameAction(this.locationOptions);
        }
    }
}