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

using ArtemisFramework.DataLayer;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace ArtemisFramework.BusinessLayer.Core
{
    public class WebDriver
    {
        // This is the webdriver instance that will be used across tests
        protected static IWebDriver driver { get; set; }

        // This is the initialization of the Config class
        protected static XMLLayer XMLLayer = new XMLLayer();

        // Method to be used for starting the browser
        public void StartBrowser()
        {
            switch (XMLLayer.Config.Browser())
            {
                default:
                    driver = new InternetExplorerDriver();
                    break;

                case "IE":
                    driver = new InternetExplorerDriver();
                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    break;

                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
            }

            // Set implicitly wait time. For custom wait times, use ExplicitlyWait from Selenium.
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            // Usually, browsers starts with a reduced window size and we need it set to maximized, so that we can see all the elements on the screen
            switch (XMLLayer.Config.WindowSize())
            {
                default:
                    driver.Manage().Window.Maximize();
                    break;

                case "Fullscreen":
                    driver.Manage().Window.Maximize();
                    break;

                case "Sized":
                    int width = XMLLayer.Config.WindowWidth();
                    int height = XMLLayer.Config.WindowHeight();
                    driver.Manage().Window.Size = new System.Drawing.Size(width, height);
                    break;
            }
        }

        // Method to be used for closing the browser
        // Configuration: Debug(aka. close_browser) / Release(aka. do_not_close_browser)
        public void CloseBrowser()
        {
            switch (XMLLayer.Config.Browser())
            {
                default:
                    driver.Quit();
                    break;

                // Close the browser when on Release
                case "Release":
                    driver.Quit();
                    break;

                // Do not close the browser when on Debug
                case "Debug": 
                    break;
            }
        }
    }
}
