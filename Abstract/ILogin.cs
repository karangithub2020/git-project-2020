using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent.Abstract
{
   public interface ILogin
    {
         bool Login(string userID, string pin);
    }
}
