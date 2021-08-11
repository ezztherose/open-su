namespace GUI_Framework_v2
{
    partial class Preliminärbokningar
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
            this.btnsök = new System.Windows.Forms.Button();
            this.btnavslåbokning = new System.Windows.Forms.Button();
            this.btngodkändbokning = new System.Windows.Forms.Button();
            this.tbpreliminärbokningar = new System.Windows.Forms.TextBox();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Bokningar = new System.Windows.Forms.GroupBox();
            this.gvpbokning = new System.Windows.Forms.DataGridView();
            this.Bokningar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvpbokning)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsök
            // 
            this.btnsök.Location = new System.Drawing.Point(252, 44);
            this.btnsök.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsök.Name = "btnsök";
            this.btnsök.Size = new System.Drawing.Size(100, 28);
            this.btnsök.TabIndex = 0;
            this.btnsök.Text = "Sök";
            this.btnsök.UseVisualStyleBackColor = true;
            this.btnsök.Click += new System.EventHandler(this.btnsök_Click);
            // 
            // btnavslåbokning
            // 
            this.btnavslåbokning.Location = new System.Drawing.Point(371, 266);
            this.btnavslåbokning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnavslåbokning.Name = "btnavslåbokning";
            this.btnavslåbokning.Size = new System.Drawing.Size(151, 28);
            this.btnavslåbokning.TabIndex = 2;
            this.btnavslåbokning.Text = "Avslå bokning";
            this.btnavslåbokning.UseVisualStyleBackColor = true;
            this.btnavslåbokning.Click += new System.EventHandler(this.button2_Click);
            // 
            // btngodkändbokning
            // 
            this.btngodkändbokning.Location = new System.Drawing.Point(529, 266);
            this.btngodkändbokning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btngodkändbokning.Name = "btngodkändbokning";
            this.btngodkändbokning.Size = new System.Drawing.Size(151, 28);
            this.btngodkändbokning.TabIndex = 3;
            this.btngodkändbokning.Text = "Godkänn bokning";
            this.btngodkändbokning.UseVisualStyleBackColor = true;
            this.btngodkändbokning.Click += new System.EventHandler(this.btngodkändbokning_Click);
            // 
            // tbpreliminärbokningar
            // 
            this.tbpreliminärbokningar.Location = new System.Drawing.Point(33, 48);
            this.tbpreliminärbokningar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbpreliminärbokningar.Name = "tbpreliminärbokningar";
            this.tbpreliminärbokningar.Size = new System.Drawing.Size(132, 22);
            this.tbpreliminärbokningar.TabIndex = 4;
            this.tbpreliminärbokningar.TextChanged += new System.EventHandler(this.tbpreliminärbokningar_TextChanged);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(33, 298);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(100, 28);
            this.btntillbaka.TabIndex = 6;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ski-Center";
            // 
            // Bokningar
            // 
            this.Bokningar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Bokningar.Controls.Add(this.gvpbokning);
            this.Bokningar.Controls.Add(this.tbpreliminärbokningar);
            this.Bokningar.Controls.Add(this.btnsök);
            this.Bokningar.Controls.Add(this.btntillbaka);
            this.Bokningar.Controls.Add(this.btnavslåbokning);
            this.Bokningar.Controls.Add(this.btngodkändbokning);
            this.Bokningar.Location = new System.Drawing.Point(17, 50);
            this.Bokningar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bokningar.Name = "Bokningar";
            this.Bokningar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bokningar.Size = new System.Drawing.Size(728, 347);
            this.Bokningar.TabIndex = 13;
            this.Bokningar.TabStop = false;
            this.Bokningar.Text = "Preliminärbokarna";
            // 
            // gvpbokning
            // 
            this.gvpbokning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvpbokning.Location = new System.Drawing.Point(33, 108);
            this.gvpbokning.Name = "gvpbokning";
            this.gvpbokning.RowHeadersWidth = 51;
            this.gvpbokning.RowTemplate.Height = 24;
            this.gvpbokning.Size = new System.Drawing.Size(647, 150);
            this.gvpbokning.TabIndex = 7;
            // 
            // Preliminärbokningar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 422);
            this.Controls.Add(this.Bokningar);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Preliminärbokningar";
            this.Text = "Preliminärbokningar";
            this.Load += new System.EventHandler(this.Preliminärbokningar_Load);
            this.Bokningar.ResumeLayout(false);
            this.Bokningar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvpbokning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsök;
        private System.Windows.Forms.Button btnavslåbokning;
        private System.Windows.Forms.Button btngodkändbokning;
        private System.Windows.Forms.TextBox tbpreliminärbokningar;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Bokningar;
        private System.Windows.Forms.DataGridView gvpbokning;
    }
}