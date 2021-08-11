
namespace GUI_Framework_v2
{
    partial class frmRegister
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnkundregister = new System.Windows.Forms.Button();
            this.btnuthyrningsregister = new System.Windows.Forms.Button();
            this.btnfakturaregister = new System.Windows.Forms.Button();
            this.btnbokningsregister = new System.Windows.Forms.Button();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ski-Center";
            // 
            // btnkundregister
            // 
            this.btnkundregister.Location = new System.Drawing.Point(81, 99);
            this.btnkundregister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnkundregister.Name = "btnkundregister";
            this.btnkundregister.Size = new System.Drawing.Size(161, 36);
            this.btnkundregister.TabIndex = 20;
            this.btnkundregister.Text = "Kundregister";
            this.btnkundregister.UseVisualStyleBackColor = true;
            this.btnkundregister.Click += new System.EventHandler(this.btnkundregister_Click);
            // 
            // btnuthyrningsregister
            // 
            this.btnuthyrningsregister.Location = new System.Drawing.Point(81, 138);
            this.btnuthyrningsregister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnuthyrningsregister.Name = "btnuthyrningsregister";
            this.btnuthyrningsregister.Size = new System.Drawing.Size(161, 41);
            this.btnuthyrningsregister.TabIndex = 21;
            this.btnuthyrningsregister.Text = "Uthyrningsregister";
            this.btnuthyrningsregister.UseVisualStyleBackColor = true;
            this.btnuthyrningsregister.Click += new System.EventHandler(this.btnuthyrningsregister_Click);
            // 
            // btnfakturaregister
            // 
            this.btnfakturaregister.Location = new System.Drawing.Point(245, 99);
            this.btnfakturaregister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnfakturaregister.Name = "btnfakturaregister";
            this.btnfakturaregister.Size = new System.Drawing.Size(157, 36);
            this.btnfakturaregister.TabIndex = 22;
            this.btnfakturaregister.Text = "Fakturaregister";
            this.btnfakturaregister.UseVisualStyleBackColor = true;
            this.btnfakturaregister.Click += new System.EventHandler(this.btnfakturaregister_Click);
            // 
            // btnbokningsregister
            // 
            this.btnbokningsregister.Location = new System.Drawing.Point(245, 138);
            this.btnbokningsregister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnbokningsregister.Name = "btnbokningsregister";
            this.btnbokningsregister.Size = new System.Drawing.Size(157, 41);
            this.btnbokningsregister.TabIndex = 23;
            this.btnbokningsregister.Text = "Bokningsregister";
            this.btnbokningsregister.UseVisualStyleBackColor = true;
            this.btnbokningsregister.Click += new System.EventHandler(this.btnbokningsregister_Click);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(273, 234);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(130, 30);
            this.btntillbaka.TabIndex = 24;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 295);
            this.Controls.Add(this.btntillbaka);
            this.Controls.Add(this.btnbokningsregister);
            this.Controls.Add(this.btnfakturaregister);
            this.Controls.Add(this.btnuthyrningsregister);
            this.Controls.Add(this.btnkundregister);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmRegister";
            this.Text = "frmRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnkundregister;
        private System.Windows.Forms.Button btnuthyrningsregister;
        private System.Windows.Forms.Button btnfakturaregister;
        private System.Windows.Forms.Button btnbokningsregister;
        private System.Windows.Forms.Button btntillbaka;
    }
}