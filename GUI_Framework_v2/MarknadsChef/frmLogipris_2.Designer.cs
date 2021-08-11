
namespace GUI_Framework_v2
{
    partial class frmLogipris_2
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
            this.tbLogiPris = new System.Windows.Forms.TextBox();
            this.btnändra = new System.Windows.Forms.Button();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.gvlogipris = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvlogipris)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLogiPris
            // 
            this.tbLogiPris.Location = new System.Drawing.Point(369, 425);
            this.tbLogiPris.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLogiPris.Name = "tbLogiPris";
            this.tbLogiPris.Size = new System.Drawing.Size(153, 22);
            this.tbLogiPris.TabIndex = 7;
            this.tbLogiPris.TextChanged += new System.EventHandler(this.tbLogiPris_TextChanged);
            // 
            // btnändra
            // 
            this.btnändra.Location = new System.Drawing.Point(546, 425);
            this.btnändra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnändra.Name = "btnändra";
            this.btnändra.Size = new System.Drawing.Size(94, 27);
            this.btnändra.TabIndex = 6;
            this.btnändra.Text = "Ändra";
            this.btnändra.UseVisualStyleBackColor = true;
            this.btnändra.Click += new System.EventHandler(this.btnändra_Click);
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(657, 425);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(94, 27);
            this.btntillbaka.TabIndex = 5;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // gvlogipris
            // 
            this.gvlogipris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvlogipris.Location = new System.Drawing.Point(12, 49);
            this.gvlogipris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gvlogipris.Name = "gvlogipris";
            this.gvlogipris.RowHeadersWidth = 51;
            this.gvlogipris.RowTemplate.Height = 24;
            this.gvlogipris.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvlogipris.Size = new System.Drawing.Size(739, 363);
            this.gvlogipris.TabIndex = 4;
            this.gvlogipris.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglogipris_CellContentClick);
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
            // frmLogipris_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 489);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLogiPris);
            this.Controls.Add(this.btnändra);
            this.Controls.Add(this.btntillbaka);
            this.Controls.Add(this.gvlogipris);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLogipris_2";
            this.Text = "frmLogipris_2";
            ((System.ComponentModel.ISupportInitialize)(this.gvlogipris)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogiPris;
        private System.Windows.Forms.Button btnändra;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.DataGridView gvlogipris;
        private System.Windows.Forms.Label label3;
    }
}