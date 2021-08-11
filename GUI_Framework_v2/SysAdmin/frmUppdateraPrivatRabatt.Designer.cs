
namespace GUI_Framework_v2
{
    partial class frmUppdateraPrivatRabatt
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
            this.frmTillbaka = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbRabatt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // frmTillbaka
            // 
            this.frmTillbaka.Location = new System.Drawing.Point(45, 214);
            this.frmTillbaka.Name = "frmTillbaka";
            this.frmTillbaka.Size = new System.Drawing.Size(212, 30);
            this.frmTillbaka.TabIndex = 0;
            this.frmTillbaka.Text = "Tillbaka";
            this.frmTillbaka.UseVisualStyleBackColor = true;
            this.frmTillbaka.Click += new System.EventHandler(this.frmTillbaka_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Uppdatera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbRabatt
            // 
            this.tbRabatt.Location = new System.Drawing.Point(45, 146);
            this.tbRabatt.Name = "tbRabatt";
            this.tbRabatt.Size = new System.Drawing.Size(212, 26);
            this.tbRabatt.TabIndex = 2;
            this.tbRabatt.TextChanged += new System.EventHandler(this.tbRabatt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Uppdatera rabatt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Skriv in rabbaten i procent.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ex: 20. Detta representerar 20%.";
            // 
            // frmUppdateraPrivatRabatt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 296);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRabatt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.frmTillbaka);
            this.Name = "frmUppdateraPrivatRabatt";
            this.Text = "Uppdatera Rabatt För PrivatKund";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button frmTillbaka;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbRabatt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}