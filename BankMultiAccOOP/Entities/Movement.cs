using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMultiAccOOP.Entities
{
    internal class Movement
    {
        private DateTime MovementDate { get; set; }

        private double MoneyMovement;

        private enum TypeOfMovement
        {
            withdraw,
            deposit
        }
        private TypeOfMovement TypeMovement { get; set; }

        public Movement() { }

        public Movement(string TypeMovementInput, double MoneyMovement)
        {
            if (!Enum.TryParse<TypeOfMovement>(TypeMovementInput, true, out TypeOfMovement MovementChosen))
            {
                throw new Exception("Problems with movement creation");
            }
            else
            {
                TypeMovement = MovementChosen;
            }

            this.TypeMovement = TypeMovement;
            this.MoneyMovement = MoneyMovement;
            MovementDate = DateTime.Now;

        }

        public string GetDepositType()
        {
            return TypeOfMovement.deposit.ToString();
        }

        public string GetWithdrawType()
        {
            return TypeOfMovement.withdraw.ToString();
        }

        public string GetTypeOfMovement()
        {
            return TypeMovement.ToString();
        }

        public double GetMoneyMovement()
        {
            return MoneyMovement;
        }
    }
}
