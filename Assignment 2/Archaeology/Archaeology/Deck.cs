using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archaeology
{
    public class Deck
    {
        //Create random variable
        private Random _rand = new Random();

        //Some fields. Arrays for all the different treasures, thief, sandstorm, and a list for list of treasure cards
        private PotShards[] _potShardsArray;
        private ParchmentScraps[] _parchmentScrapsArray;
        private Coins[] _coinsArray;
        private Talismans[] _talismansArray;
        private BrokenCup[] _brokenCupsArray;
        private Map[] _mapsArray;
        private PharaohsMask[] _pharaohsMasksArray;
        public List<Card> _treasuresList;

        private Thief[] _thievesArray;
        private Sandstorm[] _sandstormsArray;

        //Pyramid pile
        public Card[] _pyramidThreeSet = new Card[3];
        public Card[] _pyramidFiveSet = new Card[5];
        public Card[] _pyramidSevenSet = new Card[7];

        //MarketPlace
        public List<Card> marketPlace = new List<Card>();
        public List<Card> marketToPlayerList = new List<Card>();

        //This is for when a player is trading to the market, the values for how much their cards is worth, to compare to when the cards are trading 
        //with the market place's cards' values
        public int playerToMarketValue = 0;
        public int marketToPlayerValue = 0;

        //A list to store the cards player wants to discard from their hand
        public List<Card> sandstormList = new List<Card>();

        /// <summary>
        /// This initialises a Deck object
        /// </summary>
        public Deck()
        {
            //Creating objects for the empty arrays
            _potShardsArray = new PotShards[18];
            for(int i = 0; i < _potShardsArray.Length; i++)
            {
                _potShardsArray[i] = new PotShards();
            }
            _parchmentScrapsArray = new ParchmentScraps[16];
            for(int i = 0;i < _parchmentScrapsArray.Length; i++)
            {
                _parchmentScrapsArray[i] = new ParchmentScraps();
            }
            _coinsArray = new Coins[14];
            for(int i = 0; i < _coinsArray.Length ; i++)
            {
                _coinsArray [i] = new Coins();
            }
            _talismansArray = new Talismans[8];
            for(int i = 0; i < _talismansArray.Length ; i++)
            {
                _talismansArray [i] = new Talismans();
            }
            _brokenCupsArray = new BrokenCup[6];
            for(int i = 0; i < _brokenCupsArray.Length; i++)
            {
                _brokenCupsArray [i] = new BrokenCup();
            }
            _mapsArray = new Map[6];
            for(int i = 0; i < _mapsArray.Length ; i++)
            {
                _mapsArray [i] = new Map();
            }
            _pharaohsMasksArray = new PharaohsMask[4];
            for(int i = 0;i < _pharaohsMasksArray.Length ; i++)
            {
                _pharaohsMasksArray[i] = new PharaohsMask();
            }
            //Creating a list for the currently null list
            _treasuresList = new List<Card>();

            //Thief and sandstorm cards get added after player hands are dealt
            _thievesArray = new Thief[8];
            for(int i = 0; i < _thievesArray.Length ; i++)
            {
                _thievesArray[i] = new Thief();
            }
            _sandstormsArray = new Sandstorm[6];
            for(int i = 0; i < _sandstormsArray.Length ; i++)
            {
                _sandstormsArray[i] = new Sandstorm();
            }

            //Adding all objects in the arrays into the list, but not thief, sandstorm, or maps. Will be added after hands are dealt
            for(int i = 0; i < 18; i++)
            {
                _treasuresList.Add(_potShardsArray[i]);
            }
            for(int i = 0; i < 16; i++)
            {
                _treasuresList.Add(_parchmentScrapsArray[i]);
            }
            for (int i = 0; i < 14; i++)
            {
                _treasuresList.Add(_coinsArray[i]);
            }
            for (int i = 0; i < 8; i++)
            {
                _treasuresList.Add(_talismansArray[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                _treasuresList.Add(_brokenCupsArray[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                _treasuresList.Add(_pharaohsMasksArray[i]);
            }
        }

        /// <summary>
        /// Initial shuffle. Includes all cards except thief, sandstorm, map
        /// </summary>
        public void ShuffleDeck1()
        {
            int n = _treasuresList.Count;
            while (n > 1)
            {
                n--;
                int k = _rand.Next(n + 1);
                Card value = _treasuresList[k];
                _treasuresList[k] = _treasuresList[n];
                _treasuresList[n] = value;
            }
        }

        /// <summary>
        /// Add other cards in and shuffle
        /// </summary>
        public void ShuffleDeck2()
        {
            //Add thief, sandstorm, and map cards to the deck
            for (int i = 0; i < 8; i++)
            {
                _treasuresList.Add(_thievesArray[i]);
            }
            for(int i = 0; i < 6; i++)
            {
                _treasuresList.Add(_sandstormsArray[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                _treasuresList.Add(_mapsArray[i]);
            }
            //Shuffle the new deck
            int n = _treasuresList.Count;
            while (n > 1)
            {
                n--;
                int k = _rand.Next(n + 1);
                Card value = _treasuresList[k];
                _treasuresList[k] = _treasuresList[n];
                _treasuresList[n] = value;
            }
        }

        /// <summary>
        /// Initialises pyramid piles
        /// </summary>
        public void PyramidPile()
        {
            //Add 3 cards to pyramid pile with 3 cards, remove the cards from the list
            for(int i = 0; i < _pyramidThreeSet.Length; i++)
            {
                _pyramidThreeSet[i] = _treasuresList[0];
                _treasuresList.RemoveAt(0);
            }
            //Add 5 cards to pyramid pile with 5 cards, remove the cards from the list
            for(int i = 0; i < _pyramidFiveSet.Length; i++)
            {
                _pyramidFiveSet[i] = _treasuresList[0];
                _treasuresList.RemoveAt(0);
            }
            //Add 7 cards to pyramid pile with 7 cards, remove the cards from the list
            for(int i = 0; i < _pyramidSevenSet.Length; i++)
            {
                _pyramidSevenSet[i] = _treasuresList[0];
                _treasuresList.RemoveAt(0);
            }
        }

        /// <summary>
        /// Initilises market place
        /// </summary>
        public void MarketPlace()
        {
            //Add 5 cards to the market place
            for(int i = 0; i < 5; i++)
            {
                marketPlace.Add(_treasuresList[0]);
                _treasuresList.RemoveAt(0);
            }
        }

        /// <summary>
        /// Resets trade values
        /// </summary>
        public void TradeValuesReset()
        {
            playerToMarketValue = 0;
            marketToPlayerValue = 0;
        }

        /// <summary>
        /// This method explores the small chamber
        /// </summary>
        /// <param name="player"></param>
        public void ExplorePyramidSmallChamber(Player1 player)
        {
            //Add all cards from small chamber to player hand, remove cards from the chamber
            for(int i = 0; i < _pyramidThreeSet.Length; i++)
            {
                player._hand.AddCard(_pyramidThreeSet[i]);
                _pyramidThreeSet[i] = null;
            }
            //Go through player's hand, remove one map card
            int removedMaps = 0;
            for(int i = 0; i < player._hand._cardsList.Count; i++)
            {
                if(player._hand._cardsList[i] is Map)
                {
                    if(removedMaps < 1)
                    {
                        player._hand._cardsList.Remove(player._hand._cardsList[i]);
                        removedMaps++;
                    }
                }
            }
        }

        /// <summary>
        /// This method explores the medium chamber
        /// </summary>
        /// <param name="player"></param>
        public void ExplorePyramidMediumChamber(Player1 player)
        {
            //Add all cards from medium chamber to player hand, remove cards from the chamber
            for(int i = 0; i < _pyramidFiveSet.Length; i++)
            {
                player._hand.AddCard(_pyramidFiveSet[i]);
                _pyramidFiveSet[i] = null;
            }
            //Go through player's hand, remove two map cards
            int removedMaps = 0;
            for(int i = player._hand._cardsList.Count; i > 0; i--)
            {
                if (player._hand._cardsList[i - 1] is Map)
                {
                    if(removedMaps < 2)
                    {
                        player._hand._cardsList.Remove(player._hand._cardsList[i - 1]);
                        removedMaps++;
                    }
                }
            }
        }

        /// <summary>
        /// This method explores the large chamber
        /// </summary>
        /// <param name="player"></param>
        public void ExplorePyramidLargeChamber(Player1 player)
        {
            //Add all cards from large chamber to player hand, remove cards from the chamber
            for (int i = 0; i < _pyramidSevenSet.Length; i++)
            {
                player._hand.AddCard(_pyramidSevenSet[i]);
                _pyramidSevenSet[i] = null;
            }
            //Go through player's hand, remove three map cards
            int removedMaps = 0;
            for (int i = player._hand._cardsList.Count; i > 0; i--)
            {
                if (player._hand._cardsList[i - 1] is Map)
                {
                    if (removedMaps < 3)
                    {
                        player._hand._cardsList.Remove(player._hand._cardsList[i - 1]);
                        removedMaps++;
                    }
                }
            }
        }
    }
}
