using System;
using System.Collections.Generic;
using System.Text;

namespace Tumakov
{
    class BankAccount : Factory
    {
        static int Number = 0;
        string Title;
        public BankAccount(string title)
        {
            Title = title;
            Number++;
        }
        public int GetNumber()
        {
            return Number;
        }
    }
}
