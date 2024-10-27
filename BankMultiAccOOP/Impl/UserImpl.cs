using BankMultiAccOOP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMultiAccOOP.Impl
{
    internal class UserImpl
    {

        private List<User> UserList = new();

        public UserImpl()
        {
            CreateUser();
        }
        internal void CreateUser()
        {
            User User1 = new("123456", "654321");
            User User2 = new("7890", "0987");
            User User3 = new("4K4K4K", "123456789");

            AddUserToList(User1);
            AddUserToList(User2);
            AddUserToList(User3);

        }

        internal List<User>? GetUsers()
        {
            if(UserList == null)
            {
                return null;
            }
            return UserList;
        }

        private void AddUserToList(User User)
        {
            if(User == null)
            {
                Console.WriteLine("There's no User");
            }
            else
            {
                UserList.Add(User);
            }
        }


    }
}
