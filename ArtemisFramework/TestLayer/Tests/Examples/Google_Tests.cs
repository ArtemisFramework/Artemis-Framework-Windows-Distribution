// ***********************************************************************
// Copyright (c) 2016 Alexandru Moiceanu
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using NUnit.Framework;
using System;
using System.Net;

namespace ArtemisFramework.TestLayer.Configurations
{
    public sealed class Google_Tests : Google_Config
    {
        [Test]
        [TestCase("Google")]
        public void T1_Check_Title(string value)
        {
            // Arrange
            // e.g. Arrange all necessary preconditions and inputs.

            // Act 
            // e.g. Act on the object or method under test.
            PageParts.Views.Google.Navigate_To_Google();

            // Assert
            // e.g. Assert that the expected results have occurred.
            // The 'value' parameter will be set from the NUnit TestCase attribute.
            Assert.AreEqual(value, PageParts.Views.Google.Get_Title());
        }        

        [Test]
        [TestCase("OK")]
        public void T2_Check_HTTPStatusCode(string value)
        {
            // Arrange - Create a request for the URL. 		
            WebRequest request = WebRequest.Create(XMLLayer.Config.URL());

            // Act - Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Assert - Display the status.
            Assert.AreEqual(value, response.StatusCode.ToString());

            // Teardown - Close the response.
            response.Close();
        }

        [Test]
        [TestCase(0)]
        public void T3_Check_PageLoadTime(int value)
        {
            // Arrange
            // e.g. Arrange all necessary preconditions and inputs.
            int startTime, endTime;

            // Act 
            // e.g. Act on the object or method under test.
            
            // Get current system time and transform it in milliseconds
            startTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000;

            // Do some actions and measure the time
            PageParts.Views.Google.Navigate_To_Google();

            // Get elapsed system time and transform it in milliseconds
            endTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000;

            // Assert
            // e.g. Assert that the expected results have occurred.
            Assert.Greater(endTime - startTime, value);
        }
    }
}