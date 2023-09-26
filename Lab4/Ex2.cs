using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public delegate void BalanceChangedEventHandler(decimal newBalance);

    class Account
    {
        public event BalanceChangedEventHandler BalanceChanged;
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                // Kích hoạt sự kiện BalanceChanged khi số dư tài khoản thay đổi.
                OnBalanceChanged(balance);
            }
        }
        protected virtual void OnBalanceChanged(decimal newBalance)
        {
            // Kiểm tra xem có bất kỳ người đăng ký nào cho sự kiện BalanceChanged hay không.
            if (BalanceChanged != null)
            {
                // Gọi sự kiện và truyền số dư mới như một đối số.
                BalanceChanged(newBalance);
            }
        }
        
    }
    public class Program_Ex2
    {
        static void Main()
        {
            // Bước 3: Đăng ký sự kiện và callback.
            Account account = new Account();
            account.BalanceChanged += Account_BalanceChanged;

            // Giả lập giao dịch thay đổi số dư tài khoản.
            account.Balance = 1000;
            account.Balance = 2000;
        }

        static void Account_BalanceChanged(decimal newBalance)
        {
            Console.WriteLine($"New account balance: {newBalance}");
        }
    }
}
