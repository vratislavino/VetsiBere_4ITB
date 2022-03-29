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
    public partial class Menu : Form
    {
        SettingsData settingsData;

        public Menu()
        {
            InitializeComponent();
            settingsData = new SettingsData() {
                Players = new List<string> { "Karel", "David" }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // spustit hru
            Form1 game = new Form1(settingsData.Players);

            game.Show();

            this.Hide();
            game.FormClosing += (snd, evt) => {
                this.Show();
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // pomoc
            MessageBox.Show("Pomoc! Když mají 2 hráči stejné nejvyšší karty, tak oba vykládají následující 3 a třetí se porovnává znovu, platí pro ně stejná pravidla!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // nastavení
            Nastaveni n = new Nastaveni(settingsData);
            var dialogResult = n.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                // TODO: doplnit prázdný jména vygenerovanými!
                this.settingsData = n.SettingsData;
            } else
            {
                // dal cancel, nechce nic nastavit... :(
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // konec
            Application.Exit();
        }
    }
}
