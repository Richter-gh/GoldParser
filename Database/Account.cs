using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Database
{
    public class Account
    {
        private string _charName;
        private string _realmName;
        private int _goldValue;
        
        public Account(string CharName,string Realm, int Gold)
        {    
            _charName = CharName;
            _goldValue = Gold;
            _realmName = Realm;
        }
        public void Update(string CharName,string Realm, int Gold)
        {
           
            _charName = CharName;
            _goldValue = Gold;
            _realmName = Realm; 
        }
        public string CharName
        {
            get { return _charName; }
            set { _charName = value; }
        }
        public string RealmName
        {
            get { return _realmName; }
            set { _realmName = value; }
        }
       
        public int GoldValue
        {
            get { return _goldValue; }
            set { _goldValue = value; }
        }
        public string Value()
        {
            return _realmName + " | " + _charName + " | " + _goldValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}
