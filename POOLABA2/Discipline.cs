using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOLABA2
{
    public class Discipline
    {
        public string Name { get; set; }

        public string Professor { get; set; }

        public int Hours { get; set; }

        public string Form { get; set; }

        public Discipline()
        {
        }

        public Discipline(string name)
        {
            Name = name;
        }

        public Discipline(string name, string professor, int hours, string form)
        {
            Name = name;
            Professor = professor;
            Hours = hours;
            Form = form;
        }

        public void ChangeProfessor()
        {
            Console.WriteLine("Enter new Professor:");
            string NewProfessor = "";

            while (string.IsNullOrEmpty(NewProfessor))
            {

                try
                {
                    NewProfessor = Console.ReadLine();

                    if (NewProfessor.Any(char.IsDigit))
                    {
                        throw new Exception("Are u sure?");

                    }
                    this.Professor = NewProfessor;

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error" + ex.Message);
                }
            }




        }

        public void ChangeHours()
        {
            Console.WriteLine("Enter new Hours:");
            var NewHors = 0;

            while (NewHors == 0)
            {
                try
                {
                    if (int.TryParse(Console.ReadLine(), out NewHors))
                    {

                        this.Hours = NewHors;
                    }
                    else
                    {
                        throw new FormatException("Its not int");
                    }
                }
                catch (FormatException ex)
                {

                    Console.WriteLine("Error " + ex.Message);

                }


            }




        }

        public enum FormEnum : int
        {
            Exam = 1,
            Zachet = 2
        }

        public enum ContrEmun : int
        {
            Default = 1,
            OneParametr = 2,
            AllParametr = 3
        }


        public void PrintClass()
        {

            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Professor: {this.Professor}");
            Console.WriteLine($"Form: {this.Form}");
            Console.WriteLine($"Hours: {this.Hours.ToString()}");
            Console.WriteLine(" ");

        }

        public void ChangeForm()
        {
            Console.WriteLine("Enter new Form:");
            Console.WriteLine("1.Exam");
            Console.WriteLine("2.Zachet");
            int.TryParse(Console.ReadLine(), out int value);
            while(value > 2 || value < 1)
            {
                int.TryParse(Console.ReadLine(), out  value);
            }


                try
                {
                    if (value == (int)FormEnum.Exam)
                    {
                        this.Form = "Exam";

                    }
                    else if (value == (int)FormEnum.Zachet)
                    {
                        this.Form = "Zachet";
                    }
                    else
                    {
                        throw new Exception("Something wrong");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something wrong{ex.Message}");


                }


            




        }

    }
}
