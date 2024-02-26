using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archaeology
{
    public class Player1
    {
        //Each player has a hand
        public Hand _hand;
        //Have a field that can be set to true or false, to use to check if player has digged this turn
        private bool _diggedTreasure;

        //List of cards to sell
        public List<Card> _sellList;

        //A player's total money
        public int playerMoney = 0;

        //This list is list to add to for trading to market place
        public List<Card> tradeToMarketList = new List<Card>();

        public bool _turn;

        //See how many cards player has discarded
        public int cardsDiscarded = 0;
        public int cardsToDiscard = 0;

        //To turn on/off sandstorm
        public bool _sandstorm = false;
        public bool _keepAddCardToDiscard = false;

        public bool cantEndTurn = false;


        /// <summary>
        /// Initialises a player
        /// </summary>
        public Player1()
        {
            _hand = new Hand();
            _diggedTreasure = false;
            _sellList = new List<Card>();
            _turn = false;
        }

        /// <summary>
        /// Deals a hand to a player
        /// </summary>
        /// <param name="deck"></param>
        public void DealHand(Deck deck)
        {
            for(int i = 0; i < Hand.handCount; i++)
            {
                _hand.AddCard(deck._treasuresList[0]);
                deck._treasuresList.RemoveAt(0);
            }
        }

        /// <summary>
        /// Player digs for treasure 
        /// </summary>
        /// <param name="deck"></param>
        public void DigForTreasure(Deck deck)
        {
            _hand._cardsList.Add(deck._treasuresList[0]);
            deck._treasuresList.RemoveAt(0);
        }

        /// <summary>
        /// Can set digged for treasure to true/false for not allowing player to dig more than once per turn
        /// </summary>
        public bool DiggedTreasure
        {
            get { return _diggedTreasure; }
            set { _diggedTreasure = value; }
        }

        /// <summary>
        /// Method for handling selling pot shard/s
        /// </summary>
        /// <param name="itemAmount"></param>
        public void SellPotShard(int itemAmount)
        {
            int potShardSetValue = 0;
            int cardsRemoved = 0;
            //Remove the amount of cards the user wants to sell from their hand

            //Go through player's hand
            int count = _hand._cardsList.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                //If the amount of items user wants to remove is less than the number of cards removed already
                if(itemAmount > cardsRemoved)
                {
                    //If the card is a pot shard, remove the card
                    if (_hand._cardsList[i] is PotShards)
                    {
                        _hand._cardsList.RemoveAt(i);
                        cardsRemoved++;
                    }
                }
            }
            //Add to player's sell list
            for(int i = 0; i < itemAmount; i++)
            {
                PotShards potShards = new PotShards();
                _sellList.Add(potShards);
            }
            //Calculate the value of of the sell list
            if (_sellList.Count == 1)
            {
                potShardSetValue = 1;
            }
            else if (_sellList.Count == 2)
            {
                potShardSetValue = 2;
            }
            else if (_sellList.Count == 3)
            {
                potShardSetValue = 3;
            }
            else if (_sellList.Count == 4)
            {
                potShardSetValue = 4;
            }
            else if (_sellList.Count == 5)
            {
                potShardSetValue = 15;
            }
            //After selling, clear the sell list
            _sellList.Clear();
            //Save that value
            playerMoney = playerMoney + potShardSetValue;
        }

        /// <summary>
        /// Method for handling selling parchment scrap/s
        /// </summary>
        /// <param name="itemAmount"></param>
        public void SellParchmentScraps(int itemAmount)
        {
            int parchmentSetValue = 0;
            int cardsRemoved = 0;
            //Remove the amount of cards the user wants to sell from their hand

            //Go through player's hand
            int count = _hand._cardsList.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                //If the amount of items user wants to remove is less than the number of cards removed already
                if (itemAmount > cardsRemoved)
                {
                    //If the card is a parchment scrap, remove the card
                    if (_hand._cardsList[i] is ParchmentScraps)
                    {
                        _hand._cardsList.RemoveAt(i);
                        cardsRemoved++;
                    }
                }
            }
            //Add to player's sell list
            for (int i = 0; i < itemAmount; i++)
            {
                ParchmentScraps p = new ParchmentScraps();
                _sellList.Add(p);
            }
            //Calculate the value of of the sell list
            if (_sellList.Count == 1)
            {
                parchmentSetValue = 1;
            }
            else if (_sellList.Count == 2)
            {
                parchmentSetValue = 2;
            }
            else if (_sellList.Count == 3)
            {
                parchmentSetValue = 3;
            }
            else if (_sellList.Count == 4)
            {
                parchmentSetValue = 10;
            }
            //After selling, clear the sell list
            _sellList.Clear();
            //Save that value
            playerMoney = playerMoney + parchmentSetValue;
        }

        /// <summary>
        /// Method for handling selling coins
        /// </summary>
        /// <param name="itemAmount"></param>
        public void SellCoins(int itemAmount)
        {
            int coinSetValue = 0;
            int cardsRemoved = 0;
            //Remove the amount of cards the user wants to sell from their hand

            //Go through player's hand
            int count = _hand._cardsList.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                //If the amount of items user wants to remove is less than the number of cards removed already
                if (itemAmount > cardsRemoved)
                {
                    //If the card is a parchment scrap, remove the card
                    if (_hand._cardsList[i] is Coins)
                    {
                        _hand._cardsList.RemoveAt(i);
                        cardsRemoved++;
                    }
                }
            }
            //Add to player's sell list
            for (int i = 0; i < itemAmount; i++)
            {
                Coins c = new Coins();
                _sellList.Add(c);
            }
            //Calculate the value of of the sell list
            if (_sellList.Count == 1)
            {
                coinSetValue = 2;
            }
            else if (_sellList.Count == 2)
            {
                coinSetValue = 5;
            }
            else if (_sellList.Count == 3)
            {
                coinSetValue = 10;
            }
            else if (_sellList.Count == 4)
            {
                coinSetValue = 18;
            }
            else if(_sellList.Count == 5)
            {
                coinSetValue = 30;
            }
            //After selling, clear the sell list
            _sellList.Clear();
            //Save that value
            playerMoney = playerMoney + coinSetValue;
        }

        /// <summary>
        /// Method for handling selling talisman/s
        /// </summary>
        /// <param name="itemAmount"></param>
        public void SellTalismans(int itemAmount)
        {
            int talismanSetValue = 0;
            int cardsRemoved = 0;
            //Remove the amount of cards the user wants to sell from their hand

            //Go through player's hand
            int count = _hand._cardsList.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                //If the amount of items user wants to remove is less than the number of cards removed already
                if (itemAmount > cardsRemoved)
                {
                    //If the card is a parchment scrap, remove the card
                    if (_hand._cardsList[i] is Talismans)
                    {
                        _hand._cardsList.RemoveAt(i);
                        cardsRemoved++;
                    }
                }
            }
            //Add to player's sell list
            for (int i = 0; i < itemAmount; i++)
            {
                Talismans c = new Talismans();
                _sellList.Add(c);
            }
            //Calculate the value of of the sell list
            if (_sellList.Count == 1)
            {
                talismanSetValue = 3;
            }
            else if (_sellList.Count == 2)
            {
                talismanSetValue = 7;
            }
            else if (_sellList.Count == 3)
            {
                talismanSetValue = 14;
            }
            else if (_sellList.Count == 4)
            {
                talismanSetValue = 24;
            }
            else if (_sellList.Count == 5)
            {
                talismanSetValue = 40;
            }
            //After selling, clear the sell list
            _sellList.Clear();
            //Save that value
            playerMoney = playerMoney + talismanSetValue;
        }

        /// <summary>
        /// Method for handling selling broken cup/s
        /// </summary>
        /// <param name="itemAmount"></param>
        public void SellBrokenCups(int itemAmount)
        {
            int brokenCupSetValue = 0;
            int cardsRemoved = 0;
            //Remove the amount of cards the user wants to sell from their hand

            //Go through player's hand
            int count = _hand._cardsList.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                //If the amount of items user wants to remove is less than the number of cards removed already
                if (itemAmount > cardsRemoved)
                {
                    //If the card is a broken cup, remove the card
                    if (_hand._cardsList[i] is BrokenCup)
                    {
                        _hand._cardsList.RemoveAt(i);
                        cardsRemoved++;
                    }
                }
            }
            //Add to player's sell list
            for (int i = 0; i < itemAmount; i++)
            {
                BrokenCup c = new BrokenCup();
                _sellList.Add(c);
            }
            //Calculate the value of of the sell list
            if (_sellList.Count == 1)
            {
                brokenCupSetValue = 2;
            }
            else if (_sellList.Count == 2)
            {
                brokenCupSetValue = 15;
            }
            //After selling, clear the sell list
            _sellList.Clear();
            //Save that value
            playerMoney = playerMoney + brokenCupSetValue;
        }

        /// <summary>
        /// Method for handling selling map/s
        /// </summary>
        /// <param name="itemAmount"></param>
        public void SellMap(int itemAmount)
        {
            int mapSetValue = 0;
            int cardsRemoved = 0;
            //Remove the amount of cards the user wants to sell from their hand

            //Go through player's hand
            int count = _hand._cardsList.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                //If the amount of items user wants to remove is less than the number of cards removed already
                if (itemAmount > cardsRemoved)
                {
                    //If the card is a map, remove the card
                    if (_hand._cardsList[i] is Map)
                    {
                        _hand._cardsList.RemoveAt(i);
                        cardsRemoved++;
                    }
                }
            }
            //Add to player's sell list
            for (int i = 0; i < itemAmount; i++)
            {
                Map c = new Map();
                _sellList.Add(c);
            }
            //Calculate the value of of the sell list
            if (_sellList.Count == 1)
            {
                mapSetValue = 3;
            }
            //After selling, clear the sell list
            _sellList.Clear();
            //Save that value
            playerMoney = playerMoney + mapSetValue;
        }

        public void SellPharaohsMasks(int itemAmount)
        {
            int pharaohsMaskSetValue = 0;
            int cardsRemoved = 0;
            //Remove the amount of cards the user wants to sell from their hand

            //Go through player's hand
            int count = _hand._cardsList.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                //If the amount of items user wants to remove is less than the number of cards removed already
                if (itemAmount > cardsRemoved)
                {
                    //If the card is a pharaoh's mask, remove the card
                    if (_hand._cardsList[i] is PharaohsMask)
                    {
                        _hand._cardsList.RemoveAt(i);
                        cardsRemoved++;
                    }
                }
            }
            //Add to player's sell list
            for (int i = 0; i < itemAmount; i++)
            {
                PharaohsMask c = new PharaohsMask();
                _sellList.Add(c);
            }
            //Calculate the value of of the sell list
            if (_sellList.Count == 1)
            {
                pharaohsMaskSetValue = 4;
            }
            else if (_sellList.Count == 2)
            {
                pharaohsMaskSetValue = 12;
            }
            else if (_sellList.Count == 3)
            {
                pharaohsMaskSetValue = 26;
            }
            else if (_sellList.Count == 4)
            {
                pharaohsMaskSetValue = 50;
            }
            //After selling, clear the sell list
            _sellList.Clear();
            //Save that value
            playerMoney = playerMoney + pharaohsMaskSetValue;
        }

        /// <summary>
        /// This method updates listbox of player hand
        /// </summary>
        /// <param name="listBox"></param>
        public void UpdatePlayerHand(ListBox listBox)
        {
            listBox.Items.Clear();
            for (int i = 0; i < _hand._cardsList.Count; i++)
            {
                listBox.Items.Add(_hand._cardsList[i]);
            }
        }

        /// <summary>
        /// This changes whether it's a player's turn or not
        /// </summary>
        public bool Turn
        {
            get { return _turn; }
            set { _turn = value; }
        }

        /// <summary>
        /// When change player turn
        /// </summary>
        /// <param name="listBoxHand"></param>
        /// <param name="textBoxPlayerMoney"></param>
        public void PlayersTurn(ListBox listBoxHand, TextBox textBoxPlayerMoney)
        {
            Turn = true;
            //Update player's hand
            UpdatePlayerHand(listBoxHand);
            //Update player's money
            textBoxPlayerMoney.Text = playerMoney.ToString();
        }
    }
}
