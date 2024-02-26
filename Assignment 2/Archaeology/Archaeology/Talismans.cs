using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class Talismans : Treasure
    {
        /// <summary>
        /// Initilises a Talisman
        /// </summary>
        public Talismans()
        {
            _value = 3;
        }

        /// <summary>
        /// Overrides ToString method to display the card name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Talisman";
        }
    }
}
