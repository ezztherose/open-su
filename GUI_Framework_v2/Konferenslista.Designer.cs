namespace GUI_Framework_v2
{
    partial class Konferenslista
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btntabortkonferensinfo = new System.Windows.Forms.Button();
            this.konferensgrid = new System.Windows.Forms.DataGridView();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.btnsökkonferensinfo = new System.Windows.Forms.Button();
            this.tblogiinfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.konferensgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btntabortkonferensinfo);
            this.groupBox1.Controls.Add(this.konferensgrid);
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Controls.Add(this.btnsökkonferensinfo);
            this.groupBox1.Controls.Add(this.tblogiinfo);
            this.groupBox1.Location = new System.Drawing.Point(16, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(665, 331);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Konferens Information";
            // 
            // btntabortkonferensinfo
            // 
            this.btntabortkonferensinfo.Location = new System.Drawing.Point(433, 252);
            this.btntabortkonferensinfo.Margin = new System.Windows.Forms.Padding(2);
            this.btntabortkonferensinfo.Name = "btntabortkonferensinfo";
            this.btntabortkonferensinfo.Size = new System.Drawing.Size(109, 34);
            this.btntabortkonferensinfo.TabIndex = 17;
            this.btntabortkonferensinfo.Text = "Ta bort";
            this.btntabortkonferensinfo.UseVisualStyleBackColor = true;
            this.btntabortkonferensinfo.Click += new System.EventHandler(this.btntabortkonferensinfo_Click);
            // 
            // konferensgrid
            // 
            this.konferensgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.konferensgrid.Location = new System.Drawing.Point(48, 85);
            this.konferensgrid.Margin = new System.Windows.Forms.Padding(2);
            this.konferensgrid.Name = "konferensgrid";
            this.konferensgrid.RowHeadersWidth = 62;
            this.konferensgrid.RowTemplate.Height = 28;
            this.konferensgrid.Size = new System.Drawing.Size(494, 164);
            this.konferensgrid.TabIndex = 15;
            this.konferensgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.konferensgrid_CellContentClick);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(14, 274);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(125, 44);
            this.btntillbaka.TabIndex = 18;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // btnsökkonferensinfo
            // 
            this.btnsökkonferensinfo.Location = new System.Drawing.Point(196, 38);
            this.btnsökkonferensinfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnsökkonferensinfo.Name = "btnsökkonferensinfo";
            this.btnsökkonferensinfo.Size = new System.Drawing.Size(99, 34);
            this.btnsökkonferensinfo.TabIndex = 16;
            this.btnsökkonferensinfo.Text = "Sök";
            this.btnsökkonferensinfo.UseVisualStyleBackColor = true;
            this.btnsökkonferensinfo.Click += new System.EventHandler(this.btnsökinfo_Click);
            // 
            // tblogiinfo
            // 
            this.tblogiinfo.Location = new System.Drawing.Point(48, 46);
            this.tblogiinfo.Margin = new System.Windows.Forms.Padding(2);
            this.tblogiinfo.Name = "tblogiinfo";
            this.tblogiinfo.Size = new System.Drawing.Size(123, 22);
            this.tblogiinfo.TabIndex = 15;
            this.tblogiinfo.TextChanged += new System.EventHandler(this.tblogiinfo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ski-Center";
            // 
            // Konferenslista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 448);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Konferenslista";
            this.Text = "Konferenslista";
            this.Load += new System.EventHandler(this.Konferenslista_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.konferensgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btntabortkonferensinfo;
        private System.Windows.Forms.DataGridView konferensgrid;
        private System.Windows.Forms.Button btnsökkonferensinfo;
        private System.Windows.Forms.TextBox tblogiinfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btntillbaka;
    }
}