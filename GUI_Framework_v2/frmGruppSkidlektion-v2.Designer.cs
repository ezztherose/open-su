
namespace GUI_Framework_v2
{
    partial class frmGruppSkidlektion_v2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbBokning = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPriceNoCost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateBoking = new System.Windows.Forms.Button();
            this.tbPriceWithTax = new System.Windows.Forms.TextBox();
            this.tbTax = new System.Windows.Forms.TextBox();
            this.tbPriceNoTax = new System.Windows.Forms.TextBox();
            this.gbBoking = new System.Windows.Forms.GroupBox();
            this.tbParticipantName = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbReciverCash = new System.Windows.Forms.Label();
            this.tbCashName = new System.Windows.Forms.TextBox();
            this.cbCash = new System.Windows.Forms.CheckBox();
            this.cbInvoice = new System.Windows.Forms.CheckBox();
            this.gvRegCustomer = new System.Windows.Forms.DataGridView();
            this.gbParticipant = new System.Windows.Forms.GroupBox();
            this.gvParticipant = new System.Windows.Forms.DataGridView();
            this.tbRemoveParticipant = new System.Windows.Forms.Button();
            this.tbAddParticipant = new System.Windows.Forms.Button();
            this.comboBoxDays = new System.Windows.Forms.ComboBox();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbGroup = new System.Windows.Forms.Label();
            this.cbDays = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbBokning.SuspendLayout();
            this.gbBoking.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegCustomer)).BeginInit();
            this.gbParticipant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParticipant)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.gbBokning);
            this.panel1.Controls.Add(this.gbBoking);
            this.panel1.Controls.Add(this.gbParticipant);
            this.panel1.Location = new System.Drawing.Point(2, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 845);
            this.panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(32, 781);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 30);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Tillbaka";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // gbBokning
            // 
            this.gbBokning.Controls.Add(this.label3);
            this.gbBokning.Controls.Add(this.lbPriceNoCost);
            this.gbBokning.Controls.Add(this.label1);
            this.gbBokning.Controls.Add(this.btnGenerateBoking);
            this.gbBokning.Controls.Add(this.tbPriceWithTax);
            this.gbBokning.Controls.Add(this.tbTax);
            this.gbBokning.Controls.Add(this.tbPriceNoTax);
            this.gbBokning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBokning.Location = new System.Drawing.Point(27, 595);
            this.gbBokning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbBokning.Name = "gbBokning";
            this.gbBokning.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbBokning.Size = new System.Drawing.Size(756, 182);
            this.gbBokning.TabIndex = 14;
            this.gbBokning.TabStop = false;
            this.gbBokning.Text = "Bokning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Kostnad inkl. moms";
            // 
            // lbPriceNoCost
            // 
            this.lbPriceNoCost.AutoSize = true;
            this.lbPriceNoCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPriceNoCost.Location = new System.Drawing.Point(15, 100);
            this.lbPriceNoCost.Name = "lbPriceNoCost";
            this.lbPriceNoCost.Size = new System.Drawing.Size(147, 17);
            this.lbPriceNoCost.TabIndex = 15;
            this.lbPriceNoCost.Text = "Kostnad exk. moms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Moms";
            // 
            // btnGenerateBoking
            // 
            this.btnGenerateBoking.Location = new System.Drawing.Point(606, 114);
            this.btnGenerateBoking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateBoking.Name = "btnGenerateBoking";
            this.btnGenerateBoking.Size = new System.Drawing.Size(125, 42);
            this.btnGenerateBoking.TabIndex = 10;
            this.btnGenerateBoking.Text = "Boka";
            this.btnGenerateBoking.UseVisualStyleBackColor = true;
            this.btnGenerateBoking.Click += new System.EventHandler(this.btnGenerateBoking_Click);
            // 
            // tbPriceWithTax
            // 
            this.tbPriceWithTax.Location = new System.Drawing.Point(187, 132);
            this.tbPriceWithTax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPriceWithTax.Name = "tbPriceWithTax";
            this.tbPriceWithTax.ReadOnly = true;
            this.tbPriceWithTax.Size = new System.Drawing.Size(177, 26);
            this.tbPriceWithTax.TabIndex = 13;
            // 
            // tbTax
            // 
            this.tbTax.Location = new System.Drawing.Point(187, 55);
            this.tbTax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTax.Name = "tbTax";
            this.tbTax.ReadOnly = true;
            this.tbTax.Size = new System.Drawing.Size(177, 26);
            this.tbTax.TabIndex = 11;
            // 
            // tbPriceNoTax
            // 
            this.tbPriceNoTax.Location = new System.Drawing.Point(187, 94);
            this.tbPriceNoTax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPriceNoTax.Name = "tbPriceNoTax";
            this.tbPriceNoTax.ReadOnly = true;
            this.tbPriceNoTax.Size = new System.Drawing.Size(177, 26);
            this.tbPriceNoTax.TabIndex = 12;
            // 
            // gbBoking
            // 
            this.gbBoking.Controls.Add(this.tbParticipantName);
            this.gbBoking.Controls.Add(this.btnSearchCustomer);
            this.gbBoking.Controls.Add(this.panel2);
            this.gbBoking.Controls.Add(this.gvRegCustomer);
            this.gbBoking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBoking.Location = new System.Drawing.Point(27, 330);
            this.gbBoking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbBoking.Name = "gbBoking";
            this.gbBoking.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbBoking.Size = new System.Drawing.Size(756, 251);
            this.gbBoking.TabIndex = 9;
            this.gbBoking.TabStop = false;
            this.gbBoking.Text = "Betalsätt";
            // 
            // tbParticipantName
            // 
            this.tbParticipantName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbParticipantName.Location = new System.Drawing.Point(0, 167);
            this.tbParticipantName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbParticipantName.Name = "tbParticipantName";
            this.tbParticipantName.Size = new System.Drawing.Size(200, 26);
            this.tbParticipantName.TabIndex = 6;
            this.tbParticipantName.TextChanged += new System.EventHandler(this.tbParticipantName_TextChanged);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCustomer.Location = new System.Drawing.Point(0, 196);
            this.btnSearchCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(199, 28);
            this.btnSearchCustomer.TabIndex = 9;
            this.btnSearchCustomer.Text = "Sök kund";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.lbReciverCash);
            this.panel2.Controls.Add(this.tbCashName);
            this.panel2.Controls.Add(this.cbCash);
            this.panel2.Controls.Add(this.cbInvoice);
            this.panel2.Location = new System.Drawing.Point(5, 36);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 126);
            this.panel2.TabIndex = 8;
            // 
            // lbReciverCash
            // 
            this.lbReciverCash.AutoSize = true;
            this.lbReciverCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReciverCash.Location = new System.Drawing.Point(3, 38);
            this.lbReciverCash.Name = "lbReciverCash";
            this.lbReciverCash.Size = new System.Drawing.Size(139, 20);
            this.lbReciverCash.TabIndex = 6;
            this.lbReciverCash.Text = "Betalandes namn";
            // 
            // tbCashName
            // 
            this.tbCashName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCashName.Location = new System.Drawing.Point(3, 60);
            this.tbCashName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCashName.Name = "tbCashName";
            this.tbCashName.Size = new System.Drawing.Size(177, 26);
            this.tbCashName.TabIndex = 5;
            // 
            // cbCash
            // 
            this.cbCash.AutoSize = true;
            this.cbCash.Location = new System.Drawing.Point(3, 12);
            this.cbCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCash.Name = "cbCash";
            this.cbCash.Size = new System.Drawing.Size(95, 24);
            this.cbCash.TabIndex = 0;
            this.cbCash.Text = "Kontant";
            this.cbCash.UseVisualStyleBackColor = true;
            this.cbCash.CheckedChanged += new System.EventHandler(this.cbCash_CheckedChanged);
            // 
            // cbInvoice
            // 
            this.cbInvoice.AutoSize = true;
            this.cbInvoice.Location = new System.Drawing.Point(3, 89);
            this.cbInvoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbInvoice.Name = "cbInvoice";
            this.cbInvoice.Size = new System.Drawing.Size(94, 24);
            this.cbInvoice.TabIndex = 1;
            this.cbInvoice.Text = "Faktura";
            this.cbInvoice.UseVisualStyleBackColor = true;
            this.cbInvoice.CheckedChanged += new System.EventHandler(this.cbInvoice_CheckedChanged);
            // 
            // gvRegCustomer
            // 
            this.gvRegCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRegCustomer.Location = new System.Drawing.Point(204, 36);
            this.gvRegCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvRegCustomer.Name = "gvRegCustomer";
            this.gvRegCustomer.ReadOnly = true;
            this.gvRegCustomer.RowHeadersWidth = 62;
            this.gvRegCustomer.RowTemplate.Height = 28;
            this.gvRegCustomer.Size = new System.Drawing.Size(527, 188);
            this.gvRegCustomer.TabIndex = 8;
            // 
            // gbParticipant
            // 
            this.gbParticipant.Controls.Add(this.gvParticipant);
            this.gbParticipant.Controls.Add(this.tbRemoveParticipant);
            this.gbParticipant.Controls.Add(this.tbAddParticipant);
            this.gbParticipant.Controls.Add(this.comboBoxDays);
            this.gbParticipant.Controls.Add(this.comboBoxColor);
            this.gbParticipant.Controls.Add(this.tbName);
            this.gbParticipant.Controls.Add(this.cbGroup);
            this.gbParticipant.Controls.Add(this.cbDays);
            this.gbParticipant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbParticipant.Location = new System.Drawing.Point(27, 40);
            this.gbParticipant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbParticipant.Name = "gbParticipant";
            this.gbParticipant.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbParticipant.Size = new System.Drawing.Size(756, 286);
            this.gbParticipant.TabIndex = 8;
            this.gbParticipant.TabStop = false;
            this.gbParticipant.Text = "Lägg till deltagare";
            // 
            // gvParticipant
            // 
            this.gvParticipant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvParticipant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvParticipant.Location = new System.Drawing.Point(187, 91);
            this.gvParticipant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvParticipant.Name = "gvParticipant";
            this.gvParticipant.ReadOnly = true;
            this.gvParticipant.RowHeadersWidth = 62;
            this.gvParticipant.RowTemplate.Height = 28;
            this.gvParticipant.Size = new System.Drawing.Size(552, 191);
            this.gvParticipant.TabIndex = 6;
            // 
            // tbRemoveParticipant
            // 
            this.tbRemoveParticipant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemoveParticipant.Location = new System.Drawing.Point(641, 49);
            this.tbRemoveParticipant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRemoveParticipant.Name = "tbRemoveParticipant";
            this.tbRemoveParticipant.Size = new System.Drawing.Size(79, 28);
            this.tbRemoveParticipant.TabIndex = 7;
            this.tbRemoveParticipant.Text = "Ta bort";
            this.tbRemoveParticipant.UseVisualStyleBackColor = true;
            this.tbRemoveParticipant.Click += new System.EventHandler(this.tbRemoveParticipant_Click);
            // 
            // tbAddParticipant
            // 
            this.tbAddParticipant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddParticipant.Location = new System.Drawing.Point(547, 49);
            this.tbAddParticipant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAddParticipant.Name = "tbAddParticipant";
            this.tbAddParticipant.Size = new System.Drawing.Size(79, 28);
            this.tbAddParticipant.TabIndex = 5;
            this.tbAddParticipant.Text = "Lägg till";
            this.tbAddParticipant.UseVisualStyleBackColor = true;
            this.tbAddParticipant.Click += new System.EventHandler(this.tbAddParticipant_Click);
            // 
            // comboBoxDays
            // 
            this.comboBoxDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDays.FormattingEnabled = true;
            this.comboBoxDays.Items.AddRange(new object[] {
            "3",
            "5"});
            this.comboBoxDays.Location = new System.Drawing.Point(26, 91);
            this.comboBoxDays.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDays.Name = "comboBoxDays";
            this.comboBoxDays.Size = new System.Drawing.Size(108, 28);
            this.comboBoxDays.TabIndex = 0;
            this.comboBoxDays.SelectedIndexChanged += new System.EventHandler(this.comboBoxDays_SelectedIndexChanged);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "Grön",
            "Blå",
            "Röd",
            "Svart"});
            this.comboBoxColor.Location = new System.Drawing.Point(26, 166);
            this.comboBoxColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(108, 28);
            this.comboBoxColor.TabIndex = 1;
            this.comboBoxColor.SelectedIndexChanged += new System.EventHandler(this.comboBoxColor_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(187, 49);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(354, 26);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // cbGroup
            // 
            this.cbGroup.AutoSize = true;
            this.cbGroup.Location = new System.Drawing.Point(22, 134);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(47, 20);
            this.cbGroup.TabIndex = 3;
            this.cbGroup.Text = "Färg";
            // 
            // cbDays
            // 
            this.cbDays.AutoSize = true;
            this.cbDays.Location = new System.Drawing.Point(22, 55);
            this.cbDays.Name = "cbDays";
            this.cbDays.Size = new System.Drawing.Size(60, 20);
            this.cbDays.TabIndex = 2;
            this.cbDays.Text = "Dagar";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, -2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ski-Center";
            // 
            // frmGruppSkidlektion_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(871, 844);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGruppSkidlektion_v2";
            this.Text = "frmGruppSkidlektion_v2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbBokning.ResumeLayout(false);
            this.gbBokning.PerformLayout();
            this.gbBoking.ResumeLayout(false);
            this.gbBoking.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegCustomer)).EndInit();
            this.gbParticipant.ResumeLayout(false);
            this.gbParticipant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParticipant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gvParticipant;
        private System.Windows.Forms.Button tbAddParticipant;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label cbGroup;
        private System.Windows.Forms.Label cbDays;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.ComboBox comboBoxDays;
        private System.Windows.Forms.GroupBox gbBoking;
        private System.Windows.Forms.DataGridView gvRegCustomer;
        private System.Windows.Forms.TextBox tbParticipantName;
        private System.Windows.Forms.TextBox tbCashName;
        private System.Windows.Forms.CheckBox cbInvoice;
        private System.Windows.Forms.CheckBox cbCash;
        private System.Windows.Forms.GroupBox gbParticipant;
        private System.Windows.Forms.Button tbRemoveParticipant;
        private System.Windows.Forms.Button btnGenerateBoking;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox gbBokning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPriceNoCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPriceWithTax;
        private System.Windows.Forms.TextBox tbTax;
        private System.Windows.Forms.TextBox tbPriceNoTax;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbReciverCash;
        private System.Windows.Forms.Label label2;
    }
}