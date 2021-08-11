
namespace GUI_Framework_v2
{
    partial class frmHyrpris_2
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
            this.tbHyrpris = new System.Windows.Forms.TextBox();
            this.btnändra = new System.Windows.Forms.Button();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.dghyrpris = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dghyrpris)).BeginInit();
            this.SuspendLayout();
            // 
            // tbHyrpris
            // 
            this.tbHyrpris.Location = new System.Drawing.Point(493, 425);
            this.tbHyrpris.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbHyrpris.Name = "tbHyrpris";
            this.tbHyrpris.Size = new System.Drawing.Size(152, 22);
            this.tbHyrpris.TabIndex = 8;
            this.tbHyrpris.TextChanged += new System.EventHandler(this.tbHyrpris_TextChanged);
            // 
            // btnändra
            // 
            this.btnändra.Location = new System.Drawing.Point(662, 425);
            this.btnändra.Name = "btnändra";
            this.btnändra.Size = new System.Drawing.Size(95, 27);
            this.btnändra.TabIndex = 7;
            this.btnändra.Text = "Ändra";
            this.btnändra.UseVisualStyleBackColor = true;
            this.btnändra.Click += new System.EventHandler(this.btnändra_Click);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(21, 420);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(95, 27);
            this.btntillbaka.TabIndex = 6;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // dghyrpris
            // 
            this.dghyrpris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dghyrpris.Location = new System.Drawing.Point(12, 51);
            this.dghyrpris.Name = "dghyrpris";
            this.dghyrpris.RowHeadersWidth = 51;
            this.dghyrpris.RowTemplate.Height = 24;
            this.dghyrpris.Size = new System.Drawing.Size(746, 363);
            this.dghyrpris.TabIndex = 5;
            this.dghyrpris.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dghyrpris_CellContentClick);
            this.dghyrpris.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dghyrpris_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nytt pris:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ski-Center";
            // 
            // frmHyrpris_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 492);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbHyrpris);
            this.Controls.Add(this.btnändra);
            this.Controls.Add(this.btntillbaka);
            this.Controls.Add(this.dghyrpris);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmHyrpris_2";
            this.Text = "frmHyrpris_2";
            ((System.ComponentModel.ISupportInitialize)(this.dghyrpris)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHyrpris;
        private System.Windows.Forms.Button btnändra;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.DataGridView dghyrpris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}