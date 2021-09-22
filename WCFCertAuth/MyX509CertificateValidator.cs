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
using System;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace WCFCertAuth
{
    public class MyX509CertificateValidator : X509CertificateValidator
    {
        private static readonly string _validThumbprint = "{valid certificate thumbprint here}";

        public override void Validate(X509Certificate2 certificate)
        {
            // Check that there is a certificate.
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }
            // Simple thumbprint check - modify to meet your needs (check subject, expiration, etc.)
            if (certificate.Thumbprint.ToLower() == _validThumbprint)
            {
                Service1.str = certificate.Subject;
            }
            else
            {
                throw new FaultException("Invalid certificate");
            }
        }
    }
}