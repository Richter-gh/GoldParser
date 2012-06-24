using System;
using System.Collections.Generic;
using MemoryWorker;


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

        public static long Faction
        {
            get
            {
                try
                {
                    uint MyFaction = Config.Memory.ReadUInt(getPlayerBase() + 0xC);
                    return Config.Memory.ReadInt64((int)MyFaction + (int)Offset.UNIT_FIELD_FACTIONTEMPLATE);
                }
                catch
                {
                    return 0;
                }
            }
        }

        internal enum ePlayerFactions
        {
            Human = 1,
            Orc = 2,
            Dwarf = 3,
            NightElf = 4,
            Undead = 5,
            Tauren = 6,
            Gnome = 115,
            Troll = 116,
            BloodElf = 1610,
            Draenei = 1629,
            Worgen = 2203,
            Goblin = 2204,
        }

        public static string PlayerFaction
        {
            get
            {
                long faction = Faction;
                if (GoldParser.Properties.Settings.Default.lang == "Русский")
                {
                    if(faction.Equals((long) ePlayerFactions.Human))
                        return "Альянс";
                    else if(faction.Equals((long) ePlayerFactions.BloodElf))
                        return "Орда";
                    else if(faction.Equals((long) ePlayerFactions.Dwarf))
                        return "Альянс";
                    else if(faction.Equals((long) ePlayerFactions.Gnome))
                        return "Альянс";
                    else if(faction.Equals((long) ePlayerFactions.NightElf))
                        return "Альянс";
                    else if(faction.Equals((long) ePlayerFactions.Orc))
                        return "Орда";
                    else if(faction.Equals((long) ePlayerFactions.Tauren))
                        return "Орда";
                    else if(faction.Equals((long) ePlayerFactions.Troll))
                        return "Орда";
                    else if(faction.Equals((long) ePlayerFactions.Undead))
                        return "Орда";
                    else if(faction.Equals((long) ePlayerFactions.Draenei))
                        return "Альянс";
                    else if(faction.Equals((long) ePlayerFactions.Goblin))
                        return "Орда";
                    else if(faction.Equals((long) ePlayerFactions.Worgen))
                        return "Альянс";
                }
                else
                { 
                    if(faction.Equals((long) ePlayerFactions.Human))
                        return "Alliance";
                    else if(faction.Equals((long) ePlayerFactions.BloodElf))
                        return "Horde";
                    else if(faction.Equals((long) ePlayerFactions.Dwarf))
                        return "Alliance";
                    else if(faction.Equals((long) ePlayerFactions.Gnome))
                        return "Alliance";
                    else if(faction.Equals((long) ePlayerFactions.NightElf))
                        return "Alliance";
                    else if(faction.Equals((long) ePlayerFactions.Orc))
                        return "Horde";
                    else if(faction.Equals((long) ePlayerFactions.Tauren))
                        return "Horde";
                    else if(faction.Equals((long) ePlayerFactions.Troll))
                        return "Horde";
                    else if(faction.Equals((long) ePlayerFactions.Undead))
                        return "Horde";
                    else if(faction.Equals((long) ePlayerFactions.Draenei))
                        return "Alliance";
                    else if(faction.Equals((long) ePlayerFactions.Goblin))
                        return "Horde";
                    else if(faction.Equals((long) ePlayerFactions.Worgen))
                        return "Alliance";
                }
                
                return "unknown";

            }
        }
    }
}