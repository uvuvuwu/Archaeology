using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class Hand
    {
        //A hand has a list of cards
        public List<Card> _cardsList;
        //Initial hand count is 4
        public const int handCount = 4;

        /// <summary>
        /// Initialises hand
        /// </summary>
        public Hand()
        {
            _cardsList = new List<Card>();
        }

        /// <summary>
        /// Method to add a card to the hand
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            _cardsList.Add(card);
        }
    }
}
