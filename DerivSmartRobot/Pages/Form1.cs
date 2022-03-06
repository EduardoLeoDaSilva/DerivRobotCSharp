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
        private readonly IServiceProvider _serviceProvider;
        public Form1(IServiceProvider provider)
        {
            _serviceProvider = provider;
            _tradeService = provider.GetRequiredService<ITradeService>();
            _hostedService  = provider.GetRequiredService<HostedService>();

            this.Resize += new System.EventHandler(this.Form_Resize);


            InitializeComponent();
            InitializeAsync();

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
        }
    }
}
