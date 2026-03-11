using System.Reflection.Emit;
using System.Text;
using System.Transactions;

namespace assignment4
{
    internal class Program
    {
        public class BankAccount
        {
            public string name{ get; set; }
            public double balance { get; set; }
            public string accountNumber { get; set; }
            public string password { get; set; }
            public StringBuilder transactionHistory { get; set; }
            public BankAccount(string name, string password)
            {
                this.name = name;
                this.balance = 0;
                this.accountNumber = Guid.NewGuid().ToString();
                this.password = password;
                this.transactionHistory = new StringBuilder();
            }
            public void Deposit(double amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Deposit amount must be positive.");
                    return;
                }
                balance += amount;
                transactionHistory.AppendLine($"Date:{DateTime.Now} Deposited: {amount}, New Balance: {balance}");
            }
            public void Withdraw(double amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Withdrawal amount must be positive.");
                    return;
                }
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient funds.");
                    return;
                }
                balance -= amount;
                transactionHistory.AppendLine($"Date:{DateTime.Now} Withdrew: {amount}, New Balance: {balance}");
            }

            public void DisplayTransactionHistory()
            {
                Console.WriteLine($"Transaction History for {name} (Account: {accountNumber}):");
                Console.WriteLine(transactionHistory.ToString());
            }
            public void DisplayAccountInfo()
            {
                Console.WriteLine($"Account Holder: {name}");
                Console.WriteLine($"Account Number: {accountNumber}");
                Console.WriteLine($"Current Balance: {balance}");
            }
        }
        static void exit()
        {
            Environment.Exit(0);
        }
        public static void createAccount(List<BankAccount> accounts)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Create a password: ");
            string password = Console.ReadLine();
            BankAccount newAccount = new BankAccount(name, password);
            accounts.Add(newAccount);
            Console.WriteLine($"Account created successfully! Your account number is: {newAccount.accountNumber}");

        }
        public static BankAccount login(List<BankAccount> accounts)
        {
            Console.Write("Enter your account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            foreach (var account in accounts)
            {
                if (account.accountNumber == accountNumber && account.password == password)
                {
                    return account;
                }
                else
                {
                    Console.WriteLine("Invalid account number or password.");
                    return null;
                }
            }
            return null;
        }

        public static void displayMenu(List<BankAccount> accounts)
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine("please select an option:");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    createAccount(accounts);
                    displayMenu(accounts);
                    break;
                case 2:
                    var account = login(accounts);
                    if (account != null)
                    {
                        displayAccountMenu(account);
                        displayMenu(accounts);
                    }
                    else                   
                    {
                        displayMenu(accounts);
                    }
                    break;
                case 3:
                    exit();
                    break;
                default: break;
            }
        }

        public static void displayAccountMenu(BankAccount account)
        {
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Transaction History");
            Console.WriteLine("4. Logout");
            Console.WriteLine("please select an option:");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter amount to deposit: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    displayAccountMenu(account);
                    break;
                case 2:
                    Console.Write("Enter amount to withdraw: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    displayAccountMenu(account);
                    break;
                case 3:
                    account.DisplayTransactionHistory();
                    displayAccountMenu(account);
                    break;
                case 4:
                    Console.WriteLine("Logging out...");
                    return;
                default: return;
            }
        }

        
        


        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            displayMenu(accounts);


        }
    }
}