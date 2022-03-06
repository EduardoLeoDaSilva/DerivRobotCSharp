using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DerivSmartRobot.Services;

namespace DerivSmartRobot.Pages
{
    public partial class Login : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public Login(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void entrarBtn_Click(object sender, EventArgs e)
        {
            var authService = _serviceProvider.GetRequiredService<IAuthService>();

            var isValid = false;
            if (string.IsNullOrEmpty(emailTextBox.Text))
            {
                erroEmail.Text = "Campo e-mail obrigatório";
                erroGeralLogin.Text = "";
            }
            else
            {
                erroEmail.Text = "";
                erroGeralLogin.Text = "";
                isValid = true;

            }

            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                erroPassword.Text = "Campo senha obrigatório";
                erroGeralLogin.Text = "";
                
            }
            else
            {
                erroPassword.Text = "";
                erroGeralLogin.Text = "";
                isValid = true;

            }

            if (isValid == false)
            {
                return;
            }

            try
            {

                var result = await authService.Login(emailTextBox.Text, passwordTextBox.Text);

                if (result == null)
                {
                    erroGeralLogin.Text = "Usuário não encontrado";
                }
                else
                {
                    erroGeralLogin.Text = "";

                    isValid = true;
                    if (isValid)
                    {
                        this.Hide();
                        var form2 = new Browser(_serviceProvider, result);
                        form2.Closed += (s, args) => this.Close();
                        form2.Show();
                    }
                }
            }
            catch (Exception exception)
            {
                erroGeralLogin.Text = exception.Message;

            }





        }


        private void minimizeBtn_Click(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
