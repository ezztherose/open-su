namespace GUI_Framework_v2
{
    partial class Hyrutrustningslista
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
            this.btntillbaka = new System.Windows.Forms.Button();
            this.btntaborthyrdata = new System.Windows.Forms.Button();
            this.btnsökhyr = new System.Windows.Forms.Button();
            this.tbhyrinfo = new System.Windows.Forms.TextBox();
            this.dvhyrdata = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvhyrdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Controls.Add(this.btntaborthyrdata);
            this.groupBox1.Controls.Add(this.btnsökhyr);
            this.groupBox1.Controls.Add(this.tbhyrinfo);
            this.groupBox1.Controls.Add(this.dvhyrdata);
            this.groupBox1.Location = new System.Drawing.Point(17, 49);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(599, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hyr information";
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(10, 253);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(93, 38);
            this.btntillbaka.TabIndex = 18;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // btntaborthyrdata
            // 
            this.btntaborthyrdata.Location = new System.Drawing.Point(454, 242);
            this.btntaborthyrdata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntaborthyrdata.Name = "btntaborthyrdata";
            this.btntaborthyrdata.Size = new System.Drawing.Size(125, 34);
            this.btntaborthyrdata.TabIndex = 3;
            this.btntaborthyrdata.Text = "Ta bort hyrdata";
            this.btntaborthyrdata.UseVisualStyleBackColor = true;
            this.btntaborthyrdata.Click += new System.EventHandler(this.btntaborthyrdata_Click);
            // 
            // btnsökhyr
            // 
            this.btnsökhyr.Location = new System.Drawing.Point(149, 20);
            this.btnsökhyr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsökhyr.Name = "btnsökhyr";
            this.btnsökhyr.Size = new System.Drawing.Size(61, 34);
            this.btnsökhyr.TabIndex = 2;
            this.btnsökhyr.Text = "Sök";
            this.btnsökhyr.UseVisualStyleBackColor = true;
            this.btnsökhyr.Click += new System.EventHandler(this.btnsökhyr_Click);
            // 
            // tbhyrinfo
            // 
            this.tbhyrinfo.Location = new System.Drawing.Point(10, 26);
            this.tbhyrinfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbhyrinfo.Name = "tbhyrinfo";
            this.tbhyrinfo.Size = new System.Drawing.Size(122, 22);
            this.tbhyrinfo.TabIndex = 1;
            this.tbhyrinfo.TextChanged += new System.EventHandler(this.tbhyrinfo_TextChanged);
            // 
            // dvhyrdata
            // 
            this.dvhyrdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvhyrdata.Location = new System.Drawing.Point(10, 58);
            this.dvhyrdata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dvhyrdata.Name = "dvhyrdata";
            this.dvhyrdata.RowHeadersWidth = 62;
            this.dvhyrdata.RowTemplate.Height = 28;
            this.dvhyrdata.Size = new System.Drawing.Size(570, 180);
            this.dvhyrdata.TabIndex = 0;
            this.dvhyrdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvhyrdata_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ski-Center";
            // 
            // Hyrutrustningslista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Hyrutrustningslista";
            this.Text = "Hyrutrustningslista";
            this.Load += new System.EventHandler(this.Hyrutrustningslista_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvhyrdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btntaborthyrdata;
        private System.Windows.Forms.Button btnsökhyr;
        private System.Windows.Forms.TextBox tbhyrinfo;
        private System.Windows.Forms.DataGridView dvhyrdata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btntillbaka;
    }
}