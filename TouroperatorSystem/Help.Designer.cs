namespace TouroperatorSystem
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Login - PK");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Password");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("IsAdmin");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Account", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Login - PK, FK Account");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Director");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("DateLicense");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Comission");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Agency", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Code - PK");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("IdCountry - FK Country");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Airline", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Code - PK");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("IdCity - FK City");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Airport", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("ID - PK");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("IdCountry - FK Country");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("IdCityWithNearestAirport");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("City", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("ID - PK");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Country", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("ID - PK");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("NumRoute - FK Route");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("DateTime");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("FreePlaces");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Flight", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("ID - PK");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("IdCity - FK City");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Stars");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Food");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Hotel", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Passport - PK");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("AbroadPassport");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("INN");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Name");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Surname");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("IdNational - FK Country");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Sex");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Birthday");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("People", new System.Windows.Forms.TreeNode[] {
            treeNode38,
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45});
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("ID - PK");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("TypeRoom");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("IdHotel - FK Hotel");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("NumPerson");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Price");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Room", new System.Windows.Forms.TreeNode[] {
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51});
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("RouteNum - PK");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("CodeAirline - FK Airline");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("CodeAirportDeparture - FK Airport");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("CodeAirportArrive - FK Airport");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Plane");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("NumPlace");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Price");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("TimeFlight");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("TimeDeparture");
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("Days");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("Route", new System.Windows.Forms.TreeNode[] {
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56,
            treeNode57,
            treeNode58,
            treeNode59,
            treeNode60,
            treeNode61,
            treeNode62});
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("ID - PK");
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("NumNight");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("IdTypeRoom - FK Room");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("Login - FK Agency");
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("CodeAirport - FK Airport");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("Status");
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("DateHotel");
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("Voucher", new System.Windows.Forms.TreeNode[] {
            treeNode64,
            treeNode65,
            treeNode66,
            treeNode67,
            treeNode68,
            treeNode69,
            treeNode70});
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("IdVoucher - PK, FK Voucher");
            System.Windows.Forms.TreeNode treeNode73 = new System.Windows.Forms.TreeNode("IdFlight - PK, FK Flight");
            System.Windows.Forms.TreeNode treeNode74 = new System.Windows.Forms.TreeNode("VoucherFlight", new System.Windows.Forms.TreeNode[] {
            treeNode72,
            treeNode73});
            System.Windows.Forms.TreeNode treeNode75 = new System.Windows.Forms.TreeNode("IdVoucher - PK, FK Voucher");
            System.Windows.Forms.TreeNode treeNode76 = new System.Windows.Forms.TreeNode("IdPeople - PK, FK People");
            System.Windows.Forms.TreeNode treeNode77 = new System.Windows.Forms.TreeNode("VoucherPeople", new System.Windows.Forms.TreeNode[] {
            treeNode75,
            treeNode76});
            System.Windows.Forms.TreeNode treeNode78 = new System.Windows.Forms.TreeNode("Schema", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode10,
            treeNode14,
            treeNode18,
            treeNode23,
            treeNode26,
            treeNode31,
            treeNode37,
            treeNode46,
            treeNode52,
            treeNode63,
            treeNode71,
            treeNode74,
            treeNode77});
            this.PanelForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.No = new System.Windows.Forms.Button();
            this.PanelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
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
            this.PanelForm.Size = new System.Drawing.Size(521, 46);
            this.PanelForm.TabIndex = 9;
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
            this.label4.Size = new System.Drawing.Size(75, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = "Help";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(473, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(48, 46);
            this.Close.TabIndex = 0;
            this.Close.Text = "X";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.CloseButton_Click);
            this.Close.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.Close.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 311);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(519, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 311);
            this.panel2.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 355);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 2);
            this.panel3.TabIndex = 35;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.Location = new System.Drawing.Point(32, 77);
            this.treeView1.Name = "treeView1";
            treeNode1.ForeColor = System.Drawing.Color.Black;
            treeNode1.Name = "Узел3";
            treeNode1.Text = "Login - PK";
            treeNode2.Name = "Узел4";
            treeNode2.Text = "Password";
            treeNode3.Name = "Узел5";
            treeNode3.Text = "IsAdmin";
            treeNode4.Name = "Узел1";
            treeNode4.Text = "Account";
            treeNode5.Name = "Узел6";
            treeNode5.Text = "Login - PK, FK Account";
            treeNode6.Name = "Узел7";
            treeNode6.Text = "Name";
            treeNode7.Name = "Узел8";
            treeNode7.Text = "Director";
            treeNode8.Name = "Узел9";
            treeNode8.Text = "DateLicense";
            treeNode9.Name = "Узел10";
            treeNode9.Text = "Comission";
            treeNode10.Name = "Узел2";
            treeNode10.Text = "Agency";
            treeNode11.Name = "Узел11";
            treeNode11.Text = "Name";
            treeNode12.Name = "Узел12";
            treeNode12.Text = "Code - PK";
            treeNode13.Name = "Узел13";
            treeNode13.Text = "IdCountry - FK Country";
            treeNode14.Name = "Узел0";
            treeNode14.Text = "Airline";
            treeNode15.Name = "Узел14";
            treeNode15.Text = "Code - PK";
            treeNode16.Name = "Узел15";
            treeNode16.Text = "IdCity - FK City";
            treeNode17.Name = "Узел16";
            treeNode17.Text = "Name";
            treeNode18.Name = "Узел1";
            treeNode18.Text = "Airport";
            treeNode19.Name = "Узел17";
            treeNode19.Text = "ID - PK";
            treeNode20.Name = "Узел18";
            treeNode20.Text = "IdCountry - FK Country";
            treeNode21.Name = "Узел19";
            treeNode21.Text = "Name";
            treeNode22.Name = "Узел20";
            treeNode22.Text = "IdCityWithNearestAirport";
            treeNode23.Name = "Узел2";
            treeNode23.Text = "City";
            treeNode24.Name = "Узел21";
            treeNode24.Text = "ID - PK";
            treeNode25.Name = "Узел22";
            treeNode25.Text = "Name";
            treeNode26.Name = "Узел3";
            treeNode26.Text = "Country";
            treeNode27.Name = "Узел23";
            treeNode27.Text = "ID - PK";
            treeNode28.Name = "Узел24";
            treeNode28.Text = "NumRoute - FK Route";
            treeNode29.Name = "Узел25";
            treeNode29.Text = "DateTime";
            treeNode30.Name = "Узел26";
            treeNode30.Text = "FreePlaces";
            treeNode31.Name = "Узел4";
            treeNode31.Text = "Flight";
            treeNode32.Name = "Узел27";
            treeNode32.Text = "ID - PK";
            treeNode33.Name = "Узел28";
            treeNode33.Text = "IdCity - FK City";
            treeNode34.Name = "Узел29";
            treeNode34.Text = "Stars";
            treeNode35.Name = "Узел30";
            treeNode35.Text = "Food";
            treeNode36.Name = "Узел31";
            treeNode36.Text = "Name";
            treeNode37.Name = "Узел5";
            treeNode37.Text = "Hotel";
            treeNode38.Name = "Узел32";
            treeNode38.Text = "Passport - PK";
            treeNode39.Name = "Узел33";
            treeNode39.Text = "AbroadPassport";
            treeNode40.Name = "Узел34";
            treeNode40.Text = "INN";
            treeNode41.Name = "Узел35";
            treeNode41.Text = "Name";
            treeNode42.Name = "Узел36";
            treeNode42.Text = "Surname";
            treeNode43.Name = "Узел37";
            treeNode43.Text = "IdNational - FK Country";
            treeNode44.Name = "Узел38";
            treeNode44.Text = "Sex";
            treeNode45.Name = "Узел39";
            treeNode45.Text = "Birthday";
            treeNode46.Name = "Узел6";
            treeNode46.Text = "People";
            treeNode47.Name = "Узел40";
            treeNode47.Text = "ID - PK";
            treeNode48.Name = "Узел41";
            treeNode48.Text = "TypeRoom";
            treeNode49.Name = "Узел42";
            treeNode49.Text = "IdHotel - FK Hotel";
            treeNode50.Name = "Узел43";
            treeNode50.Text = "NumPerson";
            treeNode51.Name = "Узел44";
            treeNode51.Text = "Price";
            treeNode52.Name = "Узел7";
            treeNode52.Text = "Room";
            treeNode53.Name = "Узел45";
            treeNode53.Text = "RouteNum - PK";
            treeNode54.Name = "Узел46";
            treeNode54.Text = "CodeAirline - FK Airline";
            treeNode55.Name = "Узел47";
            treeNode55.Text = "CodeAirportDeparture - FK Airport";
            treeNode56.Name = "Узел48";
            treeNode56.Text = "CodeAirportArrive - FK Airport";
            treeNode57.Name = "Узел49";
            treeNode57.Text = "Plane";
            treeNode58.Name = "Узел50";
            treeNode58.Text = "NumPlace";
            treeNode59.Name = "Узел51";
            treeNode59.Text = "Price";
            treeNode60.Name = "Узел52";
            treeNode60.Text = "TimeFlight";
            treeNode61.Name = "Узел53";
            treeNode61.Text = "TimeDeparture";
            treeNode62.Name = "Узел54";
            treeNode62.Text = "Days";
            treeNode63.Name = "Узел8";
            treeNode63.Text = "Route";
            treeNode64.Name = "Узел55";
            treeNode64.Text = "ID - PK";
            treeNode65.Name = "Узел56";
            treeNode65.Text = "NumNight";
            treeNode66.Name = "Узел57";
            treeNode66.Text = "IdTypeRoom - FK Room";
            treeNode67.Name = "Узел58";
            treeNode67.Text = "Login - FK Agency";
            treeNode68.Name = "Узел59";
            treeNode68.Text = "CodeAirport - FK Airport";
            treeNode69.Name = "Узел60";
            treeNode69.Text = "Status";
            treeNode70.Name = "Узел61";
            treeNode70.Text = "DateHotel";
            treeNode71.Name = "Узел11";
            treeNode71.Text = "Voucher";
            treeNode72.Name = "Узел62";
            treeNode72.Text = "IdVoucher - PK, FK Voucher";
            treeNode73.Name = "Узел63";
            treeNode73.Text = "IdFlight - PK, FK Flight";
            treeNode74.Name = "Узел9";
            treeNode74.Text = "VoucherFlight";
            treeNode75.Name = "Узел64";
            treeNode75.Text = "IdVoucher - PK, FK Voucher";
            treeNode76.Name = "Узел65";
            treeNode76.Text = "IdPeople - PK, FK People";
            treeNode77.Name = "Узел10";
            treeNode77.Text = "VoucherPeople";
            treeNode78.Name = "Узел0";
            treeNode78.Text = "Schema";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode78});
            this.treeView1.Size = new System.Drawing.Size(454, 37);
            this.treeView1.TabIndex = 36;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 33);
            this.label1.TabIndex = 37;
            this.label1.Text = "PK - Primary Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 33);
            this.label2.TabIndex = 38;
            this.label2.Text = "FK [Table]- Foreign Key to [Table]";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(28, 137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(463, 105);
            this.panel4.TabIndex = 39;
            // 
            // No
            // 
            this.No.AutoSize = true;
            this.No.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.No.BackColor = System.Drawing.Color.CornflowerBlue;
            this.No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.No.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.No.ForeColor = System.Drawing.Color.White;
            this.No.Location = new System.Drawing.Point(165, 267);
            this.No.Name = "No";
            this.No.Padding = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.No.Size = new System.Drawing.Size(176, 57);
            this.No.TabIndex = 40;
            this.No.Text = "ОК";
            this.No.UseVisualStyleBackColor = false;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 357);
            this.Controls.Add(this.No);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.PanelForm.ResumeLayout(false);
            this.PanelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button No;
    }
}