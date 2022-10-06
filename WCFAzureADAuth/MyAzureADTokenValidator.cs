//===============================================================================
// Microsoft FastTrack for Azure
// Azure WCF Samples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;

namespace WCFAzureADAuth
{
    public class MyAzureADTokenValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            ClaimsPrincipal claimsPrincipal = null;
            string audience = ConfigurationManager.AppSettings["Audience"];
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string tenantId = ConfigurationManager.AppSettings["TenantId"];
            string authority = ConfigurationManager.AppSettings["Authority"];
            string instance = ConfigurationManager.AppSettings["Instance"];
            ConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{authority}/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
            ISecurityTokenValidator tokenValidator = new JwtSecurityTokenHandler();

            // For debugging/development purposes, one can enable additional detail in exceptions by setting IdentityModelEventSource.ShowPII to true.
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

            // Pull OIDC discovery document from Azure AD. For example, the tenant-independent version of the document is located
            // at https://login.microsoftonline.com/common/.well-known/openid-configuration.
            OpenIdConnectConfiguration config = null;
            try
            {
                config = configurationManager.GetConfigurationAsync().Result;
            }
            catch (Exception ex)
            {
                throw new FaultException($"Retrieval of OpenId configuration failed with the following error: {ex.Message}");
            }

            if (config != null)
            {
                // Support both v1 and v2 AAD issuer endpoints
                IList<string> validissuers = new List<string>()
                    {
                        $"https://login.microsoftonline.com/{tenantId}/",
                        $"https://login.microsoftonline.com/{tenantId}/v2.0/",
                        $"https://login.windows.net/{tenantId}/",
                        $"https://login.microsoft.com/{tenantId}/",
                        $"https://sts.windows.net/{tenantId}/",
                        $"{instance}{tenantId}/v2.0/" // Azure AD B2C
                    };

                // Initialize the token validation parameters
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    // Application ID URI and Client ID of this service application are both valid audiences
                    ValidAudiences = new[] { audience, clientId },
                    ValidIssuers = validissuers,
                    IssuerSigningKeys = config.SigningKeys
                };

                try
                {
                    // Validate token.
                    SecurityToken securityToken;
                    string accessToken = password;
                    claimsPrincipal = tokenValidator.ValidateToken(accessToken, validationParameters, out securityToken);

                    // This check is required to ensure that the Web API only accepts tokens from tenants where it has been consented to and provisioned.
                    if (!claimsPrincipal.Claims.Any(x => x.Type == "http://schemas.microsoft.com/identity/claims/scope")
                        && !claimsPrincipal.Claims.Any(y => y.Type == "scp")
                        && !claimsPrincipal.Claims.Any(y => y.Type == "roles"))
                    {
                        claimsPrincipal = null;
                    }
                    Service1.str = claimsPrincipal.Identity.Name;
                }
                catch (SecurityTokenValidationException stex)
                {
                    throw new FaultException($"Validation of security token failed with the following error: {stex.Message}");
                }
                catch (Exception ex)
                {
                    throw new FaultException($"Validation of security token failed with the following error: {ex.Message}");
                }
            }
        }
    }
}