using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public abstract class Treasure : Card
    {
        //Each card has its value. This stores it
        protected int _value;

        /// <summary>
        /// Initialises treasure
        /// </summary>
        public Treasure()
        {

        }

        /// <summary>
        /// Gets the value of a card
        /// </summary>
        public int Value
        {
            get { return _value; }
        }
    }
}
