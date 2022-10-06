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
using AADWinForms.ServiceReference1;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADWinForms
{
    public partial class FMain : Form
    {
        private string _idToken = string.Empty;
        private string _accessToken = string.Empty;
        private string _userName = string.Empty;
        private List<string> _scopes = new List<string>() { "openid", "offline_access", "profile" };
        private readonly string _tenantId = ConfigurationManager.AppSettings["TenantId"];
        private readonly string _clientId = ConfigurationManager.AppSettings["ClientId"];
        private readonly string _redirectUri = ConfigurationManager.AppSettings["RedirectUri"];
        private Stack<string> errors = new Stack<string>();

        public FMain()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            txtIdToken.Text = string.Empty;
            txtAccessToken.Text = string.Empty;

            _idToken = string.Empty;
            _accessToken = string.Empty;

            Task task = new Task(LoginInteractively);
            task.Start();
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

        private async void LoginInteractively()
        {
            try
            {
                IPublicClientApplication app = PublicClientApplicationBuilder.Create(_clientId).WithRedirectUri(_redirectUri).WithTenantId(_tenantId).WithAuthority(AadAuthorityAudience.AzureAdMyOrg).Build();
                AuthenticationResult authResult = null/* TODO Change to default(_) if this is not a reference type */;

                IEnumerable<IAccount> accounts = await app.GetAccountsAsync();
                bool performInterativeFlow = false;
                string apiScope = ConfigurationManager.AppSettings["APIScope"];

                if (!string.IsNullOrEmpty(apiScope)) _scopes.Add(apiScope);

                try
                {
                    authResult = await app.AcquireTokenSilent(_scopes, accounts.FirstOrDefault()).ExecuteAsync();
                }
                catch (MsalUiRequiredException ex)
                {
                    performInterativeFlow = true;
                }
                catch (Exception ex)
                {
                    errors.Push(ex.Message);
                }

                if (performInterativeFlow)
                    authResult = await app.AcquireTokenInteractive(_scopes).ExecuteAsync();

                if (authResult.AccessToken != string.Empty)
                {
                    _accessToken = authResult.AccessToken;
                    _idToken = authResult.IdToken;
                    _userName = authResult.ClaimsPrincipal.Claims.Where(c => c.Type == "name").FirstOrDefault().Value;
                }
            }
            catch (Exception ex)
            {
                errors.Push(ex.Message);
                return;
            }

            // Since this thread runs under the ui thread, we need a delegate method to update the text boxes
            txtAccessToken.BeginInvoke(new InvokeDelegate(UpdateUI));

            return;
        }

        private delegate void InvokeDelegate();
        private void UpdateUI()
        {
            txtAccessToken.Text = _accessToken;
            txtIdToken.Text = _idToken;
            lblUserName.Text = $"Hello {_userName}!";
            btnSignIn.Enabled = false;
            btnCallService.Enabled = true;
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            // Set the credentials
            client.ClientCredentials.UserName.UserName = _userName;
            client.ClientCredentials.UserName.Password = _accessToken;
            lblWCFResults.Text = client.GetData(10);
        }
    }
}
