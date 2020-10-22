namespace TouroperatorSystem
{
    partial class AddTouragency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTouragency));
            this.PanelForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.Yes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
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
            this.PanelForm.Size = new System.Drawing.Size(800, 46);
            this.PanelForm.TabIndex = 7;
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
            this.label4.Size = new System.Drawing.Size(234, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = "Add Touragency";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(752, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(48, 46);
            this.Close.TabIndex = 0;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.CloseButton_Click);
            this.Close.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.Close.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // No
            // 
            this.No.AutoSize = true;
            this.No.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.No.BackColor = System.Drawing.Color.LightSalmon;
            this.No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.No.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.No.ForeColor = System.Drawing.Color.White;
            this.No.Location = new System.Drawing.Point(414, 509);
            this.No.Name = "No";
            this.No.Padding = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.No.Size = new System.Drawing.Size(284, 57);
            this.No.TabIndex = 12;
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
            this.Yes.Location = new System.Drawing.Point(110, 509);
            this.Yes.Name = "Yes";
            this.Yes.Padding = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.Yes.Size = new System.Drawing.Size(279, 57);
            this.Yes.TabIndex = 11;
            this.Yes.Text = "Добавить";
            this.Yes.UseVisualStyleBackColor = false;
            this.Yes.Click += new System.EventHandler(this.Yes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(253, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 52);
            this.label1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(240, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 52);
            this.label2.TabIndex = 14;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(161, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 52);
            this.label3.TabIndex = 15;
            this.label3.Text = "Название";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(156, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 52);
            this.label5.TabIndex = 16;
            this.label5.Text = "Директор";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(46, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(343, 52);
            this.label6.TabIndex = 17;
            this.label6.Text = "Дата лицензии";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(148, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 52);
            this.label7.TabIndex = 18;
            this.label7.Text = "Комиссия";
            // 
            // textBox0
            // 
            this.textBox0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox0.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox0.Location = new System.Drawing.Point(414, 96);
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(274, 47);
            this.textBox0.TabIndex = 19;
            this.textBox0.TextChanged += new System.EventHandler(this.TextBox0_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(414, 256);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 47);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(414, 418);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(274, 40);
            this.textBox3.TabIndex = 22;
            this.textBox3.Text = "10";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(414, 180);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(274, 47);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.SeaGreen;
            this.label8.Location = new System.Drawing.Point(694, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 63);
            this.label8.TabIndex = 24;
            this.label8.Text = "+";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            this.label8.MouseEnter += new System.EventHandler(this.Label8_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.Label8_MouseLeave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(414, 334);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(274, 47);
            this.dateTimePicker1.TabIndex = 25;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Crimson;
            this.label9.Location = new System.Drawing.Point(155, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(533, 25);
            this.label9.TabIndex = 26;
            this.label9.Text = "Название должно состоять из 8 и больше символов";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(507, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 25);
            this.label10.TabIndex = 27;
            this.label10.Text = "Не выбран логин";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(92, 304);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(596, 25);
            this.label11.TabIndex = 28;
            this.label11.Text = "ФИО директора должно состоять из 8 и больше символов";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Crimson;
            this.label12.Location = new System.Drawing.Point(146, 383);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(542, 25);
            this.label12.TabIndex = 29;
            this.label12.Text = "Дата получение лицензии не может быть в будущем";
            this.label12.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(414, 183);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(274, 40);
            this.textBox2.TabIndex = 30;
            this.textBox2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 573);
            this.panel1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(798, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 573);
            this.panel2.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 617);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 2);
            this.panel3.TabIndex = 33;
            // 
            // AddTouragency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 619);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Yes);
            this.Controls.Add(this.PanelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTouragency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTouragency";
            this.Load += new System.EventHandler(this.AddTouragency_Load);
            this.PanelForm.ResumeLayout(false);
            this.PanelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Close;
        public System.Windows.Forms.Button No;
        public System.Windows.Forms.Button Yes;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBox0;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}