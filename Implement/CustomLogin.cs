using BusinessComponent.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Implement
{
    public class CustomLogin : ILogin
    {
        private Dictionary<string, string> users = new Dictionary<string, string>() { { "ak", "kumar" }, {"ks","shukla" } };
        public bool Login(string userID, string pin)
        {
            return users.Where(x => x.Key == userID && x.Value == pin)?.Count() > 0;
        }
    }
}
