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

namespace WCFBasicAuthClient
{
    class Program
    {
        // Valid user name and password for the WCF service
        private static readonly string _userName = "{valid user name here}";
        private static readonly string _password = "{valid password here}";

        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            // Set the credentials
            client.ClientCredentials.UserName.UserName = _userName;
            client.ClientCredentials.UserName.Password = _password;
            string result = client.GetData(10);
            Console.WriteLine($"*** Call to WCFBasicAuth service result is {result} ***");
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
