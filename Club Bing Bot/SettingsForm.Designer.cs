namespace Xenix
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GameCombo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nextwordMax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nextwordMin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nextletterMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nextletterMin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.startgameMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.startgameMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.newgameMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.newgameMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkUseDecap = new System.Windows.Forms.CheckBox();
            this.decapPass = new System.Windows.Forms.TextBox();
            this.decapUser = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.GameCombo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.nextwordMax);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.nextwordMin);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.nextletterMax);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nextletterMin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.startgameMax);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.startgameMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.newgameMax);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.newgameMin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delays (In MS)";
            // 
            // GameCombo
            // 
            this.GameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameCombo.FormattingEnabled = true;
            this.GameCombo.Items.AddRange(new object[] {
            "Random",
            "Ascending 3 -> 7 letters",
            "Descending 7 -> 3 letters"});
            this.GameCombo.Location = new System.Drawing.Point(75, 123);
            this.GameCombo.Name = "GameCombo";
            this.GameCombo.Size = new System.Drawing.Size(123, 21);
            this.GameCombo.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Ordering:";
            this.toolTip1.SetToolTip(this.label12, "In what order the answers will be typed in to the game");
            // 
            // nextwordMax
            // 
            this.nextwordMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextwordMax.Location = new System.Drawing.Point(142, 97);
            this.nextwordMax.Name = "nextwordMax";
            this.nextwordMax.Size = new System.Drawing.Size(56, 20);
            this.nextwordMax.TabIndex = 19;
            this.nextwordMax.Text = "3500";
            this.nextwordMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(131, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "-";
            // 
            // nextwordMin
            // 
            this.nextwordMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextwordMin.Location = new System.Drawing.Point(75, 97);
            this.nextwordMin.Name = "nextwordMin";
            this.nextwordMin.Size = new System.Drawing.Size(56, 20);
            this.nextwordMin.TabIndex = 17;
            this.nextwordMin.Text = "1500";
            this.nextwordMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Next Word:";
            this.toolTip1.SetToolTip(this.label10, "Delay before starting to type a new word");
            // 
            // nextletterMax
            // 
            this.nextletterMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextletterMax.Location = new System.Drawing.Point(142, 71);
            this.nextletterMax.Name = "nextletterMax";
            this.nextletterMax.Size = new System.Drawing.Size(56, 20);
            this.nextletterMax.TabIndex = 15;
            this.nextletterMax.Text = "160";
            this.nextletterMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(131, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "-";
            // 
            // nextletterMin
            // 
            this.nextletterMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextletterMin.Location = new System.Drawing.Point(74, 71);
            this.nextletterMin.Name = "nextletterMin";
            this.nextletterMin.Size = new System.Drawing.Size(56, 20);
            this.nextletterMin.TabIndex = 13;
            this.nextletterMin.Text = "80";
            this.nextletterMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Next Letter:";
            this.toolTip1.SetToolTip(this.label8, "Delay before typing the next letter in a word\r\n");
            // 
            // startgameMax
            // 
            this.startgameMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startgameMax.Location = new System.Drawing.Point(142, 45);
            this.startgameMax.Name = "startgameMax";
            this.startgameMax.Size = new System.Drawing.Size(56, 20);
            this.startgameMax.TabIndex = 11;
            this.startgameMax.Text = "4000";
            this.startgameMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(131, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "-";
            // 
            // startgameMin
            // 
            this.startgameMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startgameMin.Location = new System.Drawing.Point(74, 45);
            this.startgameMin.Name = "startgameMin";
            this.startgameMin.Size = new System.Drawing.Size(56, 20);
            this.startgameMin.TabIndex = 9;
            this.startgameMin.Text = "2000";
            this.startgameMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Start Game:";
            this.toolTip1.SetToolTip(this.label6, "Delay before starting the game after it\'s loaded");
            // 
            // newgameMax
            // 
            this.newgameMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newgameMax.Location = new System.Drawing.Point(142, 19);
            this.newgameMax.Name = "newgameMax";
            this.newgameMax.Size = new System.Drawing.Size(56, 20);
            this.newgameMax.TabIndex = 7;
            this.newgameMax.Text = "5000";
            this.newgameMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            // 
            // newgameMin
            // 
            this.newgameMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newgameMin.Location = new System.Drawing.Point(75, 19);
            this.newgameMin.Name = "newgameMin";
            this.newgameMin.Size = new System.Drawing.Size(56, 20);
            this.newgameMin.TabIndex = 5;
            this.newgameMin.Text = "2000";
            this.newgameMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "New Game:";
            this.toolTip1.SetToolTip(this.label4, "Delay before loading a new game");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Username:";
            this.toolTip1.SetToolTip(this.label1, "Delay before loading a new game");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Password:";
            this.toolTip1.SetToolTip(this.label2, "Delay before loading a new game");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkUseDecap);
            this.groupBox2.Controls.Add(this.decapPass);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.decapUser);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(222, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decaptcher";
            // 
            // checkUseDecap
            // 
            this.checkUseDecap.AutoSize = true;
            this.checkUseDecap.Location = new System.Drawing.Point(66, 68);
            this.checkUseDecap.Name = "checkUseDecap";
            this.checkUseDecap.Size = new System.Drawing.Size(104, 17);
            this.checkUseDecap.TabIndex = 26;
            this.checkUseDecap.Text = "Use Decaptcher";
            this.checkUseDecap.UseVisualStyleBackColor = true;
            // 
            // decapPass
            // 
            this.decapPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decapPass.Location = new System.Drawing.Point(70, 45);
            this.decapPass.Name = "decapPass";
            this.decapPass.Size = new System.Drawing.Size(99, 20);
            this.decapPass.TabIndex = 25;
            this.decapPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // decapUser
            // 
            this.decapUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decapUser.Location = new System.Drawing.Point(70, 19);
            this.decapUser.Name = "decapUser";
            this.decapUser.Size = new System.Drawing.Size(99, 20);
            this.decapUser.TabIndex = 23;
            this.decapUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(313, 110);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset Defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(313, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 165);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox newgameMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newgameMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nextwordMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nextwordMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nextletterMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nextletterMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox startgameMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox startgameMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox GameCombo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox decapPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox decapUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkUseDecap;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
    }
}