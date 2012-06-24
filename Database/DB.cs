using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Database
{
    public class DB
    {
        private List<Account> _db;
        
        private DataGridView _dataGrid;
        
        private int size;
        
        public DB(Account[] Accs,DataGridView DataGrid)
        {
            size = 0;
            _dataGrid = DataGrid;
            _db = new List<Account>();
            foreach (Account a in Accs)
            {
                Add(a,size);
                size++;
            }
            _dataGrid.BeginInvoke((MethodInvoker)(() => _dataGrid.Rows.Add(size)));
        }
        
        public void Add(Account Acc,int Size)
        {  
            _db.Add(Acc); 
        }

        public void SortByRealm()
        {
            _db.OrderBy((k) => k.RealmName);
            FillTable();
        }
        
        public void FillTable()
        {
            size = 0;
            foreach (Account Acc in _db)
            {   
                _dataGrid.BeginInvoke((MethodInvoker) (() => _dataGrid.Rows[size-1].Cells[0].Value = Acc.RealmName));
                _dataGrid.BeginInvoke((MethodInvoker) (() => _dataGrid.Rows[size-1].Cells[2].Value = Acc.CharName));
                _dataGrid.BeginInvoke((MethodInvoker) (() => _dataGrid.Rows[size-1].Cells[3].Value = Acc.GoldValue));
                size++;
            }
        }
    }
}
