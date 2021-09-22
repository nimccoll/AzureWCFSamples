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

namespace WCFCertAuthClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            string result = client.GetData(10);
            Console.WriteLine($"*** Call to WCFCertAuth service result is {result} ***");
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
