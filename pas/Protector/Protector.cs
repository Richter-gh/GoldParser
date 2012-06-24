using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Security;
namespace Protector
{
    public static class Protector
    {
        private static MD5 _md5;
        public static string GetHash()
        {
            string Hash="";
            Hash = FingerPrint.Value();
            return Hash;
        }
        public static string CheckHashSignature(string key)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes((key.Split('-')[3] + key.Split('-')[1]).Reverse().ToArray());
            return FingerPrint.GetHexString(sec.ComputeHash(bt));
        }
        public static string GetMotherBoardID()
        {
            string id = "";
            id = FingerPrint.baseId();
            return id;
        }
        
        
    }
}
