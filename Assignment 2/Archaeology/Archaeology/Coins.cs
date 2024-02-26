using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class Coins : Treasure
    {
        /// <summary>
        /// Initialises coins 
        /// </summary>
        public Coins()
        {
            _value = 2;
        }

        /// <summary>
        /// Overrides ToString method to display the card name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Coins";
        }
    }
}
