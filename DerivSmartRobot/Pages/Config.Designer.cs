using Newtonsoft.Json;

namespace DerivSmartRobot.Pages
{
    partial class Config
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
            this.robosCombo = new System.Windows.Forms.ComboBox();
            this.tipoMartingGaleCombo = new System.Windows.Forms.ComboBox();
            this.mercadosCombo = new System.Windows.Forms.ComboBox();
            this.stake = new System.Windows.Forms.TextBox();
            this.stopWin = new System.Windows.Forms.TextBox();
            this.stopLoss = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.erroTipoContaTextBox = new System.Windows.Forms.Label();
            this.marketErroLabel = new System.Windows.Forms.Label();
            this.stopLossErroLabel = new System.Windows.Forms.Label();
            this.stopWinErroLabel = new System.Windows.Forms.Label();
            this.roboErroLabel = new System.Windows.Forms.Label();
            this.accountTypeBox = new System.Windows.Forms.ComboBox();
            this.IniciarBtn = new System.Windows.Forms.Button();
            this.mgLabel = new System.Windows.Forms.Label();
            this.mgBoxValue = new System.Windows.Forms.TextBox();
            this.typeMgErrorlabel = new System.Windows.Forms.Label();
            this.mgErrorLabel = new System.Windows.Forms.Label();
            this.stakeErroLabel = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // robosCombo
            // 
            this.robosCombo.BackColor = System.Drawing.Color.White;
            this.robosCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.robosCombo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.robosCombo.FormattingEnabled = true;
            this.robosCombo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.robosCombo.Location = new System.Drawing.Point(107, 141);
            this.robosCombo.Name = "robosCombo";
            this.robosCombo.Size = new System.Drawing.Size(121, 25);
            this.robosCombo.TabIndex = 0;
            // 
            // tipoMartingGaleCombo
            // 
            this.tipoMartingGaleCombo.BackColor = System.Drawing.Color.White;
            this.tipoMartingGaleCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tipoMartingGaleCombo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tipoMartingGaleCombo.FormattingEnabled = true;
            this.tipoMartingGaleCombo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tipoMartingGaleCombo.Location = new System.Drawing.Point(418, 37);
            this.tipoMartingGaleCombo.Name = "tipoMartingGaleCombo";
            this.tipoMartingGaleCombo.Size = new System.Drawing.Size(121, 25);
            this.tipoMartingGaleCombo.TabIndex = 0;
            // 
            // mercadosCombo
            // 
            this.mercadosCombo.BackColor = System.Drawing.Color.White;
            this.mercadosCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mercadosCombo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mercadosCombo.FormattingEnabled = true;
            this.mercadosCombo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mercadosCombo.Location = new System.Drawing.Point(107, 93);
            this.mercadosCombo.Name = "mercadosCombo";
            this.mercadosCombo.Size = new System.Drawing.Size(121, 25);
            this.mercadosCombo.TabIndex = 0;
            this.mercadosCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // stake
            // 
            this.stake.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stake.Location = new System.Drawing.Point(418, 135);
            this.stake.Name = "stake";
            this.stake.Size = new System.Drawing.Size(100, 22);
            this.stake.TabIndex = 1;
            this.stake.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // stopWin
            // 
            this.stopWin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopWin.Location = new System.Drawing.Point(107, 187);
            this.stopWin.Name = "stopWin";
            this.stopWin.Size = new System.Drawing.Size(100, 22);
            this.stopWin.TabIndex = 1;
            // 
            // stopLoss
            // 
            this.stopLoss.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopLoss.Location = new System.Drawing.Point(107, 231);
            this.stopLoss.Name = "stopLoss";
            this.stopLoss.Size = new System.Drawing.Size(100, 22);
            this.stopLoss.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mercado";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Robô";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label5.Location = new System.Drawing.Point(305, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tipo Martingale";
            this.label5.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label6.Location = new System.Drawing.Point(305, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Stake";
            this.label6.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stopwin";
            this.label7.Click += new System.EventHandler(this.label3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(25, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Stoploss";
            this.label8.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.erroTipoContaTextBox);
            this.panel1.Controls.Add(this.marketErroLabel);
            this.panel1.Controls.Add(this.stopLossErroLabel);
            this.panel1.Controls.Add(this.stopWinErroLabel);
            this.panel1.Controls.Add(this.roboErroLabel);
            this.panel1.Controls.Add(this.accountTypeBox);
            this.panel1.Location = new System.Drawing.Point(-1, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 351);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo da conta";
            // 
            // erroTipoContaTextBox
            // 
            this.erroTipoContaTextBox.AutoSize = true;
            this.erroTipoContaTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.erroTipoContaTextBox.ForeColor = System.Drawing.Color.Red;
            this.erroTipoContaTextBox.Location = new System.Drawing.Point(108, 73);
            this.erroTipoContaTextBox.Name = "erroTipoContaTextBox";
            this.erroTipoContaTextBox.Size = new System.Drawing.Size(0, 17);
            this.erroTipoContaTextBox.TabIndex = 1;
            // 
            // marketErroLabel
            // 
            this.marketErroLabel.AutoSize = true;
            this.marketErroLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.marketErroLabel.ForeColor = System.Drawing.Color.Red;
            this.marketErroLabel.Location = new System.Drawing.Point(108, 126);
            this.marketErroLabel.Name = "marketErroLabel";
            this.marketErroLabel.Size = new System.Drawing.Size(0, 17);
            this.marketErroLabel.TabIndex = 1;
            // 
            // stopLossErroLabel
            // 
            this.stopLossErroLabel.AutoSize = true;
            this.stopLossErroLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopLossErroLabel.ForeColor = System.Drawing.Color.Red;
            this.stopLossErroLabel.Location = new System.Drawing.Point(108, 261);
            this.stopLossErroLabel.Name = "stopLossErroLabel";
            this.stopLossErroLabel.Size = new System.Drawing.Size(0, 17);
            this.stopLossErroLabel.TabIndex = 0;
            this.stopLossErroLabel.Click += new System.EventHandler(this.label9_Click);
            // 
            // stopWinErroLabel
            // 
            this.stopWinErroLabel.AutoSize = true;
            this.stopWinErroLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopWinErroLabel.ForeColor = System.Drawing.Color.Red;
            this.stopWinErroLabel.Location = new System.Drawing.Point(108, 216);
            this.stopWinErroLabel.Name = "stopWinErroLabel";
            this.stopWinErroLabel.Size = new System.Drawing.Size(0, 17);
            this.stopWinErroLabel.TabIndex = 0;
            this.stopWinErroLabel.Click += new System.EventHandler(this.label9_Click);
            // 
            // roboErroLabel
            // 
            this.roboErroLabel.AutoSize = true;
            this.roboErroLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.roboErroLabel.ForeColor = System.Drawing.Color.Red;
            this.roboErroLabel.Location = new System.Drawing.Point(108, 174);
            this.roboErroLabel.Name = "roboErroLabel";
            this.roboErroLabel.Size = new System.Drawing.Size(0, 17);
            this.roboErroLabel.TabIndex = 0;
            // 
            // accountTypeBox
            // 
            this.accountTypeBox.BackColor = System.Drawing.Color.White;
            this.accountTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountTypeBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accountTypeBox.FormattingEnabled = true;
            this.accountTypeBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.accountTypeBox.Location = new System.Drawing.Point(108, 45);
            this.accountTypeBox.Name = "accountTypeBox";
            this.accountTypeBox.Size = new System.Drawing.Size(121, 25);
            this.accountTypeBox.TabIndex = 0;
            this.accountTypeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // IniciarBtn
            // 
            this.IniciarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.IniciarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IniciarBtn.FlatAppearance.BorderSize = 0;
            this.IniciarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IniciarBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IniciarBtn.ForeColor = System.Drawing.Color.White;
            this.IniciarBtn.Location = new System.Drawing.Point(329, 271);
            this.IniciarBtn.Name = "IniciarBtn";
            this.IniciarBtn.Size = new System.Drawing.Size(190, 41);
            this.IniciarBtn.TabIndex = 4;
            this.IniciarBtn.Text = "Iniciar";
            this.IniciarBtn.UseVisualStyleBackColor = false;
            this.IniciarBtn.Click += new System.EventHandler(this.IniciarBtn_Click);
            // 
            // mgLabel
            // 
            this.mgLabel.AutoSize = true;
            this.mgLabel.BackColor = System.Drawing.SystemColors.Control;
            this.mgLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mgLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.mgLabel.Location = new System.Drawing.Point(305, 94);
            this.mgLabel.Name = "mgLabel";
            this.mgLabel.Size = new System.Drawing.Size(79, 16);
            this.mgLabel.TabIndex = 2;
            this.mgLabel.Text = "Martingale";
            this.mgLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // mgBoxValue
            // 
            this.mgBoxValue.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mgBoxValue.Location = new System.Drawing.Point(418, 89);
            this.mgBoxValue.Name = "mgBoxValue";
            this.mgBoxValue.Size = new System.Drawing.Size(100, 22);
            this.mgBoxValue.TabIndex = 1;
            this.mgBoxValue.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // typeMgErrorlabel
            // 
            this.typeMgErrorlabel.AutoSize = true;
            this.typeMgErrorlabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.typeMgErrorlabel.ForeColor = System.Drawing.Color.Red;
            this.typeMgErrorlabel.Location = new System.Drawing.Point(418, 65);
            this.typeMgErrorlabel.Name = "typeMgErrorlabel";
            this.typeMgErrorlabel.Size = new System.Drawing.Size(0, 17);
            this.typeMgErrorlabel.TabIndex = 1;
            // 
            // mgErrorLabel
            // 
            this.mgErrorLabel.AutoSize = true;
            this.mgErrorLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mgErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.mgErrorLabel.Location = new System.Drawing.Point(418, 114);
            this.mgErrorLabel.Name = "mgErrorLabel";
            this.mgErrorLabel.Size = new System.Drawing.Size(0, 17);
            this.mgErrorLabel.TabIndex = 1;
            // 
            // stakeErroLabel
            // 
            this.stakeErroLabel.AutoSize = true;
            this.stakeErroLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stakeErroLabel.ForeColor = System.Drawing.Color.Red;
            this.stakeErroLabel.Location = new System.Drawing.Point(418, 160);
            this.stakeErroLabel.Name = "stakeErroLabel";
            this.stakeErroLabel.Size = new System.Drawing.Size(0, 17);
            this.stakeErroLabel.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.SystemColors.Control;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.closeBtn.Location = new System.Drawing.Point(528, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(35, 31);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimizeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.minimizeBtn.Location = new System.Drawing.Point(496, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(35, 31);
            this.minimizeBtn.TabIndex = 0;
            this.minimizeBtn.Text = "-";
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 344);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.stakeErroLabel);
            this.Controls.Add(this.mgErrorLabel);
            this.Controls.Add(this.typeMgErrorlabel);
            this.Controls.Add(this.IniciarBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mgLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopLoss);
            this.Controls.Add(this.stopWin);
            this.Controls.Add(this.mgBoxValue);
            this.Controls.Add(this.stake);
            this.Controls.Add(this.tipoMartingGaleCombo);
            this.Controls.Add(this.mercadosCombo);
            this.Controls.Add(this.robosCombo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Config";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox robosCombo;
        private ComboBox tipoMartingGaleCombo;
        private ComboBox mercadosCombo;
        private TextBox stake;
        private TextBox stopWin;
        private TextBox stopLoss;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Panel panel1;
        private Button button1;
        private Button IniciarBtn;
        private Label mgValue;
        private TextBox mgBoxValue;
        private Label mgLabel;
        private Label marketErroLabel;
        private Label stopWinErroLabel;
        private Label roboErroLabel;
        private Label stopLossErroLabel;
        private Label typeMgErrorlabel;
        private Label mgErrorLabel;
        private Label stakeErroLabel;
        private Button closeBtn;
        private Label label1;
        private ComboBox accountTypeBox;
        private Label erroTipoContaTextBox;
        private Button minimizeBtn;
    }
}