
namespace GUI_Framework_v2
{
    partial class frmBokning
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
            this.btnBokaPrivat = new System.Windows.Forms.Button();
            this.btnBokaFöretag = new System.Windows.Forms.Button();
            this.btnBokningar = new System.Windows.Forms.Button();
            this.btnLoggaUt = new System.Windows.Forms.Button();
            this.btFakturor = new System.Windows.Forms.Button();
            this.btnPreToBoking = new System.Windows.Forms.Button();
            this.btBokningsbekräftelse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBokaPrivat
            // 
            this.btnBokaPrivat.Location = new System.Drawing.Point(29, 59);
            this.btnBokaPrivat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBokaPrivat.Name = "btnBokaPrivat";
            this.btnBokaPrivat.Size = new System.Drawing.Size(176, 72);
            this.btnBokaPrivat.TabIndex = 1;
            this.btnBokaPrivat.Text = "Boka Privat";
            this.btnBokaPrivat.UseVisualStyleBackColor = true;
            this.btnBokaPrivat.Click += new System.EventHandler(this.btnBokaPrivat_Click);
            // 
            // btnBokaFöretag
            // 
            this.btnBokaFöretag.Location = new System.Drawing.Point(220, 59);
            this.btnBokaFöretag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBokaFöretag.Name = "btnBokaFöretag";
            this.btnBokaFöretag.Size = new System.Drawing.Size(176, 72);
            this.btnBokaFöretag.TabIndex = 2;
            this.btnBokaFöretag.Text = "Boka Företag";
            this.btnBokaFöretag.UseVisualStyleBackColor = true;
            this.btnBokaFöretag.Click += new System.EventHandler(this.btnBokaFöretag_Click);
            // 
            // btnBokningar
            // 
            this.btnBokningar.Location = new System.Drawing.Point(220, 243);
            this.btnBokningar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBokningar.Name = "btnBokningar";
            this.btnBokningar.Size = new System.Drawing.Size(176, 55);
            this.btnBokningar.TabIndex = 3;
            this.btnBokningar.Text = "Bokningar";
            this.btnBokningar.UseVisualStyleBackColor = true;
            this.btnBokningar.Click += new System.EventHandler(this.btnBokningar_Click);
            // 
            // btnLoggaUt
            // 
            this.btnLoggaUt.Location = new System.Drawing.Point(220, 323);
            this.btnLoggaUt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoggaUt.Name = "btnLoggaUt";
            this.btnLoggaUt.Size = new System.Drawing.Size(176, 38);
            this.btnLoggaUt.TabIndex = 6;
            this.btnLoggaUt.Text = "Logga Ut";
            this.btnLoggaUt.UseVisualStyleBackColor = true;
            this.btnLoggaUt.Click += new System.EventHandler(this.btnLoggaUt_Click);
            // 
            // btFakturor
            // 
            this.btFakturor.Location = new System.Drawing.Point(29, 151);
            this.btFakturor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btFakturor.Name = "btFakturor";
            this.btFakturor.Size = new System.Drawing.Size(176, 72);
            this.btFakturor.TabIndex = 7;
            this.btFakturor.Text = "Utskrift fakturor";
            this.btFakturor.UseVisualStyleBackColor = true;
            this.btFakturor.Click += new System.EventHandler(this.btFakturor_Click);
            // 
            // btnPreToBoking
            // 
            this.btnPreToBoking.Location = new System.Drawing.Point(29, 243);
            this.btnPreToBoking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreToBoking.Name = "btnPreToBoking";
            this.btnPreToBoking.Size = new System.Drawing.Size(176, 55);
            this.btnPreToBoking.TabIndex = 8;
            this.btnPreToBoking.Text = "Preliminärbokningar";
            this.btnPreToBoking.UseVisualStyleBackColor = true;
            this.btnPreToBoking.Click += new System.EventHandler(this.btnPreToBoking_Click);
            // 
            // btBokningsbekräftelse
            // 
            this.btBokningsbekräftelse.Location = new System.Drawing.Point(220, 151);
            this.btBokningsbekräftelse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btBokningsbekräftelse.Name = "btBokningsbekräftelse";
            this.btBokningsbekräftelse.Size = new System.Drawing.Size(176, 72);
            this.btBokningsbekräftelse.TabIndex = 9;
            this.btBokningsbekräftelse.Text = "Utskrift Bokningsbekräftelser";
            this.btBokningsbekräftelse.UseVisualStyleBackColor = true;
            this.btBokningsbekräftelse.Click += new System.EventHandler(this.btBokningsbekräftelse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // frmBokning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 381);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btBokningsbekräftelse);
            this.Controls.Add(this.btnPreToBoking);
            this.Controls.Add(this.btFakturor);
            this.Controls.Add(this.btnLoggaUt);
            this.Controls.Add(this.btnBokningar);
            this.Controls.Add(this.btnBokaFöretag);
            this.Controls.Add(this.btnBokaPrivat);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBokning";
            this.Text = "frmBokning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBokaPrivat;
        private System.Windows.Forms.Button btnBokaFöretag;
        private System.Windows.Forms.Button btnBokningar;
        private System.Windows.Forms.Button btnLoggaUt;
        private System.Windows.Forms.Button btFakturor;
        private System.Windows.Forms.Button btnPreToBoking;
        private System.Windows.Forms.Button btBokningsbekräftelse;
        private System.Windows.Forms.Label label3;
    }
}