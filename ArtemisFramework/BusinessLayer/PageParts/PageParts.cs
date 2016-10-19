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

using ArtemisFramework.BusinessLayer.PageParts.Shared;
using ArtemisFramework.BusinessLayer.PageParts.Views;

namespace ArtemisFramework.BusinessLayer.PageParts
{
    public class PageParts
    {
        public _Shared Shared = new _Shared();
        public _Views Views = new _Views();

        public class _Shared
        {
            public Helpers Helpers = new Helpers();
        }

        public class _Views
        {
            public Login Login = new Login();
            public Logout Logout = new Logout();
            public Navigation Navigation = new Navigation();
            public Contact Contact = new Contact();
            public Home Home = new Home();
            public Register Register = new Register();
        }
    }
}
