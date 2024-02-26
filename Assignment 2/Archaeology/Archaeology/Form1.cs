using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archaeology
{
    public partial class Form1 : Form
    {
        //Make a new deck
        public Deck deck = new Deck();

        //Make player objects
        public Player1 player1 = new Player1();
        public Player1 player2 = new Player1();

        //On and off for trading at market
        public bool tradeAtMarket = false;

        //bools to check if a chamber has been explored
        public bool smallChamberExplored = false;
        public bool mediumChamberExplored = false;
        public bool largeChamberExplored = false;

        //Random variable
        public Random _rand = new Random();

        //Counter for how many times end turn without a move
        public int _endTurn = 0;

        //Bool to see if user has started a new game
        public bool gameStart = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Only allow to start the game once so user can't keep pressing start new game and crash program
            if (gameStart == false)
            {
                //Shuffle the deck. Doesn't include map, sandstorm, thief, as per the rules
                deck.ShuffleDeck1();
                //Deal cards out to players
                player1.DealHand(deck);
                player2.DealHand(deck);
                //Deal the cards to the market place
                deck.MarketPlace();
                UpdateMarketPlace();
                //Deal the cards for the pyramid pile
                deck.PyramidPile();
                //Shuffle the rest of the cards into the deck. This is the dig site
                deck.ShuffleDeck2();
                //Shows how many cards are left in the deck
                UpdateDeckAmount();
                //Show player's hand
                player1.UpdatePlayerHand(listBoxPlayerHand);
                //Set trade values to zero
                ShowTradeValues();
                //It's player 1's turn
                player1.PlayersTurn(listBoxPlayerHand, textBoxPlayerMoney);
                textBoxPlayerTurn.Text = "Player 1's turn";
                //Trade isn't happening, buttons disabled
                TradeFinished();
                //No sandstorm, disable those buttons
                SandStormButtonEnable();

                gameStart = true;
            }
        }

        /// <summary>
        /// Updates amount of cards in the deck
        /// </summary>
        public void UpdateDeckAmount()
        {
            textBoxDeckAmount.Text = deck._treasuresList.Count.ToString();
        }

        /// <summary>
        /// This buttons digs a treasure 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDig_Click(object sender, EventArgs e)
        {
            //Call the dig method for whichever player's turn it is
            if (player1.Turn == true)
            {
                Dig(player1, player2);
            }
            else if(player2.Turn == true)
            {
                Dig(player2, player1);
            }
        }

        /// <summary>
        /// Method for digging. player1 is the player for that turn, player2 is the person player1 is stealing their card from if draw thief card
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        private void Dig(Player1 player1, Player1 player2)
        {
            //If no more cards left in the deck
            if (deck._treasuresList.Count <= 0)
            {
                MessageBox.Show("No more treasures to dig");
                player1.DiggedTreasure = true;
                buttonDig.Enabled = false;
            }
            else
            {
                //If player hasn't digged
                if (player1.DiggedTreasure == false)
                {
                    //Player can dig for treasure
                    player1.DigForTreasure(deck);
                    //Set digged to true, so that can't dig more than one treasure until next turn
                    player1.DiggedTreasure = true;
                    buttonDig.Enabled = false;
                    //Update amount of cards in the deck
                    UpdateDeckAmount();
                    player1.UpdatePlayerHand(listBoxPlayerHand);

                    //Check if digged card is thief
                    if (player1._hand._cardsList[player1._hand._cardsList.Count - 1] is Thief)
                    {
                        //Remove thief from hand
                        player1._hand._cardsList.RemoveAt(player1._hand._cardsList.Count - 1);
                        MessageBox.Show("You found a thief card! You steal a random card from the other player");
                        //Take a random card from the other player
                        if(player2._hand._cardsList.Count <= 0)
                        {
                            MessageBox.Show("The other person has no cards :(");
                        }
                        else
                        {
                            int randomNum = _rand.Next(0, player2._hand._cardsList.Count - 1);
                            player1._hand.AddCard(player2._hand._cardsList[randomNum]);
                            //Remove the card from their hand
                            player2._hand._cardsList.RemoveAt(randomNum);
                        }
                        //Update player hand
                        player1.UpdatePlayerHand(listBoxPlayerHand);
                    }
                    //Check if digged card is sandstorm
                    if (player1._hand._cardsList[player1._hand._cardsList.Count - 1] is Sandstorm)
                    {
                        //Remove sandstorm from hand
                        player1._hand._cardsList.RemoveAt(player1._hand._cardsList.Count - 1);
                        MessageBox.Show("Sandstorm! You must discard half your cards");
                        //Set sandstorm to true, disable other buttons
                        Sandstorm();
                        player1.UpdatePlayerHand(listBoxPlayerHand);
                        player1._keepAddCardToDiscard = true;
                        //Number of cards to discard
                        player1.cardsToDiscard = player1._hand._cardsList.Count / 2;
                    }
                }
                //Else player has digged so can't dig this turn
                else
                {

                }
            }
        }

        /// <summary>
        /// When player clicks sell to museum, this method runs the code for selling to museum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSellToMuseum_Click(object sender, EventArgs e)
        {
            
            //If combobox does not have anything selected, give an error
            if(comboBoxSellMuseum.SelectedItem == null)
            {
                MessageBox.Show("Please select a type of card");
            }
            //Else a card is selected
            else
            {
                if (player1.Turn == true)
                {
                    SellToMuseum(player1);
                }
                else if(player2.Turn == true)
                {
                    SellToMuseum(player2);
                }
                _endTurn = 0;
                buttonEndTurn.Enabled = true;
            }
        }

        /// <summary>
        /// Sells a player's card/s to the Museum
        /// </summary>
        /// <param name="player"></param>
        public void SellToMuseum(Player1 player)
        {
            //Try catch structure is implemented so that if the user inputs something that's not a number into textbox the program won't crash
            try
            {
                //See how many items user is selling
                int itemAmount = int.Parse(textBoxNumberOfItemSell.Text);
                int howManyItems = 0;
                //If the user wants to sell pot shards
                if (comboBoxSellMuseum.SelectedItem.ToString() == "Pot Shards")
                {
                    //Check trying to sell less than 0 or >= 6 cards pot shard cards
                    if (itemAmount >= 6 || itemAmount <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of cards to sell");
                    }
                    else
                    {
                        //Check if the user has that amount of pot shards in their hand
                        for (int i = 0; i < player._hand._cardsList.Count; i++)
                        {
                            if (player._hand._cardsList[i] is PotShards)
                            {
                                howManyItems++;
                            }
                        }
                        //If the user has enough cards to sell, let them sell cards
                        if (howManyItems >= itemAmount)
                        {
                            player.SellPotShard(itemAmount);
                            //Remove card/s from listbox
                            player.UpdatePlayerHand(listBoxPlayerHand);
                            //Update player money
                            textBoxPlayerMoney.Text = player.playerMoney.ToString();
                        }
                        //Else don't have enough cards
                        else
                        {
                            MessageBox.Show("You don't have enough cards to sell");
                        }
                    }
                }
                //Reset counter
                howManyItems = 0;

                //If the user wasnts to sell parchment scraps
                if (comboBoxSellMuseum.SelectedItem.ToString() == "Parchment Scraps")
                {
                    //Check if the user is trying to sell and invalid number of cards
                    if (itemAmount >= 5 || itemAmount <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of cards to sell");
                    }
                    else
                    {
                        //Check if the user has that amount of parchment scraps in their hand
                        for (int i = 0; i < player._hand._cardsList.Count; i++)
                        {
                            if (player._hand._cardsList[i] is ParchmentScraps)
                            {
                                howManyItems++;
                            }
                        }
                        //If the user has enough cards to sell, let them sell cards
                        if (howManyItems >= itemAmount)
                        {
                            player.SellParchmentScraps(itemAmount);
                            //Remove card/s from listbox
                            player.UpdatePlayerHand(listBoxPlayerHand);
                            //Update player money
                            textBoxPlayerMoney.Text = player.playerMoney.ToString();
                        }
                        //Else don't have enough cards
                        else
                        {
                            MessageBox.Show("You don't have enough cards to sell");
                        }
                    }
                }
                //Reset counter
                howManyItems = 0;

                //If the user wasnts to sell coins
                if (comboBoxSellMuseum.SelectedItem.ToString() == "Coins")
                {
                    //Check if the user is trying to sell and invalid number of cards
                    if (itemAmount >= 6 || itemAmount <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of cards to sell");
                    }
                    else
                    {
                        //Check if the user has that amount of coins in their hand
                        for (int i = 0; i < player._hand._cardsList.Count; i++)
                        {
                            if (player._hand._cardsList[i] is Coins)
                            {
                                howManyItems++;
                            }
                        }
                        //If the user has enough cards to sell, let them sell cards
                        if (howManyItems >= itemAmount)
                        {
                            player.SellCoins(itemAmount);
                            //Remove card/s from listbox
                            player.UpdatePlayerHand(listBoxPlayerHand);
                            //Update player money
                            textBoxPlayerMoney.Text = player.playerMoney.ToString();
                        }
                        //Else don't have enough cards
                        else
                        {
                            MessageBox.Show("You don't have enough cards to sell");
                        }
                    }
                }
                //Reset counter
                howManyItems = 0;

                //If the user wasnts to sell talismans
                if (comboBoxSellMuseum.SelectedItem.ToString() == "Talismans")
                {
                    //Check if the user is trying to sell and invalid number of cards
                    if (itemAmount >= 6 || itemAmount <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of cards to sell");
                    }
                    else
                    {
                        //Check if the user has that amount of coins in their hand
                        for (int i = 0; i < player._hand._cardsList.Count; i++)
                        {
                            if (player._hand._cardsList[i] is Talismans)
                            {
                                howManyItems++;
                            }
                        }
                        //If the user has enough cards to sell, let them sell cards
                        if (howManyItems >= itemAmount)
                        {
                            player.SellTalismans(itemAmount);
                            //Remove card/s from listbox
                            player.UpdatePlayerHand(listBoxPlayerHand);
                            //Update player money
                            textBoxPlayerMoney.Text = player.playerMoney.ToString();
                        }
                        //Else don't have enough cards
                        else
                        {
                            MessageBox.Show("You don't have enough cards to sell");
                        }
                    }
                }

                //If the user wasnts to sell broken cups
                if (comboBoxSellMuseum.SelectedItem.ToString() == "Broken Cups")
                {
                    //Check if the user is trying to sell and invalid number of cards
                    if (itemAmount >= 3 || itemAmount <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of cards to sell");
                    }
                    else
                    {
                        //Check if the user has that amount of broken cups in their hand
                        for (int i = 0; i < player._hand._cardsList.Count; i++)
                        {
                            if (player._hand._cardsList[i] is BrokenCup)
                            {
                                howManyItems++;
                            }
                        }
                        //If the user has enough cards to sell, let them sell cards
                        if (howManyItems >= itemAmount)
                        {
                            player.SellBrokenCups(itemAmount);
                            //Remove card/s from listbox
                            player.UpdatePlayerHand(listBoxPlayerHand);
                            //Update player money
                            textBoxPlayerMoney.Text = player.playerMoney.ToString();
                        }
                        //Else don't have enough cards
                        else
                        {
                            MessageBox.Show("You don't have enough cards to sell");
                        }
                    }
                }
                //Reset counter
                howManyItems = 0;

                //If the user wasnts to sell maps
                if (comboBoxSellMuseum.SelectedItem.ToString() == "Maps")
                {
                    //Check if the user is trying to sell and invalid number of cards
                    if (itemAmount >= 2 || itemAmount <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of cards to sell");
                    }
                    else
                    {
                        //Check if the user has that amount of maps in their hand
                        for (int i = 0; i < player._hand._cardsList.Count; i++)
                        {
                            if (player._hand._cardsList[i] is Map)
                            {
                                howManyItems++;
                            }
                        }
                        //If the user has enough cards to sell, let them sell cards
                        if (howManyItems >= itemAmount)
                        {
                            player.SellMap(itemAmount);
                            //Remove card/s from listbox
                            player.UpdatePlayerHand(listBoxPlayerHand);
                            //Update player money
                            textBoxPlayerMoney.Text = player.playerMoney.ToString();
                        }
                        //Else don't have enough cards
                        else
                        {
                            MessageBox.Show("You don't have enough cards to sell");
                        }
                    }
                }
                //Reset counter
                howManyItems = 0;

                //If the user wants to sell Pharaoh's mask
                if (comboBoxSellMuseum.SelectedItem.ToString() == "Pharaoh's Masks")
                {
                    //Check if the user is trying to sell and invalid number of cards
                    if (itemAmount >= 5 || itemAmount <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of cards to sell");
                    }
                    else
                    {
                        //Check if the user has that amount of Pharaoh's Masks in their hand
                        for (int i = 0; i < player._hand._cardsList.Count; i++)
                        {
                            if (player._hand._cardsList[i] is PharaohsMask)
                            {
                                howManyItems++;
                            }
                        }
                        //If the user has enough cards to sell, let them sell cards
                        if (howManyItems >= itemAmount)
                        {
                            player.SellPharaohsMasks(itemAmount);
                            //Remove card/s from listbox
                            player.UpdatePlayerHand(listBoxPlayerHand);
                            //Update player money
                            textBoxPlayerMoney.Text = player.playerMoney.ToString();
                        }
                        //Else don't have enough cards
                        else
                        {
                            MessageBox.Show("You don't have enough cards to sell");
                        }
                    }
                }
                //Reset counter
                howManyItems = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This method updates market place listbox
        /// </summary>
        private void UpdateMarketPlace()
        {
            listBoxMarketPlace.Items.Clear();
            foreach(Card card in deck.marketPlace)
            {
                listBoxMarketPlace.Items.Add(card);
            }
        }

        /// <summary>
        /// Updates player to market listbox
        /// </summary>
        private void UpdatePlayerToMarket()
        {
            if (player1.Turn == true)
            {
                listBoxPlayerToMarket.Items.Clear();
                foreach (Card card in player1.tradeToMarketList)
                {
                    listBoxPlayerToMarket.Items.Add(card);
                }
            }
            else if (player2.Turn == true)
            {
                listBoxPlayerToMarket.Items.Clear();
                foreach (Card card in player2.tradeToMarketList)
                {
                    listBoxPlayerToMarket.Items.Add(card);
                }
            }
        }

        /// <summary>
        /// Method to update market to player listbox
        /// </summary>
        private void UpdateMarketToPlayer()
        {
            listBoxMarketToPlayer.Items.Clear();
            foreach(Card card in deck.marketToPlayerList)
            {
                listBoxMarketToPlayer.Items.Add(card);
            }
        }

        /// <summary>
        /// When listboxPlayerHand has an item selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPlayerHand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (player1.Turn == true)
            {
                PlayerHandIndexChanged(player1);
            }
            else if(player2.Turn == true)
            {
                PlayerHandIndexChanged(player2);
            }
        }

        /// <summary>
        /// Method for when listbox player hand has an item selected. Can be used for different players.
        /// </summary>
        /// <param name="player"></param>
        private void PlayerHandIndexChanged(Player1 player)
        {
            if (tradeAtMarket == true)
            {
                //If index is between 0 and player's hand count
                int index = listBoxPlayerHand.SelectedIndex;
                if (index <= player._hand._cardsList.Count && index >= 0)
                {
                    //Add selected card to tradeToMarket List
                    Card t = player._hand._cardsList[index];
                    player.tradeToMarketList.Add(t);
                    deck.playerToMarketValue += ((Treasure)t).Value;
                    ShowTradeValues();
                    //Remove card from player's hand
                    player._hand._cardsList.RemoveAt(index);
                    UpdatePlayerToMarket();
                    player.UpdatePlayerHand(listBoxPlayerHand);
                }
            }
            //If player drew a sandstorm card
            if (player._sandstorm == true)
            {
                //If index is between 0 and player's hand count
                int index = listBoxPlayerHand.SelectedIndex;
                if (index <= player._hand._cardsList.Count && index >= 0)
                {
                    //If keep discarding == true, then allow to keep discarding. Else do nothing when card is clicked on
                    if (player._keepAddCardToDiscard == true)
                    {
                        //Add selected card to sandstorm list
                        Card c = player._hand._cardsList[index];
                        deck.sandstormList.Add(c);
                        UpdateSandstormListbox();
                        //Remove card from player's hand
                        player._hand._cardsList.RemoveAt(index);
                        player.UpdatePlayerHand(listBoxPlayerHand);
                        //Add one to number of cards discarded
                        player.cardsDiscarded = player.cardsDiscarded + 1;

                        //If the discarded number of cards is equal or greater than the number of cards to discard
                        if (player.cardsDiscarded >= player.cardsToDiscard)
                        {
                            //Stop adding cards
                            player._keepAddCardToDiscard = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Start the trade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTradeAtMarket_Click(object sender, EventArgs e)
        {
            //Set trade at market place to true
            tradeAtMarket = true;
            ShowTradeValues();

            buttonConfirmTrade.Enabled = true;
            buttonCancelTrade.Enabled = true;
            buttonDig.Enabled = false;
            buttonSellToMuseum.Enabled = false;
            buttonTradeAtMarket.Enabled = false;
            buttonExplorePyramid.Enabled = false;
            buttonConfirmDiscard.Enabled = false;
            buttonCancelDiscard.Enabled = false;
            buttonEndTurn.Enabled = false;
        }

        /// <summary>
        /// Player cancels the trade, returns cards back to their original places
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelTrade_Click(object sender, EventArgs e)
        {
            TradeFinished();
            if (player1.Turn == true)
            {
                CancelTrade(player1);
                if(player1.DiggedTreasure == true)
                {
                    buttonDig.Enabled = false;
                }
            }
            if (player2.Turn == true)
            {
                CancelTrade(player2);
                if(player2.DiggedTreasure == true)
                {
                    buttonDig.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Method to disable buttons for when trade isn't happening
        /// </summary>
        private void TradeFinished()
        {
            buttonConfirmTrade.Enabled = false;
            buttonCancelTrade.Enabled = false;
            buttonDig.Enabled = true;
            buttonSellToMuseum.Enabled = true;
            buttonTradeAtMarket.Enabled = true;
            buttonExplorePyramid.Enabled = true;
            buttonEndTurn.Enabled = true;
        }

        /// <summary>
        /// Method for player cancelling trade
        /// </summary>
        /// <param name="player"></param>
        private void CancelTrade(Player1 player)
        {
            //Add all cards from trade to market list back to player's hand
            int count = player.tradeToMarketList.Count;
            for (int i = count; i > 0; i--)
            {
                player._hand.AddCard(player.tradeToMarketList[i - 1]);
                player.tradeToMarketList.Remove(player.tradeToMarketList[i - 1]);
            }
            //Update player hand listbox
            player.UpdatePlayerHand(listBoxPlayerHand);
            //Update player to market listbox
            UpdatePlayerToMarket();

            //Add all cards from market to player list back to the market
            int count2 = deck.marketToPlayerList.Count;
            for (int i = count2; i > 0; i--)
            {
                deck.marketPlace.Add(deck.marketToPlayerList[i - 1]);
                deck.marketToPlayerList.Remove(deck.marketToPlayerList[i - 1]);
            }
            //Update market place listbox and market to player listbox
            UpdateMarketToPlayer();
            UpdateMarketPlace();
            //Trade values goes back to zero
            deck.TradeValuesReset();
            //Updates the textboxes of trade values
            ShowTradeValues();

            tradeAtMarket = false;
        }

        /// <summary>
        /// If user is trading at the market, selecting cards will add them to marketToPlayerList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxMarketPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Only let player add cards to marketToPlayer list and listbox if they're trading at the market
            if(tradeAtMarket == false)
            {
                
            }
            else
            {
                //If selected item is a card
                int index = listBoxMarketPlace.SelectedIndex;
                if(index <= deck.marketPlace.Count && index >= 0)
                {
                    //Add selected card to marketToPlayer List
                    Card t = deck.marketPlace[index];
                    deck.marketToPlayerList.Add(t);
                    deck.marketToPlayerValue += ((Treasure)t).Value;
                    ShowTradeValues();
                    //Remove card from market place
                    deck.marketPlace.RemoveAt(index);
                    UpdateMarketToPlayer();
                    UpdateMarketPlace();
                }
            }
        }

        /// <summary>
        /// Shows the values of the cards put in for the trade
        /// </summary>
        private void ShowTradeValues()
        {
            textBoxPlayerTradeValue.Text = deck.playerToMarketValue.ToString();
            textBoxMarketTradeValue.Text = deck.marketToPlayerValue.ToString();
        }

        /// <summary>
        /// This button confirms trade. Executes all trading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirmTrade_Click(object sender, EventArgs e)
        {
            TradeFinished();
            if (player1.Turn == true)
            {
                ConfirmTrade(player1);
                if(player1.DiggedTreasure == true)
                {
                    buttonDig.Enabled = false;
                }
            }
            else if (player2.Turn == true)
            {
                ConfirmTrade(player2);
                if(player2.DiggedTreasure == true)
                {
                    buttonDig.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Method for confirming trade
        /// </summary>
        /// <param name="player"></param>
        private void ConfirmTrade(Player1 player)
        {
            //If the total value of player cards that want to be traded > the cards they want from the market
            if (deck.playerToMarketValue >= deck.marketToPlayerValue)
            {
                //Let them trade at the market
                TradeAtMarket();

                //Update all listboxes and textboxes
                UpdateMarketPlace();
                player.UpdatePlayerHand(listBoxPlayerHand);
                UpdateMarketToPlayer();
                UpdatePlayerToMarket();
                deck.TradeValuesReset();
                ShowTradeValues();
                //Set tradeAtMarket to false so when player clicks on their hand or marketplace the cards no longer go to the other list
                tradeAtMarket = false;
            }
            else
            {
                MessageBox.Show("Your treasures have lower value than the trade market place's");
            }
            
        }

        /// <summary>
        /// Which player trades at market
        /// </summary>
        public void TradeAtMarket()
        {
            if (player1._turn == true)
            {
                TradingAtMarket(player1);
            }
            else if(player2._turn == true)
            {
                TradingAtMarket(player2);
            }
        }

        /// <summary>
        /// Method for player trades at market
        /// </summary>
        /// <param name="player"></param>
        private void TradingAtMarket(Player1 player)
        {
            //Get market to player list, add all cards in the list to player hand
            int count = deck.marketToPlayerList.Count;
            for (int i = count; i > 0; i--)
            {
                //Add card to player hand
                player._hand.AddCard(deck.marketToPlayerList[i - 1]);
                //Remove card from market to player list
                deck.marketToPlayerList.Remove(deck.marketToPlayerList[i - 1]);
            }
            //Get player to market list, add all cards in the list to market
            int count2 = player.tradeToMarketList.Count;
            for (int i = count2; i > 0; i--)
            {
                //Add card to market place
                deck.marketPlace.Add(player.tradeToMarketList[i - 1]);
                //Remove card from player to market list
                player.tradeToMarketList.Remove(player.tradeToMarketList[i - 1]);
            }
            //Remove cards from market to player list, and player to market list
            deck.marketToPlayerList.Clear();
            player.tradeToMarketList.Clear();
        }

        /// <summary>
        /// This button lets player explore pyramid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExplorePyramid_Click(object sender, EventArgs e)
        {
            //If there is no item selected in combobox
            if (comboBoxPyramid.SelectedItem == null)
            {
                //Show an error
                MessageBox.Show("Please select a chamber to explore");
            }
            //Else there is an item selected in combobox
            else
            {
                if (player1._turn == true)
                {
                    ExplorePyramid(player1);
                }
                else if(player2._turn == true)
                {
                    ExplorePyramid(player2);
                }
            }
        }

        /// <summary>
        /// Method for player exploring pyramid
        /// </summary>
        /// <param name="player"></param>
        private void ExplorePyramid(Player1 player)
        {
            //If player wants to explore small chamber
            if (comboBoxPyramid.SelectedItem.ToString() == "Small Chamber")
            {
                //Check they have enough map cards in their hand
                int mapNum = NumberOfMaps(player);
                if (mapNum > 0)
                {
                    //Check chamber hasn't been explore already
                    if (smallChamberExplored == false)
                    {
                        //Explore chamber
                        deck.ExplorePyramidSmallChamber(player);
                        //Update listbox for player hand
                        player.UpdatePlayerHand(listBoxPlayerHand);
                        //Set small chamber to explored
                        smallChamberExplored = true;
                    }
                    //Else tell player chamber has been explored
                    else
                    {
                        MessageBox.Show("This chamber has been explored already!");
                    }
                }
                //Else not enough map cards
                else
                {
                    MessageBox.Show("You don't have enough map cards :(");
                }
            }

            //If player want to explore medium chamber
            if (comboBoxPyramid.SelectedItem.ToString() == "Medium Chamber")
            {
                //Check they have enough map cards in their hand
                int mapNum = NumberOfMaps(player);
                if (mapNum > 1)
                {
                    //Check chamber hasn't been explored already
                    if (mediumChamberExplored == false)
                    {
                        //Explore chamber
                        deck.ExplorePyramidMediumChamber(player);
                        //Update listbox for player hand
                        player.UpdatePlayerHand(listBoxPlayerHand);
                        //Set medium chamber to explored
                        mediumChamberExplored = true;
                    }
                    //Else tell player chamber has been explored
                    else
                    {
                        MessageBox.Show("This chamber has been explored already!");
                    }
                }
                //Else not enough map cards
                else
                {
                    MessageBox.Show("You don't have enough map cards :(");
                }
            }

            //If player want to explore large chamber
            if (comboBoxPyramid.SelectedItem.ToString() == "Large Chamber")
            {
                //Check they have enough map cards in their hand
                int mapNum = NumberOfMaps(player);
                if (mapNum > 2)
                {
                    //Check chamber hasn't been explored already
                    if (largeChamberExplored == false)
                    {
                        //Explore chamber
                        deck.ExplorePyramidLargeChamber(player);
                        //Update listbox for player hand
                        player.UpdatePlayerHand(listBoxPlayerHand);
                        //Set medium chamber to explored
                        largeChamberExplored = true;
                    }
                    //Else tell player chamber has been explored
                    else
                    {
                        MessageBox.Show("This chamber has been explored already!");
                    }
                }
                //Else not enough map cards
                else
                {
                    MessageBox.Show("You don't have enough map cards :(");
                }
            }
        }

        /// <summary>
        /// Returns number of maps of a player hand
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private int NumberOfMaps(Player1 player)
        {
            if (player1._turn == true)
            {
                int mapCount = 0;
                for (int i = 0; i < player1._hand._cardsList.Count; i++)
                {
                    if (player._hand._cardsList[i] is Map)
                    {
                        mapCount++;
                    }
                }
                return mapCount;
            }
            //else if player 2's turn
            else
            {
                int mapCount = 0;
                for (int i = 0; i < player2._hand._cardsList.Count; i++)
                {
                    if (player._hand._cardsList[i] is Map)
                    {
                        mapCount++;
                    }
                }
                return mapCount;
            }
        }

        /// <summary>
        /// Set sandstorm to true, disable other buttons
        /// </summary>
        private void Sandstorm()
        {
            player1._sandstorm = true;
            player2._sandstorm = true;
            buttonConfirmDiscard.Enabled = true;
            buttonCancelDiscard.Enabled = true;
            buttonDig.Enabled = false;
            buttonSellToMuseum.Enabled = false;
            buttonTradeAtMarket.Enabled = false;
            buttonConfirmTrade.Enabled = false;
            buttonCancelTrade.Enabled = false;
            buttonExplorePyramid.Enabled = false;
            buttonEndTurn.Enabled = false;
        }

        /// <summary>
        /// This method confirms cards to discard in sandstorm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirmDiscard_Click(object sender, EventArgs e)
        {
            if (player1._turn == true)
            {
                ConfirmDiscard(player1);
            }
            else if(player2._turn == true)
            {
                ConfirmDiscard(player2);
            }
        }

        /// <summary>
        /// Method for confirming discard cards in sandstorm
        /// </summary>
        /// <param name="player"></param>
        private void ConfirmDiscard(Player1 player)
        {
            //Check if the number of discarded cards match number of cards to discard
            if (player.cardsDiscarded == player.cardsToDiscard)
            {
                //If true, add discarded cards to market place
                for (int i = 0; i < deck.sandstormList.Count; i++)
                {
                    deck.marketPlace.Add(deck.sandstormList[i]);
                }
                for (int i = deck.sandstormList.Count - 1; i >= 0; i--)
                {
                    //Remove cards from sandstorm list
                    deck.sandstormList.RemoveAt(i);
                }
                //Update listboxes
                UpdateSandstormListbox();
                UpdateMarketPlace();

                //Set sandstorm to false
                player._sandstorm = false;
                //Enable other buttons
                SandStormButtonEnable();
                //Reset cards discarded, and cards to discard
                player.cardsDiscarded = 0;
                player.cardsToDiscard = 0;
                //If player has digged, disable dig button
                if(player.DiggedTreasure == true)
                {
                    buttonDig.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Updates sandstorm listbox
        /// </summary>
        private void UpdateSandstormListbox()
        {
            listBoxSandstorm.Items.Clear();
            foreach(Card card in deck.sandstormList)
            {
                listBoxSandstorm.Items.Add(card);
            }
        }

        /// <summary>
        /// Return cards back to player hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelDiscard_Click(object sender, EventArgs e)
        {
            if (player1._turn == true)
            {
                //Add cards back to player hand
                for (int i = deck.sandstormList.Count - 1; i >= 0; i--)
                {
                    player1._hand.AddCard(deck.sandstormList[i]);
                    deck.sandstormList.RemoveAt(i);
                }
                //Update listboxes
                player1.UpdatePlayerHand(listBoxPlayerHand);
                UpdateSandstormListbox();

                player1.cardsDiscarded = 0;
                player1._keepAddCardToDiscard = true;
            }
            else if(player2._turn == true)
            {
                //Add cards back to player hand
                for (int i = deck.sandstormList.Count - 1; i >= 0; i--)
                {
                    player2._hand.AddCard(deck.sandstormList[i]);
                    deck.sandstormList.RemoveAt(i);
                }
                //Update listboxes
                player2.UpdatePlayerHand(listBoxPlayerHand);
                UpdateSandstormListbox();

                player2.cardsDiscarded = 0;
                player2._keepAddCardToDiscard = true;
            }
        }

        /// <summary>
        /// Ends turn of a player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            //If there are no cards in the deck, and both players are out of cards
            if (deck._treasuresList.Count <= 0 && player1._hand._cardsList.Count <= 0 && player2._hand._cardsList.Count <= 0)
            {
                //If player 1 has more money than player 2, player 1 wins.
                if(player1.playerMoney > player2.playerMoney)
                {
                    MessageBox.Show("Player 1 wins! Congratulations!");
                }
                //Else if player 2 has more money than player 1, player 2 wins
                else if(player2.playerMoney > player1.playerMoney)
                {
                    MessageBox.Show("Player 2 wins! Congratulations!");
                }
                //Else if they have the same amount of money, it's a tie
                else if(player1.playerMoney == player2.playerMoney)
                {
                    MessageBox.Show("It's a tie");
                }
            }
            //If player 1 is ending turn
            if(player1.Turn == true)
            {
                player2.PlayersTurn(listBoxPlayerHand, textBoxPlayerMoney);
                player1.Turn = false;
                textBoxPlayerTurn.Text = "Player 2's turn";
                player1.DiggedTreasure = false;
                if (player2._sandstorm == true)
                {
                    MessageBox.Show("Sandstorm! You must discard half your cards");
                    //Disable other buttons
                    SandStormButtonsDisable();
                    player2.UpdatePlayerHand(listBoxPlayerHand);
                    player2._keepAddCardToDiscard = true;
                    //Number of cards to discard
                    player2.cardsToDiscard = player2._hand._cardsList.Count / 2;
                }

                //If there are no cards in the deck, and at least one of the players has at least a card
                if (deck._treasuresList.Count <= 0 && (player1._hand._cardsList.Count != 0 || player2._hand._cardsList.Count != 0))
                {
                    _endTurn++;
                    if (_endTurn >= 2)
                    {
                        if (player2._hand._cardsList.Count > 0)
                        {
                            buttonEndTurn.Enabled = false;
                        }
                    }
                }
            }
            //If player 2 is ending turn
            else if(player2.Turn == true)
            {
                player2.Turn = false;
                player1.PlayersTurn(listBoxPlayerHand, textBoxPlayerMoney);
                textBoxPlayerTurn.Text = "Player 1's turn";
                player2.DiggedTreasure = false;
                if (player1._sandstorm == true)
                {
                    MessageBox.Show("Sandstorm! You must discard half your cards");
                    //Disable other buttons
                    SandStormButtonsDisable();
                    player1.UpdatePlayerHand(listBoxPlayerHand);
                    player1._keepAddCardToDiscard = true;
                    //Number of cards to discard
                    player1.cardsToDiscard = player1._hand._cardsList.Count / 2;
                }

                //If there are no cards in the deck, and at least one of the players has at least a card
                if (deck._treasuresList.Count <= 0 && (player1._hand._cardsList.Count != 0 || player2._hand._cardsList.Count != 0))
                {
                    _endTurn++;
                    if (_endTurn >= 2)
                    {
                        if (player1._hand._cardsList.Count > 0)
                        {
                            buttonEndTurn.Enabled = false;
                        }
                    }
                }
            }
            //If there is no sandstorm while ending turn, enable dig
            if (player1._sandstorm == false && player2._sandstorm == false)
            {
                buttonDig.Enabled = true;
            }
        }

        /// <summary>
        /// Disables other buttons for sandstorm
        /// </summary>
        private void SandStormButtonsDisable()
        {
            buttonConfirmDiscard.Enabled = true;
            buttonCancelDiscard.Enabled = true;
            buttonDig.Enabled = false;
            buttonSellToMuseum.Enabled = false;
            buttonTradeAtMarket.Enabled = false;
            buttonConfirmTrade.Enabled = false;
            buttonCancelTrade.Enabled = false;
            buttonExplorePyramid.Enabled = false;
            buttonEndTurn.Enabled = false;
        }

        /// <summary>
        /// This method enables to buttons after sandstorm
        /// </summary>
        private void SandStormButtonEnable()
        {
            buttonConfirmDiscard.Enabled = false;
            buttonCancelDiscard.Enabled = false;
            buttonDig.Enabled = true;
            buttonSellToMuseum.Enabled = true;
            buttonTradeAtMarket.Enabled = true;
            buttonExplorePyramid.Enabled = true;
            buttonEndTurn.Enabled = true;
        }
    }
}
