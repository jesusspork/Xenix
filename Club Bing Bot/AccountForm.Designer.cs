namespace Xenix
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRemove = new System.Windows.Forms.Button();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.Email = new System.Windows.Forms.ColumnHeader();
            this.Password = new System.Windows.Forms.ColumnHeader();
            this.Game = new System.Windows.Forms.ColumnHeader();
            this.Tickets = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.GameCombo = new System.Windows.Forms.ComboBox();
            this.GameLabel = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemove.Location = new System.Drawing.Point(483, 207);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(98, 23);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Remove Account";
            this.btnRemove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // ListView1
            // 
            this.ListView1.CheckBoxes = true;
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Email,
            this.Password,
            this.Game,
            this.Tickets});
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.Location = new System.Drawing.Point(12, 25);
            this.ListView1.MultiSelect = false;
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(461, 206);
            this.ListView1.TabIndex = 14;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            this.ListView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 168;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 107;
            // 
            // Game
            // 
            this.Game.Text = "Game";
            this.Game.Width = 109;
            // 
            // Tickets
            // 
            this.Tickets.Text = "Tickets";
            this.Tickets.Width = 73;
            // 
            // btnEdit
            // 
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEdit.Location = new System.Drawing.Point(483, 178);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 23);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Update Account";
            this.btnEdit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(482, 149);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Add Account";
            this.btnOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(481, 83);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(155, 20);
            this.PasswordTextBox.TabIndex = 11;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(481, 34);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(155, 20);
            this.EmailTextBox.TabIndex = 9;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(480, 57);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(66, 23);
            this.PasswordLabel.TabIndex = 10;
            this.PasswordLabel.Text = "Password:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EmailLabel
            // 
            this.EmailLabel.Location = new System.Drawing.Point(480, 8);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(65, 23);
            this.EmailLabel.TabIndex = 8;
            this.EmailLabel.Text = "Email:";
            this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameCombo
            // 
            this.GameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameCombo.FormattingEnabled = true;
            this.GameCombo.Items.AddRange(new object[] {
            "Chicktionary",
            "Spelling Bee",
            "Word Slugger"});
            this.GameCombo.Location = new System.Drawing.Point(481, 122);
            this.GameCombo.Name = "GameCombo";
            this.GameCombo.Size = new System.Drawing.Size(155, 21);
            this.GameCombo.TabIndex = 16;
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.Location = new System.Drawing.Point(480, 106);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(35, 13);
            this.GameLabel.TabIndex = 17;
            this.GameLabel.Text = "Game";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(587, 149);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(49, 37);
            this.btnUp.TabIndex = 18;
            this.btnUp.Text = "Move Up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(587, 193);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(49, 37);
            this.btnDown.TabIndex = 19;
            this.btnDown.Text = "Move Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 238);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.GameLabel);
            this.Controls.Add(this.GameCombo);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(659, 272);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(659, 272);
            this.Name = "AccountForm";
            this.Text = "Account Manager";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.ListView ListView1;
        internal System.Windows.Forms.ColumnHeader Email;
        internal System.Windows.Forms.ColumnHeader Password;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.TextBox PasswordTextBox;
        internal System.Windows.Forms.TextBox EmailTextBox;
        internal System.Windows.Forms.Label PasswordLabel;
        internal System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.ComboBox GameCombo;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.ColumnHeader Game;
        private System.Windows.Forms.ColumnHeader Tickets;
        internal System.Windows.Forms.Button btnUp;
        internal System.Windows.Forms.Button btnDown;
    }
}