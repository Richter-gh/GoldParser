using System;
using System.Collections.Generic;



namespace ObjectManager
{
    public class ObjectManager
    {
        public static List<int> getAllObject()
        {
            int BaseAdresseNew;
            List<int> TempsListObject = new List<int>();
            int BaseAdresse = Config.Memory.ReadInt32(s_curMgr() + Offset.FirstObject);
            while (BaseAdresse != 0)
            {
                TempsListObject.Add(BaseAdresse);

                BaseAdresseNew = Config.Memory.ReadInt32(BaseAdresse + Offset.NextObject);
                if (BaseAdresseNew == BaseAdresse)
                {
                    break;
                }
                BaseAdresse = BaseAdresseNew;
            }
            return TempsListObject;
        }

        public static int getPlayerBase()
        {
            UInt64 guidPlayer = Config.Memory.ReadUInt64(s_curMgr() + Offset.PlayerGuid);

            foreach (int o in getAllObject())
            {
                if (Config.Memory.ReadUInt64(o + Offset.Guid) == guidPlayer)
                {
                    return o;
                }
            }
            return 0;
        }

        public static int s_curMgr()
        {
            int Val;
            Val = Config.Memory.ReadInt32(Config.Memory.ReadInt32(Config.baseAddressModule + Offset.CurMgrPointer) + Offset.CurMgrOffset);
            return Val;
        }
    }
}