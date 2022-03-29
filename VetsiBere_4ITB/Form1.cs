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
            players.ForEach(p => {
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
                players[playerIndex].Cards.Add(cards[i]);
                playerIndex = (playerIndex + 1) % players.Count;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            players.ForEach(p => {
                playerViews[p].Card = p.Cards.First();
            });
        }
    }
}
