
namespace GUI_Framework_v2
{
    partial class frmSkidlärare
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btVälj = new System.Windows.Forms.Button();
            this.btSök = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDagar = new System.Windows.Forms.ComboBox();
            this.btnTillbaka = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnskrivutlärare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvgrupplektioner = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btVäljLektion = new System.Windows.Forms.Button();
            this.btSkrivUtPrivat = new System.Windows.Forms.Button();
            this.btTillbakaPrivat = new System.Windows.Forms.Button();
            this.gvPrivatlektioner = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvgrupplektioner)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivatlektioner)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 38);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ski-Center";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(825, 518);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btVälj);
            this.tabPage1.Controls.Add(this.btSök);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbDagar);
            this.tabPage1.Controls.Add(this.btnTillbaka);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.btnskrivutlärare);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.gvgrupplektioner);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grupplektioner";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(381, 398);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(128, 51);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Rensa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btVälj
            // 
            this.btVälj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVälj.Location = new System.Drawing.Point(514, 398);
            this.btVälj.Name = "btVälj";
            this.btVälj.Size = new System.Drawing.Size(128, 51);
            this.btVälj.TabIndex = 11;
            this.btVälj.Text = "Välj";
            this.btVälj.UseVisualStyleBackColor = true;
            this.btVälj.Click += new System.EventHandler(this.btVälj_Click);
            // 
            // btSök
            // 
            this.btSök.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSök.Location = new System.Drawing.Point(631, 30);
            this.btSök.Name = "btSök";
            this.btSök.Size = new System.Drawing.Size(128, 39);
            this.btSök.TabIndex = 10;
            this.btSök.Text = "Sök";
            this.btSök.UseVisualStyleBackColor = true;
            this.btSök.Click += new System.EventHandler(this.btSök_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Antal dagar";
            // 
            // cbDagar
            // 
            this.cbDagar.FormattingEnabled = true;
            this.cbDagar.Location = new System.Drawing.Point(472, 30);
            this.cbDagar.Name = "cbDagar";
            this.cbDagar.Size = new System.Drawing.Size(126, 32);
            this.cbDagar.TabIndex = 8;
            // 
            // btnTillbaka
            // 
            this.btnTillbaka.Location = new System.Drawing.Point(7, 398);
            this.btnTillbaka.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTillbaka.Name = "btnTillbaka";
            this.btnTillbaka.Size = new System.Drawing.Size(121, 51);
            this.btnTillbaka.TabIndex = 7;
            this.btnTillbaka.Text = "Logga ut";
            this.btnTillbaka.UseVisualStyleBackColor = true;
            this.btnTillbaka.Click += new System.EventHandler(this.btnTillbaka_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(114, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 32);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnskrivutlärare
            // 
            this.btnskrivutlärare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnskrivutlärare.Location = new System.Drawing.Point(648, 398);
            this.btnskrivutlärare.Name = "btnskrivutlärare";
            this.btnskrivutlärare.Size = new System.Drawing.Size(128, 51);
            this.btnskrivutlärare.TabIndex = 4;
            this.btnskrivutlärare.Text = "Skriv ut";
            this.btnskrivutlärare.UseVisualStyleBackColor = true;
            this.btnskrivutlärare.Click += new System.EventHandler(this.btnskrivutlärare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gruppfärg";
            // 
            // gvgrupplektioner
            // 
            this.gvgrupplektioner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvgrupplektioner.Location = new System.Drawing.Point(4, 75);
            this.gvgrupplektioner.Name = "gvgrupplektioner";
            this.gvgrupplektioner.ReadOnly = true;
            this.gvgrupplektioner.RowHeadersWidth = 62;
            this.gvgrupplektioner.RowTemplate.Height = 28;
            this.gvgrupplektioner.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvgrupplektioner.Size = new System.Drawing.Size(767, 318);
            this.gvgrupplektioner.TabIndex = 0;
            this.gvgrupplektioner.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvskidlärare_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btVäljLektion);
            this.tabPage2.Controls.Add(this.btSkrivUtPrivat);
            this.tabPage2.Controls.Add(this.btTillbakaPrivat);
            this.tabPage2.Controls.Add(this.gvPrivatlektioner);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(817, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Privatlektioner";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tillbaka";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Välj lektion och sök deltagare";
            // 
            // btVäljLektion
            // 
            this.btVäljLektion.Location = new System.Drawing.Point(282, 24);
            this.btVäljLektion.Margin = new System.Windows.Forms.Padding(4);
            this.btVäljLektion.Name = "btVäljLektion";
            this.btVäljLektion.Size = new System.Drawing.Size(132, 39);
            this.btVäljLektion.TabIndex = 3;
            this.btVäljLektion.Text = "Sök";
            this.btVäljLektion.UseVisualStyleBackColor = true;
            this.btVäljLektion.Click += new System.EventHandler(this.btSökPrivat_Click);
            // 
            // btSkrivUtPrivat
            // 
            this.btSkrivUtPrivat.Location = new System.Drawing.Point(670, 406);
            this.btSkrivUtPrivat.Margin = new System.Windows.Forms.Padding(4);
            this.btSkrivUtPrivat.Name = "btSkrivUtPrivat";
            this.btSkrivUtPrivat.Size = new System.Drawing.Size(132, 54);
            this.btSkrivUtPrivat.TabIndex = 2;
            this.btSkrivUtPrivat.Text = "Skriv ut";
            this.btSkrivUtPrivat.UseVisualStyleBackColor = true;
            this.btSkrivUtPrivat.Click += new System.EventHandler(this.btSkrivUtPrivat_Click);
            // 
            // btTillbakaPrivat
            // 
            this.btTillbakaPrivat.Location = new System.Drawing.Point(22, 411);
            this.btTillbakaPrivat.Margin = new System.Windows.Forms.Padding(4);
            this.btTillbakaPrivat.Name = "btTillbakaPrivat";
            this.btTillbakaPrivat.Size = new System.Drawing.Size(132, 54);
            this.btTillbakaPrivat.TabIndex = 1;
            this.btTillbakaPrivat.Text = "Logga ut";
            this.btTillbakaPrivat.UseVisualStyleBackColor = true;
            this.btTillbakaPrivat.Click += new System.EventHandler(this.btTillbakaPrivat_Click);
            // 
            // gvPrivatlektioner
            // 
            this.gvPrivatlektioner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrivatlektioner.Location = new System.Drawing.Point(4, 72);
            this.gvPrivatlektioner.Margin = new System.Windows.Forms.Padding(4);
            this.gvPrivatlektioner.Name = "gvPrivatlektioner";
            this.gvPrivatlektioner.RowHeadersWidth = 51;
            this.gvPrivatlektioner.RowTemplate.Height = 24;
            this.gvPrivatlektioner.Size = new System.Drawing.Size(798, 326);
            this.gvPrivatlektioner.TabIndex = 0;
            this.gvPrivatlektioner.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPrivatlektioner_CellContentClick);
            // 
            // frmSkidlärare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(879, 654);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSkidlärare";
            this.Text = "frmSkidlärare";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvgrupplektioner)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivatlektioner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnväljlärare;
        private System.Windows.Forms.Button btnskrivutlärare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvgrupplektioner;
        private System.Windows.Forms.Button btnLoggaUt;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btväljp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTillbaka;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDagar;
        private System.Windows.Forms.Button btSök;
        private System.Windows.Forms.Button btVäljLektion;
        private System.Windows.Forms.Button btSkrivUtPrivat;
        private System.Windows.Forms.Button btTillbakaPrivat;
        private System.Windows.Forms.DataGridView gvPrivatlektioner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btVälj;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
    }
}