namespace GUI_Framework_v2
{
    partial class UppdateraKundFöretag
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
            this.btnsökfkund = new System.Windows.Forms.Button();
            this.Tbsökföretagskund = new System.Windows.Forms.TextBox();
            this.gvfkund = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbKredit = new System.Windows.Forms.Label();
            this.tbKreditgräns = new System.Windows.Forms.TextBox();
            this.btntabort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbfakturaort = new System.Windows.Forms.TextBox();
            this.tbfakturapnr = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbrabatt = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbrefperson = new System.Windows.Forms.TextBox();
            this.tbfakturaadress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbpostort = new System.Windows.Forms.TextBox();
            this.tbpostnr = new System.Windows.Forms.TextBox();
            this.tbadress = new System.Windows.Forms.TextBox();
            this.tbtelefon = new System.Windows.Forms.TextBox();
            this.btnuppdaterafkund = new System.Windows.Forms.Button();
            this.tbepost = new System.Windows.Forms.TextBox();
            this.tborgnummer = new System.Windows.Forms.TextBox();
            this.Tbfkund = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvfkund)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsökfkund
            // 
            this.btnsökfkund.Location = new System.Drawing.Point(228, 22);
            this.btnsökfkund.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnsökfkund.Name = "btnsökfkund";
            this.btnsökfkund.Size = new System.Drawing.Size(75, 31);
            this.btnsökfkund.TabIndex = 22;
            this.btnsökfkund.Text = "Sök";
            this.btnsökfkund.UseVisualStyleBackColor = true;
            this.btnsökfkund.Click += new System.EventHandler(this.btnsökfkund_Click);
            // 
            // Tbsökföretagskund
            // 
            this.Tbsökföretagskund.Location = new System.Drawing.Point(21, 23);
            this.Tbsökföretagskund.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Tbsökföretagskund.Name = "Tbsökföretagskund";
            this.Tbsökföretagskund.Size = new System.Drawing.Size(199, 26);
            this.Tbsökföretagskund.TabIndex = 21;
            this.Tbsökföretagskund.TextChanged += new System.EventHandler(this.Tbsökföretagskund_TextChanged);
            // 
            // gvfkund
            // 
            this.gvfkund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvfkund.Location = new System.Drawing.Point(21, 56);
            this.gvfkund.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gvfkund.Name = "gvfkund";
            this.gvfkund.RowHeadersWidth = 62;
            this.gvfkund.RowTemplate.Height = 28;
            this.gvfkund.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvfkund.Size = new System.Drawing.Size(282, 479);
            this.gvfkund.TabIndex = 19;
            this.gvfkund.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvfkund_CellContentClick);
            this.gvfkund.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvfkund_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbKredit);
            this.groupBox2.Controls.Add(this.tbKreditgräns);
            this.groupBox2.Controls.Add(this.btntabort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbfakturaort);
            this.groupBox2.Controls.Add(this.tbfakturapnr);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.tbrabatt);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tbrefperson);
            this.groupBox2.Controls.Add(this.tbfakturaadress);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbpostort);
            this.groupBox2.Controls.Add(this.tbpostnr);
            this.groupBox2.Controls.Add(this.tbadress);
            this.groupBox2.Controls.Add(this.tbtelefon);
            this.groupBox2.Controls.Add(this.btnuppdaterafkund);
            this.groupBox2.Controls.Add(this.tbepost);
            this.groupBox2.Controls.Add(this.tborgnummer);
            this.groupBox2.Controls.Add(this.Tbfkund);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(309, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupBox2.Size = new System.Drawing.Size(356, 491);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uppdatera företagskund";
            // 
            // lbKredit
            // 
            this.lbKredit.AutoSize = true;
            this.lbKredit.Location = new System.Drawing.Point(6, 323);
            this.lbKredit.Name = "lbKredit";
            this.lbKredit.Size = new System.Drawing.Size(90, 20);
            this.lbKredit.TabIndex = 33;
            this.lbKredit.Text = "Kreditgräns";
            // 
            // tbKreditgräns
            // 
            this.tbKreditgräns.Location = new System.Drawing.Point(129, 320);
            this.tbKreditgräns.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbKreditgräns.Name = "tbKreditgräns";
            this.tbKreditgräns.Size = new System.Drawing.Size(199, 26);
            this.tbKreditgräns.TabIndex = 30;
            this.tbKreditgräns.TextChanged += new System.EventHandler(this.tbKreditgräns_TextChanged);
            // 
            // btntabort
            // 
            this.btntabort.Location = new System.Drawing.Point(231, 437);
            this.btntabort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntabort.Name = "btntabort";
            this.btntabort.Size = new System.Drawing.Size(97, 38);
            this.btntabort.TabIndex = 32;
            this.btntabort.Text = "Ta bort";
            this.btntabort.UseVisualStyleBackColor = true;
            this.btntabort.Click += new System.EventHandler(this.btntabort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Faktura Ort";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Faktura Postnummer";
            // 
            // tbfakturaort
            // 
            this.tbfakturaort.Location = new System.Drawing.Point(129, 387);
            this.tbfakturaort.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbfakturaort.Name = "tbfakturaort";
            this.tbfakturaort.Size = new System.Drawing.Size(199, 26);
            this.tbfakturaort.TabIndex = 29;
            this.tbfakturaort.TextChanged += new System.EventHandler(this.tbfakturaort_TextChanged);
            // 
            // tbfakturapnr
            // 
            this.tbfakturapnr.Location = new System.Drawing.Point(186, 348);
            this.tbfakturapnr.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbfakturapnr.Name = "tbfakturapnr";
            this.tbfakturapnr.Size = new System.Drawing.Size(142, 26);
            this.tbfakturapnr.TabIndex = 28;
            this.tbfakturapnr.TextChanged += new System.EventHandler(this.tbfakturapnr_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 279);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 20);
            this.label20.TabIndex = 27;
            this.label20.Text = "Rabatt";
            // 
            // tbrabatt
            // 
            this.tbrabatt.Location = new System.Drawing.Point(129, 279);
            this.tbrabatt.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbrabatt.Name = "tbrabatt";
            this.tbrabatt.Size = new System.Drawing.Size(199, 26);
            this.tbrabatt.TabIndex = 26;
            this.tbrabatt.TextChanged += new System.EventHandler(this.tbrabatt_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 249);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 20);
            this.label19.TabIndex = 25;
            this.label19.Text = "Ref. Person";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 221);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 20);
            this.label18.TabIndex = 24;
            this.label18.Text = "Fakturaadress";
            // 
            // tbrefperson
            // 
            this.tbrefperson.Location = new System.Drawing.Point(129, 249);
            this.tbrefperson.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbrefperson.Name = "tbrefperson";
            this.tbrefperson.Size = new System.Drawing.Size(199, 26);
            this.tbrefperson.TabIndex = 22;
            this.tbrefperson.TextChanged += new System.EventHandler(this.tbrefperson_TextChanged);
            // 
            // tbfakturaadress
            // 
            this.tbfakturaadress.Location = new System.Drawing.Point(129, 221);
            this.tbfakturaadress.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbfakturaadress.Name = "tbfakturaadress";
            this.tbfakturaadress.Size = new System.Drawing.Size(199, 26);
            this.tbfakturaadress.TabIndex = 21;
            this.tbfakturaadress.TextChanged += new System.EventHandler(this.tbfakturaadress_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Postort";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "Post nr.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "Adress";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Telefon";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "E-post";
            // 
            // tbpostort
            // 
            this.tbpostort.Location = new System.Drawing.Point(129, 199);
            this.tbpostort.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpostort.Name = "tbpostort";
            this.tbpostort.Size = new System.Drawing.Size(199, 26);
            this.tbpostort.TabIndex = 15;
            this.tbpostort.TextChanged += new System.EventHandler(this.tbpostort_TextChanged);
            // 
            // tbpostnr
            // 
            this.tbpostnr.Location = new System.Drawing.Point(129, 169);
            this.tbpostnr.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbpostnr.Name = "tbpostnr";
            this.tbpostnr.Size = new System.Drawing.Size(199, 26);
            this.tbpostnr.TabIndex = 14;
            this.tbpostnr.TextChanged += new System.EventHandler(this.tbpostnr_TextChanged);
            // 
            // tbadress
            // 
            this.tbadress.Location = new System.Drawing.Point(129, 145);
            this.tbadress.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbadress.Name = "tbadress";
            this.tbadress.Size = new System.Drawing.Size(199, 26);
            this.tbadress.TabIndex = 13;
            this.tbadress.TextChanged += new System.EventHandler(this.tbadress_TextChanged);
            // 
            // tbtelefon
            // 
            this.tbtelefon.Location = new System.Drawing.Point(129, 119);
            this.tbtelefon.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbtelefon.Name = "tbtelefon";
            this.tbtelefon.Size = new System.Drawing.Size(199, 26);
            this.tbtelefon.TabIndex = 12;
            this.tbtelefon.TextChanged += new System.EventHandler(this.tbtelefon_TextChanged);
            // 
            // btnuppdaterafkund
            // 
            this.btnuppdaterafkund.Location = new System.Drawing.Point(115, 437);
            this.btnuppdaterafkund.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnuppdaterafkund.Name = "btnuppdaterafkund";
            this.btnuppdaterafkund.Size = new System.Drawing.Size(109, 39);
            this.btnuppdaterafkund.TabIndex = 11;
            this.btnuppdaterafkund.Text = "Uppdatera";
            this.btnuppdaterafkund.UseVisualStyleBackColor = true;
            this.btnuppdaterafkund.Click += new System.EventHandler(this.btnuppdaterafkund_Click);
            // 
            // tbepost
            // 
            this.tbepost.Location = new System.Drawing.Point(129, 91);
            this.tbepost.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbepost.Name = "tbepost";
            this.tbepost.Size = new System.Drawing.Size(199, 26);
            this.tbepost.TabIndex = 4;
            this.tbepost.TextChanged += new System.EventHandler(this.tbepost_TextChanged);
            // 
            // tborgnummer
            // 
            this.tborgnummer.Location = new System.Drawing.Point(129, 66);
            this.tborgnummer.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tborgnummer.Name = "tborgnummer";
            this.tborgnummer.Size = new System.Drawing.Size(199, 26);
            this.tborgnummer.TabIndex = 3;
            this.tborgnummer.TextChanged += new System.EventHandler(this.tborgnummer_TextChanged);
            // 
            // Tbfkund
            // 
            this.Tbfkund.Location = new System.Drawing.Point(129, 40);
            this.Tbfkund.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Tbfkund.Name = "Tbfkund";
            this.Tbfkund.Size = new System.Drawing.Size(199, 26);
            this.Tbfkund.TabIndex = 1;
            this.Tbfkund.TextChanged += new System.EventHandler(this.Tbfkund_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Namn";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "Org. nummer";
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(21, 537);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(109, 39);
            this.btntillbaka.TabIndex = 27;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 40);
            this.label3.TabIndex = 29;
            this.label3.Text = "Ski-Center";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.Tbsökföretagskund);
            this.groupBox1.Controls.Add(this.gvfkund);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Controls.Add(this.btnsökfkund);
            this.groupBox1.Location = new System.Drawing.Point(19, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 598);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Företagskund";
            // 
            // UppdateraKundFöretag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 670);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UppdateraKundFöretag";
            this.Text = "UppdateraKundFöretag";
            this.Load += new System.EventHandler(this.UppdateraKundFöretag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvfkund)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsökfkund;
        private System.Windows.Forms.TextBox Tbsökföretagskund;
        private System.Windows.Forms.DataGridView gvfkund;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbrabatt;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbrefperson;
        private System.Windows.Forms.TextBox tbfakturaadress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbpostort;
        private System.Windows.Forms.TextBox tbpostnr;
        private System.Windows.Forms.TextBox tbadress;
        private System.Windows.Forms.TextBox tbtelefon;
        private System.Windows.Forms.Button btnuppdaterafkund;
        private System.Windows.Forms.TextBox tbepost;
        private System.Windows.Forms.TextBox tborgnummer;
        private System.Windows.Forms.TextBox Tbfkund;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbfakturaort;
        private System.Windows.Forms.TextBox tbfakturapnr;
        private System.Windows.Forms.Button btntabort;
        private System.Windows.Forms.Label lbKredit;
        private System.Windows.Forms.TextBox tbKreditgräns;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}