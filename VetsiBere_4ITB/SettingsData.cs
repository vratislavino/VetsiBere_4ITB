//sussybaka
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere_4ITB
{
    public class SettingsData
    {
        List<string> jmenaOfPlayers = new List<string>();

        public List<string> Players {
            get { return jmenaOfPlayers; }
            set { jmenaOfPlayers = value; }
        }

        public SettingsData(SettingsData settingsData)
        {
            settingsData.jmenaOfPlayers.ForEach(player => jmenaOfPlayers.Add(player));
        }

        public SettingsData() { }

        public void AddJmenaOfPlayers(List<string> players)
        {
            this.jmenaOfPlayers = players;
        }
    }
}
