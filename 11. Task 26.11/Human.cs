using System;
using System.Collections.Generic;
using System.Text;

namespace Task_26._11
{
    class Human
    {
        string Name;
        public string[] Hobbies;
        public Human(string name, string[] hobbies)
        {
            Name = name;
            Hobbies = hobbies;
        }
        public void MakeReaction(string eventTitle)
        {
            Console.WriteLine($"Урааа! Люблю {eventTitle}! - сказал {Name}");
        }
    }
}
