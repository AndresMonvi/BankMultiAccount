using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMultiAccOOP.Entities
{
    internal class Account
    {
        private string Id { get; set; }
        private string UserId;
        private double Balance { get; set; }
        List<Movement> Movements { get; }

        public Account() { }

        public Account(string id)
        {
            this.Id = Id;
        }

        public Account(string Id, string UserId, double Balance, List<Movement> Movements)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.Balance = Balance;
            this.Movements = Movements;
        }

        public string GetUserId()
        {
            return UserId;
        }

        public List<Movement> GetMovementList()
        {
            return Movements;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public void SetBalance(double Balance)
        {
            this.Balance = Balance;
        }
    }
}
