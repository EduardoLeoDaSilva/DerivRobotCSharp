using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Services;

namespace DerivSmartRobot.Pages
{
    public partial class Dash : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITradeService _tradeService;
        private readonly ReaderService _readerService;
        private System.Threading.Timer t;
        public int LeftSeconds { get; set; } = 0;
        public Dash(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _tradeService = _serviceProvider.GetRequiredService<ITradeService>();
            _readerService = serviceProvider.GetRequiredService<ReaderService>();
            InitializeComponent();
            t = new System.Threading.Timer(TimerCallback, null, 0, 1000);

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void listViewOperacoes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public delegate void TimerCallbackDelegate(object o);

        //Método invocado passado para a classe Timer
        public void TimerCallback(Object o)
        {

            try
            {

                //Verifica se é necessário invocar esse método na thread principal para interagir com os controles
                if (InvokeRequired)
                {
                    //Invoca este próprio método
                    Invoke((TimerCallbackDelegate)TimerCallback, o);

                }
                else
                {

                    //Aqui seu código estará rodando na thread principal e será possível interagir com os componentes
                    var roboOperationInfos = _tradeService.GetOperations();


                    if (roboOperationInfos.Log != null)
                    {
                        if (LeftSeconds > 0)
                        {
                           LeftSeconds -= 1;
                        }
                        var logs = roboOperationInfos.Log.Log.Split(';');
                        string analise = $"Data: {DateTime.Now}\n";
                        foreach (var log in logs)
                        {
                            var it = new ListViewItem(new[] { roboOperationInfos.Log.Date.ToString("g"), log });
                            analise += $"\n {log}";
                        }

                        analiseLabel.Text = analise;
                    }

                    if (roboOperationInfos != null)
                    {


                        balanceLabel.Text = roboOperationInfos.OperationInfo.CurrentOperationBalance.ToString("F2");
                        saldoGeralLabel.Text = roboOperationInfos.OperationInfo.Balance.ToString("F2");


                        if (roboOperationInfos.RobotConfigutarion != null)
                        {
                            mercadoLabel.Text = roboOperationInfos.RobotConfigutarion.Market;
                            stakeLabel.Text = roboOperationInfos.RobotConfigutarion.Stake.ToString("F2");
                            roboTipoLabel.Text = roboOperationInfos.RobotConfigutarion.RobotType.ToString();
                            stopWinLabel.Text = roboOperationInfos.RobotConfigutarion.StopWin.ToString("F2");
                            StopLossLabel.Text = roboOperationInfos.RobotConfigutarion.StopLoss.ToString("F2");
                            martingaleLabel.Text = roboOperationInfos.RobotConfigutarion.MartingaleValue.ToString("F2");
                        }

                        if (roboOperationInfos.OperationInfo != null)
                        {
                            vitoriasLabel.Text = roboOperationInfos.OperationInfo.QuantWin.ToString();
                            derrotasLabel.Text = roboOperationInfos.OperationInfo.QuantLoss.ToString();
                            porcentagemVitoriaLabel.Text = roboOperationInfos.OperationInfo.RobotAccuracy.ToString("F2");
                        }

                       
                            var op = roboOperationInfos.Operation;


                            if (LeftSeconds <= 0 && op != null)
                            {
                                LeftSeconds = (int)(op.Expiration -DateTime.Now).TotalSeconds;

                            }

                            var item = listViewOperacoes.FindItemWithText(op.ContractId);

                                if (item != null)
                                {
                                    listViewOperacoes.Items.Remove(item);


                                    item = new ListViewItem(new[]
                                    {
                                    
                                    op.ContractId,  LeftSeconds <= 0 || (op.Status == "won" || op.Status=="lost") ? "vendido"  : LeftSeconds.ToString(), op.Contract.ToString(), op.Market.ToString(),
                                   
                                    op.Amount.ToString("F2"), op.Duration.ToString(), op.DurationType,
                                    op.Profit.ToString("F2")
                                });

                                    if (op.Status == "won")
                                    {
                                        item.BackColor = Color.MediumSeaGreen;
                                        item.ForeColor = Color.White;
                                        _tradeService.Operation = null;
                                        _tradeService.HasOpenContract = false;

                                        LeftSeconds = 0;
                                    }
                                    else if(op.Status =="lost")
                                    {
                                        item.BackColor = Color.DarkRed;
                                        item.ForeColor = Color.White;
                                        _tradeService.HasOpenContract = false;
                                        LeftSeconds = 0;


                                    }
                                    else
                                    {
                                        item.BackColor = Color.Goldenrod ;
                                        item.ForeColor = Color.White;
                                        
                                }

                                    listViewOperacoes.Items.Add(item);


                                }
                                else
                                {
                                    item = new ListViewItem(new[] { op.ContractId, LeftSeconds <= 0 ? "vendido" : LeftSeconds.ToString(), op.Contract.ToString(), op.Market.ToString(), (op.Amount * -1).ToString("F2"), op.Duration.ToString(), op.DurationType, op.Profit.ToString("F2") });
                                    listViewOperacoes.Items.Add(item);
                                }
                            

                        }

                    }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dash_Load(object sender, EventArgs e)
        {

        }

        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
