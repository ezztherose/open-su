namespace GUI_Framework_v2
{
    partial class Uthyrningsregister
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
            this.btnskrivututhyrningsregister = new System.Windows.Forms.Button();
            this.gvuthyrningr = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvuthyrningr)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(54, 291);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(137, 34);
            this.btntillbaka.TabIndex = 17;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // btnskrivututhyrningsregister
            // 
            this.btnskrivututhyrningsregister.Location = new System.Drawing.Point(364, 291);
            this.btnskrivututhyrningsregister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnskrivututhyrningsregister.Name = "btnskrivututhyrningsregister";
            this.btnskrivututhyrningsregister.Size = new System.Drawing.Size(147, 34);
            this.btnskrivututhyrningsregister.TabIndex = 16;
            this.btnskrivututhyrningsregister.Text = "Skriv ut";
            this.btnskrivututhyrningsregister.UseVisualStyleBackColor = true;
            this.btnskrivututhyrningsregister.Click += new System.EventHandler(this.btnskrivututhyrningsregister_Click);
            // 
            // gvuthyrningr
            // 
            this.gvuthyrningr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvuthyrningr.Location = new System.Drawing.Point(54, 62);
            this.gvuthyrningr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gvuthyrningr.Name = "gvuthyrningr";
            this.gvuthyrningr.RowHeadersWidth = 62;
            this.gvuthyrningr.Size = new System.Drawing.Size(457, 224);
            this.gvuthyrningr.TabIndex = 15;
            this.gvuthyrningr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ski-Center";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.gvuthyrningr);
            this.groupBox1.Controls.Add(this.btnskrivututhyrningsregister);
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Location = new System.Drawing.Point(17, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(618, 377);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uthyrningsregister";
            // 
            // Uthyrningsregister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Uthyrningsregister";
            this.Text = "Uthyrningsregister";
            this.Load += new System.EventHandler(this.Uthyrningsregister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvuthyrningr)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Button btnskrivututhyrningsregister;
        private System.Windows.Forms.DataGridView gvuthyrningr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}