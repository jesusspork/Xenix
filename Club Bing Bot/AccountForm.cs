using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Xenix
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (isValidEmail(EmailTextBox.Text) & PasswordTextBox.Text.Length >= 6 & GameCombo.Text.Length > 5)
                ListView1.Items.Add(new ListViewItem(new string[] { EmailTextBox.Text, PasswordTextBox.Text, GameCombo.Text, "0" }));
            else
                MessageBox.Show("Invalid email, password is to short, or you haven't chosen a game for the account");
        }

        public static bool isValidEmail(string email)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
                @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
                @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Match match =
                System.Text.RegularExpressions.Regex.Match(email.Trim(), pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
                return true;
            else
                return false;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            ListView1.SelectedItems[0].Remove();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (isValidEmail(EmailTextBox.Text) & PasswordTextBox.Text.Length >= 6 & GameCombo.Text.Length > 5)
            {
                ListView1.Items[ListView1.SelectedIndices[0]].Text = EmailTextBox.Text;
                ListView1.Items[ListView1.SelectedIndices[0]].SubItems[1].Text = PasswordTextBox.Text;
                ListView1.Items[ListView1.SelectedIndices[0]].SubItems[2].Text = GameCombo.SelectedItem.ToString();
                EmailTextBox.Focus();
            }
            else { MessageBox.Show("Invalid email, password is to short, or you haven't chosen a game for the account"); }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count > 0)
            {
                btnOK.Enabled = false;
                EmailTextBox.Text = ListView1.Items[ListView1.SelectedIndices[0]].SubItems[0].Text;
                PasswordTextBox.Text = ListView1.Items[ListView1.SelectedIndices[0]].SubItems[1].Text;
                switch (ListView1.Items[ListView1.SelectedIndices[0]].SubItems[2].Text)
                {
                    case "Chicktionary":
                        GameCombo.SelectedIndex = 0;
                        break;
                    case "Spelling Bee":
                        GameCombo.SelectedIndex = 1;
                        break;
                    case "Word Slugger":
                        GameCombo.SelectedIndex = 2;
                        break;
                }
            }
            else
            {
                btnOK.Enabled = true;
                EmailTextBox.Clear();
                PasswordTextBox.Clear();
                GameCombo.Text = String.Empty;
            }

            try
            {
                if (ListView1.SelectedItems[0].Index > 0)
                { btnUp.Enabled = true; }
                else
                { btnUp.Enabled = false; }
            }
            catch { btnUp.Enabled = false; }

            try
            {
                if (ListView1.SelectedItems[0].Index != (ListView1.Items.Count - 1))
                { btnDown.Enabled = true; }
                else
                { btnDown.Enabled = false; }
            }
            catch { btnDown.Enabled = false; }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveListViewItem(ref ListView1, true);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveListViewItem(ref ListView1, false);
        }

        //Pulled from http://www.knowdotnet.com/articles/listviewmoveitem.html
        private void MoveListViewItem(ref ListView lv, bool moveUp)
        {
            string cache;
            int selIdx;
            bool itemchecked = false;
            bool otheritemchecked = false;


            selIdx = lv.SelectedItems[0].Index;
            if (lv.Items[selIdx].Checked) { itemchecked = true; }
            if (moveUp)
            {
                if (lv.Items[selIdx - 1].Checked) { otheritemchecked = true; }
                // ignore moveup of row(0)
                if (selIdx == 0)
                    return;

                // move the subitems for the previous row
                // to cache to make room for the selected row
                for (int i = 0; i < lv.Items[selIdx].SubItems.Count; i++)
                {
                    cache = lv.Items[selIdx - 1].SubItems[i].Text;
                    lv.Items[selIdx - 1].SubItems[i].Text =
                      lv.Items[selIdx].SubItems[i].Text;
                    lv.Items[selIdx].SubItems[i].Text = cache;
                }
                lv.Items[selIdx - 1].Selected = true;
                if (itemchecked) { lv.Items[selIdx - 1].Checked = true; } else { lv.Items[selIdx - 1].Checked = false; }
                if (otheritemchecked)
                {
                    lv.Items[selIdx].Checked = true;
                }
                else
                {
                    lv.Items[selIdx].Checked = false;
                }
                lv.Refresh();
                lv.Focus();
            }
            else
            {
                if (lv.Items[selIdx + 1].Checked) { otheritemchecked = true; }
                // ignore movedown of last item
                if (selIdx == lv.Items.Count - 1)
                    return;
                // move the subitems for the next row
                // to cache so we can move the selected row down
                for (int i = 0; i < lv.Items[selIdx].SubItems.Count; i++)
                {
                    cache = lv.Items[selIdx + 1].SubItems[i].Text;
                    lv.Items[selIdx + 1].SubItems[i].Text =
                      lv.Items[selIdx].SubItems[i].Text;
                    lv.Items[selIdx].SubItems[i].Text = cache;
                }
                lv.Items[selIdx + 1].Selected = true;
                if (itemchecked) { lv.Items[selIdx + 1].Checked = true; } else { lv.Items[selIdx + 1].Checked = false; }
                if (otheritemchecked)
                {
                    lv.Items[selIdx].Checked = true;
                }
                else
                {
                    lv.Items[selIdx].Checked = false;
                }
                lv.Refresh();
                lv.Focus();
            }
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            try
            {
                StreamReader inputstream = new StreamReader("XenixAccounts.txt");
                string[] newstr = new string[3];

                while (inputstream.Peek() != -1)
                {
                    newstr = inputstream.ReadLine().Split('|');

                    ListView1.Items.Add(newstr[1]);
                    ListView1.Items[ListView1.Items.Count - 1].SubItems.Add(newstr[2]);
                    ListView1.Items[ListView1.Items.Count - 1].SubItems.Add(newstr[3]);
                    ListView1.Items[ListView1.Items.Count - 1].SubItems.Add(newstr[4]);
                    ListView1.Items[ListView1.Items.Count - 1].Checked = Convert.ToBoolean(newstr[0]);
                }
                inputstream.Close();
                newstr = null;
            }
            catch (Exception ex) { MessageBox.Show("Error loading accounts.\nError:\n" + ex.Message); }
        }

        private void AccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StreamWriter outputstream = File.CreateText("XenixAccounts.txt");
                string[] newstr = new string[4];
                bool UserEnabled = false;
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    for (int s = 0; s <= 3; s++)
                    {
                        UserEnabled = ListView1.Items[i].Checked;
                        newstr[s] = ListView1.Items[i].SubItems[s].Text;
                    }
                    outputstream.WriteLine(
                              UserEnabled.ToString() + 
                        '|' + newstr[0] + 
                        '|' + newstr[1] + 
                        '|' + newstr[2] + 
                        '|' + newstr[3] + 
                        '|');
                }
                outputstream.Close();
                newstr = null;
            }
            catch (Exception exx) { MessageBox.Show("Error saving accounts.\nError:\n" + exx.Message); }
        }
    }
}
