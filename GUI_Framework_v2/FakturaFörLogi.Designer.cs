namespace GUI_Framework_v2
{
    partial class FakturaFörLogi
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnsök = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.btnskrivutf = new System.Windows.Forms.Button();
            this.gvfldata = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvfldata)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnsök);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dateTimePicker2);
            this.groupBox3.Location = new System.Drawing.Point(21, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Size = new System.Drawing.Size(158, 68);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datum";
            // 
            // btnsök
            // 
            this.btnsök.Location = new System.Drawing.Point(106, 36);
            this.btnsök.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnsök.Name = "btnsök";
            this.btnsök.Size = new System.Drawing.Size(50, 21);
            this.btnsök.TabIndex = 2;
            this.btnsök.Text = "Sök";
            this.btnsök.UseVisualStyleBackColor = true;
            this.btnsök.Click += new System.EventHandler(this.btnsök_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Välj datum";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(2, 36);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(102, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btntillbaka);
            this.groupBox4.Controls.Add(this.btnskrivutf);
            this.groupBox4.Controls.Add(this.gvfldata);
            this.groupBox4.Location = new System.Drawing.Point(21, 103);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Size = new System.Drawing.Size(442, 238);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data";
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(8, 199);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(75, 23);
            this.btntillbaka.TabIndex = 7;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // btnskrivutf
            // 
            this.btnskrivutf.Location = new System.Drawing.Point(340, 199);
            this.btnskrivutf.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnskrivutf.Name = "btnskrivutf";
            this.btnskrivutf.Size = new System.Drawing.Size(90, 23);
            this.btnskrivutf.TabIndex = 3;
            this.btnskrivutf.Text = "Skriv ut faktura";
            this.btnskrivutf.UseVisualStyleBackColor = true;
            this.btnskrivutf.Click += new System.EventHandler(this.btnskrivutf_Click);
            // 
            // gvfldata
            // 
            this.gvfldata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvfldata.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gvfldata.Location = new System.Drawing.Point(8, 13);
            this.gvfldata.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gvfldata.Name = "gvfldata";
            this.gvfldata.RowHeadersWidth = 62;
            this.gvfldata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvfldata.RowTemplate.Height = 28;
            this.gvfldata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvfldata.Size = new System.Drawing.Size(422, 177);
            this.gvfldata.TabIndex = 2;
            this.gvfldata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvfldata_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ski-Center";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(23, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(474, 356);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Faktura för Logi";
            // 
            // FakturaFörLogi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 440);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "FakturaFörLogi";
            this.Text = "FakturaFörLogi";
            this.Load += new System.EventHandler(this.FakturaFörLogi_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvfldata)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnsök;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnskrivutf;
        private System.Windows.Forms.DataGridView gvfldata;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}