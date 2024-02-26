using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class PotShards : Treasure
    {
        /// <summary>
        /// Initialises pot shards
        /// </summary>
        public PotShards()
        {
            _value = 1;
        }

        /// <summary>
        /// Overrides ToString method to display the card name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Pot Shards";
        }
    }
}
