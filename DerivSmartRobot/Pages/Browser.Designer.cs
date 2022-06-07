
using System.Diagnostics;
using DerivSmartRobot.Services;

namespace DerivSmartRobot.Pages
{
    partial class Browser
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

        async void InitializeAsync()
        {
            var authService = _serviceProvider.GetRequiredService<IAuthService>();

           if (string.IsNullOrEmpty(_user.TokensOAuth) || DateTime.Now > _user.TokenDateDeadLine || _user.TokenDateDeadLine == null)
           {

              process= Process.Start("rundll32", "url.dll,FileProtocolHandler https://oauth.binary.com/oauth2/authorize?app_id=31306");
           }
           else
           {
               this.label1.Text = "Aguarde, sincronizando dados";
           }

            //await webview.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            //await webview.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");

        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Faça o login na corretora pelo navegador.";
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(522, 95);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.Name = "Browser";
            this.Text = "Browser";
            this.Closed += new System.EventHandler(this.onClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Label label1;
        private Process process;
    }
}