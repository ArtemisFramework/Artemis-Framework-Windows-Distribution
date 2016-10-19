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

using OpenQA.Selenium;
using ArtemisFramework.BusinessLayer.Core;

namespace ArtemisFramework.BusinessLayer.PageParts.Views
{
    public class Login : WebDriver
    {
        /// <summary>
        /// Remember that you have the XML Config file, where you can store usernames and passwords. 
        /// The default value will be the one used for login.
        /// In the Config file you can call the default value with the following code: 
        /// code sample: PageParts.Views.Login.Perform(XMLLayer.Config.User(), XMLLayer.Config.Password());
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>

        public void Perform(string user, string password)
        {
            // Go to Login page
            driver.Navigate().GoToUrl("login_url");

            // Fill in 'username'            
            driver.FindElement(By.XPath("username_textbox_xpath")).SendKeys(user);

            // Fill in 'password'
            driver.FindElement(By.XPath("password_textbox_xpath")).SendKeys(password);

            // Click on 'Login' button
            driver.FindElement(By.XPath("login_button_xpath")).Click();
        }

        public string Get_SomeText()
        {
            return "some_text";
        }
    }
}
