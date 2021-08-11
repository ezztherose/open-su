
namespace GUI_Framework_v2
{
    partial class frmLogin_2
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
            this.btnavsluta = new System.Windows.Forms.Button();
            this.btnLoggin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLösen = new System.Windows.Forms.TextBox();
            this.tbAnvändare = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(189, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 36);
            this.label3.TabIndex = 20;
            this.label3.Text = "Ski-Center";
            // 
            // btnavsluta
            // 
            this.btnavsluta.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnavsluta.Location = new System.Drawing.Point(332, 130);
            this.btnavsluta.Margin = new System.Windows.Forms.Padding(2);
            this.btnavsluta.Name = "btnavsluta";
            this.btnavsluta.Size = new System.Drawing.Size(90, 29);
            this.btnavsluta.TabIndex = 19;
            this.btnavsluta.Text = "Avsluta";
            this.btnavsluta.UseVisualStyleBackColor = false;
            this.btnavsluta.Click += new System.EventHandler(this.btnavsluta_Click);
            // 
            // btnLoggin
            // 
            this.btnLoggin.BackColor = System.Drawing.Color.Lime;
            this.btnLoggin.Location = new System.Drawing.Point(195, 130);
            this.btnLoggin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoggin.Name = "btnLoggin";
            this.btnLoggin.Size = new System.Drawing.Size(132, 29);
            this.btnLoggin.TabIndex = 18;
            this.btnLoggin.Text = "Logga in";
            this.btnLoggin.UseVisualStyleBackColor = false;
            this.btnLoggin.Click += new System.EventHandler(this.btnLoggin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Lösenord";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Användarnamn";
            // 
            // tbLösen
            // 
            this.tbLösen.Location = new System.Drawing.Point(195, 102);
            this.tbLösen.Margin = new System.Windows.Forms.Padding(2);
            this.tbLösen.Multiline = true;
            this.tbLösen.Name = "tbLösen";
            this.tbLösen.PasswordChar = '*';
            this.tbLösen.Size = new System.Drawing.Size(228, 25);
            this.tbLösen.TabIndex = 15;
            this.tbLösen.TextChanged += new System.EventHandler(this.tbLösen_TextChanged);
            this.tbLösen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLösen_KeyDown);
            // 
            // tbAnvändare
            // 
            this.tbAnvändare.Location = new System.Drawing.Point(195, 66);
            this.tbAnvändare.Margin = new System.Windows.Forms.Padding(2);
            this.tbAnvändare.Multiline = true;
            this.tbAnvändare.Name = "tbAnvändare";
            this.tbAnvändare.Size = new System.Drawing.Size(228, 25);
            this.tbAnvändare.TabIndex = 14;
            this.tbAnvändare.TextChanged += new System.EventHandler(this.tbAnvändare_TextChanged);
            // 
            // frmLogin_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 202);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnavsluta);
            this.Controls.Add(this.btnLoggin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLösen);
            this.Controls.Add(this.tbAnvändare);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLogin_2";
            this.Text = "frmLogin_2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnavsluta;
        private System.Windows.Forms.Button btnLoggin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLösen;
        private System.Windows.Forms.TextBox tbAnvändare;
    }
}