namespace GUI_Framework_v2
{
    partial class BelStatistik
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLogialternativ = new System.Windows.Forms.ComboBox();
            this.cbSlutVecka = new System.Windows.Forms.ComboBox();
            this.cbSlutÅr = new System.Windows.Forms.ComboBox();
            this.rbMånad = new System.Windows.Forms.RadioButton();
            this.rbVecka = new System.Windows.Forms.RadioButton();
            this.cbMånad = new System.Windows.Forms.ComboBox();
            this.btVälj = new System.Windows.Forms.Button();
            this.gvBeStatic = new System.Windows.Forms.DataGridView();
            this.cbStartMånad = new System.Windows.Forms.ComboBox();
            this.cbStartVecka = new System.Windows.Forms.ComboBox();
            this.btnExporteraTillExellbt = new System.Windows.Forms.Button();
            this.cbStartår = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btntillbaka = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logiBokningBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBeStatic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logiBokningBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.cbLogialternativ);
            this.groupBox1.Controls.Add(this.btntillbaka);
            this.groupBox1.Controls.Add(this.cbSlutVecka);
            this.groupBox1.Controls.Add(this.cbSlutÅr);
            this.groupBox1.Controls.Add(this.rbMånad);
            this.groupBox1.Controls.Add(this.rbVecka);
            this.groupBox1.Controls.Add(this.cbMånad);
            this.groupBox1.Controls.Add(this.btVälj);
            this.groupBox1.Controls.Add(this.gvBeStatic);
            this.groupBox1.Controls.Add(this.cbStartMånad);
            this.groupBox1.Controls.Add(this.cbStartVecka);
            this.groupBox1.Controls.Add(this.btnExporteraTillExellbt);
            this.groupBox1.Controls.Add(this.cbStartår);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(765, 552);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Beläggningsstatistik";
            // 
            // cbLogialternativ
            // 
            this.cbLogialternativ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLogialternativ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLogialternativ.FormattingEnabled = true;
            this.cbLogialternativ.Location = new System.Drawing.Point(583, 102);
            this.cbLogialternativ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLogialternativ.Name = "cbLogialternativ";
            this.cbLogialternativ.Size = new System.Drawing.Size(125, 28);
            this.cbLogialternativ.TabIndex = 32;
            this.cbLogialternativ.Text = "Logialternativ";
            // 
            // cbSlutVecka
            // 
            this.cbSlutVecka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSlutVecka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSlutVecka.FormattingEnabled = true;
            this.cbSlutVecka.Location = new System.Drawing.Point(293, 105);
            this.cbSlutVecka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSlutVecka.Name = "cbSlutVecka";
            this.cbSlutVecka.Size = new System.Drawing.Size(136, 28);
            this.cbSlutVecka.TabIndex = 31;
            this.cbSlutVecka.Text = "Vecka";
            // 
            // cbSlutÅr
            // 
            this.cbSlutÅr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSlutÅr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSlutÅr.FormattingEnabled = true;
            this.cbSlutÅr.Location = new System.Drawing.Point(293, 70);
            this.cbSlutÅr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSlutÅr.Name = "cbSlutÅr";
            this.cbSlutÅr.Size = new System.Drawing.Size(136, 28);
            this.cbSlutÅr.TabIndex = 30;
            this.cbSlutÅr.Text = "Slutår";
            // 
            // rbMånad
            // 
            this.rbMånad.AutoSize = true;
            this.rbMånad.Location = new System.Drawing.Point(109, 37);
            this.rbMånad.Name = "rbMånad";
            this.rbMånad.Size = new System.Drawing.Size(83, 24);
            this.rbMånad.TabIndex = 29;
            this.rbMånad.TabStop = true;
            this.rbMånad.Text = "Månad";
            this.rbMånad.UseVisualStyleBackColor = true;
            this.rbMånad.CheckedChanged += new System.EventHandler(this.rbMånad_CheckedChanged);
            // 
            // rbVecka
            // 
            this.rbVecka.AutoSize = true;
            this.rbVecka.Location = new System.Drawing.Point(26, 37);
            this.rbVecka.Name = "rbVecka";
            this.rbVecka.Size = new System.Drawing.Size(79, 24);
            this.rbVecka.TabIndex = 28;
            this.rbVecka.TabStop = true;
            this.rbVecka.Text = "Vecka";
            this.rbVecka.UseVisualStyleBackColor = true;
            this.rbVecka.CheckedChanged += new System.EventHandler(this.rbVecka_CheckedChanged);
            // 
            // cbMånad
            // 
            this.cbMånad.FormattingEnabled = true;
            this.cbMånad.Location = new System.Drawing.Point(293, 140);
            this.cbMånad.Name = "cbMånad";
            this.cbMånad.Size = new System.Drawing.Size(136, 28);
            this.cbMånad.TabIndex = 27;
            this.cbMånad.Text = "Månad";
            // 
            // btVälj
            // 
            this.btVälj.Location = new System.Drawing.Point(583, 137);
            this.btVälj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btVälj.Name = "btVälj";
            this.btVälj.Size = new System.Drawing.Size(126, 33);
            this.btVälj.TabIndex = 26;
            this.btVälj.Text = "Välj";
            this.btVälj.UseVisualStyleBackColor = true;
            this.btVälj.Click += new System.EventHandler(this.btVälj_Click);
            // 
            // gvBeStatic
            // 
            this.gvBeStatic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBeStatic.Enabled = false;
            this.gvBeStatic.Location = new System.Drawing.Point(26, 187);
            this.gvBeStatic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvBeStatic.Name = "gvBeStatic";
            this.gvBeStatic.ReadOnly = true;
            this.gvBeStatic.RowHeadersWidth = 62;
            this.gvBeStatic.RowTemplate.Height = 28;
            this.gvBeStatic.Size = new System.Drawing.Size(717, 280);
            this.gvBeStatic.TabIndex = 25;
            // 
            // cbStartMånad
            // 
            this.cbStartMånad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStartMånad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStartMånad.FormattingEnabled = true;
            this.cbStartMånad.Location = new System.Drawing.Point(30, 140);
            this.cbStartMånad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbStartMånad.Name = "cbStartMånad";
            this.cbStartMånad.Size = new System.Drawing.Size(146, 28);
            this.cbStartMånad.TabIndex = 22;
            this.cbStartMånad.Text = "Månad";
            // 
            // cbStartVecka
            // 
            this.cbStartVecka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStartVecka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStartVecka.FormattingEnabled = true;
            this.cbStartVecka.Location = new System.Drawing.Point(30, 105);
            this.cbStartVecka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbStartVecka.Name = "cbStartVecka";
            this.cbStartVecka.Size = new System.Drawing.Size(146, 28);
            this.cbStartVecka.TabIndex = 20;
            this.cbStartVecka.Text = "Vecka:";
            // 
            // btnExporteraTillExellbt
            // 
            this.btnExporteraTillExellbt.Location = new System.Drawing.Point(583, 483);
            this.btnExporteraTillExellbt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExporteraTillExellbt.Name = "btnExporteraTillExellbt";
            this.btnExporteraTillExellbt.Size = new System.Drawing.Size(160, 33);
            this.btnExporteraTillExellbt.TabIndex = 18;
            this.btnExporteraTillExellbt.Text = "Exportera till excel";
            this.btnExporteraTillExellbt.UseVisualStyleBackColor = true;
            this.btnExporteraTillExellbt.Click += new System.EventHandler(this.btnExporteraTillExellbt_Click);
            // 
            // cbStartår
            // 
            this.cbStartår.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStartår.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStartår.FormattingEnabled = true;
            this.cbStartår.Location = new System.Drawing.Point(30, 70);
            this.cbStartår.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbStartår.Name = "cbStartår";
            this.cbStartår.Size = new System.Drawing.Size(146, 28);
            this.cbStartår.TabIndex = 17;
            this.cbStartår.Text = "Startår";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 15;
            // 
            // btntillbaka
            // 
            this.btntillbaka.Location = new System.Drawing.Point(26, 479);
            this.btntillbaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntillbaka.Name = "btntillbaka";
            this.btntillbaka.Size = new System.Drawing.Size(156, 40);
            this.btntillbaka.TabIndex = 26;
            this.btntillbaka.Text = "Tillbaka";
            this.btntillbaka.UseVisualStyleBackColor = true;
            this.btntillbaka.Click += new System.EventHandler(this.btntillbaka_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 40);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ski-Center";
            // 
            // logiBokningBindingSource
            // 
            this.logiBokningBindingSource.DataMember = "LogiBokning";
            // 
            // BelStatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "BelStatistik";
            this.Text = "BelStatistik";
            this.Load += new System.EventHandler(this.BelStatistik_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBeStatic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logiBokningBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvBeStatic;
        private System.Windows.Forms.ComboBox cbStartMånad;
        private System.Windows.Forms.ComboBox cbStartVecka;
        private System.Windows.Forms.Button btnExporteraTillExellbt;
        private System.Windows.Forms.ComboBox cbStartår;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntillbaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource logiBokningBindingSource;
        private System.Windows.Forms.Button btVälj;
        private System.Windows.Forms.ComboBox cbMånad;
        private System.Windows.Forms.RadioButton rbMånad;
        private System.Windows.Forms.RadioButton rbVecka;
        private System.Windows.Forms.ComboBox cbSlutVecka;
        private System.Windows.Forms.ComboBox cbSlutÅr;
        private System.Windows.Forms.ComboBox cbLogialternativ;
    }
}