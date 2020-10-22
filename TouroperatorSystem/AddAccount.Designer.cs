namespace TouroperatorSystem
{
    partial class AddAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccount));
            this.PanelForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.Button();
            this.Yes = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PanelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelForm
            // 
            this.PanelForm.BackColor = System.Drawing.Color.CornflowerBlue;
            this.PanelForm.Controls.Add(this.pictureBox1);
            this.PanelForm.Controls.Add(this.label4);
            this.PanelForm.Controls.Add(this.Close);
            this.PanelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelForm.Location = new System.Drawing.Point(0, 0);
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.Size = new System.Drawing.Size(729, 46);
            this.PanelForm.TabIndex = 8;
            this.PanelForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelForm_MouseDown);
            this.PanelForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelForm_MouseMove);
            this.PanelForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelForm_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(59, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = "Add Account";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(681, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(48, 46);
            this.Close.TabIndex = 0;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.CloseButton_Click);
            this.Close.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.Close.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Crimson;
            this.label9.Location = new System.Drawing.Point(164, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(495, 25);
            this.label9.TabIndex = 29;
            this.label9.Text = "Логин должен состоять из 8 и больше символов";
            this.label9.Visible = false;
            // 
            // textBox0
            // 
            this.textBox0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox0.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox0.Location = new System.Drawing.Point(380, 87);
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(274, 47);
            this.textBox0.TabIndex = 28;
            this.textBox0.TextChanged += new System.EventHandler(this.TextBox0_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(203, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 52);
            this.label3.TabIndex = 27;
            this.label3.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(144, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Пароль должен состоять из 8 и больше символов";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(380, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 47);
            this.textBox1.TabIndex = 31;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(170, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 52);
            this.label2.TabIndex = 30;
            this.label2.Text = "Пароль";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Турагентство",
            "Администратор"});
            this.comboBox1.Location = new System.Drawing.Point(380, 260);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(274, 47);
            this.comboBox1.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(51, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 52);
            this.label5.TabIndex = 34;
            this.label5.Text = "Тип аккаунта";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(118, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 52);
            this.label6.TabIndex = 33;
            // 
            // No
            // 
            this.No.AutoSize = true;
            this.No.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.No.BackColor = System.Drawing.Color.LightSalmon;
            this.No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.No.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.No.ForeColor = System.Drawing.Color.White;
            this.No.Location = new System.Drawing.Point(369, 341);
            this.No.Name = "No";
            this.No.Padding = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.No.Size = new System.Drawing.Size(284, 57);
            this.No.TabIndex = 37;
            this.No.Text = "Отменить";
            this.No.UseVisualStyleBackColor = false;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // Yes
            // 
            this.Yes.AutoSize = true;
            this.Yes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Yes.BackColor = System.Drawing.Color.SeaGreen;
            this.Yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Yes.ForeColor = System.Drawing.Color.White;
            this.Yes.Location = new System.Drawing.Point(65, 341);
            this.Yes.Name = "Yes";
            this.Yes.Padding = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.Yes.Size = new System.Drawing.Size(279, 57);
            this.Yes.TabIndex = 36;
            this.Yes.Text = "Добавить";
            this.Yes.UseVisualStyleBackColor = false;
            this.Yes.Click += new System.EventHandler(this.Yes_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(380, 264);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(274, 40);
            this.textBox2.TabIndex = 38;
            this.textBox2.Text = "Турагентство";
            this.textBox2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 403);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(727, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 403);
            this.panel2.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 447);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 2);
            this.panel3.TabIndex = 41;
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 449);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Yes);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PanelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.PanelForm.ResumeLayout(false);
            this.PanelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox0;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button No;
        public System.Windows.Forms.Button Yes;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}