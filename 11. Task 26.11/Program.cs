using System;
using System.Collections.Generic;
using System.IO;

namespace Task_26._11
{

    class Program
    {
        static void Main(string[] args)
        {
            //Первое задание
            List<Student> students = new List<Student>();
            using (StreamReader stream = new StreamReader("Students.txt"))
            {
                string str;
                while ((str = stream.ReadLine()) != null)
                {
                    string[] words = str.Split(" ");
                    string name = words[0];
                    int groupNumber;
                    if (!int.TryParse(words[1], out groupNumber))
                    {
                        continue;
                    }
                    students.Add(new Student(name, groupNumber));
                }
            }

            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Хотите создать мероприятие?\n(варианты ответов: да, нет)");
                string answer1 = Console.ReadLine().ToLower();
                switch (answer1)
                {
                    case "да":
                        Console.WriteLine("Напишите через ЗАПЯТУЮ И ПРОБЕЛ название мероприятия, дату его проведения(формат записи: дд.мм.гггг) и количество участников");
                        string[] answer2 = Console.ReadLine().Split(", ");
                        string title = answer2[0];

                        string[] temp1 = answer2[1].Split(".");
                        int[] temp2 = new int[3];
                        for(int i = 0; i < temp1.Length; i++)
                        {
                            temp2[i] = int.Parse(temp1[i]);
                        }
                        
                        int numberOfParticipants = int.Parse(answer2[2]);


                        for (int i = 0; i < students.Count; i++) 
                        {
                            for (int j = i + 1; j < students.Count - 1; j++) 
                            {
                                if (students[i].NumberOfEventsHeDidintParticipateBefore == 3 || students[j].NumberOfEventsHeDidintParticipateBefore == 3)
                                {
                                    if (students[i].NumberOfEventsHeDidintParticipateBefore < students[j].NumberOfEventsHeDidintParticipateBefore)
                                    {
                                        Student tmp;
                                        tmp = students[i];
                                        students[i] = students[j];
                                        students[j] = tmp;
                                    }
                                }
                            }
                        }
                        using (StreamWriter stream = new StreamWriter("Events.txt", true))
                        {
                            stream.WriteLine($"{temp2[0]}.{temp2[1]}.{temp2[2]} <<{title}>> Участники: ");
                        }
                        for(int i = 0; i < students.Count; i++)
                        {
                            if (i < numberOfParticipants)
                            {
                                using (StreamWriter stream = new StreamWriter("Events.txt", true))
                                {
                                    stream.Write($"{students[i].Name} {students[i].GroupNumber}  ");
                                }
                                students[i].NumberOfEventsHeDidintParticipateBefore = 0;
                            }
                            else
                            {
                                students[i].IncreaseNumberOfEventsHeDidintParticipateBefore();
                            } 
                        }
                        using (StreamWriter stream = new StreamWriter("Events.txt", true))
                        {
                            stream.WriteLine(" ");
                        }
                        break;
                    case "нет":
                        flag = true;
                        Console.Clear();
                        Console.WriteLine("Мероприятий больше нет.");
                        break;
                    default:
                        Console.WriteLine("Неправильный ответ, попробуй еще раз.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }




            //Второе задание
            #region *Creation of people*
            string[] hobbies1 = new string[] { "Дартс", "Бадминтон" };
                Human human1 = new Human("Ринат", hobbies1);

                string[] hobbies2 = new string[] { "Дартс", "Баскетбол" };
                Human human2 = new Human("Марат", hobbies2);

                string[] hobbies3 = new string[] { "Бадминтон", "Баскетбол" };
                Human human3 = new Human("Ильназ", hobbies3);
            #endregion
            List<Human> people = new List<Human> { human1, human2, human3 };
            Console.WriteLine("Как называется событие?");
            string eventTitle = Console.ReadLine();
            foreach (Human thing in people)
            {
                foreach (string hobby in thing.Hobbies) 
                {
                    if (hobby == eventTitle) 
                    {
                        thing.MakeReaction(eventTitle);
                        break;
                    }
                }
            }  
        }
    }
}
