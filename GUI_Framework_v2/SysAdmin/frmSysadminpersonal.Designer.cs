
namespace GUI_Framework_v2
{
    partial class frmSysadminpersonal
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
            this.btntillbaka = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnsökupdatepersonal = new System.Windows.Forms.Button();
            this.tbpersonal = new System.Windows.Forms.TextBox();
            this.btnläggtillpersonal = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnändrapersonal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btntabortpersonal = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbanställdstyp = new System.Windows.Forms.ComboBox();
            this.cbbehörig = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tblösenord = new System.Windows.Forms.TextBox();
            this.tbefternamn = new System.Windows.Forms.TextBox();
            this.tbförnamn = new System.Windows.Forms.TextBox();
            this.tbanvändarnamn = new System.Windows.Forms.TextBox();
            this.gvpersonaldata = new System.Windows.Forms.DataGridView();
            this.btnuppdateraanställd = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvpersonaldata)).BeginInit();
            this.SuspendLayout();
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(822, 465);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(180, 50);
            this.btntillbaka.TabIndex = 18;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(992, 442);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnsökupdatepersonal);
            this.tabPage2.Controls.Add(this.tbpersonal);
            this.tabPage2.Controls.Add(this.btnläggtillpersonal);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.btnändrapersonal);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btntabortpersonal);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.gvpersonaldata);
            this.tabPage2.Controls.Add(this.btnuppdateraanställd);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(984, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Anställdslista";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnsökupdatepersonal
            // 
            this.btnsökupdatepersonal.Location = new System.Drawing.Point(294, 6);
            this.btnsökupdatepersonal.Margin = new System.Windows.Forms.Padding(2);
            this.btnsökupdatepersonal.Name = "btnsökupdatepersonal";
            this.btnsökupdatepersonal.Size = new System.Drawing.Size(126, 48);
            this.btnsökupdatepersonal.TabIndex = 43;
            this.btnsökupdatepersonal.Text = "Sök";
            this.btnsökupdatepersonal.UseVisualStyleBackColor = true;
            this.btnsökupdatepersonal.Click += new System.EventHandler(this.btnsökupdatepersonal_Click);
            // 
            // tbpersonal
            // 
            this.tbpersonal.Location = new System.Drawing.Point(124, 20);
            this.tbpersonal.Margin = new System.Windows.Forms.Padding(2);
            this.tbpersonal.Name = "tbpersonal";
            this.tbpersonal.Size = new System.Drawing.Size(166, 26);
            this.tbpersonal.TabIndex = 42;
            this.tbpersonal.TextChanged += new System.EventHandler(this.tbpersonal_TextChanged);
            // 
            // btnläggtillpersonal
            // 
            this.btnläggtillpersonal.Location = new System.Drawing.Point(150, 342);
            this.btnläggtillpersonal.Margin = new System.Windows.Forms.Padding(2);
            this.btnläggtillpersonal.Name = "btnläggtillpersonal";
            this.btnläggtillpersonal.Size = new System.Drawing.Size(156, 35);
            this.btnläggtillpersonal.TabIndex = 41;
            this.btnläggtillpersonal.Text = "Lägg till personal";
            this.btnläggtillpersonal.UseVisualStyleBackColor = true;
            this.btnläggtillpersonal.Click += new System.EventHandler(this.btnläggtillpersonal_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(285, 658);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(297, 70);
            this.button2.TabIndex = 40;
            this.button2.Text = "Lägg till Personal";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnändrapersonal
            // 
            this.btnändrapersonal.Location = new System.Drawing.Point(1174, 658);
            this.btnändrapersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnändrapersonal.Name = "btnändrapersonal";
            this.btnändrapersonal.Size = new System.Drawing.Size(84, 35);
            this.btnändrapersonal.TabIndex = 39;
            this.btnändrapersonal.Text = "Ändra";
            this.btnändrapersonal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "Personal";
            // 
            // btntabortpersonal
            // 
            this.btntabortpersonal.Location = new System.Drawing.Point(18, 342);
            this.btntabortpersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntabortpersonal.Name = "btntabortpersonal";
            this.btntabortpersonal.Size = new System.Drawing.Size(111, 35);
            this.btntabortpersonal.TabIndex = 37;
            this.btntabortpersonal.Text = "Ta bort personal";
            this.btntabortpersonal.UseVisualStyleBackColor = true;
            this.btntabortpersonal.Click += new System.EventHandler(this.btntabortpersonal_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.cbanställdstyp);
            this.groupBox4.Controls.Add(this.cbbehörig);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.tblösenord);
            this.groupBox4.Controls.Add(this.tbefternamn);
            this.groupBox4.Controls.Add(this.tbförnamn);
            this.groupBox4.Controls.Add(this.tbanvändarnamn);
            this.groupBox4.Location = new System.Drawing.Point(693, 68);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(282, 270);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Information";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Anställd",
            "Marknadschef",
            "Systemadmin"});
            this.comboBox2.Location = new System.Drawing.Point(152, 206);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(115, 28);
            this.comboBox2.TabIndex = 42;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sysadmin",
            "Butik",
            "Chef",
            "Reception",
            "Skidlärare"});
            this.comboBox1.Location = new System.Drawing.Point(152, 174);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 28);
            this.comboBox1.TabIndex = 41;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbanställdstyp
            // 
            this.cbanställdstyp.FormattingEnabled = true;
            this.cbanställdstyp.Items.AddRange(new object[] {
            "Anställd",
            "Marknadschef",
            "Systemadministratör"});
            this.cbanställdstyp.Location = new System.Drawing.Point(303, 398);
            this.cbanställdstyp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbanställdstyp.Name = "cbanställdstyp";
            this.cbanställdstyp.Size = new System.Drawing.Size(115, 28);
            this.cbanställdstyp.TabIndex = 41;
            // 
            // cbbehörig
            // 
            this.cbbehörig.FormattingEnabled = true;
            this.cbbehörig.Items.AddRange(new object[] {
            "Admin",
            "Butik",
            "Marknadschef",
            "Reception",
            "Skidskola"});
            this.cbbehörig.Location = new System.Drawing.Point(303, 334);
            this.cbbehörig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbehörig.Name = "cbbehörig";
            this.cbbehörig.Size = new System.Drawing.Size(115, 28);
            this.cbbehörig.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Anställds typ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Behörighet";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Lösenord";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Efternamn";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "Förnamn";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Användarnamn";
            // 
            // tblösenord
            // 
            this.tblösenord.Location = new System.Drawing.Point(152, 140);
            this.tblösenord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblösenord.Name = "tblösenord";
            this.tblösenord.Size = new System.Drawing.Size(115, 26);
            this.tblösenord.TabIndex = 32;
            this.tblösenord.TextChanged += new System.EventHandler(this.tblösenord_TextChanged);
            // 
            // tbefternamn
            // 
            this.tbefternamn.Location = new System.Drawing.Point(152, 105);
            this.tbefternamn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbefternamn.Name = "tbefternamn";
            this.tbefternamn.Size = new System.Drawing.Size(115, 26);
            this.tbefternamn.TabIndex = 31;
            this.tbefternamn.TextChanged += new System.EventHandler(this.tbefternamn_TextChanged);
            // 
            // tbförnamn
            // 
            this.tbförnamn.Location = new System.Drawing.Point(152, 68);
            this.tbförnamn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbförnamn.Name = "tbförnamn";
            this.tbförnamn.Size = new System.Drawing.Size(115, 26);
            this.tbförnamn.TabIndex = 30;
            this.tbförnamn.TextChanged += new System.EventHandler(this.tbförnamn_TextChanged);
            // 
            // tbanvändarnamn
            // 
            this.tbanvändarnamn.Location = new System.Drawing.Point(152, 32);
            this.tbanvändarnamn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbanvändarnamn.Name = "tbanvändarnamn";
            this.tbanvändarnamn.Size = new System.Drawing.Size(115, 26);
            this.tbanvändarnamn.TabIndex = 29;
            this.tbanvändarnamn.TextChanged += new System.EventHandler(this.tbanvändarnamn_TextChanged);
            // 
            // gvpersonaldata
            // 
            this.gvpersonaldata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvpersonaldata.Location = new System.Drawing.Point(18, 58);
            this.gvpersonaldata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvpersonaldata.Name = "gvpersonaldata";
            this.gvpersonaldata.RowHeadersWidth = 62;
            this.gvpersonaldata.RowTemplate.Height = 28;
            this.gvpersonaldata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvpersonaldata.Size = new System.Drawing.Size(672, 282);
            this.gvpersonaldata.TabIndex = 35;
            this.gvpersonaldata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvpersonaldata_CellContentClick);
            this.gvpersonaldata.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvpersonaldata_CellMouseClick);
            // 
            // btnuppdateraanställd
            // 
            this.btnuppdateraanställd.Location = new System.Drawing.Point(693, 342);
            this.btnuppdateraanställd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnuppdateraanställd.Name = "btnuppdateraanställd";
            this.btnuppdateraanställd.Size = new System.Drawing.Size(111, 35);
            this.btnuppdateraanställd.TabIndex = 32;
            this.btnuppdateraanställd.Text = "Uppdatera";
            this.btnuppdateraanställd.UseVisualStyleBackColor = true;
            this.btnuppdateraanställd.Click += new System.EventHandler(this.btnuppdateraanställd_Click);
            // 
            // frmSysadminpersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1029, 538);
            this.Controls.Add(this.btntillbaka);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSysadminpersonal";
            this.Text = "frmSysadminpersonal";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvpersonaldata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnsökupdatepersonal;
        private System.Windows.Forms.TextBox tbpersonal;
        private System.Windows.Forms.Button btnläggtillpersonal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnändrapersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntabortpersonal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbanställdstyp;
        private System.Windows.Forms.ComboBox cbbehörig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tblösenord;
        private System.Windows.Forms.TextBox tbefternamn;
        private System.Windows.Forms.TextBox tbförnamn;
        private System.Windows.Forms.TextBox tbanvändarnamn;
        private System.Windows.Forms.DataGridView gvpersonaldata;
        private System.Windows.Forms.Button btnuppdateraanställd;
    }
}