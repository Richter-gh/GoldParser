using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.IO;
namespace MemoryWorker
{
    public class Memory
    {
        #region Fields

        private int _ProcessHwnd;
        private int _ProcessId;

        #endregion Fields

        #region Constructors

        public Memory(int ProcessId)
        {
            _ProcessId = ProcessId;
            _ProcessHwnd = Open(_ProcessId);
        }

        #endregion Constructors

        #region Properties

        public int ProcessHwnd
        {
            get { return _ProcessHwnd; }
        }

        public int ProcessId
        {
            get { return _ProcessId; }
        }

        #endregion Properties

        #region Methods

        public static Int32 GetModule(Int32 IdProcess, string ModuleName)
        {
            ProcessModuleCollection modules = Process.GetProcessById(IdProcess).Modules;
            for (int i = 0; i < modules.Count; i++)
            {
                if (modules[i].ModuleName.ToLower() == ModuleName.ToLower())
                {
                    return (int)modules[i].BaseAddress;
                }
            }
            return 0;
        }

       
        public int ReadInt(int MemoryAddress)
        {
            return BitConverter.ToInt32(ReadProcessMemory((IntPtr)MemoryAddress, 4), 0);
        }

        public int ReadInt32(int MemoryAddress)
        {
            return BitConverter.ToInt32(ReadProcessMemory((IntPtr)MemoryAddress, 4), 0);
        }

        public long ReadInt64(int MemoryAddress)
        {
            return BitConverter.ToInt64(ReadProcessMemory((IntPtr)MemoryAddress, 8), 0);
        }

        public byte[] ReadProcessMemory(IntPtr MemoryAddress, UInt32 bytesToRead)
        {
            try
            {
                if (bytesToRead > 0 && MemoryAddress != null)
                {
                    byte[] buffer = new byte[bytesToRead];
                    IntPtr ptr;
                    ReadProcessMemory((IntPtr)_ProcessHwnd, MemoryAddress, buffer, bytesToRead, out ptr);
                    return buffer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.Write("Error :\n" + e.ToString(), "Alerte");
                return null;
            }
        }

       
        public string ReadString(int MemoryAddress, UInt32 Len)
        {
            string str = "";
            byte[] buffer = ReadProcessMemory((IntPtr)MemoryAddress, Len);
            str = BitConverter.ToString(buffer, 0);
            Encoding b = Encoding.GetEncoding(Encoding.UTF8.CodePage); 
            return b.GetString(buffer);                                
        }

        public UInt32 ReadUInt(int MemoryAddress)
        {
            return BitConverter.ToUInt32(ReadProcessMemory((IntPtr)MemoryAddress, 4), 0);
        }

        
        public UInt64 ReadUInt64(int MemoryAddress)
        {
            return BitConverter.ToUInt64(ReadProcessMemory((IntPtr)MemoryAddress, 8), 0);
        }

        

        [DllImport("kernel32")]
        private static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);

        private int Open(int ProcessId)
        {
            try
            {
                int ProcessOpen;

                if (ProcessId == 0)
                {
                    throw new Exception("Process not Select.");
                }

                System.Diagnostics.Process.EnterDebugMode();

                ProcessOpen = OpenProcessAllMode(ProcessId);

                return ProcessOpen;
            }
            catch (Exception e)
            {
                Console.Write("Error :\n" + e.ToString(), "Alerte");
                return 0;
            }
        }

        private int OpenProcessAllMode(int IdProcess)
        {
            try
            {
                return (int)OpenProcess(0x1F0FFF, false, IdProcess);
            }
            catch (Exception e)
            {
                Console.Write("Error :\n" + e.ToString(), "Alerte");
                return 0;
            }
        }

        #endregion Methods
    }
}