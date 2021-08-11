namespace GUI_Framework_v2.Boka
{
    partial class utskriftfaktura
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
            this.gvFakturor = new System.Windows.Forms.DataGridView();
            this.btTillbaka = new System.Windows.Forms.Button();
            this.btUtskriftAlla = new System.Windows.Forms.Button();
            this.btUtskriftEnskild = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvFakturor)).BeginInit();
            this.SuspendLayout();
            // 
            // gvFakturor
            // 
            this.gvFakturor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFakturor.Location = new System.Drawing.Point(60, 47);
            this.gvFakturor.Name = "gvFakturor";
            this.gvFakturor.RowHeadersWidth = 51;
            this.gvFakturor.RowTemplate.Height = 24;
            this.gvFakturor.Size = new System.Drawing.Size(673, 250);
            this.gvFakturor.TabIndex = 0;
            // 
            // btTillbaka
            // 
            this.btTillbaka.Location = new System.Drawing.Point(60, 373);
            this.btTillbaka.Name = "btTillbaka";
            this.btTillbaka.Size = new System.Drawing.Size(119, 44);
            this.btTillbaka.TabIndex = 2;
            this.btTillbaka.Text = "Tillbaka";
            this.btTillbaka.UseVisualStyleBackColor = true;
            this.btTillbaka.Click += new System.EventHandler(this.btTillbaka_Click);
            // 
            // btUtskriftAlla
            // 
            this.btUtskriftAlla.Location = new System.Drawing.Point(614, 373);
            this.btUtskriftAlla.Name = "btUtskriftAlla";
            this.btUtskriftAlla.Size = new System.Drawing.Size(119, 44);
            this.btUtskriftAlla.TabIndex = 3;
            this.btUtskriftAlla.Text = "Skriv ut alla";
            this.btUtskriftAlla.UseVisualStyleBackColor = true;
            this.btUtskriftAlla.Click += new System.EventHandler(this.btUtskriftAlla_Click);
            // 
            // btUtskriftEnskild
            // 
            this.btUtskriftEnskild.Location = new System.Drawing.Point(471, 373);
            this.btUtskriftEnskild.Name = "btUtskriftEnskild";
            this.btUtskriftEnskild.Size = new System.Drawing.Size(119, 44);
            this.btUtskriftEnskild.TabIndex = 4;
            this.btUtskriftEnskild.Text = "Skriv ut enskild";
            this.btUtskriftEnskild.UseVisualStyleBackColor = true;
            this.btUtskriftEnskild.Click += new System.EventHandler(this.btUtskriftEnskild_Click);
            // 
            // utskriftfaktura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btUtskriftEnskild);
            this.Controls.Add(this.btUtskriftAlla);
            this.Controls.Add(this.btTillbaka);
            this.Controls.Add(this.gvFakturor);
            this.Name = "utskriftfaktura";
            this.Text = "utskriftfaktura";
            ((System.ComponentModel.ISupportInitialize)(this.gvFakturor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFakturor;
        private System.Windows.Forms.Button btTillbaka;
        private System.Windows.Forms.Button btUtskriftAlla;
        private System.Windows.Forms.Button btUtskriftEnskild;
    }
}