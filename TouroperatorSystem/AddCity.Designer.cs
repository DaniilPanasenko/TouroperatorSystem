namespace TouroperatorSystem
{
    partial class AddCity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCity));
            this.PanelForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Yes = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.PanelForm.Location = new System.Drawing.Point(2, 0);
            this.PanelForm.Name = "PanelForm";
            this.PanelForm.Size = new System.Drawing.Size(820, 46);
            this.PanelForm.TabIndex = 62;
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
            this.label4.Size = new System.Drawing.Size(132, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = "Add City";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(772, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(48, 46);
            this.Close.TabIndex = 0;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.CloseButton_Click);
            this.Close.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.Close.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // textBox0
            // 
            this.textBox0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox0.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox0.Location = new System.Drawing.Point(280, 166);
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(355, 47);
            this.textBox0.TabIndex = 69;
            this.textBox0.TextChanged += new System.EventHandler(this.TextBox0_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 52);
            this.label3.TabIndex = 68;
            this.label3.Text = "Название";
            // 
            // Yes
            // 
            this.Yes.AutoSize = true;
            this.Yes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Yes.BackColor = System.Drawing.Color.SeaGreen;
            this.Yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Yes.ForeColor = System.Drawing.Color.White;
            this.Yes.Location = new System.Drawing.Point(117, 482);
            this.Yes.Name = "Yes";
            this.Yes.Padding = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.Yes.Size = new System.Drawing.Size(279, 57);
            this.Yes.TabIndex = 67;
            this.Yes.Text = "Добавить";
            this.Yes.UseVisualStyleBackColor = false;
            this.Yes.Click += new System.EventHandler(this.Yes_Click);
            // 
            // No
            // 
            this.No.AutoSize = true;
            this.No.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.No.BackColor = System.Drawing.Color.LightSalmon;
            this.No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.No.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.No.ForeColor = System.Drawing.Color.White;
            this.No.Location = new System.Drawing.Point(425, 482);
            this.No.Name = "No";
            this.No.Padding = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.No.Size = new System.Drawing.Size(284, 57);
            this.No.TabIndex = 66;
            this.No.Text = "Отменить";
            this.No.UseVisualStyleBackColor = false;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 583);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(820, 2);
            this.panel3.TabIndex = 65;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(822, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 585);
            this.panel2.TabIndex = 64;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 585);
            this.panel1.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.SeaGreen;
            this.label8.Location = new System.Drawing.Point(640, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 63);
            this.label8.TabIndex = 72;
            this.label8.Text = "+";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            this.label8.MouseEnter += new System.EventHandler(this.Label8_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.Label8_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(75, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 52);
            this.label5.TabIndex = 71;
            this.label5.Text = "Страна";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(280, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(352, 47);
            this.comboBox2.TabIndex = 70;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            this.comboBox2.TextUpdate += new System.EventHandler(this.ComboBox2_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(75, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 52);
            this.label1.TabIndex = 74;
            this.label1.Text = "Страна";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(280, 317);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(352, 47);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 73;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(79, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 52);
            this.label6.TabIndex = 76;
            this.label6.Text = "Города";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(280, 394);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(352, 47);
            this.comboBox3.Sorted = true;
            this.comboBox3.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(769, 52);
            this.label2.TabIndex = 77;
            this.label2.Text = "Город с ближайшим аэропортом";
            // 
            // AddCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 585);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.PanelForm);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Yes);
            this.Controls.Add(this.No);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add City";
            this.Load += new System.EventHandler(this.AddCity_Load);
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
        public System.Windows.Forms.TextBox textBox0;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button Yes;
        public System.Windows.Forms.Button No;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.Label label2;
    }
}