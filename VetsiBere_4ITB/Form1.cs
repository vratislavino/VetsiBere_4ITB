using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetsiBere_4ITB
{
    public partial class Form1 : Form
    {
        List<Card> cards;
        List<Player> players = new List<Player>();
        Dictionary<Player, PlayerView> playerViews = new Dictionary<Player, PlayerView>();

        public Form1(List<string> playerNames = null)
        {
            InitializeComponent();
            var cardCreator = new CardCreator("karty.png");
            cards = cardCreator.Cards;

            if (playerNames != null)
            {
                CreatePlayers(playerNames);
                ShuffleCards();
                DealCards();
                CreatePlayerViews();
            }
        }

        private void CreatePlayers(List<string> playerNames)
        {
            for (int i = 0; i < playerNames.Count; i++)
            {
                players.Add(new Player(playerNames[i]));
            }
        }

        private void CreatePlayerViews()
        {
            players.ForEach(p =>
            {
                PlayerView view = new PlayerView(p);
                flowLayoutPanel1.Controls.Add(view);
                playerViews.Add(p, view);
            });
        }

        private void ShuffleCards()
        {
            Random r = new Random();
            Card temp;
            for (int i = 0; i < 100000; i++)
            {
                int a = r.Next(cards.Count);
                int b = r.Next(cards.Count);

                if (a != b)
                {
                    temp = cards[a];
                    cards[a] = cards[b];
                    cards[b] = temp;
                }
            }

        }

        private void DealCards()
        {
            int playerIndex = 0;
            int rest = cards.Count % players.Count;
            for (int i = 0; i < cards.Count - rest; i++)
            {
                players[playerIndex].EnqueueCard(cards[i]);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            Dictionary<Player, PlayerView> tempViews = new Dictionary<Player, PlayerView>();
            List<Player> tempPlayers = new List<Player>();
            List<Card> cardsToTake = new List<Card>();

            tempPlayers.AddRange(players);
            foreach (var pair in playerViews)
            {
                tempViews.Add(pair.Key, pair.Value);
            }

            CheckTurn(tempViews, tempPlayers, cardsToTake);

        }

        private void CheckTurn(Dictionary<Player, PlayerView> playerViews, List<Player> players, List<Card> cardsToTake)
        {
            // každý hráč vyndá kartu navrchu
            players.ForEach(p =>
            {
                playerViews[p].Card = p.DequeueCard();
                if (playerViews[p].Card == null)
                    playerViews.Remove(p);
                else
                {
                    cardsToTake.Add(playerViews[p].Card);
                }
            });

            // jaká karta je nejvyšší vyložená?
            var maxKarta = playerViews.Values.Max(pv => pv.Card.hodnota);

            // kteří hráči mají nejvyšší kartu
            var playersWithMaxKarta = playerViews.Values.Where(pv => pv.Card.hodnota == maxKarta).ToList();

            // pokud má nejvyšší kartu jen jeden
            if (playersWithMaxKarta.Count == 1)
            {
                // vezmi všechny karty na stole a dej je hráči s nejvyšší kartou
                //for (int i = 0; i < playerViews.Count; i++)
                //{
                    for(int j = 0; j < cardsToTake.Count; j++)
                    {
                        playersWithMaxKarta.First().Player.EnqueueCard(cardsToTake[j]);
                    }
                //}
            }
            else
            {
                for (int i = 0; i < playersWithMaxKarta.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (playersWithMaxKarta[i].Player.CountOfCards > 1)
                        {
                            playersWithMaxKarta[i].Card = playersWithMaxKarta[i].Player.DequeueCard();
                            if(playersWithMaxKarta[i].Card != null)
                                cardsToTake.Add(playersWithMaxKarta[i].Card);
                        }
                    }
                }
                Dictionary<Player, PlayerView> viewsToNextLevel = new Dictionary<Player, PlayerView>();
                playersWithMaxKarta.ForEach(pv => viewsToNextLevel.Add(pv.Player, pv));

                CheckTurn(viewsToNextLevel, playersWithMaxKarta.Select(x => x.Player).ToList(), cardsToTake);
            }
            CheckPlayersForDeath();
        }

        private void CheckPlayersForDeath()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].CountOfCards == 0)
                {
                    playerViews[players[i]].Enabled = false;
                    playerViews[players[i]].Card = null;
                    playerViews[players[i]].BackColor = Color.Red;
                    playerViews.Remove(players[i]);
                    players.Remove(players[i]);
                    i--;
                    timer1.Stop();
                }
            }

            CheckForWin();
        }

        private void CheckForWin()
        {
            if (players.Count == 1)
            {
                MessageBox.Show("Vyhrál hráč " + players.First().Name);
                Close();
            }
        }

        private void auto_button_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawButton_Click(null, null);
        }
    }
}
