namespace WindowsFormsApplication3
{
    partial class Form1
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
            this.bn_Conect = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonGoto = new System.Windows.Forms.Button();
            this.groupBoxGOTO = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPosition = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelVars = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelConection = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxJogRigth = new System.Windows.Forms.CheckBox();
            this.numericUpDownJogSpeed = new System.Windows.Forms.NumericUpDown();
            this.checkBoxJogLeft = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonEnergize = new System.Windows.Forms.Button();
            this.groupBoxGOTO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosition)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJogSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // bn_Conect
            // 
            this.bn_Conect.Location = new System.Drawing.Point(15, 25);
            this.bn_Conect.Name = "bn_Conect";
            this.bn_Conect.Size = new System.Drawing.Size(75, 23);
            this.bn_Conect.TabIndex = 0;
            this.bn_Conect.Text = "Conect";
            this.bn_Conect.UseVisualStyleBackColor = true;
            this.bn_Conect.Click += new System.EventHandler(this.bn_Conect_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(400, 14);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(94, 23);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "HOME";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonGoto
            // 
            this.buttonGoto.Location = new System.Drawing.Point(6, 16);
            this.buttonGoto.Name = "buttonGoto";
            this.buttonGoto.Size = new System.Drawing.Size(75, 23);
            this.buttonGoto.TabIndex = 2;
            this.buttonGoto.Text = "RUN";
            this.buttonGoto.UseVisualStyleBackColor = true;
            this.buttonGoto.Click += new System.EventHandler(this.buttonGoto_Click);
            // 
            // groupBoxGOTO
            // 
            this.groupBoxGOTO.Controls.Add(this.label2);
            this.groupBoxGOTO.Controls.Add(this.label1);
            this.groupBoxGOTO.Controls.Add(this.numericUpDownSpeed);
            this.groupBoxGOTO.Controls.Add(this.numericUpDownPosition);
            this.groupBoxGOTO.Controls.Add(this.buttonGoto);
            this.groupBoxGOTO.Location = new System.Drawing.Point(15, 77);
            this.groupBoxGOTO.Name = "groupBoxGOTO";
            this.groupBoxGOTO.Size = new System.Drawing.Size(225, 72);
            this.groupBoxGOTO.TabIndex = 3;
            this.groupBoxGOTO.TabStop = false;
            this.groupBoxGOTO.Text = "GOTO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Position";
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Location = new System.Drawing.Point(143, 42);
            this.numericUpDownSpeed.Maximum = new decimal(new int[] {
            50000000,
            0,
            0,
            0});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownSpeed.TabIndex = 5;
            this.numericUpDownSpeed.Value = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            // 
            // numericUpDownPosition
            // 
            this.numericUpDownPosition.Location = new System.Drawing.Point(144, 16);
            this.numericUpDownPosition.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPosition.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownPosition.Name = "numericUpDownPosition";
            this.numericUpDownPosition.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownPosition.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelVars);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Location = new System.Drawing.Point(15, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 418);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STATUS";
            // 
            // labelVars
            // 
            this.labelVars.Location = new System.Drawing.Point(8, 18);
            this.labelVars.Name = "labelVars";
            this.labelVars.Size = new System.Drawing.Size(176, 397);
            this.labelVars.TabIndex = 1;
            this.labelVars.Text = "Vars";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(184, 16);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(307, 159);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelPosition);
            this.groupBox2.Location = new System.Drawing.Point(214, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(17, 23);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(13, 13);
            this.labelPosition.TabIndex = 0;
            this.labelPosition.Text = "0";
            // 
            // labelConection
            // 
            this.labelConection.AutoSize = true;
            this.labelConection.Location = new System.Drawing.Point(19, 23);
            this.labelConection.Name = "labelConection";
            this.labelConection.Size = new System.Drawing.Size(23, 13);
            this.labelConection.TabIndex = 0;
            this.labelConection.Text = "NO";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelConection);
            this.groupBox3.Location = new System.Drawing.Point(96, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(95, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conection";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.checkBoxJogRigth);
            this.groupBox5.Controls.Add(this.numericUpDownJogSpeed);
            this.groupBox5.Controls.Add(this.checkBoxJogLeft);
            this.groupBox5.Location = new System.Drawing.Point(295, 76);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(215, 80);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "JOG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Speed";
            // 
            // checkBoxJogRigth
            // 
            this.checkBoxJogRigth.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxJogRigth.Location = new System.Drawing.Point(116, 21);
            this.checkBoxJogRigth.Name = "checkBoxJogRigth";
            this.checkBoxJogRigth.Size = new System.Drawing.Size(80, 23);
            this.checkBoxJogRigth.TabIndex = 7;
            this.checkBoxJogRigth.Text = "--->";
            this.checkBoxJogRigth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxJogRigth.UseVisualStyleBackColor = true;
            this.checkBoxJogRigth.CheckedChanged += new System.EventHandler(this.checkBoxJogRigth_CheckedChanged);
            // 
            // numericUpDownJogSpeed
            // 
            this.numericUpDownJogSpeed.Location = new System.Drawing.Point(116, 50);
            this.numericUpDownJogSpeed.Maximum = new decimal(new int[] {
            50000000,
            0,
            0,
            0});
            this.numericUpDownJogSpeed.Name = "numericUpDownJogSpeed";
            this.numericUpDownJogSpeed.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownJogSpeed.TabIndex = 8;
            this.numericUpDownJogSpeed.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            // 
            // checkBoxJogLeft
            // 
            this.checkBoxJogLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxJogLeft.Location = new System.Drawing.Point(23, 21);
            this.checkBoxJogLeft.Name = "checkBoxJogLeft";
            this.checkBoxJogLeft.Size = new System.Drawing.Size(80, 23);
            this.checkBoxJogLeft.TabIndex = 6;
            this.checkBoxJogLeft.Text = "<---";
            this.checkBoxJogLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxJogLeft.UseVisualStyleBackColor = true;
            this.checkBoxJogLeft.CheckedChanged += new System.EventHandler(this.checkBoxJogLeft_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonEnergize
            // 
            this.buttonEnergize.Location = new System.Drawing.Point(400, 43);
            this.buttonEnergize.Name = "buttonEnergize";
            this.buttonEnergize.Size = new System.Drawing.Size(94, 23);
            this.buttonEnergize.TabIndex = 6;
            this.buttonEnergize.Text = "DEENERGIZE";
            this.buttonEnergize.UseVisualStyleBackColor = true;
            this.buttonEnergize.Click += new System.EventHandler(this.buttonEnergize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 592);
            this.Controls.Add(this.buttonEnergize);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxGOTO);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.bn_Conect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxGOTO.ResumeLayout(false);
            this.groupBoxGOTO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosition)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJogSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bn_Conect;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonGoto;
        private System.Windows.Forms.GroupBox groupBoxGOTO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelConection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownPosition;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxJogRigth;
        private System.Windows.Forms.CheckBox checkBoxJogLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownJogSpeed;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelVars;
        private System.Windows.Forms.Button buttonEnergize;
    }
}

