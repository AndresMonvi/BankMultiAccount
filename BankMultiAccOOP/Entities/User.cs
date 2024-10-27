using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMultiAccOOP.Entities
{
    internal class User
    {

        private string Id;
        private string UserPassword;

        public User() { }

        public User(string Id, string UserPassword)
        {
            this.Id = Id;
            this.UserPassword = UserPassword;

        }

        public string GetUserId()
        {
            return Id;
        }

        public string GetUserPassword()
        {
            return UserPassword;
        }

    }
}
