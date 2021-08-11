namespace GUI_Framework_v2.Boka
{
    partial class frmUtskriftBokningsbekräftelse
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
            this.btUtskriftEnskild = new System.Windows.Forms.Button();
            this.btUtskriftAlla = new System.Windows.Forms.Button();
            this.btTillbaka = new System.Windows.Forms.Button();
            this.gvBokningsbekräftelser = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvBokningsbekräftelser)).BeginInit();
            this.SuspendLayout();
            // 
            // btUtskriftEnskild
            // 
            this.btUtskriftEnskild.Location = new System.Drawing.Point(473, 363);
            this.btUtskriftEnskild.Name = "btUtskriftEnskild";
            this.btUtskriftEnskild.Size = new System.Drawing.Size(119, 44);
            this.btUtskriftEnskild.TabIndex = 8;
            this.btUtskriftEnskild.Text = "Skriv ut enskild";
            this.btUtskriftEnskild.UseVisualStyleBackColor = true;
            this.btUtskriftEnskild.Click += new System.EventHandler(this.btUtskriftEnskild_Click);
            // 
            // btUtskriftAlla
            // 
            this.btUtskriftAlla.Location = new System.Drawing.Point(616, 363);
            this.btUtskriftAlla.Name = "btUtskriftAlla";
            this.btUtskriftAlla.Size = new System.Drawing.Size(119, 44);
            this.btUtskriftAlla.TabIndex = 7;
            this.btUtskriftAlla.Text = "Skriv ut alla";
            this.btUtskriftAlla.UseVisualStyleBackColor = true;
            this.btUtskriftAlla.Click += new System.EventHandler(this.btUtskriftAlla_Click);
            // 
            // btTillbaka
            // 
            this.btTillbaka.Location = new System.Drawing.Point(62, 363);
            this.btTillbaka.Name = "btTillbaka";
            this.btTillbaka.Size = new System.Drawing.Size(119, 44);
            this.btTillbaka.TabIndex = 6;
            this.btTillbaka.Text = "Tillbaka";
            this.btTillbaka.UseVisualStyleBackColor = true;
            this.btTillbaka.Click += new System.EventHandler(this.btTillbaka_Click);
            // 
            // gvBokningsbekräftelser
            // 
            this.gvBokningsbekräftelser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBokningsbekräftelser.Location = new System.Drawing.Point(62, 77);
            this.gvBokningsbekräftelser.Name = "gvBokningsbekräftelser";
            this.gvBokningsbekräftelser.RowHeadersWidth = 51;
            this.gvBokningsbekräftelser.RowTemplate.Height = 24;
            this.gvBokningsbekräftelser.Size = new System.Drawing.Size(673, 250);
            this.gvBokningsbekräftelser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // frmUtskriftBokningsbekräftelse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btUtskriftEnskild);
            this.Controls.Add(this.btUtskriftAlla);
            this.Controls.Add(this.btTillbaka);
            this.Controls.Add(this.gvBokningsbekräftelser);
            this.Name = "frmUtskriftBokningsbekräftelse";
            this.Text = "frmUtskriftBokningsbekräftelse";
            ((System.ComponentModel.ISupportInitialize)(this.gvBokningsbekräftelser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btUtskriftEnskild;
        private System.Windows.Forms.Button btUtskriftAlla;
        private System.Windows.Forms.Button btTillbaka;
        private System.Windows.Forms.DataGridView gvBokningsbekräftelser;
        private System.Windows.Forms.Label label3;
    }
}