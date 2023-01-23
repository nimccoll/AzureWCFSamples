//===============================================================================
// Microsoft FastTrack for Azure
// Azure Active Directory Native Client Authentication Samples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADWinForms
{
    public partial class FSupervisorLogin : Form
    {
        private List<string> _scopes = new List<string>() { "openid", "offline_access", "profile" };
        private readonly string _tenantId = ConfigurationManager.AppSettings["TenantId"];
        private readonly string _clientId = ConfigurationManager.AppSettings["ClientId"];
        private readonly string _redirectUri = ConfigurationManager.AppSettings["RedirectUri"];
        private Stack<string> errors = new Stack<string>();

        public FSupervisorLogin()
        {
            InitializeComponent();
        }

        private async void LoginInteractively(bool isSupervisor)
        {
            string accessToken = string.Empty;
            string idToken = string.Empty;
            string userName = string.Empty;
            bool status = false;

            try
            {
                IPublicClientApplication app = PublicClientApplicationBuilder.Create(_clientId).WithRedirectUri(_redirectUri).WithTenantId(_tenantId).WithAuthority(AadAuthorityAudience.AzureAdMyOrg).Build();
                AuthenticationResult authResult = null/* TODO Change to default(_) if this is not a reference type */;

                IEnumerable<IAccount> accounts = await app.GetAccountsAsync();
                // The WithPrompt option will always force the user to sign in - no single sign-on
                authResult = await app.AcquireTokenInteractive(_scopes).WithPrompt(Prompt.ForceLogin).ExecuteAsync();

                if (authResult.AccessToken != string.Empty)
                {
                    accessToken = authResult.AccessToken;
                    idToken = authResult.IdToken;
                    userName = authResult.ClaimsPrincipal.Claims.Where(c => c.Type == "name").FirstOrDefault().Value;
                    status = true;
                }
            }
            catch (Exception ex)
            {
                errors.Push(ex.Message);
            }

            // Since this thread runs under the ui thread, we need a delegate method to update the text boxes
            if (isSupervisor)
            {
                lblSupervisorName.BeginInvoke(new InvokeDelegate(UpdateSupervisorUI), userName, status);
            }
            else
            {
                lblUserName.BeginInvoke(new InvokeDelegate(UpdateUI), userName, status);
            }

            return;
        }

        private delegate void InvokeDelegate(string userName, bool status);
        private void UpdateSupervisorUI(string userName, bool status)
        {
            lblSupervisorName.Text = userName;
            lblSupervisorStatus.Text = status ? "Success" : "Failed";
        }

        private void UpdateUI(string userName, bool status)
        {
            lblUserName.Text = userName;
            lblUserStatus.Text = status ? "Success" : "Failed";
            if (status)
            {
                btnSupervisorSignIn.Enabled = true;
            }
        }

        private void btnCurrentUserSignIn_Click(object sender, EventArgs e)
        {
            lblUserName.Text = string.Empty;
            lblUserStatus.Text = string.Empty;
            lblSupervisorName.Text = string.Empty;
            lblSupervisorStatus.Text = string.Empty;
            btnSupervisorSignIn.Enabled = false;

            Task task = Task.Factory.StartNew(() => { LoginInteractively(false); });
            task.Wait();

            if (errors.Count > 0)
            {
                StringBuilder errorMessages = new StringBuilder();
                while (errors.Count > 0)
                {
                    if (errorMessages.Length > 0) errorMessages.Append("\r\n");
                    errorMessages.Append(errors.Pop());
                }
                MessageBox.Show($"Errors encountered: {errorMessages}");
            }
        }

        private void btnSupervisorSignIn_Click(object sender, EventArgs e)
        {
            lblSupervisorName.Text = string.Empty;
            lblSupervisorStatus.Text = string.Empty;

            Task task = Task.Factory.StartNew(() => { LoginInteractively(true); });
            task.Wait();

            if (errors.Count > 0)
            {
                StringBuilder errorMessages = new StringBuilder();
                while (errors.Count > 0)
                {
                    if (errorMessages.Length > 0) errorMessages.Append("\r\n");
                    errorMessages.Append(errors.Pop());
                }
                MessageBox.Show($"Errors encountered: {errorMessages}");
            }
        }
    }
}
