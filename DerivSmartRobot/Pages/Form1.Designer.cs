using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Services;

namespace DerivSmartRobot.Pages
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


        async Task InitializeAsync()
        {
            //await webView21.EnsureCoreWebView2Async(null);

            //await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            //await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");

        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        ///
        /// 
        /// 
        private async  void InitializeComponent()
        {
            this.webView21 = new WebBrowser();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.Location = new System.Drawing.Point(4, 1);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(844, 429);
            this.webView21.Url = new System.Uri("https://www.google.com/?gws_rd=ssl", System.UriKind.Absolute);
            this.webView21.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 442);
            this.Controls.Add(this.webView21);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WebBrowser webView21;

    }
}