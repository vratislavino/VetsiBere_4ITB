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

        public Form1()
        {
            InitializeComponent();
            var cardCreator = new CardCreator("karty.png");
            cards = cardCreator.Cards;
            pictureBox1.BackgroundImage = cards[5].bitmap;
        }
    }
}
