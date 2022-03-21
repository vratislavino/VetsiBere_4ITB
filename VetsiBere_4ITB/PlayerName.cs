﻿using System;
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

        public PlayerName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestDelete?.Invoke(this);
        }
    }
}
