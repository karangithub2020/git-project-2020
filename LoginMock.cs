using BusinessComponent.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject_core
{
    public class LoginMock : ILogin
    {
        public bool Login(string userID, string pin)
        {
            return true;
        }
    }
}
