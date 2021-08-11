namespace GUI_Framework_v2
{
    partial class ButikSkidskolaPrivat
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbsökregistreradebokningar = new System.Windows.Forms.TextBox();
            this.btnsök = new System.Windows.Forms.Button();
            this.gvSökDelatager = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDag = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnregistrera = new System.Windows.Forms.Button();
            this.btntabortdeltagare = new System.Windows.Forms.Button();
            this.gvPrivatSkidlektion = new System.Windows.Forms.DataGridView();
            this.btnläggtillkund = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPris = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbFaktura = new System.Windows.Forms.CheckBox();
            this.cbKontant = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbFörnamn = new System.Windows.Forms.TextBox();
            this.btnLäggTillEjBokadDeltagare = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEfternamn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvSökDelatager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivatSkidlektion)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sök på kunder (efternamn)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbsökregistreradebokningar
            // 
            this.tbsökregistreradebokningar.Location = new System.Drawing.Point(22, 34);
            this.tbsökregistreradebokningar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbsökregistreradebokningar.Name = "tbsökregistreradebokningar";
            this.tbsökregistreradebokningar.Size = new System.Drawing.Size(279, 22);
            this.tbsökregistreradebokningar.TabIndex = 1;
            this.tbsökregistreradebokningar.TextChanged += new System.EventHandler(this.tbsökregistreradebokningar_TextChanged);
            // 
            // btnsök
            // 
            this.btnsök.Location = new System.Drawing.Point(307, 31);
            this.btnsök.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsök.Name = "btnsök";
            this.btnsök.Size = new System.Drawing.Size(87, 28);
            this.btnsök.TabIndex = 2;
            this.btnsök.Text = "Sök";
            this.btnsök.UseVisualStyleBackColor = true;
            this.btnsök.Click += new System.EventHandler(this.btnsök_Click);
            // 
            // gvSökDelatager
            // 
            this.gvSökDelatager.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gvSökDelatager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSökDelatager.Location = new System.Drawing.Point(22, 64);
            this.gvSökDelatager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvSökDelatager.Name = "gvSökDelatager";
            this.gvSökDelatager.ReadOnly = true;
            this.gvSökDelatager.RowHeadersWidth = 62;
            this.gvSökDelatager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSökDelatager.Size = new System.Drawing.Size(523, 129);
            this.gvSökDelatager.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Välj Dag och Tid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dag";
            // 
            // cbDag
            // 
            this.cbDag.FormattingEnabled = true;
            this.cbDag.Location = new System.Drawing.Point(15, 65);
            this.cbDag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDag.Name = "cbDag";
            this.cbDag.Size = new System.Drawing.Size(81, 24);
            this.cbDag.TabIndex = 6;
            this.cbDag.SelectedIndexChanged += new System.EventHandler(this.cbDag_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tid";
            // 
            // cbTid
            // 
            this.cbTid.FormattingEnabled = true;
            this.cbTid.Location = new System.Drawing.Point(121, 65);
            this.cbTid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTid.Name = "cbTid";
            this.cbTid.Size = new System.Drawing.Size(81, 24);
            this.cbTid.TabIndex = 8;
            this.cbTid.SelectedIndexChanged += new System.EventHandler(this.cbTid_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Deltagare";
            // 
            // btnregistrera
            // 
            this.btnregistrera.BackColor = System.Drawing.Color.PaleGreen;
            this.btnregistrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistrera.Location = new System.Drawing.Point(723, 624);
            this.btnregistrera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnregistrera.Name = "btnregistrera";
            this.btnregistrera.Size = new System.Drawing.Size(161, 51);
            this.btnregistrera.TabIndex = 11;
            this.btnregistrera.Text = "Registrera ";
            this.btnregistrera.UseVisualStyleBackColor = false;
            this.btnregistrera.Click += new System.EventHandler(this.btnregistrera_Click);
            // 
            // btntabortdeltagare
            // 
            this.btntabortdeltagare.BackColor = System.Drawing.Color.Tomato;
            this.btntabortdeltagare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntabortdeltagare.Location = new System.Drawing.Point(716, 24);
            this.btntabortdeltagare.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntabortdeltagare.Name = "btntabortdeltagare";
            this.btntabortdeltagare.Size = new System.Drawing.Size(145, 26);
            this.btntabortdeltagare.TabIndex = 12;
            this.btntabortdeltagare.Text = "Ta bort deltagare";
            this.btntabortdeltagare.UseVisualStyleBackColor = false;
            this.btntabortdeltagare.Click += new System.EventHandler(this.btntabortdeltagare_Click);
            // 
            // gvPrivatSkidlektion
            // 
            this.gvPrivatSkidlektion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrivatSkidlektion.Location = new System.Drawing.Point(22, 55);
            this.gvPrivatSkidlektion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvPrivatSkidlektion.Name = "gvPrivatSkidlektion";
            this.gvPrivatSkidlektion.ReadOnly = true;
            this.gvPrivatSkidlektion.RowHeadersWidth = 62;
            this.gvPrivatSkidlektion.Size = new System.Drawing.Size(838, 185);
            this.gvPrivatSkidlektion.TabIndex = 13;
            // 
            // btnläggtillkund
            // 
            this.btnläggtillkund.Location = new System.Drawing.Point(400, 201);
            this.btnläggtillkund.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnläggtillkund.Name = "btnläggtillkund";
            this.btnläggtillkund.Size = new System.Drawing.Size(145, 26);
            this.btnläggtillkund.TabIndex = 14;
            this.btnläggtillkund.Text = "Lägg till deltagare";
            this.btnläggtillkund.UseVisualStyleBackColor = true;
            this.btnläggtillkund.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(855, 60);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 21);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Faktura ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(855, 89);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(83, 21);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Kontant ";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Betalsätt";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btntillbaka);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnregistrera);
            this.panel1.Location = new System.Drawing.Point(5, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 700);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(20, 656);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(99, 44);
            this.btntillbaka.TabIndex = 20;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.tbPris);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Location = new System.Drawing.Point(462, 538);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(185, 109);
            this.panel7.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "SEK";
            // 
            // tbPris
            // 
            this.tbPris.Location = new System.Drawing.Point(54, 51);
            this.tbPris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPris.Name = "tbPris";
            this.tbPris.Size = new System.Drawing.Size(103, 22);
            this.tbPris.TabIndex = 18;
            this.tbPris.TextChanged += new System.EventHandler(this.tbPris_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Totalpris";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.gvPrivatSkidlektion);
            this.panel6.Controls.Add(this.btntabortdeltagare);
            this.panel6.Location = new System.Drawing.Point(23, 276);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(889, 258);
            this.panel6.TabIndex = 31;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel5.Controls.Add(this.gvSökDelatager);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.tbsökregistreradebokningar);
            this.panel5.Controls.Add(this.btnsök);
            this.panel5.Controls.Add(this.btnläggtillkund);
            this.panel5.Location = new System.Drawing.Point(23, 30);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 232);
            this.panel5.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.cbFaktura);
            this.panel4.Controls.Add(this.cbKontant);
            this.panel4.Location = new System.Drawing.Point(254, 538);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(202, 109);
            this.panel4.TabIndex = 29;
            // 
            // cbFaktura
            // 
            this.cbFaktura.AutoSize = true;
            this.cbFaktura.Location = new System.Drawing.Point(12, 45);
            this.cbFaktura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFaktura.Name = "cbFaktura";
            this.cbFaktura.Size = new System.Drawing.Size(82, 21);
            this.cbFaktura.TabIndex = 18;
            this.cbFaktura.Text = "Faktura ";
            this.cbFaktura.UseVisualStyleBackColor = true;
            this.cbFaktura.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // cbKontant
            // 
            this.cbKontant.AutoSize = true;
            this.cbKontant.Location = new System.Drawing.Point(117, 45);
            this.cbKontant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbKontant.Name = "cbKontant";
            this.cbKontant.Size = new System.Drawing.Size(83, 21);
            this.cbKontant.TabIndex = 19;
            this.cbKontant.Text = "Kontant ";
            this.cbKontant.UseVisualStyleBackColor = true;
            this.cbKontant.CheckedChanged += new System.EventHandler(this.cbKontant_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbDag);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbTid);
            this.panel3.Location = new System.Drawing.Point(23, 538);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 109);
            this.panel3.TabIndex = 28;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.tbFörnamn);
            this.panel2.Controls.Add(this.btnLäggTillEjBokadDeltagare);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbEfternamn);
            this.panel2.Location = new System.Drawing.Point(608, 80);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 138);
            this.panel2.TabIndex = 28;
            // 
            // tbFörnamn
            // 
            this.tbFörnamn.Location = new System.Drawing.Point(98, 41);
            this.tbFörnamn.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbFörnamn.Name = "tbFörnamn";
            this.tbFörnamn.Size = new System.Drawing.Size(145, 22);
            this.tbFörnamn.TabIndex = 23;
            this.tbFörnamn.TextChanged += new System.EventHandler(this.tbFörnamn_TextChanged);
            // 
            // btnLäggTillEjBokadDeltagare
            // 
            this.btnLäggTillEjBokadDeltagare.Location = new System.Drawing.Point(98, 105);
            this.btnLäggTillEjBokadDeltagare.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLäggTillEjBokadDeltagare.Name = "btnLäggTillEjBokadDeltagare";
            this.btnLäggTillEjBokadDeltagare.Size = new System.Drawing.Size(145, 26);
            this.btnLäggTillEjBokadDeltagare.TabIndex = 27;
            this.btnLäggTillEjBokadDeltagare.Text = "Lägg till";
            this.btnLäggTillEjBokadDeltagare.UseVisualStyleBackColor = true;
            this.btnLäggTillEjBokadDeltagare.Click += new System.EventHandler(this.btnLäggTillEjBokadDeltagare_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Lägg till icke registrerad deltagare";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Efternamn:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Förnamn:";
            // 
            // tbEfternamn
            // 
            this.tbEfternamn.Location = new System.Drawing.Point(98, 78);
            this.tbEfternamn.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbEfternamn.Name = "tbEfternamn";
            this.tbEfternamn.Size = new System.Drawing.Size(145, 22);
            this.tbEfternamn.TabIndex = 25;
            this.tbEfternamn.TextChanged += new System.EventHandler(this.tbEfternamn_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, -1);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 29);
            this.label12.TabIndex = 33;
            this.label12.Text = "Ski-Center";
            // 
            // ButikSkidskolaPrivat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ButikSkidskolaPrivat";
            this.Text = "ButikSkidskolaPrivat";
            this.Load += new System.EventHandler(this.ButikSkidskolaPrivat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSökDelatager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivatSkidlektion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbsökregistreradebokningar;
        private System.Windows.Forms.Button btnsök;
        private System.Windows.Forms.DataGridView gvSökDelatager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnregistrera;
        private System.Windows.Forms.Button btntabortdeltagare;
        private System.Windows.Forms.DataGridView gvPrivatSkidlektion;
        private System.Windows.Forms.Button btnläggtillkund;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbFaktura;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.CheckBox cbKontant;
        private System.Windows.Forms.Button btnLäggTillEjBokadDeltagare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbEfternamn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFörnamn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbPris;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}