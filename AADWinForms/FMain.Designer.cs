
namespace AADWinForms
{
    partial class FMain
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
            this.btnSignIn = new System.Windows.Forms.Button();
            this.txtIdToken = new System.Windows.Forms.TextBox();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.lblIdToken = new System.Windows.Forms.Label();
            this.lblAccessToken = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCallService = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWCFResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(389, 332);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(200, 100);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // txtIdToken
            // 
            this.txtIdToken.Location = new System.Drawing.Point(288, 529);
            this.txtIdToken.Multiline = true;
            this.txtIdToken.Name = "txtIdToken";
            this.txtIdToken.ReadOnly = true;
            this.txtIdToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIdToken.Size = new System.Drawing.Size(905, 150);
            this.txtIdToken.TabIndex = 1;
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(288, 733);
            this.txtAccessToken.Multiline = true;
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.ReadOnly = true;
            this.txtAccessToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccessToken.Size = new System.Drawing.Size(905, 150);
            this.txtAccessToken.TabIndex = 2;
            // 
            // lblIdToken
            // 
            this.lblIdToken.AutoSize = true;
            this.lblIdToken.Location = new System.Drawing.Point(178, 535);
            this.lblIdToken.Name = "lblIdToken";
            this.lblIdToken.Size = new System.Drawing.Size(104, 25);
            this.lblIdToken.TabIndex = 3;
            this.lblIdToken.Text = "ID Token:";
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Location = new System.Drawing.Point(128, 739);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(154, 25);
            this.lblAccessToken.TabIndex = 4;
            this.lblAccessToken.Text = "Access Token:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(288, 462);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 25);
            this.lblUserName.TabIndex = 5;
            // 
            // btnCallService
            // 
            this.btnCallService.Enabled = false;
            this.btnCallService.Location = new System.Drawing.Point(657, 332);
            this.btnCallService.Name = "btnCallService";
            this.btnCallService.Size = new System.Drawing.Size(200, 100);
            this.btnCallService.TabIndex = 6;
            this.btnCallService.Text = "Call WCF Service";
            this.btnCallService.UseVisualStyleBackColor = true;
            this.btnCallService.Click += new System.EventHandler(this.btnCallService_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 908);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "WCF Results:";
            // 
            // lblWCFResults
            // 
            this.lblWCFResults.AutoSize = true;
            this.lblWCFResults.Location = new System.Drawing.Point(288, 908);
            this.lblWCFResults.Name = "lblWCFResults";
            this.lblWCFResults.Size = new System.Drawing.Size(0, 25);
            this.lblWCFResults.TabIndex = 8;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 953);
            this.Controls.Add(this.lblWCFResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCallService);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblAccessToken);
            this.Controls.Add(this.lblIdToken);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.txtIdToken);
            this.Controls.Add(this.btnSignIn);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForms Azure AD Login Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox txtIdToken;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.Label lblIdToken;
        private System.Windows.Forms.Label lblAccessToken;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnCallService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWCFResults;
    }
}

