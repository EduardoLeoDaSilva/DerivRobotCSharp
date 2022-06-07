using System.Diagnostics;
using System.Windows.Forms;

namespace DerivSmartRobot.Pages
{
    partial class Dash
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.martingaleLabel = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.StopLossLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stopWinLabel = new System.Windows.Forms.Label();
            this.stakeLabel = new System.Windows.Forms.Label();
            this.mercadoLabel = new System.Windows.Forms.Label();
            this.roboTipoLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.saldoGeralLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.vitoriasLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.porcentagemVitoriaLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.derrotasLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.analiseLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.listViewOperacoes = new System.Windows.Forms.ListView();
            this.ContratoId = new System.Windows.Forms.ColumnHeader();
            this.Tempo = new System.Windows.Forms.ColumnHeader();
            this.Contrato = new System.Windows.Forms.ColumnHeader();
            this.Mercado = new System.Windows.Forms.ColumnHeader();
            this.Stake = new System.Windows.Forms.ColumnHeader();
            this.Duração = new System.Windows.Forms.ColumnHeader();
            this.TipoDuração = new System.Windows.Forms.ColumnHeader();
            this.Profit = new System.Windows.Forms.ColumnHeader();
            this.label18 = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            tableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tableLayoutPanel1.Location = new System.Drawing.Point(12, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1102, 118);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.martingaleLabel);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.StopLossLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.stopWinLabel);
            this.panel1.Controls.Add(this.stakeLabel);
            this.panel1.Controls.Add(this.mercadoLabel);
            this.panel1.Controls.Add(this.roboTipoLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 110);
            this.panel1.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(121, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 16);
            this.label19.TabIndex = 1;
            this.label19.Text = "TipoRobo:";
            this.label19.Click += new System.EventHandler(this.label2_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(121, 67);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 16);
            this.label23.TabIndex = 1;
            this.label23.Text = "Mercado:";
            this.label23.Click += new System.EventHandler(this.label2_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(121, 89);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 16);
            this.label24.TabIndex = 1;
            this.label24.Text = "Stake:";
            this.label24.Click += new System.EventHandler(this.label2_Click);
            // 
            // martingaleLabel
            // 
            this.martingaleLabel.AutoSize = true;
            this.martingaleLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.martingaleLabel.ForeColor = System.Drawing.Color.Black;
            this.martingaleLabel.Location = new System.Drawing.Point(77, 91);
            this.martingaleLabel.Name = "martingaleLabel";
            this.martingaleLabel.Size = new System.Drawing.Size(79, 17);
            this.martingaleLabel.TabIndex = 1;
            this.martingaleLabel.Text = "carregando";
            this.martingaleLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(12, 89);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 16);
            this.label28.TabIndex = 1;
            this.label28.Text = "ValorMg:";
            this.label28.Click += new System.EventHandler(this.label3_Click);
            // 
            // StopLossLabel
            // 
            this.StopLossLabel.AutoSize = true;
            this.StopLossLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StopLossLabel.ForeColor = System.Drawing.Color.Black;
            this.StopLossLabel.Location = new System.Drawing.Point(77, 69);
            this.StopLossLabel.Name = "StopLossLabel";
            this.StopLossLabel.Size = new System.Drawing.Size(79, 17);
            this.StopLossLabel.TabIndex = 1;
            this.StopLossLabel.Text = "carregando";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "StopLoss:";
            // 
            // stopWinLabel
            // 
            this.stopWinLabel.AutoSize = true;
            this.stopWinLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopWinLabel.ForeColor = System.Drawing.Color.Black;
            this.stopWinLabel.Location = new System.Drawing.Point(77, 49);
            this.stopWinLabel.Name = "stopWinLabel";
            this.stopWinLabel.Size = new System.Drawing.Size(79, 17);
            this.stopWinLabel.TabIndex = 1;
            this.stopWinLabel.Text = "carregando";
            this.stopWinLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // stakeLabel
            // 
            this.stakeLabel.AutoSize = true;
            this.stakeLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stakeLabel.ForeColor = System.Drawing.Color.Black;
            this.stakeLabel.Location = new System.Drawing.Point(174, 91);
            this.stakeLabel.Name = "stakeLabel";
            this.stakeLabel.Size = new System.Drawing.Size(79, 17);
            this.stakeLabel.TabIndex = 1;
            this.stakeLabel.Text = "carregando";
            this.stakeLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // mercadoLabel
            // 
            this.mercadoLabel.AutoSize = true;
            this.mercadoLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mercadoLabel.ForeColor = System.Drawing.Color.Black;
            this.mercadoLabel.Location = new System.Drawing.Point(191, 68);
            this.mercadoLabel.Name = "mercadoLabel";
            this.mercadoLabel.Size = new System.Drawing.Size(79, 17);
            this.mercadoLabel.TabIndex = 1;
            this.mercadoLabel.Text = "carregando";
            this.mercadoLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // roboTipoLabel
            // 
            this.roboTipoLabel.AutoSize = true;
            this.roboTipoLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.roboTipoLabel.ForeColor = System.Drawing.Color.Black;
            this.roboTipoLabel.Location = new System.Drawing.Point(191, 49);
            this.roboTipoLabel.Name = "roboTipoLabel";
            this.roboTipoLabel.Size = new System.Drawing.Size(79, 17);
            this.roboTipoLabel.TabIndex = 1;
            this.roboTipoLabel.Text = "carregando";
            this.roboTipoLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "StopWin:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Robô";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.balanceLabel);
            this.panel2.Controls.Add(this.saldoGeralLabel);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(278, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 110);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(74, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "USD";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.balanceLabel.ForeColor = System.Drawing.Color.White;
            this.balanceLabel.Location = new System.Drawing.Point(167, 51);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(0, 22);
            this.balanceLabel.TabIndex = 1;
            this.balanceLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // saldoGeralLabel
            // 
            this.saldoGeralLabel.AutoSize = true;
            this.saldoGeralLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saldoGeralLabel.ForeColor = System.Drawing.Color.White;
            this.saldoGeralLabel.Location = new System.Drawing.Point(127, 83);
            this.saldoGeralLabel.Name = "saldoGeralLabel";
            this.saldoGeralLabel.Size = new System.Drawing.Size(16, 18);
            this.saldoGeralLabel.TabIndex = 0;
            this.saldoGeralLabel.Text = "0";
            this.saldoGeralLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.saldoGeralLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Saldo Conta: $ ";
            this.label6.Click += new System.EventHandler(this.label5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Saldo Atual";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.vitoriasLabel);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.porcentagemVitoriaLabel);
            this.panel3.Location = new System.Drawing.Point(553, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 110);
            this.panel3.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(11, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 23);
            this.label12.TabIndex = 1;
            this.label12.Text = "%";
            // 
            // vitoriasLabel
            // 
            this.vitoriasLabel.AutoSize = true;
            this.vitoriasLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vitoriasLabel.ForeColor = System.Drawing.Color.White;
            this.vitoriasLabel.Location = new System.Drawing.Point(211, 51);
            this.vitoriasLabel.Name = "vitoriasLabel";
            this.vitoriasLabel.Size = new System.Drawing.Size(0, 22);
            this.vitoriasLabel.TabIndex = 1;
            this.vitoriasLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Vitórias";
            // 
            // porcentagemVitoriaLabel
            // 
            this.porcentagemVitoriaLabel.AutoSize = true;
            this.porcentagemVitoriaLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.porcentagemVitoriaLabel.ForeColor = System.Drawing.Color.White;
            this.porcentagemVitoriaLabel.Location = new System.Drawing.Point(192, 84);
            this.porcentagemVitoriaLabel.Name = "porcentagemVitoriaLabel";
            this.porcentagemVitoriaLabel.Size = new System.Drawing.Size(32, 22);
            this.porcentagemVitoriaLabel.TabIndex = 1;
            this.porcentagemVitoriaLabel.Text = "50";
            this.porcentagemVitoriaLabel.Click += new System.EventHandler(this.label10_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panel4.Controls.Add(this.derrotasLabel);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Location = new System.Drawing.Point(828, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(271, 110);
            this.panel4.TabIndex = 3;
            // 
            // derrotasLabel
            // 
            this.derrotasLabel.AutoSize = true;
            this.derrotasLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.derrotasLabel.ForeColor = System.Drawing.Color.White;
            this.derrotasLabel.Location = new System.Drawing.Point(214, 51);
            this.derrotasLabel.Name = "derrotasLabel";
            this.derrotasLabel.Size = new System.Drawing.Size(0, 22);
            this.derrotasLabel.TabIndex = 1;
            this.derrotasLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(14, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 23);
            this.label14.TabIndex = 0;
            this.label14.Text = "Derrotas";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.analiseLabel);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Location = new System.Drawing.Point(3, 193);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(407, 407);
            this.panel5.TabIndex = 4;
            // 
            // analiseLabel
            // 
            this.analiseLabel.AutoSize = true;
            this.analiseLabel.Font = new System.Drawing.Font("Century Gothic", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.analiseLabel.Location = new System.Drawing.Point(15, 74);
            this.analiseLabel.Name = "analiseLabel";
            this.analiseLabel.Size = new System.Drawing.Size(0, 19);
            this.analiseLabel.TabIndex = 1;
            this.analiseLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label17.Location = new System.Drawing.Point(160, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 25);
            this.label17.TabIndex = 0;
            this.label17.Text = "Análise";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(tableLayoutPanel1);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(0, 33);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1126, 159);
            this.panel6.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel7.Location = new System.Drawing.Point(0, 1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(559, 156);
            this.panel7.TabIndex = 1;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimizeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.minimizeBtn.Location = new System.Drawing.Point(1054, 2);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(35, 31);
            this.minimizeBtn.TabIndex = 0;
            this.minimizeBtn.Text = "-";
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.SystemColors.Control;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.closeBtn.Location = new System.Drawing.Point(1091, 2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(35, 31);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panel9
            // 
            this.panel9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.listViewOperacoes);
            this.panel9.Controls.Add(this.label18);
            this.panel9.Location = new System.Drawing.Point(416, 193);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(710, 407);
            this.panel9.TabIndex = 6;
            // 
            // listViewOperacoes
            // 
            this.listViewOperacoes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewOperacoes.BackColor = System.Drawing.SystemColors.Control;
            this.listViewOperacoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewOperacoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContratoId,
            this.Tempo,
            this.Contrato,
            this.Mercado,
            this.Stake,
            this.Duração,
            this.TipoDuração,
            this.Profit});
            this.listViewOperacoes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listViewOperacoes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOperacoes.Location = new System.Drawing.Point(3, 55);
            this.listViewOperacoes.MultiSelect = false;
            this.listViewOperacoes.Name = "listViewOperacoes";
            this.listViewOperacoes.Size = new System.Drawing.Size(704, 352);
            this.listViewOperacoes.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listViewOperacoes.TabIndex = 1;
            this.listViewOperacoes.UseCompatibleStateImageBehavior = false;
            this.listViewOperacoes.View = System.Windows.Forms.View.Details;
            this.listViewOperacoes.SelectedIndexChanged += new System.EventHandler(this.listViewOperacoes_SelectedIndexChanged);
            // 
            // ContratoId
            // 
            this.ContratoId.Tag = "ContratoId";
            this.ContratoId.Text = "ContratoId";
            this.ContratoId.Width = 120;
            // 
            // Tempo
            // 
            this.Tempo.Text = "Tempo";
            this.Tempo.Width = 100;
            // 
            // Contrato
            // 
            this.Contrato.Tag = "Contrato";
            this.Contrato.Text = "Contrato";
            this.Contrato.Width = 80;
            // 
            // Mercado
            // 
            this.Mercado.Tag = "Mercado";
            this.Mercado.Text = "Mercado";
            this.Mercado.Width = 90;
            // 
            // Stake
            // 
            this.Stake.Tag = "Stake";
            this.Stake.Text = "Stake";
            this.Stake.Width = 70;
            // 
            // Duração
            // 
            this.Duração.Tag = "Duração";
            this.Duração.Text = "Duração";
            this.Duração.Width = 70;
            // 
            // TipoDuração
            // 
            this.TipoDuração.Tag = "TipoDuração";
            this.TipoDuração.Text = "TipoDuração";
            this.TipoDuração.Width = 80;
            // 
            // Profit
            // 
            this.Profit.Tag = "Profit";
            this.Profit.Text = "Profit";
            this.Profit.Width = 100;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.label18.Location = new System.Drawing.Point(254, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(126, 25);
            this.label18.TabIndex = 0;
            this.label18.Text = "Operações";
            // 
            // Dash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1126, 603);
            this.ControlBox = false;
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dash";
            this.Text = "Dash";
            this.Load += new System.EventHandler(this.Dash_Load);
            this.MouseDown += OnMouseDown;

            tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel5;
        private Panel panel6;
        private Panel panel9;
        private Panel panel1;
        private Label label4;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label balanceLabel;
        private Label label5;
        private Label label12;
        private Label vitoriasLabel;
        private Label label9;
        private Label porcentagemVitoriaLabel;
        private Label derrotasLabel;
        private Label label14;
        private Label label17;
        private Label label18;
        private Panel panel7;
        private Label StopLossLabel;
        private Label label19;
        private Label martingaleLabel;
        private Label label28;
        private Label stopWinLabel;
        private Label stakeLabel;
        private Label label24;
        private Label mercadoLabel;
        private Label label23;
        private Label roboTipoLabel;
        private ListView listViewOperacoes;
        private ColumnHeader Contrato;
        private ColumnHeader Stake;
        private ColumnHeader Duração;
        private ColumnHeader TipoDuração;
        private ColumnHeader Profit;
        private Label label3;
        private ColumnHeader Mercado;
        private ColumnHeader ContratoId;
        private Label saldoGeralLabel;
        private Label label6;
        private ColumnHeader Logs;
        private ColumnHeader Data;
        private Button closeBtn;
        private Process Process;
        private Button minimizeBtn;
        private Label analiseLabel;
        private Panel panel8;
        private ColumnHeader Tempo;
    }
}