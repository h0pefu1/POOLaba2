using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOLABA2
{
    public class DisciplineController
    {

        public enum Actions : int
        {
            ChangeProf = 1,
            ChangeHours,
            ChangeForm,
            Print
        }

        public void Initilization()
        {
            Console.WriteLine("Which constructor u wwant to use");
            Console.WriteLine("1.Default(without parameters)");
            Console.WriteLine("2.With one parametr");
            Console.WriteLine("3.With all Parametr");

            int.TryParse(Console.ReadLine(), out int value);
            while (value > 3 || value < 1)
            {
                Console.WriteLine("Enter again");
                int.TryParse(Console.ReadLine(), out value);
            }

            //создаем пустой объект
            Discipline discipline = null;
            try
            {
                if (value == (int)Discipline.ContrEmun.Default)                                           /*в этом блоке мы даем пользователю выбор какой конструктор
                                                                                                           * мы будем использовать*/
                {
                    discipline = new Discipline();


                }
                else if (value == (int)Discipline.ContrEmun.OneParametr)
                {
                    string Name = "";
                    while (string.IsNullOrEmpty(Name))
                    {
                        Console.WriteLine("Enter Name of an object");
                        Name = Console.ReadLine();
                    }


                    discipline = new Discipline(Name);

                }
                else if (value == (int)Discipline.ContrEmun.AllParametr)
                {
                    string name = "";
                    string Professor = "";
                    string Form = "";
                    int hours = 0;
                    try
                    {
                        Console.WriteLine("Enter Name: ");

                        name = Console.ReadLine();

                        Console.WriteLine("Enter Professor: ");

                        Professor = Console.ReadLine();

                        Console.WriteLine("Enter Form: ");

                        Form = Console.ReadLine();

                        Console.WriteLine("Enter Hours");

                        int.TryParse(Console.ReadLine(), out hours);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Что-то пошло не так{ex.Message}");
                    }

                    discipline = new Discipline(name, Professor, hours, Form);


                }
                else
                {
                    throw new Exception("Something wrong");
                }
                discipline.PrintClass();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Что-то пошло не так {ex.Message}");
            }
            int choice = 0;
            while (choice != 5)
            {
                //меню для выбора действий над объектом
                choice = Menu();
                if (choice == (int)Actions.ChangeProf)
                {
                    discipline.ChangeProfessor();
                }
                if (choice == (int)Actions.ChangeHours)
                {
                    discipline.ChangeHours();
                }
                if (choice == (int)Actions.ChangeForm)
                {
                    discipline.ChangeForm();
                }
                if (choice == (int)Actions.Print)
                {
                    discipline.PrintClass();
                }
                if (choice == 5)
                {
                    Console.WriteLine("Exiting the programm");
                    GC.Collect();
                }
                

            }
      

        }



        public int Menu()
        {
            
            Console.WriteLine("What do you want to do do?");
            
            Console.WriteLine("1.Change Professor");
            Console.WriteLine("2.Change Hours");
            Console.WriteLine("3.Change Form");
            Console.WriteLine("4.Print Class");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }
    }




}

