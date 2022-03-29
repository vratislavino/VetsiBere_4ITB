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
    public partial class PlayerName : UserControl
    {
        public event Action<PlayerName> RequestDelete;

        public string Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private static Random random = new Random();
        private static string[] randNames = { "Árný", "Štěpán", "JB", "AB", "Dan", "Eh? Kdo?", "Mates", "Džandyys"};

        public PlayerName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestDelete?.Invoke(this);
        }

        public void CompleteName()
        {
            if(string.IsNullOrEmpty(Value))
            {
                Value = randNames[random.Next(randNames.Length)];
            }
        }
    }
}
