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
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Services;

namespace DerivSmartRobot.Pages
{
    public partial class Form1 : Form
    {
        private readonly ITradeService _tradeService;
        private readonly HostedService _hostedService;
        public Form1(IServiceProvider provider)
        {
            _tradeService = provider.GetRequiredService<ITradeService>();
            _hostedService  = provider.GetRequiredService<HostedService>();







            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            AllocConsole();


            var operationInfo = new OperationInfo
            {
                QuantLoss = 0,
                QuantWin = 0,
                RobotAccuracy = 0,
                CurrentOperationBalance = 0,
                LossToRecover = 0,
                LastValueLost = 0,
                NewAmount = 0
            };

            var RobotConfig = new RobotConfigutarion
            {
                Market = "",
                MartigaleType = MartingaleType.Normal,
                Stake = 0,
                MartingaleValue = 0,
                RobotType = RobotType.Digit,
                StopLoss = 0,
                StopWin = 0,
                MaxLossSequence = 0,
                MaxLossSequenceAfterThisProfit = 0
            };



            Console.WriteLine("--Bem vindo ao robo buceta do trovão--.");
            Console.WriteLine("Selecione o Robo:");
            Console.WriteLine("Digite 1 para o Robo RSI");
            Console.WriteLine("Digite 2 para o Robo Digito");
            Console.WriteLine("Digite 3 para o Robo MACD");
            Console.WriteLine("Digite 4 para o Robo RSI/MACD");

            if (Enum.TryParse<RobotType>(Console.ReadLine(), out var robotType))
                RobotConfig.RobotType = robotType;
            Console.WriteLine("Digite o mercado que quer trabalhar: ");
            RobotConfig.Market = Console.ReadLine();

            Console.WriteLine("Digite o valor do stake: ");
            if (decimal.TryParse(Console.ReadLine(), out var stake))
                RobotConfig.Stake = stake;

            Console.WriteLine("Digite o Tipo de martingale ");
            Console.WriteLine("1 para martingale normal ");
            Console.WriteLine("2 para martingale para recuperar valor perdido ");


            if (Enum.TryParse<MartingaleType>(Console.ReadLine(), out var martingale))
                RobotConfig.MartigaleType = martingale;

            if (RobotConfig.MartigaleType == MartingaleType.Normal)
            {
                Console.WriteLine("Digite o valor do martinggale: ");
                if (decimal.TryParse(Console.ReadLine(), out var martinga))
                    RobotConfig.MartingaleValue = martinga;
            }


            Console.WriteLine("Digite o valor da meta: ");
            if (decimal.TryParse(Console.ReadLine(), out var meta))
                RobotConfig.StopWin = meta;

            Console.WriteLine("Digite o valor do stopLoss: ");
            if (decimal.TryParse(Console.ReadLine(), out var stopLoss))
                RobotConfig.StopLoss = stopLoss;

            Console.WriteLine("Ativar sequencia maxima de loss? sim ou nao");
            var resposta = Console.ReadLine();
            if (resposta == "sim")
            {
                Console.WriteLine("Digite a sequencia máxima de perdas");
                if (int.TryParse(Console.ReadLine(), out var sequenciaPerdas))
                    RobotConfig.MaxLossSequence = sequenciaPerdas;


                Console.WriteLine("Ativar sequencia de perdas após qual valor?");
                if (decimal.TryParse(Console.ReadLine(), out var valorSequenciaPerdas))
                    RobotConfig.MaxLossSequenceAfterThisProfit = valorSequenciaPerdas;
            }



            try
            {
                _tradeService.currentOperation = operationInfo;
                _tradeService.RobotConfigutarion = RobotConfig;


                await _hostedService.StartAsync(CancellationToken.None);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Config(_tradeService, _hostedService);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
