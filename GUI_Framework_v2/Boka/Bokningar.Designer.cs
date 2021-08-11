namespace GUI_Framework_v2
{
    partial class Bokningar
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
            this.btnskrivutb = new System.Windows.Forms.Button();
            this.btnsökb = new System.Windows.Forms.Button();
            this.tbSökBokningar = new System.Windows.Forms.TextBox();
            this.gvBokningar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvBokningar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnskrivutb
            // 
            this.btnskrivutb.Location = new System.Drawing.Point(889, 472);
            this.btnskrivutb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnskrivutb.Name = "btnskrivutb";
            this.btnskrivutb.Size = new System.Drawing.Size(155, 48);
            this.btnskrivutb.TabIndex = 11;
            this.btnskrivutb.Text = "Skriv ut alla bokningar";
            this.btnskrivutb.UseVisualStyleBackColor = true;
            this.btnskrivutb.Click += new System.EventHandler(this.btnskrivutb_Click);
            // 
            // btnsökb
            // 
            this.btnsökb.Location = new System.Drawing.Point(250, 74);
            this.btnsökb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsökb.Name = "btnsökb";
            this.btnsökb.Size = new System.Drawing.Size(69, 25);
            this.btnsökb.TabIndex = 10;
            this.btnsökb.Text = "Sök";
            this.btnsökb.UseVisualStyleBackColor = true;
            this.btnsökb.Click += new System.EventHandler(this.btnsökb_Click);
            // 
            // tbSökBokningar
            // 
            this.tbSökBokningar.Location = new System.Drawing.Point(23, 75);
            this.tbSökBokningar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSökBokningar.Name = "tbSökBokningar";
            this.tbSökBokningar.Size = new System.Drawing.Size(221, 22);
            this.tbSökBokningar.TabIndex = 9;
            this.tbSökBokningar.TextChanged += new System.EventHandler(this.tbSökBokningar_TextChanged);
            // 
            // gvBokningar
            // 
            this.gvBokningar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBokningar.Location = new System.Drawing.Point(23, 103);
            this.gvBokningar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvBokningar.Name = "gvBokningar";
            this.gvBokningar.RowHeadersWidth = 62;
            this.gvBokningar.RowTemplate.Height = 28;
            this.gvBokningar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvBokningar.Size = new System.Drawing.Size(1021, 350);
            this.gvBokningar.TabIndex = 8;
            this.gvBokningar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBokningar_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Bokningar till utskrift";
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(729, 472);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(155, 48);
            this.btntillbaka.TabIndex = 13;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // Bokningar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btntillbaka);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnskrivutb);
            this.Controls.Add(this.btnsökb);
            this.Controls.Add(this.tbSökBokningar);
            this.Controls.Add(this.gvBokningar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Bokningar";
            this.Text = "Bokningar";
            this.Load += new System.EventHandler(this.Bokningar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvBokningar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnskrivutb;
        private System.Windows.Forms.Button btnsökb;
        private System.Windows.Forms.TextBox tbSökBokningar;
        private System.Windows.Forms.DataGridView gvBokningar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label3;
    }
}