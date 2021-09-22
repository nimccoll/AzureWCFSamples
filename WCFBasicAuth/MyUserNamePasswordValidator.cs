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
using System.ServiceModel;

namespace WCFBasicAuth
{
    public class MyUserNamePasswordValidator: UserNamePasswordValidator
    {
        private readonly string _validUserName = "{valid user name here}";
        private readonly string _validPassword = "{valid password here}";

        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            // Simple user name password validation - modify to meet your needs (database lookup, directory lookup, etc.)
            if (!(userName == _validUserName && password == _validPassword))
            {
                throw new FaultException("Incorrect Username or Password");
            }
            Service1.str = userName;
        }
    }
}