using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;

namespace DerivSmartRobot.Pages
{
    public partial class Browser : Form
    {
        private bool ExchangeAuthSucess = false;
        private System.Threading.Timer t;
        private readonly IServiceProvider _serviceProvider;
        private User _user;
        private DateTime ConsultDeadLine;

        public Browser(IServiceProvider serviceProvider, User user)
        {
            _serviceProvider = serviceProvider;
            _user = user;

            InitializeComponent();
            InitializeAsync();
            t = new System.Threading.Timer(TimerCallback, null, 0, 5000);
            ConsultDeadLine = DateTime.Now.AddMinutes(2);
        }



        private void Process_Exited(object sender, EventArgs e)
        {
            this.label1.Text = "Por favor aguardo. Estamos sincronizando os dados";
        }


        //private void webview_onPostMessage(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
        //{
        //    var msg  =e.TryGetWebMessageAsString();

        //    if ((!string.IsNullOrEmpty(msg)) && msg == "sucesso")
        //    {
        //        ExchangeAuthSucess = true;
        //        this.Close();
        //    }else if ((!string.IsNullOrEmpty(msg)) && msg == "falha")
        //    {
        //        ExchangeAuthSucess = false;
        //        this.Close();
        //    }

        //}

        private void onClosed(object? sender, EventArgs e)
        {
            if (ExchangeAuthSucess == false)
            {
                MessageBox.Show("Login na corretora não efetuado com sucesso.");
            }
        }

        private void webView1_Load(object sender, EventArgs e)
        {


        }

        public delegate void TimerCallbackDelegate(object o);

        //Método invocado passado para a classe Timer
        public async void TimerCallback(Object o)
        {
            var authService = _serviceProvider.GetRequiredService<IAuthService>();
            try
            {

                if (DateTime.Now > ConsultDeadLine)
                {
                    t.Dispose();

                    var tt =   MessageBox.Show("Tempo limite de espera atingindo, refaça o login e tente novamente");
                    process.Kill();
                    Application.Exit();
                }

                //Verifica se é necessário invocar esse método na thread principal para interagir com os controles
                if (InvokeRequired)
                {
                    //Invoca este próprio método
                    Invoke((TimerCallbackDelegate)TimerCallback, o);

                }
                else
                {
                    //Aqui seu código estará rodando na thread principal e será possível interagir com os componentes
                    if (string.IsNullOrEmpty(_user.TokensOAuth) || DateTime.Now > _user.TokenDateDeadLine || _user.TokenDateDeadLine == null)
                    {
                        var user = await authService.GetOAuthData(_user.Email, _user.JwtToken);
                        if (user != null)
                        {
                            _user.Id = user.Id;
                            _user.Robots = user.Robots;
                            _user.Active = user.Active;
                            _user.Email = user.Email;
                            _user.Password = user.Password;
                            _user.TokenDateDeadLine = user.TokenDateDeadLine;
                            _user.TokensOAuth = user.TokensOAuth;
                        }
                    }
                    else
                    {
                        t.Dispose();

                        var traderService = _serviceProvider.GetRequiredService<ITradeService>();
                        var hostedService = _serviceProvider.GetRequiredService<HostedService>();
                        this.Hide();

                        var form2 = new Config(traderService, hostedService, _serviceProvider, _user);
                        form2.Closed += (s, args) => this.Close();
                        form2.Show();

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
