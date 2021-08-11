namespace GUI_Framework_v2
{
    partial class ButikÅterlämning
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
            this.tbSök = new System.Windows.Forms.TextBox();
            this.gvÅterlämning = new System.Windows.Forms.DataGridView();
            this.btnTillbaka = new System.Windows.Forms.Button();
            this.btnÅterlämna = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSök = new System.Windows.Forms.Button();
            this.btKund = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvÅterlämning)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSök
            // 
            this.tbSök.Location = new System.Drawing.Point(25, 62);
            this.tbSök.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSök.Name = "tbSök";
            this.tbSök.Size = new System.Drawing.Size(245, 26);
            this.tbSök.TabIndex = 0;
            this.tbSök.TextChanged += new System.EventHandler(this.tbSök_TextChanged);
            this.tbSök.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSök_KeyDown);
            // 
            // gvÅterlämning
            // 
            this.gvÅterlämning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvÅterlämning.Location = new System.Drawing.Point(25, 98);
            this.gvÅterlämning.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvÅterlämning.Name = "gvÅterlämning";
            this.gvÅterlämning.RowHeadersWidth = 51;
            this.gvÅterlämning.Size = new System.Drawing.Size(624, 231);
            this.gvÅterlämning.TabIndex = 1;
            this.gvÅterlämning.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvÅterlämning_CellContentClick);
            // 
            // btnTillbaka
            // 
            this.btnTillbaka.Location = new System.Drawing.Point(25, 362);
            this.btnTillbaka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTillbaka.Name = "btnTillbaka";
            this.btnTillbaka.Size = new System.Drawing.Size(112, 35);
            this.btnTillbaka.TabIndex = 2;
            this.btnTillbaka.Text = "Tillbaka";
            this.btnTillbaka.UseVisualStyleBackColor = true;
            this.btnTillbaka.Click += new System.EventHandler(this.btnTillbaka_Click);
            // 
            // btnÅterlämna
            // 
            this.btnÅterlämna.Location = new System.Drawing.Point(495, 339);
            this.btnÅterlämna.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnÅterlämna.Name = "btnÅterlämna";
            this.btnÅterlämna.Size = new System.Drawing.Size(154, 58);
            this.btnÅterlämna.TabIndex = 3;
            this.btnÅterlämna.Text = "Återlämna";
            this.btnÅterlämna.UseVisualStyleBackColor = true;
            this.btnÅterlämna.Click += new System.EventHandler(this.btnÅterlämna_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sök namn";
            // 
            // btnSök
            // 
            this.btnSök.Location = new System.Drawing.Point(537, 62);
            this.btnSök.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSök.Name = "btnSök";
            this.btnSök.Size = new System.Drawing.Size(112, 35);
            this.btnSök.TabIndex = 6;
            this.btnSök.Text = "Sök";
            this.btnSök.UseVisualStyleBackColor = true;
            this.btnSök.Click += new System.EventHandler(this.btnSök_Click);
            // 
            // btKund
            // 
            this.btKund.Location = new System.Drawing.Point(312, 339);
            this.btKund.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btKund.Name = "btKund";
            this.btKund.Size = new System.Drawing.Size(144, 58);
            this.btKund.TabIndex = 7;
            this.btKund.Text = "Välj kund";
            this.btKund.UseVisualStyleBackColor = true;
            this.btKund.Click += new System.EventHandler(this.btKund_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.gvÅterlämning);
            this.groupBox1.Controls.Add(this.tbSök);
            this.groupBox1.Controls.Add(this.btKund);
            this.groupBox1.Controls.Add(this.btnTillbaka);
            this.groupBox1.Controls.Add(this.btnSök);
            this.groupBox1.Controls.Add(this.btnÅterlämna);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 502);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Återlämning";
            // 
            // ButikÅterlämning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 587);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ButikÅterlämning";
            this.Text = "ButikÅterlämning";
            this.Load += new System.EventHandler(this.ButikÅterlämning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvÅterlämning)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSök;
        private System.Windows.Forms.DataGridView gvÅterlämning;
        private System.Windows.Forms.Button btnTillbaka;
        private System.Windows.Forms.Button btnÅterlämna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSök;
        private System.Windows.Forms.Button btKund;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}