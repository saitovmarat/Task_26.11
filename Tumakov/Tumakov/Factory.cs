using System;
using System.Collections;

namespace Tumakov
{
    class Factory
    {
        static Hashtable Storage = new Hashtable();
        public int CreateAccount()
        {
            BankAccount a = new BankAccount("Title");
            Storage.Add(a.GetNumber(), a);
            return a.GetNumber();
        }
        public void CloseBankAccount(int number)
        {
            Storage.Remove(number);
        }

    }
}
