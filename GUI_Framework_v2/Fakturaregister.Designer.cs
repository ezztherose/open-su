namespace GUI_Framework_v2
{
    partial class Fakturaregister
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
            this.btnskrivutregister = new System.Windows.Forms.Button();
            this.dgvFakturaRegister = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakturaRegister)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(22, 331);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(154, 42);
            this.btntillbaka.TabIndex = 13;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // btnskrivutregister
            // 
            this.btnskrivutregister.Location = new System.Drawing.Point(371, 331);
            this.btnskrivutregister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnskrivutregister.Name = "btnskrivutregister";
            this.btnskrivutregister.Size = new System.Drawing.Size(165, 42);
            this.btnskrivutregister.TabIndex = 12;
            this.btnskrivutregister.Text = "Skriv ut register";
            this.btnskrivutregister.UseVisualStyleBackColor = true;
            this.btnskrivutregister.Click += new System.EventHandler(this.btnskrivutregister_Click);
            // 
            // dgvFakturaRegister
            // 
            this.dgvFakturaRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFakturaRegister.Location = new System.Drawing.Point(22, 44);
            this.dgvFakturaRegister.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvFakturaRegister.Name = "dgvFakturaRegister";
            this.dgvFakturaRegister.RowHeadersWidth = 62;
            this.dgvFakturaRegister.Size = new System.Drawing.Size(514, 280);
            this.dgvFakturaRegister.TabIndex = 11;
            this.dgvFakturaRegister.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFakturaRegister_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.dgvFakturaRegister);
            this.groupBox1.Controls.Add(this.btnskrivutregister);
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Location = new System.Drawing.Point(17, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 423);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fakturaregister";
            // 
            // Fakturaregister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Fakturaregister";
            this.Text = "Fakturaregister";
            this.Load += new System.EventHandler(this.Fakturaregister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakturaRegister)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Button btnskrivutregister;
        private System.Windows.Forms.DataGridView dgvFakturaRegister;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}