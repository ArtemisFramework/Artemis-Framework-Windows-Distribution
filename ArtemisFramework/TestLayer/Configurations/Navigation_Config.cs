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

using ArtemisFramework.BusinessLayer;
using ArtemisFramework.TestLayer.Interfaces;
using NUnit.Framework;

namespace ArtemisFramework.TestLayer.Configurations
{
    public abstract class Navigation_Config : TestFramework, IConfig
    {
        [OneTimeSetUp]
        public void BeforeTestSuite()
        {
            // Add here methods to be used before the tests are runned
            // e.g. 'Start browser'

            // This is the way the StartBrowser method can be used
            PageParts.Shared.Helpers.StartBrowser();

            // In case you need authentication to perform some tests on the Home page, then you need to call the login action
            PageParts.Views.Login.Perform(XMLLayer.Config.User(), XMLLayer.Config.Password());
        }

        [SetUp]
        public void BeforeEachTest()
        {
            // Add here methods to be used before each test
            // e.g. 'Read config file'
        }

        [TearDown]
        public void AfterEachTest()
        {
            // Add here methods to be used after each test
            // e.g. 'Write error to log file'
        }

        [OneTimeTearDown]
        public void AfterTestSuite()
        {
            // Add here methods to be used after all tests have been runned     
            // e.g. 'Close browser" , 'Write test results' , 'Generate reports'

            PageParts.Shared.Helpers.CloseBrowser();
        }
    }
}