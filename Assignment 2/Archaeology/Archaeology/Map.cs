using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class Map : Treasure
    {
        /// <summary>
        /// Initialises a map
        /// </summary>
        public Map()
        {
            _value = 3;
        }

        /// <summary>
        /// Overrides ToString method to display the card name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Map";
        }
    }
}
