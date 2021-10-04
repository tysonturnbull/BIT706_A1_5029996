namespace BIT706_A1_5029996
{
    public abstract class Account
    { 
        public double balance;
        protected static int nextID = 1;
        protected int iD;

        public Account() //Default creates an ID for each account
        {
            iD = nextID;
            nextID++;
        }

        public Account(double newBalance)
        {
            balance = newBalance;
        }

        public virtual string Info()
        {
            return "\nID: " + iD + ".\nBalance:  $" + balance + ".";
        }
    }

    public class Everyday : Account
    {
        public Everyday(double newBalance) : base(newBalance) {}

        public override string Info()
        {
            return "Account: Everyday.  " + base.Info() + "\nInterest Rate:  0%.\nOverdraft Limit:  $0.\nFees:  $0.";
        }

        public string Deposit(double deposit)
        {
            balance += deposit;
            return "Account: Everday.  Deposit:  $" + deposit + ".  Balance:  $" + balance + ".";
        }

        public string Withdrawal(double withdrawal)
        {
            if (balance-withdrawal >= 0)
            {
                balance -= withdrawal;
                return "Account: Investment.  Withdrawal:  $" + withdrawal + ".  Balance:  $" + balance + ".";
            }
            else
            {
                return "Unable to widthraw $" +withdrawal + ".  Balance:  $" + balance + ".";
            }

        }
    }

    public class Investment : Account
    {
        private double interestRate;
        private double fees = 10;
        private double overdraft = 0;

        public Investment(double newBalance) : base(newBalance) 
        {
            overdraft = 0;
        }

        public Investment(double newBalance, double newIR):this(newBalance)
        {
            interestRate = newIR;
            balance += interestRate * balance;
        }

        public override string Info()
        {
            return "Account: Investment.  " + base.Info() + "\nInterest Rate:  "+ interestRate + "%.\nOverdraft Limit:  $" + overdraft +".\nFees:  $" + fees + ".";
        }

        public string Deposit(double deposit)
        {
            balance += deposit;
            return "Account: Investment.  Deposit:  $" + deposit + ".  Balance:  $" + balance + ".";
        }

        public string Withdrawal(double withdrawal)
        {
            if (balance - withdrawal >= 0)
            {
                balance -= withdrawal;
                return "Account: Investment.  Withdrawal:  $" + withdrawal + ".  Balance:  $" + balance + ".";
            }
            else
            {
                balance -= fees;
                return "Unable to widthraw $" + withdrawal + ".  Balance:  $" + balance + ".";
            }
        }
    }

    public class Omni : Account
    {
        private double interestRate;
        private double fees = 10;
        private double overdraft;
        public Omni(double newBalance) : base(newBalance) { }

        public Omni(double newBalance, double newIR, double newOD) : this(newBalance)
        {
            if(newBalance > 1000)
            {
                interestRate = newIR;
                balance += balance * interestRate;
            }
            else
            {
                interestRate = 0;
                balance = newBalance;
            }

            overdraft = newOD;
        }
        public override string Info()
        {
            return "Account:  Omni." + base.Info() + "\nInterest Rate:  " + interestRate + "%.\nOverdraft Limit:  $" + overdraft + ".\nFees:   $" + fees + ".";
        }

        public string Deposit(double deposit)
        {
            balance += deposit;
            return "Account: Investment.  Deposit:  $" + deposit + ".  Balance:  $" + balance + ".";
        }

        public string Withdrawal(double withdrawal)
        {
            if ((balance - withdrawal) >= overdraft)
            {
                balance -= withdrawal;
                return "Account: Investment.  Withdrawal:  $" + withdrawal + ".  Balance:  $" + balance + ".";
            }
            else
            {
                balance -= fees;
                return "Unable to widthraw $" + withdrawal + ".  Balance:  $" + balance + ".";
            }
        }
    }
}
