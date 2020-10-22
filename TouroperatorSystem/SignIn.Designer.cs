namespace TouroperatorSystem
{
    partial class SignIn
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.label1 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SignInButton = new System.Windows.Forms.Button();
            this.PanelForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.PanelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(93, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вход в систему";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginTextBox.Location = new System.Drawing.Point(200, 145);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(274, 47);
            this.LoginTextBox.TabIndex = 1;
            this.LoginTextBox.TextChanged += new System.EventHandler(this.LoginTextBox_TextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PasswordTextBox.Location = new System.Drawing.Point(200, 220);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '•';
            this.PasswordTextBox.Size = new System.Drawing.Size(274, 47);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(80, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(54, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пароль";
            // 
            // SignInButton
            // 
            this.SignInButton.BackColor = System.Drawing.Color.LightSalmon;
            this.SignInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignInButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignInButton.ForeColor = System.Drawing.Color.White;
            this.SignInButton.Location = new System.Drawing.Point(152, 295);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(243, 56);
            this.SignInButton.TabIndex = 5;
            this.SignInButton.Text = "Войти";
            this.SignInButton.UseVisualStyleBackColor = false;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
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
            this.PanelForm.Size = new System.Drawing.Size(533, 46);
            this.PanelForm.TabIndex = 6;
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
            this.label4.Size = new System.Drawing.Size(97, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sign In";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(485, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(48, 46);
            this.Close.TabIndex = 0;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.CloseButton_Click);
            this.Close.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.Close.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(533, 392);
            this.Controls.Add(this.PanelForm);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход в систему";
            this.PanelForm.ResumeLayout(false);
            this.PanelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Panel PanelForm;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}

