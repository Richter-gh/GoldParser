using System;
using System.Windows.Forms;
using ObjectManager;

namespace GoldParser
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Properties.Settings.Default.Reset();
            Application.Run(new MainForm());
                //if (Properties.Settings.Default.FL1)
                //{
                //    Properties.Settings.Default.MBID1 = Protector.Protector.GetMotherBoardID();
                //    Properties.Settings.Default.Save();
                //    Application.Run(new ProtectorForm()); 
                //}
                //else if (!Properties.Settings.Default.FL1 &&
                //   Properties.Settings.Default.MBID1 == Protector.Protector.GetMotherBoardID())
                //{
                //    if (Properties.Settings.Default.K1 == Properties.Settings.Default.H1 && Properties.Settings.Default.CL1)
                //        Application.Run(new MainForm());
                //}
                //else
                //{
                //    Properties.Settings.Default.MBID1 = Protector.Protector.GetMotherBoardID();
                //    Properties.Settings.Default.H1 = "";
                //    Properties.Settings.Default.CL1 = false; 
                //    Properties.Settings.Default.Save();
                //    Application.Run(new ProtectorForm());
                //}
            

        }
    }

}
