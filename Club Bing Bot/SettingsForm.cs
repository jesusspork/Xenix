using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Xenix
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will reset all min/max settings to their default amounts.\nContinue?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
            {
                newgameMin.Text = "2000";
                newgameMax.Text = "5000";
                startgameMin.Text = "2000";
                startgameMax.Text = "4000";
                nextletterMin.Text = "80";
                nextletterMax.Text = "160";
                nextwordMin.Text = "1500";
                nextwordMax.Text = "3500";
                GameCombo.SelectedIndex = 0;
                btnSave.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter outputstream = File.CreateText("XenixSettings.txt");
                outputstream.WriteLine(
                          newgameMin.Text +
                    '|' + newgameMax.Text +
                    '|' + startgameMin.Text +
                    '|' + startgameMax.Text +
                    '|' + nextletterMin.Text +
                    '|' + nextletterMax.Text +
                    '|' + nextwordMin.Text +
                    '|' + nextwordMax.Text +
                    '|' + GameCombo.SelectedIndex +
                    '|' + decapUser.Text +
                    '|' + decapPass.Text +
                    '|' + checkUseDecap.Checked.ToString() +
                    '|');
                outputstream.Close();
                Form1.Instance.LoadSettings();
            }
            catch (Exception exx) { MessageBox.Show("Error saving settings.\nError:\n" + exx.Message); }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            try
            {
                StreamReader inputstream = new StreamReader("XenixSettings.txt");
                string[] newstr = new string[9];
                while (inputstream.Peek() != -1)
                {
                    newstr = inputstream.ReadLine().Split('|');

                    newgameMin.Text = newstr[0];
                    newgameMax.Text = newstr[1];
                    startgameMin.Text = newstr[2];
                    startgameMax.Text = newstr[3];
                    nextletterMin.Text = newstr[4];
                    nextletterMax.Text = newstr[5];
                    nextwordMin.Text = newstr[6];
                    nextwordMax.Text = newstr[7];
                    GameCombo.SelectedIndex = Int32.Parse(newstr[8]);
                    //decapUser.Text = newstr[9];
                    //decapPass.Text = newstr[10];
                    //checkUseDecap.Checked = Convert.ToBoolean(newstr[11]);
                }
                inputstream.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error loading settings.\nError:\n" + ex.Message); }
        }
    }
}
