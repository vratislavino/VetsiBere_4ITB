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
    public partial class Nastaveni : Form
    {
        SettingsData currentSettingsData;

        List<PlayerName> playerNames = new List<PlayerName>();

        public SettingsData SettingsData
        {
            get
            {
                List<string> names = new List<string>();
                for(int i = 0; i < playerNames.Count; i++)
                {
                    names.Add(playerNames[i].Value);
                }

                currentSettingsData.AddJmenaOfPlayers(names);
                return currentSettingsData;
            }
        }

        public Nastaveni(SettingsData settingsData)
        {
            InitializeComponent();
            currentSettingsData = new SettingsData(settingsData);
            foreach(string player in currentSettingsData.Players)
            {
                AddPlayerName(player);
            }
        }

        private void AddPlayerName(string player)
        {
            var playerName = new PlayerName();
            playerName.Value = player;
            flowLayoutPanel1.Controls.Add(playerName);
            playerNames.Add(playerName);

            playerName.RequestDelete += (pn) => {
                if (playerNames.Count <= 2)
                {
                    MessageBox.Show("Nelze mít méně než 2 hráče!");
                }
                else { 
                    flowLayoutPanel1.Controls.Remove(pn);
                    playerNames.Remove(pn);
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPlayerName("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playerNames.ForEach(pn => pn.CompleteName());
        }
    }
}
