
namespace GUI_Framework_v2
{
    partial class frmGodkännaPreBokningar
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
            this.dgvPreBoknings = new System.Windows.Forms.DataGridView();
            this.btnTillbaka = new System.Windows.Forms.Button();
            this.btnBoka = new System.Windows.Forms.Button();
            this.gbPreToBoking = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreBoknings)).BeginInit();
            this.gbPreToBoking.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPreBoknings
            // 
            this.dgvPreBoknings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreBoknings.Location = new System.Drawing.Point(20, 55);
            this.dgvPreBoknings.Name = "dgvPreBoknings";
            this.dgvPreBoknings.RowHeadersWidth = 62;
            this.dgvPreBoknings.RowTemplate.Height = 28;
            this.dgvPreBoknings.Size = new System.Drawing.Size(645, 238);
            this.dgvPreBoknings.TabIndex = 0;
            // 
            // btnTillbaka
            // 
            this.btnTillbaka.Location = new System.Drawing.Point(20, 299);
            this.btnTillbaka.Name = "btnTillbaka";
            this.btnTillbaka.Size = new System.Drawing.Size(101, 47);
            this.btnTillbaka.TabIndex = 1;
            this.btnTillbaka.Text = "Tillbaka";
            this.btnTillbaka.UseVisualStyleBackColor = true;
            this.btnTillbaka.Click += new System.EventHandler(this.btnTillbaka_Click);
            // 
            // btnBoka
            // 
            this.btnBoka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoka.Location = new System.Drawing.Point(512, 299);
            this.btnBoka.Name = "btnBoka";
            this.btnBoka.Size = new System.Drawing.Size(153, 47);
            this.btnBoka.TabIndex = 2;
            this.btnBoka.Text = "Boka";
            this.btnBoka.UseVisualStyleBackColor = true;
            this.btnBoka.Click += new System.EventHandler(this.btnBoka_Click);
            // 
            // gbPreToBoking
            // 
            this.gbPreToBoking.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbPreToBoking.Controls.Add(this.btnAll);
            this.gbPreToBoking.Controls.Add(this.dgvPreBoknings);
            this.gbPreToBoking.Controls.Add(this.btnBoka);
            this.gbPreToBoking.Controls.Add(this.btnTillbaka);
            this.gbPreToBoking.Location = new System.Drawing.Point(12, 81);
            this.gbPreToBoking.Name = "gbPreToBoking";
            this.gbPreToBoking.Size = new System.Drawing.Size(711, 427);
            this.gbPreToBoking.TabIndex = 3;
            this.gbPreToBoking.TabStop = false;
            this.gbPreToBoking.Text = "Skapa Bokningar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 40);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ski-Center";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(381, 299);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(125, 47);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "Boka alla";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // frmGodkännaPreBokningar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 587);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbPreToBoking);
            this.Name = "frmGodkännaPreBokningar";
            this.Text = "frmGodkännaPreBokningar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreBoknings)).EndInit();
            this.gbPreToBoking.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreBoknings;
        private System.Windows.Forms.Button btnTillbaka;
        private System.Windows.Forms.Button btnBoka;
        private System.Windows.Forms.GroupBox gbPreToBoking;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAll;
    }
}