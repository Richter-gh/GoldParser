using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using MemoryWorker;
using ObjectManager;
using Database;
namespace GoldParser
{
    public partial class MainForm : Form
    {
        #region Not used
        private static string Decode(string S)
        {
            if(S == null) throw new ArgumentNullException("S");

            Encoding a = Encoding.GetEncoding(Encoding.Default.CodePage);
            Encoding b = Encoding.GetEncoding(Encoding.Default.CodePage);
            byte[] l = a.GetBytes(S);
            return b.GetString(l);
        }
        #endregion

        #region Fields
        private Account[] _accounts;
        private int _count;
        private int _account;
        
        private DB _dataBase;
        #endregion
        private static DispatcherTimer timer = new DispatcherTimer();
        
        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc);
        private void Scan()
        {
            _account = 0;
            var processes = Process.GetProcessesByName("wow");  
            if (processes.Length == 0)
            {
                if(Properties.Settings.Default.lang=="Русский")
                    
                MessageBox.Show(_count < 2
                                    ? "Не обнаружен подходящий вов\nИли программа запущена без админских прав"
                                    : "Ты што сука совсем еблан?");
                else
                    MessageBox.Show(_count < 2
                                    ? "Cant find any WoW\nOr launched without admin rigts"
                                    : "Are you stupid?");
                _count++;
                return;
            }
            accountGrid.Refresh();
            bool ret = false;
            _accounts = new Account[processes.Length];
            for (int i = 0; i < processes.Length; i++)
            {
                EmptyWorkingSet(processes[i].Handle);
                Config.Memory = new Memory(processes[i].Id);
                Config.baseAddressModule = Memory.GetModule(processes[i].Id, "Wow.exe"); 
                if (Config.Memory.ReadInt(Config.baseAddressModule + Offset.GameState)==1)
                {
                    ret = true;
                }
                if (ret)
                {  
                    var pName = Config.Memory.ReadString(Config.baseAddressModule + Offset.PlayerName,30);
                    var pRealm =Config.Memory.ReadString(Config.baseAddressModule + Offset.Realm,30);
                    var pGold = Config.Memory.ReadInt((int)Config.Memory.ReadUInt(ObjectManager.ObjectManager.getPlayerBase() + 0xC) + Offset.Gold) / 10000;
                    var pFaction = ObjectManager.ObjectManager.PlayerFaction;
                    _accounts[i] = new Account(pName.Split('\0')[0], pRealm.Split('\0')[0], pGold, pFaction);
                    _account++;
                    
                } 
            }    
            if (_account != 0)
            {
                _dataBase = new DB(_accounts,accountGrid);
                _dataBase.FillTable();
            } 
        }

        #region Interface of form
        
        private void LoadAccounts()
        { 
            accountGrid.Columns.Clear();
            accountGrid.AutoGenerateColumns = false;
            accountGrid.DataSource = null; 
            DataGridViewColumn realm = new DataGridViewTextBoxColumn();
            realm.DataPropertyName = "Realm";
            realm.Name = "Realm";
            realm.HeaderText = "Realm";
            accountGrid.Columns.Add(realm);
            DataGridViewColumn Faction = new DataGridViewTextBoxColumn();
            Faction.DataPropertyName = "Faction";
            Faction.Name = "Faction";
            Faction.HeaderText = "Faction";
            accountGrid.Columns.Add(Faction);
            DataGridViewColumn CharName = new DataGridViewTextBoxColumn();
            CharName.DataPropertyName = "Name";
            CharName.Name = "Name";
            CharName.HeaderText = "Name";
            accountGrid.Columns.Add(CharName);
            DataGridViewColumn gold = new DataGridViewTextBoxColumn();
            gold.DataPropertyName = "Gold";
            gold.Name = "Gold";
            gold.HeaderText = "Gold";
            accountGrid.Columns.Add(gold);
        }
        #region Buttons+MainForm Constructor
        public MainForm()
        {

            _count = 0;
            InitializeComponent();
            LoadAccounts();
            timer.Tick +=
                delegate(object s, EventArgs args)
                {
                    Scan();
                };

            timer.Interval = new TimeSpan(0, 0, 5); // one second

        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }
          
        private void button3_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("skype:ololasek64?chat");
        }
        #endregion
       
    }
     
}
   