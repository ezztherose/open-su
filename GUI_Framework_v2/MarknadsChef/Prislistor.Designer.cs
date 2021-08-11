namespace GUI_Framework_v2
{
    partial class Prislistor
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnkonferenspriser = new System.Windows.Forms.Button();
            this.btnhyrpriser = new System.Windows.Forms.Button();
            this.btnlogipriser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.btnkonferenspriser);
            this.groupBox3.Controls.Add(this.btnhyrpriser);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnlogipriser);
            this.groupBox3.Location = new System.Drawing.Point(30, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 165);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // btnkonferenspriser
            // 
            this.btnkonferenspriser.Location = new System.Drawing.Point(312, 75);
            this.btnkonferenspriser.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnkonferenspriser.Name = "btnkonferenspriser";
            this.btnkonferenspriser.Size = new System.Drawing.Size(141, 43);
            this.btnkonferenspriser.TabIndex = 8;
            this.btnkonferenspriser.Text = "Konferenspriser";
            this.btnkonferenspriser.UseVisualStyleBackColor = true;
            this.btnkonferenspriser.Click += new System.EventHandler(this.btnkonferenspriser_Click);
            // 
            // btnhyrpriser
            // 
            this.btnhyrpriser.Location = new System.Drawing.Point(170, 75);
            this.btnhyrpriser.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnhyrpriser.Name = "btnhyrpriser";
            this.btnhyrpriser.Size = new System.Drawing.Size(93, 43);
            this.btnhyrpriser.TabIndex = 7;
            this.btnhyrpriser.Text = "Hyrpriser";
            this.btnhyrpriser.UseVisualStyleBackColor = true;
            this.btnhyrpriser.Click += new System.EventHandler(this.btnhyrpriser_Click);
            // 
            // btnlogipriser
            // 
            this.btnlogipriser.Location = new System.Drawing.Point(21, 75);
            this.btnlogipriser.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnlogipriser.Name = "btnlogipriser";
            this.btnlogipriser.Size = new System.Drawing.Size(105, 43);
            this.btnlogipriser.TabIndex = 6;
            this.btnlogipriser.Text = "Logipriser";
            this.btnlogipriser.UseVisualStyleBackColor = true;
            this.btnlogipriser.Click += new System.EventHandler(this.btnlogipriser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Prislistor";
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(30, 270);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(141, 43);
            this.btntillbaka.TabIndex = 14;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 40);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ski-Center";
            // 
            // Prislistor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(549, 340);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btntillbaka);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Prislistor";
            this.Text = "Prislistor";
            this.Load += new System.EventHandler(this.Prislistor_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnkonferenspriser;
        private System.Windows.Forms.Button btnhyrpriser;
        private System.Windows.Forms.Button btnlogipriser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label3;
    }
}