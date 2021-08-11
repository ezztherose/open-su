namespace GUI_Framework_v2
{
    partial class Logilista
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.cblogi = new System.Windows.Forms.ComboBox();
            this.btntabortlogiinfo = new System.Windows.Forms.Button();
            this.dglogidata = new System.Windows.Forms.DataGridView();
            this.btnsökinfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglogidata)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ski-Center";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Controls.Add(this.cblogi);
            this.groupBox1.Controls.Add(this.btntabortlogiinfo);
            this.groupBox1.Controls.Add(this.dglogidata);
            this.groupBox1.Controls.Add(this.btnsökinfo);
            this.groupBox1.Location = new System.Drawing.Point(16, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(666, 330);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logi Information";
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(6, 291);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(109, 34);
            this.btntillbaka.TabIndex = 15;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // cblogi
            // 
            this.cblogi.FormattingEnabled = true;
            this.cblogi.Location = new System.Drawing.Point(48, 45);
            this.cblogi.Margin = new System.Windows.Forms.Padding(2);
            this.cblogi.Name = "cblogi";
            this.cblogi.Size = new System.Drawing.Size(145, 24);
            this.cblogi.TabIndex = 18;
            this.cblogi.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btntabortlogiinfo
            // 
            this.btntabortlogiinfo.Location = new System.Drawing.Point(516, 260);
            this.btntabortlogiinfo.Margin = new System.Windows.Forms.Padding(2);
            this.btntabortlogiinfo.Name = "btntabortlogiinfo";
            this.btntabortlogiinfo.Size = new System.Drawing.Size(109, 34);
            this.btntabortlogiinfo.TabIndex = 17;
            this.btntabortlogiinfo.Text = "Ta bort";
            this.btntabortlogiinfo.UseVisualStyleBackColor = true;
            this.btntabortlogiinfo.Click += new System.EventHandler(this.btntabortlogiinfo_Click);
            // 
            // dglogidata
            // 
            this.dglogidata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglogidata.Location = new System.Drawing.Point(48, 86);
            this.dglogidata.Margin = new System.Windows.Forms.Padding(2);
            this.dglogidata.Name = "dglogidata";
            this.dglogidata.RowHeadersWidth = 62;
            this.dglogidata.RowTemplate.Height = 28;
            this.dglogidata.Size = new System.Drawing.Size(578, 164);
            this.dglogidata.TabIndex = 15;
            // 
            // btnsökinfo
            // 
            this.btnsökinfo.Location = new System.Drawing.Point(196, 38);
            this.btnsökinfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnsökinfo.Name = "btnsökinfo";
            this.btnsökinfo.Size = new System.Drawing.Size(99, 34);
            this.btnsökinfo.TabIndex = 16;
            this.btnsökinfo.Text = "Sök";
            this.btnsökinfo.UseVisualStyleBackColor = true;
            this.btnsökinfo.Click += new System.EventHandler(this.btnsökinfo_Click);
            // 
            // Logilista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 420);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Logilista";
            this.Text = "Logilista";
            this.Load += new System.EventHandler(this.Logilista_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dglogidata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnsökinfo;
        private System.Windows.Forms.DataGridView dglogidata;
        private System.Windows.Forms.Button btntabortlogiinfo;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.ComboBox cblogi;
    }
}