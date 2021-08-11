namespace GUI_Framework_v2
{
    partial class UppdateraKundPrivat
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnsökpkund = new System.Windows.Forms.Button();
            this.Tbsökkund = new System.Windows.Forms.TextBox();
            this.gvpkund = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btntabort = new System.Windows.Forms.Button();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnuppdatera = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbpostort = new System.Windows.Forms.TextBox();
            this.tbpostadress = new System.Windows.Forms.TextBox();
            this.tbadress = new System.Windows.Forms.TextBox();
            this.tbtelefon = new System.Windows.Forms.TextBox();
            this.tbepost = new System.Windows.Forms.TextBox();
            this.tbefternamn = new System.Windows.Forms.TextBox();
            this.tbkund = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvpkund)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 40);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ski-Center";
            // 
            // btnsökpkund
            // 
            this.btnsökpkund.Location = new System.Drawing.Point(208, 19);
            this.btnsökpkund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsökpkund.Name = "btnsökpkund";
            this.btnsökpkund.Size = new System.Drawing.Size(80, 34);
            this.btnsökpkund.TabIndex = 31;
            this.btnsökpkund.Text = "Sök";
            this.btnsökpkund.UseVisualStyleBackColor = true;
            this.btnsökpkund.Click += new System.EventHandler(this.btnsökpkund_Click);
            // 
            // Tbsökkund
            // 
            this.Tbsökkund.Location = new System.Drawing.Point(4, 21);
            this.Tbsökkund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tbsökkund.Name = "Tbsökkund";
            this.Tbsökkund.Size = new System.Drawing.Size(199, 26);
            this.Tbsökkund.TabIndex = 30;
            this.Tbsökkund.TextChanged += new System.EventHandler(this.Tbsökkund_TextChanged);
            // 
            // gvpkund
            // 
            this.gvpkund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvpkund.Location = new System.Drawing.Point(6, 53);
            this.gvpkund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvpkund.Name = "gvpkund";
            this.gvpkund.RowHeadersWidth = 62;
            this.gvpkund.RowTemplate.Height = 28;
            this.gvpkund.Size = new System.Drawing.Size(282, 425);
            this.gvpkund.TabIndex = 29;
            this.gvpkund.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvpkund_CellContentClick);
            this.gvpkund.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvpkund_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btntabort);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnuppdatera);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbpostort);
            this.groupBox1.Controls.Add(this.tbpostadress);
            this.groupBox1.Controls.Add(this.tbadress);
            this.groupBox1.Controls.Add(this.tbtelefon);
            this.groupBox1.Controls.Add(this.tbepost);
            this.groupBox1.Controls.Add(this.tbefternamn);
            this.groupBox1.Controls.Add(this.tbkund);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(294, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(336, 425);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uppdatera privat kund";
            // 
            // btntabort
            // 
            this.btntabort.Location = new System.Drawing.Point(214, 245);
            this.btntabort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntabort.Name = "btntabort";
            this.btntabort.Size = new System.Drawing.Size(94, 38);
            this.btntabort.TabIndex = 34;
            this.btntabort.Text = "Ta bort";
            this.btntabort.UseVisualStyleBackColor = true;
            this.btntabort.Click += new System.EventHandler(this.btntabort_Click);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(6, 482);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(110, 38);
            this.btntillbaka.TabIndex = 33;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Postort";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Post nr.";
            // 
            // btnuppdatera
            // 
            this.btnuppdatera.Location = new System.Drawing.Point(92, 245);
            this.btnuppdatera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnuppdatera.Name = "btnuppdatera";
            this.btnuppdatera.Size = new System.Drawing.Size(105, 38);
            this.btnuppdatera.TabIndex = 25;
            this.btnuppdatera.Text = "Uppdatera";
            this.btnuppdatera.UseVisualStyleBackColor = true;
            this.btnuppdatera.Click += new System.EventHandler(this.btnuppdatera_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Adress";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Telefon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "E-post";
            // 
            // tbpostort
            // 
            this.tbpostort.Location = new System.Drawing.Point(92, 192);
            this.tbpostort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpostort.Name = "tbpostort";
            this.tbpostort.Size = new System.Drawing.Size(199, 26);
            this.tbpostort.TabIndex = 15;
            this.tbpostort.TextChanged += new System.EventHandler(this.tbpostort_TextChanged);
            // 
            // tbpostadress
            // 
            this.tbpostadress.Location = new System.Drawing.Point(92, 166);
            this.tbpostadress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpostadress.Name = "tbpostadress";
            this.tbpostadress.Size = new System.Drawing.Size(199, 26);
            this.tbpostadress.TabIndex = 14;
            this.tbpostadress.TextChanged += new System.EventHandler(this.tbpostadress_TextChanged);
            // 
            // tbadress
            // 
            this.tbadress.Location = new System.Drawing.Point(92, 142);
            this.tbadress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbadress.Name = "tbadress";
            this.tbadress.Size = new System.Drawing.Size(199, 26);
            this.tbadress.TabIndex = 13;
            this.tbadress.TextChanged += new System.EventHandler(this.tbadress_TextChanged);
            // 
            // tbtelefon
            // 
            this.tbtelefon.Location = new System.Drawing.Point(92, 115);
            this.tbtelefon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbtelefon.Name = "tbtelefon";
            this.tbtelefon.Size = new System.Drawing.Size(199, 26);
            this.tbtelefon.TabIndex = 12;
            this.tbtelefon.TextChanged += new System.EventHandler(this.tbtelefon_TextChanged);
            // 
            // tbepost
            // 
            this.tbepost.Location = new System.Drawing.Point(92, 89);
            this.tbepost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbepost.Name = "tbepost";
            this.tbepost.Size = new System.Drawing.Size(199, 26);
            this.tbepost.TabIndex = 4;
            this.tbepost.TextChanged += new System.EventHandler(this.tbepost_TextChanged);
            // 
            // tbefternamn
            // 
            this.tbefternamn.Location = new System.Drawing.Point(92, 62);
            this.tbefternamn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbefternamn.Name = "tbefternamn";
            this.tbefternamn.Size = new System.Drawing.Size(199, 26);
            this.tbefternamn.TabIndex = 3;
            this.tbefternamn.TextChanged += new System.EventHandler(this.tbefternamn_TextChanged);
            // 
            // tbkund
            // 
            this.tbkund.Location = new System.Drawing.Point(92, 40);
            this.tbkund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbkund.Name = "tbkund";
            this.tbkund.Size = new System.Drawing.Size(199, 26);
            this.tbkund.TabIndex = 1;
            this.tbkund.TextChanged += new System.EventHandler(this.tbkund_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Efternamn";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.gvpkund);
            this.groupBox2.Controls.Add(this.btntillbaka);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.Tbsökkund);
            this.groupBox2.Controls.Add(this.btnsökpkund);
            this.groupBox2.Location = new System.Drawing.Point(19, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 540);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Privat kund";
            // 
            // UppdateraKundPrivat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UppdateraKundPrivat";
            this.Text = "UppdateraKundPrivat";
            this.Load += new System.EventHandler(this.UppdateraKundPrivat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvpkund)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsökpkund;
        private System.Windows.Forms.TextBox Tbsökkund;
        private System.Windows.Forms.DataGridView gvpkund;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnuppdatera;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbpostort;
        private System.Windows.Forms.TextBox tbpostadress;
        private System.Windows.Forms.TextBox tbadress;
        private System.Windows.Forms.TextBox tbtelefon;
        private System.Windows.Forms.TextBox tbepost;
        private System.Windows.Forms.TextBox tbefternamn;
        private System.Windows.Forms.TextBox tbkund;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Button btntabort;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}