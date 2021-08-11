
namespace GUI_Framework_v2
{
    partial class frmButikMeny
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
            this.btnSkidskolaPrivat = new System.Windows.Forms.Button();
            this.btnSkidskolaGrupp = new System.Windows.Forms.Button();
            this.btnSkiduthyrning = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnÅterlämning = new System.Windows.Forms.Button();
            this.btnLoggaUt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSkidskolaPrivat
            // 
            this.btnSkidskolaPrivat.Location = new System.Drawing.Point(12, 72);
            this.btnSkidskolaPrivat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSkidskolaPrivat.Name = "btnSkidskolaPrivat";
            this.btnSkidskolaPrivat.Size = new System.Drawing.Size(176, 72);
            this.btnSkidskolaPrivat.TabIndex = 1;
            this.btnSkidskolaPrivat.Text = "Skidskola Privat";
            this.btnSkidskolaPrivat.UseVisualStyleBackColor = true;
            this.btnSkidskolaPrivat.Click += new System.EventHandler(this.btnSkidskolaPrivat_Click);
            // 
            // btnSkidskolaGrupp
            // 
            this.btnSkidskolaGrupp.Location = new System.Drawing.Point(194, 72);
            this.btnSkidskolaGrupp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSkidskolaGrupp.Name = "btnSkidskolaGrupp";
            this.btnSkidskolaGrupp.Size = new System.Drawing.Size(176, 72);
            this.btnSkidskolaGrupp.TabIndex = 2;
            this.btnSkidskolaGrupp.Text = "Skidskola Grupp";
            this.btnSkidskolaGrupp.UseVisualStyleBackColor = true;
            this.btnSkidskolaGrupp.Click += new System.EventHandler(this.btnSkidskolaGrupp_Click);
            // 
            // btnSkiduthyrning
            // 
            this.btnSkiduthyrning.Location = new System.Drawing.Point(12, 158);
            this.btnSkiduthyrning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSkiduthyrning.Name = "btnSkiduthyrning";
            this.btnSkiduthyrning.Size = new System.Drawing.Size(176, 72);
            this.btnSkiduthyrning.TabIndex = 3;
            this.btnSkiduthyrning.Text = "Skiduthyrning";
            this.btnSkiduthyrning.UseVisualStyleBackColor = true;
            this.btnSkiduthyrning.Click += new System.EventHandler(this.btnSkiduthyrning_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(194, 158);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(176, 72);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Butiksregister";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnÅterlämning
            // 
            this.btnÅterlämning.Location = new System.Drawing.Point(105, 246);
            this.btnÅterlämning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnÅterlämning.Name = "btnÅterlämning";
            this.btnÅterlämning.Size = new System.Drawing.Size(176, 72);
            this.btnÅterlämning.TabIndex = 5;
            this.btnÅterlämning.Text = "Återlämning";
            this.btnÅterlämning.UseVisualStyleBackColor = true;
            this.btnÅterlämning.Click += new System.EventHandler(this.btnÅterlämning_Click);
            // 
            // btnLoggaUt
            // 
            this.btnLoggaUt.Location = new System.Drawing.Point(228, 345);
            this.btnLoggaUt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoggaUt.Name = "btnLoggaUt";
            this.btnLoggaUt.Size = new System.Drawing.Size(176, 34);
            this.btnLoggaUt.TabIndex = 6;
            this.btnLoggaUt.Text = "Logga ut";
            this.btnLoggaUt.UseVisualStyleBackColor = true;
            this.btnLoggaUt.Click += new System.EventHandler(this.btnLoggaUt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // frmButikMeny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 402);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoggaUt);
            this.Controls.Add(this.btnÅterlämning);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnSkiduthyrning);
            this.Controls.Add(this.btnSkidskolaGrupp);
            this.Controls.Add(this.btnSkidskolaPrivat);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmButikMeny";
            this.Text = "frmButikMeny";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSkidskolaPrivat;
        private System.Windows.Forms.Button btnSkidskolaGrupp;
        private System.Windows.Forms.Button btnSkiduthyrning;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnÅterlämning;
        private System.Windows.Forms.Button btnLoggaUt;
        private System.Windows.Forms.Label label3;
    }
}