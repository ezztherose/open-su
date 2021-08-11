namespace GUI_Framework_v2
{
    partial class FakturaFörKöp
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnsök = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.btnskrivutfakturas = new System.Windows.Forms.Button();
            this.gvFKdata = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFKdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox6.Controls.Add(this.btnsök);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.dateTimePicker2);
            this.groupBox6.Location = new System.Drawing.Point(13, 55);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox6.Size = new System.Drawing.Size(171, 68);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Datum";
            // 
            // btnsök
            // 
            this.btnsök.Location = new System.Drawing.Point(107, 35);
            this.btnsök.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnsök.Name = "btnsök";
            this.btnsök.Size = new System.Drawing.Size(50, 21);
            this.btnsök.TabIndex = 3;
            this.btnsök.Text = "Sök";
            this.btnsök.UseVisualStyleBackColor = true;
            this.btnsök.Click += new System.EventHandler(this.btnsök_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Välj datum";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(2, 36);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(102, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox5.Controls.Add(this.btntillbaka);
            this.groupBox5.Controls.Add(this.btnskrivutfakturas);
            this.groupBox5.Controls.Add(this.gvFKdata);
            this.groupBox5.Location = new System.Drawing.Point(13, 131);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox5.Size = new System.Drawing.Size(442, 252);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Data";
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(4, 218);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(75, 23);
            this.btntillbaka.TabIndex = 8;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // btnskrivutfakturas
            // 
            this.btnskrivutfakturas.Location = new System.Drawing.Point(332, 218);
            this.btnskrivutfakturas.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnskrivutfakturas.Name = "btnskrivutfakturas";
            this.btnskrivutfakturas.Size = new System.Drawing.Size(94, 23);
            this.btnskrivutfakturas.TabIndex = 3;
            this.btnskrivutfakturas.Text = "Skriv ut faktura";
            this.btnskrivutfakturas.UseVisualStyleBackColor = true;
            this.btnskrivutfakturas.Click += new System.EventHandler(this.btnskrivutfakturas_Click);
            // 
            // gvFKdata
            // 
            this.gvFKdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFKdata.Location = new System.Drawing.Point(4, 31);
            this.gvFKdata.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gvFKdata.Name = "gvFKdata";
            this.gvFKdata.RowHeadersWidth = 62;
            this.gvFKdata.RowTemplate.Height = 28;
            this.gvFKdata.Size = new System.Drawing.Size(422, 177);
            this.gvFKdata.TabIndex = 2;
            this.gvFKdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFKdata_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ski-Center";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Faktura för köp";
            // 
            // FakturaFörKöp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 400);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Name = "FakturaFörKöp";
            this.Text = "FakturaFörKöp";
            this.Load += new System.EventHandler(this.FakturaFörKöp_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvFKdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnsök;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnskrivutfakturas;
        private System.Windows.Forms.DataGridView gvFKdata;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}