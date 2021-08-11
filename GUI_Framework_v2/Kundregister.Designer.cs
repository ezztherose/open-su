namespace GUI_Framework_v2
{
    partial class Kundregister
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
            this.gvföretagskundregister = new System.Windows.Forms.DataGridView();
            this.gvprivatkundregister = new System.Windows.Forms.DataGridView();
            this.btnskrivutregisterförföretagskund = new System.Windows.Forms.Button();
            this.btnskrivutregisterförprivatkund = new System.Windows.Forms.Button();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvföretagskundregister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvprivatkundregister)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvföretagskundregister
            // 
            this.gvföretagskundregister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvföretagskundregister.Location = new System.Drawing.Point(334, 19);
            this.gvföretagskundregister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvföretagskundregister.Name = "gvföretagskundregister";
            this.gvföretagskundregister.RowHeadersWidth = 82;
            this.gvföretagskundregister.RowTemplate.Height = 33;
            this.gvföretagskundregister.Size = new System.Drawing.Size(312, 306);
            this.gvföretagskundregister.TabIndex = 15;
            this.gvföretagskundregister.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.företagskundregistergrid_CellContentClick);
            // 
            // gvprivatkundregister
            // 
            this.gvprivatkundregister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvprivatkundregister.Location = new System.Drawing.Point(5, 19);
            this.gvprivatkundregister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvprivatkundregister.Name = "gvprivatkundregister";
            this.gvprivatkundregister.RowHeadersWidth = 82;
            this.gvprivatkundregister.RowTemplate.Height = 33;
            this.gvprivatkundregister.Size = new System.Drawing.Size(312, 306);
            this.gvprivatkundregister.TabIndex = 16;
            // 
            // btnskrivutregisterförföretagskund
            // 
            this.btnskrivutregisterförföretagskund.Location = new System.Drawing.Point(422, 350);
            this.btnskrivutregisterförföretagskund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnskrivutregisterförföretagskund.Name = "btnskrivutregisterförföretagskund";
            this.btnskrivutregisterförföretagskund.Size = new System.Drawing.Size(224, 39);
            this.btnskrivutregisterförföretagskund.TabIndex = 18;
            this.btnskrivutregisterförföretagskund.Text = "Skriv ut register (Företagskund)";
            this.btnskrivutregisterförföretagskund.UseVisualStyleBackColor = true;
            this.btnskrivutregisterförföretagskund.Click += new System.EventHandler(this.btnskrivutregisterförföretagskund_Click);
            // 
            // btnskrivutregisterförprivatkund
            // 
            this.btnskrivutregisterförprivatkund.Location = new System.Drawing.Point(5, 350);
            this.btnskrivutregisterförprivatkund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnskrivutregisterförprivatkund.Name = "btnskrivutregisterförprivatkund";
            this.btnskrivutregisterförprivatkund.Size = new System.Drawing.Size(224, 39);
            this.btnskrivutregisterförprivatkund.TabIndex = 17;
            this.btnskrivutregisterförprivatkund.Text = "Skriv ut register (Privakund)";
            this.btnskrivutregisterförprivatkund.UseVisualStyleBackColor = true;
            this.btnskrivutregisterförprivatkund.Click += new System.EventHandler(this.btnskrivutregisterförprivatkund_Click);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(5, 414);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(137, 34);
            this.btntillbaka.TabIndex = 19;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.gvprivatkundregister);
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Controls.Add(this.gvföretagskundregister);
            this.groupBox1.Controls.Add(this.btnskrivutregisterförföretagskund);
            this.groupBox1.Controls.Add(this.btnskrivutregisterförprivatkund);
            this.groupBox1.Location = new System.Drawing.Point(16, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(678, 475);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kundregister";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // Kundregister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 546);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Kundregister";
            this.Text = "Kundregister";
            this.Load += new System.EventHandler(this.Kundregister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvföretagskundregister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvprivatkundregister)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gvföretagskundregister;
        private System.Windows.Forms.DataGridView gvprivatkundregister;
        private System.Windows.Forms.Button btnskrivutregisterförföretagskund;
        private System.Windows.Forms.Button btnskrivutregisterförprivatkund;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}