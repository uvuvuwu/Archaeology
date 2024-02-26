using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class PharaohsMask : Treasure
    {
        /// <summary>
        /// Initialises a Pharaoh's Mask
        /// </summary>
        public PharaohsMask()
        {
            _value = 4;
        }

        /// <summary>
        /// Overrides ToString method to display the card name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Pharaoh's Mask";
        }
    }
}
