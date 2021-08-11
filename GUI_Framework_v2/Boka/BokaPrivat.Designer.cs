namespace GUI_Framework_v2
{
    partial class BokaPrivat
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
            this.Priser = new System.Windows.Forms.GroupBox();
            this.tbavbeställningsskydd = new System.Windows.Forms.TextBox();
            this.tbRabatt = new System.Windows.Forms.TextBox();
            this.tbExklMoms = new System.Windows.Forms.TextBox();
            this.tbMoms = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tbtotalpris = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnUppdatera = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.checkBoxVecka = new System.Windows.Forms.CheckBox();
            this.checkBoxHelg = new System.Windows.Forms.CheckBox();
            this.checkBoxDagar = new System.Windows.Forms.CheckBox();
            this.gvBokning = new System.Windows.Forms.DataGridView();
            this.btnTaBort = new System.Windows.Forms.Button();
            this.btnBoka = new System.Windows.Forms.Button();
            this.btavbeställningsskydd = new System.Windows.Forms.CheckBox();
            this.btnSökKund = new System.Windows.Forms.Button();
            this.tbSökKund = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gvtypavlgh = new System.Windows.Forms.DataGridView();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.tbveckonummer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbår = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.tbantalpersoner = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.btnSökLgh = new System.Windows.Forms.Button();
            this.comboBoxLägenhetstyp = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnVäljKund = new System.Windows.Forms.Button();
            this.btnNyKund = new System.Windows.Forms.Button();
            this.gvPrivatKund = new System.Windows.Forms.DataGridView();
            this.label26 = new System.Windows.Forms.Label();
            this.gvLedigaAlt = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tillbakaknapp = new System.Windows.Forms.Button();
            this.gvPrebokningar = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Priser.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBokning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvtypavlgh)).BeginInit();
            this.groupBox14.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivatKund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedigaAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrebokningar)).BeginInit();
            this.SuspendLayout();
            // 
            // Priser
            // 
            this.Priser.Controls.Add(this.tbavbeställningsskydd);
            this.Priser.Controls.Add(this.tbRabatt);
            this.Priser.Controls.Add(this.tbExklMoms);
            this.Priser.Controls.Add(this.tbMoms);
            this.Priser.Controls.Add(this.label44);
            this.Priser.Controls.Add(this.tbtotalpris);
            this.Priser.Controls.Add(this.label45);
            this.Priser.Controls.Add(this.label29);
            this.Priser.Controls.Add(this.label28);
            this.Priser.Controls.Add(this.label27);
            this.Priser.Location = new System.Drawing.Point(771, 87);
            this.Priser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Priser.Name = "Priser";
            this.Priser.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Priser.Size = new System.Drawing.Size(328, 252);
            this.Priser.TabIndex = 42;
            this.Priser.TabStop = false;
            this.Priser.Text = "Priser";
            // 
            // tbavbeställningsskydd
            // 
            this.tbavbeställningsskydd.Location = new System.Drawing.Point(147, 124);
            this.tbavbeställningsskydd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbavbeställningsskydd.Name = "tbavbeställningsskydd";
            this.tbavbeställningsskydd.Size = new System.Drawing.Size(135, 22);
            this.tbavbeställningsskydd.TabIndex = 9;
            // 
            // tbRabatt
            // 
            this.tbRabatt.Location = new System.Drawing.Point(147, 100);
            this.tbRabatt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbRabatt.Name = "tbRabatt";
            this.tbRabatt.Size = new System.Drawing.Size(135, 22);
            this.tbRabatt.TabIndex = 8;
            this.tbRabatt.TextChanged += new System.EventHandler(this.tbRabatt_TextChanged);
            // 
            // tbExklMoms
            // 
            this.tbExklMoms.Location = new System.Drawing.Point(147, 34);
            this.tbExklMoms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbExklMoms.Name = "tbExklMoms";
            this.tbExklMoms.Size = new System.Drawing.Size(135, 22);
            this.tbExklMoms.TabIndex = 7;
            this.tbExklMoms.TextChanged += new System.EventHandler(this.tbExklMoms_TextChanged);
            // 
            // tbMoms
            // 
            this.tbMoms.Location = new System.Drawing.Point(147, 53);
            this.tbMoms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMoms.Name = "tbMoms";
            this.tbMoms.Size = new System.Drawing.Size(135, 22);
            this.tbMoms.TabIndex = 6;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(91, 103);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(54, 17);
            this.label44.TabIndex = 3;
            this.label44.Text = "Rabatt:";
            // 
            // tbtotalpris
            // 
            this.tbtotalpris.Location = new System.Drawing.Point(147, 172);
            this.tbtotalpris.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbtotalpris.Name = "tbtotalpris";
            this.tbtotalpris.Size = new System.Drawing.Size(135, 22);
            this.tbtotalpris.TabIndex = 5;
            this.tbtotalpris.TextChanged += new System.EventHandler(this.tbtotalpris_TextChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(5, 126);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(140, 17);
            this.label45.TabIndex = 4;
            this.label45.Text = "Avbeställningsskydd:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(91, 57);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(45, 17);
            this.label29.TabIndex = 2;
            this.label29.Text = "Moms";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(59, 34);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 17);
            this.label28.TabIndex = 1;
            this.label28.Text = "exkl moms:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 172);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(133, 17);
            this.label27.TabIndex = 0;
            this.label27.Text = "Totalpris inkl moms:";
            // 
            // btnUppdatera
            // 
            this.btnUppdatera.Location = new System.Drawing.Point(525, 544);
            this.btnUppdatera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUppdatera.Name = "btnUppdatera";
            this.btnUppdatera.Size = new System.Drawing.Size(99, 30);
            this.btnUppdatera.TabIndex = 51;
            this.btnUppdatera.Text = "Uppdatera";
            this.btnUppdatera.UseVisualStyleBackColor = true;
            this.btnUppdatera.Click += new System.EventHandler(this.btnUppdatera_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.checkBoxVecka);
            this.groupBox13.Controls.Add(this.checkBoxHelg);
            this.groupBox13.Controls.Add(this.checkBoxDagar);
            this.groupBox13.Location = new System.Drawing.Point(381, 20);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Size = new System.Drawing.Size(200, 107);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Välj vecka";
            // 
            // checkBoxVecka
            // 
            this.checkBoxVecka.AutoSize = true;
            this.checkBoxVecka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVecka.Location = new System.Drawing.Point(11, 22);
            this.checkBoxVecka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxVecka.Name = "checkBoxVecka";
            this.checkBoxVecka.Size = new System.Drawing.Size(158, 24);
            this.checkBoxVecka.TabIndex = 0;
            this.checkBoxVecka.Text = "Sön-Sön (Vecka)";
            this.checkBoxVecka.UseVisualStyleBackColor = true;
            this.checkBoxVecka.CheckedChanged += new System.EventHandler(this.checkBoxVecka_CheckedChanged);
            // 
            // checkBoxHelg
            // 
            this.checkBoxHelg.AutoSize = true;
            this.checkBoxHelg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHelg.Location = new System.Drawing.Point(11, 68);
            this.checkBoxHelg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxHelg.Name = "checkBoxHelg";
            this.checkBoxHelg.Size = new System.Drawing.Size(143, 24);
            this.checkBoxHelg.TabIndex = 2;
            this.checkBoxHelg.Text = "Fre-Sön (Helg)";
            this.checkBoxHelg.UseVisualStyleBackColor = true;
            // 
            // checkBoxDagar
            // 
            this.checkBoxDagar.AutoSize = true;
            this.checkBoxDagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDagar.Location = new System.Drawing.Point(11, 44);
            this.checkBoxDagar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxDagar.Name = "checkBoxDagar";
            this.checkBoxDagar.Size = new System.Drawing.Size(168, 24);
            this.checkBoxDagar.TabIndex = 1;
            this.checkBoxDagar.Text = "Sön-Fre(5 dagars)";
            this.checkBoxDagar.UseVisualStyleBackColor = true;
            // 
            // gvBokning
            // 
            this.gvBokning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBokning.Location = new System.Drawing.Point(35, 37);
            this.gvBokning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvBokning.Name = "gvBokning";
            this.gvBokning.RowHeadersWidth = 62;
            this.gvBokning.RowTemplate.Height = 28;
            this.gvBokning.Size = new System.Drawing.Size(296, 151);
            this.gvBokning.TabIndex = 56;
            // 
            // btnTaBort
            // 
            this.btnTaBort.Location = new System.Drawing.Point(37, 218);
            this.btnTaBort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaBort.Name = "btnTaBort";
            this.btnTaBort.Size = new System.Drawing.Size(125, 38);
            this.btnTaBort.TabIndex = 1;
            this.btnTaBort.Text = "Ta bort";
            this.btnTaBort.UseVisualStyleBackColor = true;
            this.btnTaBort.Click += new System.EventHandler(this.btnTaBort_Click);
            // 
            // btnBoka
            // 
            this.btnBoka.Location = new System.Drawing.Point(205, 218);
            this.btnBoka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBoka.Name = "btnBoka";
            this.btnBoka.Size = new System.Drawing.Size(125, 38);
            this.btnBoka.TabIndex = 0;
            this.btnBoka.Text = "Boka";
            this.btnBoka.UseVisualStyleBackColor = true;
            this.btnBoka.Click += new System.EventHandler(this.btnBoka_Click);
            // 
            // btavbeställningsskydd
            // 
            this.btavbeställningsskydd.AutoSize = true;
            this.btavbeställningsskydd.Location = new System.Drawing.Point(24, 558);
            this.btavbeställningsskydd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btavbeställningsskydd.Name = "btavbeställningsskydd";
            this.btavbeställningsskydd.Size = new System.Drawing.Size(151, 21);
            this.btavbeställningsskydd.TabIndex = 59;
            this.btavbeställningsskydd.Text = "Avbeställningskydd";
            this.btavbeställningsskydd.UseVisualStyleBackColor = true;
            this.btavbeställningsskydd.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSökKund
            // 
            this.btnSökKund.Location = new System.Drawing.Point(227, 364);
            this.btnSökKund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSökKund.Name = "btnSökKund";
            this.btnSökKund.Size = new System.Drawing.Size(59, 23);
            this.btnSökKund.TabIndex = 58;
            this.btnSökKund.Text = "Sök";
            this.btnSökKund.UseVisualStyleBackColor = true;
            this.btnSökKund.Click += new System.EventHandler(this.btnSökKund_Click);
            // 
            // tbSökKund
            // 
            this.tbSökKund.Location = new System.Drawing.Point(64, 364);
            this.tbSökKund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSökKund.Name = "tbSökKund";
            this.tbSökKund.Size = new System.Drawing.Size(145, 22);
            this.tbSökKund.TabIndex = 57;
            this.tbSökKund.TextChanged += new System.EventHandler(this.tbSökKund_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "Typ av lägenhet";
            // 
            // gvtypavlgh
            // 
            this.gvtypavlgh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvtypavlgh.Location = new System.Drawing.Point(333, 199);
            this.gvtypavlgh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvtypavlgh.Name = "gvtypavlgh";
            this.gvtypavlgh.RowHeadersWidth = 62;
            this.gvtypavlgh.RowTemplate.Height = 28;
            this.gvtypavlgh.Size = new System.Drawing.Size(296, 151);
            this.gvtypavlgh.TabIndex = 55;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.tbveckonummer);
            this.groupBox14.Controls.Add(this.label1);
            this.groupBox14.Controls.Add(this.tbår);
            this.groupBox14.Controls.Add(this.label43);
            this.groupBox14.Controls.Add(this.label38);
            this.groupBox14.Controls.Add(this.tbantalpersoner);
            this.groupBox14.Controls.Add(this.label42);
            this.groupBox14.Controls.Add(this.btnSökLgh);
            this.groupBox14.Controls.Add(this.comboBoxLägenhetstyp);
            this.groupBox14.Location = new System.Drawing.Point(16, 20);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Size = new System.Drawing.Size(309, 153);
            this.groupBox14.TabIndex = 49;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Tid och antal";
            // 
            // tbveckonummer
            // 
            this.tbveckonummer.Location = new System.Drawing.Point(125, 38);
            this.tbveckonummer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbveckonummer.Name = "tbveckonummer";
            this.tbveckonummer.Size = new System.Drawing.Size(68, 22);
            this.tbveckonummer.TabIndex = 51;
            this.tbveckonummer.TextChanged += new System.EventHandler(this.tbveckonummer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Veckonummer";
            // 
            // tbår
            // 
            this.tbår.Location = new System.Drawing.Point(8, 38);
            this.tbår.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbår.Name = "tbår";
            this.tbår.Size = new System.Drawing.Size(68, 22);
            this.tbår.TabIndex = 49;
            this.tbår.TextChanged += new System.EventHandler(this.tbår_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(120, 68);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(101, 17);
            this.label43.TabIndex = 48;
            this.label43.Text = "Antal personer";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(5, 21);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(22, 17);
            this.label38.TabIndex = 41;
            this.label38.Text = "År";
            // 
            // tbantalpersoner
            // 
            this.tbantalpersoner.Location = new System.Drawing.Point(127, 85);
            this.tbantalpersoner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbantalpersoner.Name = "tbantalpersoner";
            this.tbantalpersoner.Size = new System.Drawing.Size(68, 22);
            this.tbantalpersoner.TabIndex = 47;
            this.tbantalpersoner.TextChanged += new System.EventHandler(this.tbantalpersoner_TextChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(5, 68);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(110, 17);
            this.label42.TabIndex = 46;
            this.label42.Text = "Typ av lägenhet";
            // 
            // btnSökLgh
            // 
            this.btnSökLgh.Location = new System.Drawing.Point(232, 117);
            this.btnSökLgh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSökLgh.Name = "btnSökLgh";
            this.btnSökLgh.Size = new System.Drawing.Size(64, 23);
            this.btnSökLgh.TabIndex = 44;
            this.btnSökLgh.Text = "Sök";
            this.btnSökLgh.UseVisualStyleBackColor = true;
            this.btnSökLgh.Click += new System.EventHandler(this.btnSökLgh_Click);
            // 
            // comboBoxLägenhetstyp
            // 
            this.comboBoxLägenhetstyp.FormattingEnabled = true;
            this.comboBoxLägenhetstyp.Location = new System.Drawing.Point(8, 86);
            this.comboBoxLägenhetstyp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxLägenhetstyp.Name = "comboBoxLägenhetstyp";
            this.comboBoxLägenhetstyp.Size = new System.Drawing.Size(79, 24);
            this.comboBoxLägenhetstyp.TabIndex = 45;
            this.comboBoxLägenhetstyp.SelectedIndexChanged += new System.EventHandler(this.comboBoxLägenhetstyp_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.gvBokning);
            this.groupBox8.Controls.Add(this.btnTaBort);
            this.groupBox8.Controls.Add(this.btnBoka);
            this.groupBox8.Location = new System.Drawing.Point(771, 362);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(365, 263);
            this.groupBox8.TabIndex = 39;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Bokning";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btavbeställningsskydd);
            this.groupBox9.Controls.Add(this.btnSökKund);
            this.groupBox9.Controls.Add(this.tbSökKund);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.gvtypavlgh);
            this.groupBox9.Controls.Add(this.btnUppdatera);
            this.groupBox9.Controls.Add(this.groupBox13);
            this.groupBox9.Controls.Add(this.groupBox14);
            this.groupBox9.Controls.Add(this.btnVäljKund);
            this.groupBox9.Controls.Add(this.btnNyKund);
            this.groupBox9.Controls.Add(this.gvPrivatKund);
            this.groupBox9.Controls.Add(this.label26);
            this.groupBox9.Controls.Add(this.gvLedigaAlt);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Location = new System.Drawing.Point(99, 87);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(643, 614);
            this.groupBox9.TabIndex = 40;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Lägenheter";
            // 
            // btnVäljKund
            // 
            this.btnVäljKund.Location = new System.Drawing.Point(525, 580);
            this.btnVäljKund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVäljKund.Name = "btnVäljKund";
            this.btnVäljKund.Size = new System.Drawing.Size(99, 30);
            this.btnVäljKund.TabIndex = 40;
            this.btnVäljKund.Text = "Välj";
            this.btnVäljKund.UseVisualStyleBackColor = true;
            this.btnVäljKund.Click += new System.EventHandler(this.btnVäljKund_Click_1);
            // 
            // btnNyKund
            // 
            this.btnNyKund.Location = new System.Drawing.Point(392, 544);
            this.btnNyKund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNyKund.Name = "btnNyKund";
            this.btnNyKund.Size = new System.Drawing.Size(101, 30);
            this.btnNyKund.TabIndex = 37;
            this.btnNyKund.Text = "Ny kund";
            this.btnNyKund.UseVisualStyleBackColor = true;
            this.btnNyKund.Click += new System.EventHandler(this.btnNyKund_Click);
            // 
            // gvPrivatKund
            // 
            this.gvPrivatKund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrivatKund.Location = new System.Drawing.Point(11, 389);
            this.gvPrivatKund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvPrivatKund.Name = "gvPrivatKund";
            this.gvPrivatKund.RowHeadersWidth = 62;
            this.gvPrivatKund.RowTemplate.Height = 28;
            this.gvPrivatKund.Size = new System.Drawing.Size(613, 149);
            this.gvPrivatKund.TabIndex = 32;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 368);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 17);
            this.label26.TabIndex = 31;
            this.label26.Text = "Kund";
            // 
            // gvLedigaAlt
            // 
            this.gvLedigaAlt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLedigaAlt.Location = new System.Drawing.Point(13, 199);
            this.gvLedigaAlt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvLedigaAlt.Name = "gvLedigaAlt";
            this.gvLedigaAlt.RowHeadersWidth = 62;
            this.gvLedigaAlt.RowTemplate.Height = 28;
            this.gvLedigaAlt.Size = new System.Drawing.Size(296, 151);
            this.gvLedigaAlt.TabIndex = 27;
            this.gvLedigaAlt.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLedigaAlt_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Lediga altternativ:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(103, 37);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(189, 25);
            this.label30.TabIndex = 41;
            this.label30.Text = "Boka lägenhet privat";
            // 
            // tillbakaknapp
            // 
            this.tillbakaknapp.Location = new System.Drawing.Point(1011, 684);
            this.tillbakaknapp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tillbakaknapp.Name = "tillbakaknapp";
            this.tillbakaknapp.Size = new System.Drawing.Size(112, 28);
            this.tillbakaknapp.TabIndex = 43;
            this.tillbakaknapp.Text = "Tillbaka";
            this.tillbakaknapp.UseVisualStyleBackColor = true;
            this.tillbakaknapp.Click += new System.EventHandler(this.tillbakaknapp_Click);
            // 
            // gvPrebokningar
            // 
            this.gvPrebokningar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrebokningar.Location = new System.Drawing.Point(1164, 107);
            this.gvPrebokningar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvPrebokningar.Name = "gvPrebokningar";
            this.gvPrebokningar.RowHeadersWidth = 62;
            this.gvPrebokningar.RowTemplate.Height = 28;
            this.gvPrebokningar.Size = new System.Drawing.Size(370, 218);
            this.gvPrebokningar.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1159, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 25);
            this.label3.TabIndex = 58;
            this.label3.Text = "Preliminärbokningar";
            // 
            // BokaPrivat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 721);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gvPrebokningar);
            this.Controls.Add(this.tillbakaknapp);
            this.Controls.Add(this.Priser);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.label30);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BokaPrivat";
            this.Text = "Boka logi och camping privatkund";
            this.Load += new System.EventHandler(this.BokaPrivat_Load);
            this.Priser.ResumeLayout(false);
            this.Priser.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBokning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvtypavlgh)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivatKund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedigaAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrebokningar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Priser;
        private System.Windows.Forms.TextBox tbavbeställningsskydd;
        private System.Windows.Forms.TextBox tbRabatt;
        private System.Windows.Forms.TextBox tbExklMoms;
        private System.Windows.Forms.TextBox tbMoms;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox tbtotalpris;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnUppdatera;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox checkBoxVecka;
        private System.Windows.Forms.CheckBox checkBoxHelg;
        private System.Windows.Forms.CheckBox checkBoxDagar;
        private System.Windows.Forms.DataGridView gvBokning;
        private System.Windows.Forms.Button btnTaBort;
        private System.Windows.Forms.Button btnBoka;
        private System.Windows.Forms.CheckBox btavbeställningsskydd;
        private System.Windows.Forms.Button btnSökKund;
        private System.Windows.Forms.TextBox tbSökKund;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gvtypavlgh;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox tbveckonummer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbår;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox tbantalpersoner;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button btnSökLgh;
        private System.Windows.Forms.ComboBox comboBoxLägenhetstyp;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnVäljKund;
        private System.Windows.Forms.Button btnNyKund;
        private System.Windows.Forms.DataGridView gvPrivatKund;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView gvLedigaAlt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button tillbakaknapp;
        private System.Windows.Forms.DataGridView gvPrebokningar;
        private System.Windows.Forms.Label label3;
    }
}