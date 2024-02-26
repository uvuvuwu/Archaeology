using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class ParchmentScraps : Treasure
    {
        /// <summary>
        /// Initilises parchment scrap
        /// </summary>
        public ParchmentScraps()
        {
            _value = 1;
        }

        /// <summary>
        /// Overrides ToString method to display the card name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Parchment Scraps";
        }
    }
}
