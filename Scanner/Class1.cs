using System.Diagnostics;
using System.Text;
using ObjectManager;
using System.Windows.Forms;
using ObjectManager;

namespace Scanner
{
    public class Scanner
    {
        private static string Decode(string s)
        {
            Encoding a = Encoding.GetEncoding(1251);
            Encoding b = Encoding.GetEncoding(Encoding.UTF8.CodePage);
            byte[] l = a.GetBytes(s);
            return b.GetString(l);
        }
        public void Scan()
        {
            string pFaction = "";
            #region asd
            var processes = Process.GetProcessesByName("wow");
            this.accountGrid.BeginInvoke((MethodInvoker)(() => this.accountGrid.Rows.Clear()));
            if (processes.Length == 0)
            {
                this.accountGrid.BeginInvoke((MethodInvoker)(() => this.accountGrid.Rows.Clear()));
                MessageBox.Show("Шутник дохуя, вов включи");
            }
            for (int i = 0; i < processes.Length; i++)
            {
                this.accountGrid.BeginInvoke((MethodInvoker)(() => this.accountGrid.Rows.Add("", "", "", "")));
            }
            this.accountGrid.BeginInvoke((MethodInvoker)(() => this.accountGrid.Refresh()));
            bool ret = false;
            #endregion
            for (int i = 0; i < processes.Length; i++)
            {
                Config.Memory = new Memory(processes[i].Id);
                Config.baseAddressModule = Memory.GetModule(processes[i].Id, "Wow.exe");
                if (Config.Memory.ReadInt(Config.baseAddressModule + Offset.GameState) == 1)
                {
                    Config.baseAddressModule = Memory.GetModule(processes[i].Id, "Wow.exe");
                    ret = true;
                }
                if (ret)
                {
                    string pName = Config.Memory.ReadString(Config.baseAddressModule + Offset.PlayerName, 20);
                    string pRealm = Config.Memory.ReadString(Config.baseAddressModule + Offset.Realm, 25);
                    //pFaction = Config.Memory.ReadInt((int)Config.Memory.ReadUInt(ObjectManager.getPlayerBase() + 0xC) + Offset.Faction).ToString();
                    var pGold = Config.Memory.ReadInt((int)Config.Memory.ReadUInt(ObjectManager.ObjectManager.getPlayerBase() + 0xC) + Offset.Gold) / 10000;
                    accountGrid.Rows[i].Cells[0].Value = pRealm;
                    accountGrid.Rows[i].Cells[1].Value = pName;
                    // accountGrid.Rows[i].Cells[1].Value = "ДЖИГУРДА"; //pFaction
                    accountGrid.Rows[i].Cells[2].Value = pGold.ToString();
                }
                else
                {
                    MessageBox.Show("Чето нихуя не получилось, слыш");
                    return;
                }
            }
        } 
    }
}
