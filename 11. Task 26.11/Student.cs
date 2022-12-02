using System;
using System.Collections.Generic;
using System.Text;

namespace Task_26._11
{
    class Student
    {
        public int NumberOfEventsHeDidintParticipateBefore;
        public string Name { get; }
        public int GroupNumber { get; }
        public Student(string name, int groupNumber)
        {
            Name = name;
            GroupNumber = groupNumber;
        }
        public void IncreaseNumberOfEventsHeDidintParticipateBefore()
        {
            NumberOfEventsHeDidintParticipateBefore++;
        }
    }
}
