
namespace GUI_Framework_v2
{
    partial class frmSysadminLäggTillPersonal
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnläggtillpersonal = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblösenord = new System.Windows.Forms.TextBox();
            this.tbefternamn = new System.Windows.Forms.TextBox();
            this.tbförnamn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbnanvändarnamn = new System.Windows.Forms.TextBox();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(15, 49);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(341, 438);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.btnläggtillpersonal);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.tblösenord);
            this.tabPage1.Controls.Add(this.tbefternamn);
            this.tabPage1.Controls.Add(this.tbförnamn);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbnanvändarnamn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(333, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lägg till Personal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Anställd",
            "Marknadschef",
            "Systemadmin"});
            this.comboBox2.Location = new System.Drawing.Point(128, 180);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(187, 24);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btnläggtillpersonal
            // 
            this.btnläggtillpersonal.Location = new System.Drawing.Point(163, 354);
            this.btnläggtillpersonal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnläggtillpersonal.Name = "btnläggtillpersonal";
            this.btnläggtillpersonal.Size = new System.Drawing.Size(149, 34);
            this.btnläggtillpersonal.TabIndex = 12;
            this.btnläggtillpersonal.Text = "Lägg till personal";
            this.btnläggtillpersonal.UseVisualStyleBackColor = true;
            this.btnläggtillpersonal.Click += new System.EventHandler(this.btnläggtillpersonal_Click);
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
            this.comboBox1.Location = new System.Drawing.Point(128, 148);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tblösenord
            // 
            this.tblösenord.Location = new System.Drawing.Point(128, 110);
            this.tblösenord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblösenord.Name = "tblösenord";
            this.tblösenord.Size = new System.Drawing.Size(187, 22);
            this.tblösenord.TabIndex = 9;
            this.tblösenord.TextChanged += new System.EventHandler(this.tblösenord_TextChanged);
            // 
            // tbefternamn
            // 
            this.tbefternamn.Location = new System.Drawing.Point(128, 82);
            this.tbefternamn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbefternamn.Name = "tbefternamn";
            this.tbefternamn.Size = new System.Drawing.Size(187, 22);
            this.tbefternamn.TabIndex = 8;
            this.tbefternamn.TextChanged += new System.EventHandler(this.tbefternamn_TextChanged);
            // 
            // tbförnamn
            // 
            this.tbförnamn.Location = new System.Drawing.Point(128, 55);
            this.tbförnamn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbförnamn.Name = "tbförnamn";
            this.tbförnamn.Size = new System.Drawing.Size(187, 22);
            this.tbförnamn.TabIndex = 7;
            this.tbförnamn.TextChanged += new System.EventHandler(this.tbförnamn_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Anställningstyp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Behörighet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lösenord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Efternamn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Förnamn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Användarnamn";
            // 
            // tbnanvändarnamn
            // 
            this.tbnanvändarnamn.Location = new System.Drawing.Point(128, 27);
            this.tbnanvändarnamn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbnanvändarnamn.Name = "tbnanvändarnamn";
            this.tbnanvändarnamn.Size = new System.Drawing.Size(187, 22);
            this.tbnanvändarnamn.TabIndex = 0;
            this.tbnanvändarnamn.TextChanged += new System.EventHandler(this.tbnanvändarnamn_TextChanged);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(15, 503);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(83, 27);
            this.btntillbaka.TabIndex = 2;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 29);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ski-Center";
            // 
            // frmSysadminLäggTillPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(405, 559);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btntillbaka);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSysadminLäggTillPersonal";
            this.Text = "frmSysadminLäggTillPersonal";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnläggtillpersonal;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox tblösenord;
        private System.Windows.Forms.TextBox tbefternamn;
        private System.Windows.Forms.TextBox tbförnamn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbnanvändarnamn;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label7;
    }
}