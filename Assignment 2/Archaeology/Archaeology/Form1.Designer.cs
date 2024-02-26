namespace Archaeology
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxMarketPlace = new System.Windows.Forms.ListBox();
            this.labelDeckAmount = new System.Windows.Forms.Label();
            this.textBoxDeckAmount = new System.Windows.Forms.TextBox();
            this.listBoxPlayerHand = new System.Windows.Forms.ListBox();
            this.buttonDig = new System.Windows.Forms.Button();
            this.buttonSellToMuseum = new System.Windows.Forms.Button();
            this.comboBoxSellMuseum = new System.Windows.Forms.ComboBox();
            this.labelWhichItemToSell = new System.Windows.Forms.Label();
            this.textBoxNumberOfItemSell = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPlayerMoney = new System.Windows.Forms.TextBox();
            this.labelPlayerMoney = new System.Windows.Forms.Label();
            this.labelMarketPlace = new System.Windows.Forms.Label();
            this.labelPlayerHand = new System.Windows.Forms.Label();
            this.buttonTradeAtMarket = new System.Windows.Forms.Button();
            this.listBoxPlayerToMarket = new System.Windows.Forms.ListBox();
            this.listBoxMarketToPlayer = new System.Windows.Forms.ListBox();
            this.buttonCancelTrade = new System.Windows.Forms.Button();
            this.textBoxPlayerTradeValue = new System.Windows.Forms.TextBox();
            this.textBoxMarketTradeValue = new System.Windows.Forms.TextBox();
            this.buttonConfirmTrade = new System.Windows.Forms.Button();
            this.comboBoxPyramid = new System.Windows.Forms.ComboBox();
            this.buttonExplorePyramid = new System.Windows.Forms.Button();
            this.listBoxSandstorm = new System.Windows.Forms.ListBox();
            this.buttonConfirmDiscard = new System.Windows.Forms.Button();
            this.buttonCancelDiscard = new System.Windows.Forms.Button();
            this.textBoxPlayerTurn = new System.Windows.Forms.TextBox();
            this.buttonEndTurn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1235, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewGameToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startNewGameToolStripMenuItem
            // 
            this.startNewGameToolStripMenuItem.Name = "startNewGameToolStripMenuItem";
            this.startNewGameToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.startNewGameToolStripMenuItem.Text = "Start new game";
            this.startNewGameToolStripMenuItem.Click += new System.EventHandler(this.startNewGameToolStripMenuItem_Click);
            // 
            // listBoxMarketPlace
            // 
            this.listBoxMarketPlace.FormattingEnabled = true;
            this.listBoxMarketPlace.Location = new System.Drawing.Point(230, 66);
            this.listBoxMarketPlace.Name = "listBoxMarketPlace";
            this.listBoxMarketPlace.Size = new System.Drawing.Size(338, 238);
            this.listBoxMarketPlace.TabIndex = 1;
            this.listBoxMarketPlace.SelectedIndexChanged += new System.EventHandler(this.listBoxMarketPlace_SelectedIndexChanged);
            // 
            // labelDeckAmount
            // 
            this.labelDeckAmount.AutoSize = true;
            this.labelDeckAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeckAmount.Location = new System.Drawing.Point(12, 43);
            this.labelDeckAmount.Name = "labelDeckAmount";
            this.labelDeckAmount.Size = new System.Drawing.Size(193, 16);
            this.labelDeckAmount.TabIndex = 2;
            this.labelDeckAmount.Text = "Amount of cards left in the deck:";
            // 
            // textBoxDeckAmount
            // 
            this.textBoxDeckAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeckAmount.Location = new System.Drawing.Point(15, 66);
            this.textBoxDeckAmount.Name = "textBoxDeckAmount";
            this.textBoxDeckAmount.Size = new System.Drawing.Size(100, 22);
            this.textBoxDeckAmount.TabIndex = 3;
            // 
            // listBoxPlayerHand
            // 
            this.listBoxPlayerHand.FormattingEnabled = true;
            this.listBoxPlayerHand.Location = new System.Drawing.Point(230, 402);
            this.listBoxPlayerHand.Name = "listBoxPlayerHand";
            this.listBoxPlayerHand.Size = new System.Drawing.Size(338, 95);
            this.listBoxPlayerHand.TabIndex = 4;
            this.listBoxPlayerHand.SelectedIndexChanged += new System.EventHandler(this.listBoxPlayerHand_SelectedIndexChanged);
            // 
            // buttonDig
            // 
            this.buttonDig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDig.Location = new System.Drawing.Point(672, 66);
            this.buttonDig.Name = "buttonDig";
            this.buttonDig.Size = new System.Drawing.Size(105, 50);
            this.buttonDig.TabIndex = 5;
            this.buttonDig.Text = "Dig for treasure";
            this.buttonDig.UseVisualStyleBackColor = true;
            this.buttonDig.Click += new System.EventHandler(this.buttonDig_Click);
            // 
            // buttonSellToMuseum
            // 
            this.buttonSellToMuseum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSellToMuseum.Location = new System.Drawing.Point(819, 66);
            this.buttonSellToMuseum.Name = "buttonSellToMuseum";
            this.buttonSellToMuseum.Size = new System.Drawing.Size(108, 50);
            this.buttonSellToMuseum.TabIndex = 6;
            this.buttonSellToMuseum.Text = "Sell to Museum";
            this.buttonSellToMuseum.UseVisualStyleBackColor = true;
            this.buttonSellToMuseum.Click += new System.EventHandler(this.buttonSellToMuseum_Click);
            // 
            // comboBoxSellMuseum
            // 
            this.comboBoxSellMuseum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSellMuseum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSellMuseum.FormattingEnabled = true;
            this.comboBoxSellMuseum.Items.AddRange(new object[] {
            "Pot Shards",
            "Parchment Scraps",
            "Coins",
            "Talismans",
            "Broken Cups",
            "Maps",
            "Pharaoh\'s Masks"});
            this.comboBoxSellMuseum.Location = new System.Drawing.Point(951, 66);
            this.comboBoxSellMuseum.Name = "comboBoxSellMuseum";
            this.comboBoxSellMuseum.Size = new System.Drawing.Size(169, 28);
            this.comboBoxSellMuseum.TabIndex = 7;
            // 
            // labelWhichItemToSell
            // 
            this.labelWhichItemToSell.AutoSize = true;
            this.labelWhichItemToSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWhichItemToSell.Location = new System.Drawing.Point(947, 43);
            this.labelWhichItemToSell.Name = "labelWhichItemToSell";
            this.labelWhichItemToSell.Size = new System.Drawing.Size(260, 20);
            this.labelWhichItemToSell.TabIndex = 8;
            this.labelWhichItemToSell.Text = "Select which item to sell to museum";
            // 
            // textBoxNumberOfItemSell
            // 
            this.textBoxNumberOfItemSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfItemSell.Location = new System.Drawing.Point(951, 124);
            this.textBoxNumberOfItemSell.Name = "textBoxNumberOfItemSell";
            this.textBoxNumberOfItemSell.Size = new System.Drawing.Size(100, 26);
            this.textBoxNumberOfItemSell.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(947, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "How many are you selling:";
            // 
            // textBoxPlayerMoney
            // 
            this.textBoxPlayerMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerMoney.Location = new System.Drawing.Point(15, 131);
            this.textBoxPlayerMoney.Name = "textBoxPlayerMoney";
            this.textBoxPlayerMoney.ReadOnly = true;
            this.textBoxPlayerMoney.Size = new System.Drawing.Size(100, 26);
            this.textBoxPlayerMoney.TabIndex = 11;
            // 
            // labelPlayerMoney
            // 
            this.labelPlayerMoney.AutoSize = true;
            this.labelPlayerMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerMoney.Location = new System.Drawing.Point(12, 108);
            this.labelPlayerMoney.Name = "labelPlayerMoney";
            this.labelPlayerMoney.Size = new System.Drawing.Size(107, 20);
            this.labelPlayerMoney.TabIndex = 12;
            this.labelPlayerMoney.Text = "Player money:";
            // 
            // labelMarketPlace
            // 
            this.labelMarketPlace.AutoSize = true;
            this.labelMarketPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarketPlace.Location = new System.Drawing.Point(227, 43);
            this.labelMarketPlace.Name = "labelMarketPlace";
            this.labelMarketPlace.Size = new System.Drawing.Size(89, 16);
            this.labelMarketPlace.TabIndex = 13;
            this.labelMarketPlace.Text = "Market Place:";
            // 
            // labelPlayerHand
            // 
            this.labelPlayerHand.AutoSize = true;
            this.labelPlayerHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerHand.Location = new System.Drawing.Point(227, 379);
            this.labelPlayerHand.Name = "labelPlayerHand";
            this.labelPlayerHand.Size = new System.Drawing.Size(82, 16);
            this.labelPlayerHand.TabIndex = 14;
            this.labelPlayerHand.Text = "Player hand:";
            // 
            // buttonTradeAtMarket
            // 
            this.buttonTradeAtMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTradeAtMarket.Location = new System.Drawing.Point(672, 187);
            this.buttonTradeAtMarket.Name = "buttonTradeAtMarket";
            this.buttonTradeAtMarket.Size = new System.Drawing.Size(108, 50);
            this.buttonTradeAtMarket.TabIndex = 15;
            this.buttonTradeAtMarket.Text = "Trade at Market";
            this.buttonTradeAtMarket.UseVisualStyleBackColor = true;
            this.buttonTradeAtMarket.Click += new System.EventHandler(this.buttonTradeAtMarket_Click);
            // 
            // listBoxPlayerToMarket
            // 
            this.listBoxPlayerToMarket.FormattingEnabled = true;
            this.listBoxPlayerToMarket.Location = new System.Drawing.Point(672, 254);
            this.listBoxPlayerToMarket.Name = "listBoxPlayerToMarket";
            this.listBoxPlayerToMarket.Size = new System.Drawing.Size(188, 95);
            this.listBoxPlayerToMarket.TabIndex = 16;
            // 
            // listBoxMarketToPlayer
            // 
            this.listBoxMarketToPlayer.FormattingEnabled = true;
            this.listBoxMarketToPlayer.Location = new System.Drawing.Point(877, 254);
            this.listBoxMarketToPlayer.Name = "listBoxMarketToPlayer";
            this.listBoxMarketToPlayer.Size = new System.Drawing.Size(225, 95);
            this.listBoxMarketToPlayer.TabIndex = 17;
            // 
            // buttonCancelTrade
            // 
            this.buttonCancelTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelTrade.Location = new System.Drawing.Point(976, 187);
            this.buttonCancelTrade.Name = "buttonCancelTrade";
            this.buttonCancelTrade.Size = new System.Drawing.Size(108, 50);
            this.buttonCancelTrade.TabIndex = 18;
            this.buttonCancelTrade.Text = "Cancel Trade";
            this.buttonCancelTrade.UseVisualStyleBackColor = true;
            this.buttonCancelTrade.Click += new System.EventHandler(this.buttonCancelTrade_Click);
            // 
            // textBoxPlayerTradeValue
            // 
            this.textBoxPlayerTradeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerTradeValue.Location = new System.Drawing.Point(672, 355);
            this.textBoxPlayerTradeValue.Name = "textBoxPlayerTradeValue";
            this.textBoxPlayerTradeValue.ReadOnly = true;
            this.textBoxPlayerTradeValue.Size = new System.Drawing.Size(100, 26);
            this.textBoxPlayerTradeValue.TabIndex = 19;
            // 
            // textBoxMarketTradeValue
            // 
            this.textBoxMarketTradeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarketTradeValue.Location = new System.Drawing.Point(877, 355);
            this.textBoxMarketTradeValue.Name = "textBoxMarketTradeValue";
            this.textBoxMarketTradeValue.ReadOnly = true;
            this.textBoxMarketTradeValue.Size = new System.Drawing.Size(100, 26);
            this.textBoxMarketTradeValue.TabIndex = 20;
            // 
            // buttonConfirmTrade
            // 
            this.buttonConfirmTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmTrade.Location = new System.Drawing.Point(828, 187);
            this.buttonConfirmTrade.Name = "buttonConfirmTrade";
            this.buttonConfirmTrade.Size = new System.Drawing.Size(108, 50);
            this.buttonConfirmTrade.TabIndex = 21;
            this.buttonConfirmTrade.Text = "Confirm Trade";
            this.buttonConfirmTrade.UseVisualStyleBackColor = true;
            this.buttonConfirmTrade.Click += new System.EventHandler(this.buttonConfirmTrade_Click);
            // 
            // comboBoxPyramid
            // 
            this.comboBoxPyramid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPyramid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPyramid.FormattingEnabled = true;
            this.comboBoxPyramid.Items.AddRange(new object[] {
            "Small Chamber",
            "Medium Chamber",
            "Large Chamber"});
            this.comboBoxPyramid.Location = new System.Drawing.Point(877, 402);
            this.comboBoxPyramid.Name = "comboBoxPyramid";
            this.comboBoxPyramid.Size = new System.Drawing.Size(169, 28);
            this.comboBoxPyramid.TabIndex = 22;
            // 
            // buttonExplorePyramid
            // 
            this.buttonExplorePyramid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExplorePyramid.Location = new System.Drawing.Point(672, 402);
            this.buttonExplorePyramid.Name = "buttonExplorePyramid";
            this.buttonExplorePyramid.Size = new System.Drawing.Size(141, 28);
            this.buttonExplorePyramid.TabIndex = 23;
            this.buttonExplorePyramid.Text = "Explore Pyramid";
            this.buttonExplorePyramid.UseVisualStyleBackColor = true;
            this.buttonExplorePyramid.Click += new System.EventHandler(this.buttonExplorePyramid_Click);
            // 
            // listBoxSandstorm
            // 
            this.listBoxSandstorm.FormattingEnabled = true;
            this.listBoxSandstorm.Location = new System.Drawing.Point(672, 445);
            this.listBoxSandstorm.Name = "listBoxSandstorm";
            this.listBoxSandstorm.Size = new System.Drawing.Size(188, 82);
            this.listBoxSandstorm.TabIndex = 24;
            // 
            // buttonConfirmDiscard
            // 
            this.buttonConfirmDiscard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmDiscard.Location = new System.Drawing.Point(877, 462);
            this.buttonConfirmDiscard.Name = "buttonConfirmDiscard";
            this.buttonConfirmDiscard.Size = new System.Drawing.Size(108, 50);
            this.buttonConfirmDiscard.TabIndex = 25;
            this.buttonConfirmDiscard.Text = "Confirm Discard";
            this.buttonConfirmDiscard.UseVisualStyleBackColor = true;
            this.buttonConfirmDiscard.Click += new System.EventHandler(this.buttonConfirmDiscard_Click);
            // 
            // buttonCancelDiscard
            // 
            this.buttonCancelDiscard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelDiscard.Location = new System.Drawing.Point(1012, 462);
            this.buttonCancelDiscard.Name = "buttonCancelDiscard";
            this.buttonCancelDiscard.Size = new System.Drawing.Size(108, 50);
            this.buttonCancelDiscard.TabIndex = 26;
            this.buttonCancelDiscard.Text = "Cancel Discard";
            this.buttonCancelDiscard.UseVisualStyleBackColor = true;
            this.buttonCancelDiscard.Click += new System.EventHandler(this.buttonCancelDiscard_Click);
            // 
            // textBoxPlayerTurn
            // 
            this.textBoxPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerTurn.Location = new System.Drawing.Point(230, 559);
            this.textBoxPlayerTurn.Name = "textBoxPlayerTurn";
            this.textBoxPlayerTurn.ReadOnly = true;
            this.textBoxPlayerTurn.Size = new System.Drawing.Size(338, 29);
            this.textBoxPlayerTurn.TabIndex = 27;
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEndTurn.Location = new System.Drawing.Point(1012, 538);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(108, 50);
            this.buttonEndTurn.TabIndex = 28;
            this.buttonEndTurn.Text = "End Turn";
            this.buttonEndTurn.UseVisualStyleBackColor = true;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 622);
            this.Controls.Add(this.buttonEndTurn);
            this.Controls.Add(this.textBoxPlayerTurn);
            this.Controls.Add(this.buttonCancelDiscard);
            this.Controls.Add(this.buttonConfirmDiscard);
            this.Controls.Add(this.listBoxSandstorm);
            this.Controls.Add(this.buttonExplorePyramid);
            this.Controls.Add(this.comboBoxPyramid);
            this.Controls.Add(this.buttonConfirmTrade);
            this.Controls.Add(this.textBoxMarketTradeValue);
            this.Controls.Add(this.textBoxPlayerTradeValue);
            this.Controls.Add(this.buttonCancelTrade);
            this.Controls.Add(this.listBoxMarketToPlayer);
            this.Controls.Add(this.listBoxPlayerToMarket);
            this.Controls.Add(this.buttonTradeAtMarket);
            this.Controls.Add(this.labelPlayerHand);
            this.Controls.Add(this.labelMarketPlace);
            this.Controls.Add(this.labelPlayerMoney);
            this.Controls.Add(this.textBoxPlayerMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumberOfItemSell);
            this.Controls.Add(this.labelWhichItemToSell);
            this.Controls.Add(this.comboBoxSellMuseum);
            this.Controls.Add(this.buttonSellToMuseum);
            this.Controls.Add(this.buttonDig);
            this.Controls.Add(this.listBoxPlayerHand);
            this.Controls.Add(this.textBoxDeckAmount);
            this.Controls.Add(this.labelDeckAmount);
            this.Controls.Add(this.listBoxMarketPlace);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewGameToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxMarketPlace;
        private System.Windows.Forms.Label labelDeckAmount;
        private System.Windows.Forms.TextBox textBoxDeckAmount;
        private System.Windows.Forms.ListBox listBoxPlayerHand;
        private System.Windows.Forms.Button buttonDig;
        private System.Windows.Forms.Button buttonSellToMuseum;
        private System.Windows.Forms.ComboBox comboBoxSellMuseum;
        private System.Windows.Forms.Label labelWhichItemToSell;
        private System.Windows.Forms.TextBox textBoxNumberOfItemSell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPlayerMoney;
        private System.Windows.Forms.Label labelPlayerMoney;
        private System.Windows.Forms.Label labelMarketPlace;
        private System.Windows.Forms.Label labelPlayerHand;
        private System.Windows.Forms.Button buttonTradeAtMarket;
        private System.Windows.Forms.ListBox listBoxPlayerToMarket;
        private System.Windows.Forms.ListBox listBoxMarketToPlayer;
        private System.Windows.Forms.Button buttonCancelTrade;
        private System.Windows.Forms.TextBox textBoxPlayerTradeValue;
        private System.Windows.Forms.TextBox textBoxMarketTradeValue;
        private System.Windows.Forms.Button buttonConfirmTrade;
        private System.Windows.Forms.ComboBox comboBoxPyramid;
        private System.Windows.Forms.Button buttonExplorePyramid;
        private System.Windows.Forms.ListBox listBoxSandstorm;
        private System.Windows.Forms.Button buttonConfirmDiscard;
        private System.Windows.Forms.Button buttonCancelDiscard;
        private System.Windows.Forms.TextBox textBoxPlayerTurn;
        private System.Windows.Forms.Button buttonEndTurn;
    }
}

