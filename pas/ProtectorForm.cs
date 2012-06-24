using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoldParser
{
    public partial class ProtectorForm : Form
    {
        public ProtectorForm()
        {
            InitializeComponent();
            Properties.Settings.Default.MBID1 = Protector.Protector.GetMotherBoardID();
            Properties.Settings.Default.Save();
            HashKeyTextBox.Text = Protector.Protector.GetHash();
            Properties.Settings.Default.H1 = Protector.Protector.CheckHashSignature(HashKeyTextBox.Text);
            Properties.Settings.Default.Save();
        }

        private void GenerateKeyButton_Click(object sender, EventArgs e)
        {
            HashKeyTextBox.Text = Protector.Protector.GetHash();
            Properties.Settings.Default.H1 = Protector.Protector.CheckHashSignature(HashKeyTextBox.Text);
            Properties.Settings.Default.Save();
        }

        private void CheckKeyButton_Click(object sender, EventArgs e)
        {
            if (CheckHashTextBox.Text != "")
            {
                Properties.Settings.Default.K1 = CheckHashTextBox.Text;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.K1 == Protector.Protector.CheckHashSignature(HashKeyTextBox.Text))
                {
                    Properties.Settings.Default.FL1 = false;
                    Properties.Settings.Default.CL1 = true;
                    Properties.Settings.Default.lang = comboBox1.SelectedText;
                    Properties.Settings.Default.Save();
                }
                else MessageBox.Show("ERROR");
               
            }
            if(Properties.Settings.Default.CL1)
            {
                Application.Exit();
            }
            
        }
        private void ProtectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("skype:ololasek64?chat");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
