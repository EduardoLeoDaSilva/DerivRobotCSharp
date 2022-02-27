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
            this.IniciarBtn = new System.Windows.Forms.Button();
            this.mgLabel = new System.Windows.Forms.Label();
            this.mgBoxValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // robosCombo
            // 
            this.robosCombo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.robosCombo.FormattingEnabled = true;
            this.robosCombo.Location = new System.Drawing.Point(107, 81);
            this.robosCombo.Name = "robosCombo";
            this.robosCombo.Size = new System.Drawing.Size(121, 25);
            this.robosCombo.TabIndex = 0;
            // 
            // tipoMartingGaleCombo
            // 
            this.tipoMartingGaleCombo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tipoMartingGaleCombo.FormattingEnabled = true;
            this.tipoMartingGaleCombo.Location = new System.Drawing.Point(418, 37);
            this.tipoMartingGaleCombo.Name = "tipoMartingGaleCombo";
            this.tipoMartingGaleCombo.Size = new System.Drawing.Size(121, 25);
            this.tipoMartingGaleCombo.TabIndex = 0;
            // 
            // mercadosCombo
            // 
            this.mercadosCombo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mercadosCombo.FormattingEnabled = true;
            this.mercadosCombo.Location = new System.Drawing.Point(107, 42);
            this.mercadosCombo.Name = "mercadosCombo";
            this.mercadosCombo.Size = new System.Drawing.Size(121, 25);
            this.mercadosCombo.TabIndex = 0;
            this.mercadosCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // stake
            // 
            this.stake.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stake.Location = new System.Drawing.Point(418, 115);
            this.stake.Name = "stake";
            this.stake.Size = new System.Drawing.Size(100, 22);
            this.stake.TabIndex = 1;
            this.stake.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // stopWin
            // 
            this.stopWin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopWin.Location = new System.Drawing.Point(107, 137);
            this.stopWin.Name = "stopWin";
            this.stopWin.Size = new System.Drawing.Size(100, 22);
            this.stopWin.TabIndex = 1;
            // 
            // stopLoss
            // 
            this.stopLoss.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopLoss.Location = new System.Drawing.Point(107, 175);
            this.stopLoss.Name = "stopLoss";
            this.stopLoss.Size = new System.Drawing.Size(100, 22);
            this.stopLoss.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.OrangeRed;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mercado";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.OrangeRed;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Robô";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(305, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tipo Martingale";
            this.label5.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(305, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Stake";
            this.label6.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.OrangeRed;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stopwin";
            this.label7.Click += new System.EventHandler(this.label3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.OrangeRed;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(25, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Stoploss";
            this.label8.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 253);
            this.panel1.TabIndex = 3;
            // 
            // IniciarBtn
            // 
            this.IniciarBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.IniciarBtn.FlatAppearance.BorderSize = 0;
            this.IniciarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IniciarBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IniciarBtn.ForeColor = System.Drawing.Color.White;
            this.IniciarBtn.Location = new System.Drawing.Point(339, 183);
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
            this.mgLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mgLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.mgLabel.Location = new System.Drawing.Point(305, 81);
            this.mgLabel.Name = "mgLabel";
            this.mgLabel.Size = new System.Drawing.Size(77, 17);
            this.mgLabel.TabIndex = 2;
            this.mgLabel.Text = "Martingale";
            this.mgLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // mgBoxValue
            // 
            this.mgBoxValue.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mgBoxValue.Location = new System.Drawing.Point(418, 76);
            this.mgBoxValue.Name = "mgBoxValue";
            this.mgBoxValue.Size = new System.Drawing.Size(100, 22);
            this.mgBoxValue.TabIndex = 1;
            this.mgBoxValue.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 248);
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
    }
}