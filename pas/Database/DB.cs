using System.Linq;
using System.Windows.Forms;

namespace Database
{
    public class DB
    {
        private Account[] _db;
        
        private DataGridView _dataGrid;

        public DB(Account[] Accs,DataGridView DataGrid)
        {
            _dataGrid = DataGrid;
            _db = new Account[Accs.Length];
            for(int i = 0; i < Accs.Length; i++)
            {
                var a = Accs[i];
                _db[i]=a;
            }
        }

        public Account this[int index]
        {
            get { return _db.ElementAt(index); }
        }

        public int Count
        {
            get { return _db.Length; }
        }

        public void FillTable()
        {
            int count = 0;
            
            _dataGrid.Rows.Clear();
            for (int i = 0; i < _db.Length; i++)
            {
                if (_db[i] != null)
                {
                    _dataGrid.Rows.Add();
                    _dataGrid.Rows[count].Cells[0].Value = _db[i].RealmName;
                    _dataGrid.Rows[count].Cells[1].Value = _db[i].Faction;
                    _dataGrid.Rows[count].Cells[2].Value = _db[i].CharName;
                    _dataGrid.Rows[count].Cells[3].Value = _db[i].GoldValue;
                    count++;
                }
            }
            GoldParser.MainForm.accountGrid = _dataGrid; 
        }
    }
}
