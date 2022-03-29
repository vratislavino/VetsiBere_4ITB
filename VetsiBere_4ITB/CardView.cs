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
    public partial class CardView : UserControl
    {
        private Card card;

        public Card Card
        {
            get { return card; }
            set { 
                card = value;
                pictureBox1.BackgroundImage = card.bitmap;
                label1.Text = card.FullName;
            }
        }

        public CardView()
        {
            InitializeComponent();
        }

    }
}
