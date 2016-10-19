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

using System;
using System.Xml;

namespace ArtemisFramework.DataLayer
{
    public class XMLLayer
    {
        public _Config Config = new _Config();

        public class _Config
        {
            private readonly string ConfigFile = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug", "") + @"AppData\Config.xml";
            XmlDocument doc = new XmlDocument();

            #region Utilities
            private string InnerText(string node)
            {
                doc.Load(ConfigFile);
                string _value = "";

                foreach (XmlNode _node in doc.SelectNodes(node))
                {
                    if (_node.Attributes["default"].Value == "y") { _value = _node.InnerText; }
                }
                return _value;
            }

            private string AttributeText(string node, string attribute)
            {
                doc.Load(ConfigFile);
                string _value = "";

                foreach (XmlNode _node in doc.SelectNodes(node))
                {
                    if (_node.Attributes["default"].Value == "y") { _value = _node.Attributes[attribute].Value; }
                }
                return _value;
            }
            #endregion

            /// <summary>
            /// This command will return the default URL: default="y"
            /// </summary>
            /// <returns>URL</returns>
            public string URL()
            {
                return InnerText("//url");
            }

            /// <summary>
            /// This command will return the default user: default="y"
            /// </summary>
            /// <returns>User</returns>
            public string User()
            {
                return InnerText("//user");
            }

            /// <summary>
            /// This command will return the default password: default="y"
            /// </summary>
            /// <returns>Password</returns>
            public string Password()
            {
                return AttributeText("//user", "password");
            }

            /// <summary>
            /// This command will return the default browser: default="y"
            /// </summary>
            /// <returns>Browser</returns>
            public string Browser()
            {
                return InnerText("//browser");
            }

            /// <summary>
            /// This command will return the default windows size: default="y"
            /// </summary>
            /// <returns>WindowSize</returns>
            public string WindowSize()
            {
                return InnerText("//size");
            }

            /// <summary>
            /// This command will return the default window width: default="y"
            /// </summary>
            /// <returns>WindowWidth</returns>
            public int WindowWidth()
            {
                return Convert.ToInt32(AttributeText("//size", "width"));
            }

            /// <summary>
            /// This command will return the default window height: default="y"
            /// </summary>
            /// <returns>WindowHeight</returns>
            public int WindowHeight()
            {
                return Convert.ToInt32(AttributeText("//size", "height"));
            }

            /// <summary>
            /// This command will return the default configuration: default="y"
            /// </summary>
            /// <returns>Configuration</returns>
            public string Configuration()
            {
                return InnerText("//configuration");
            }
        }
    }
}
