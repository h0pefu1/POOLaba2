

using System.Transactions;

namespace POOLABA2
{
    class Program
    {
        static void Main()
        {
             //выбираем какую программу мы будем использовать
            Console.WriteLine("What programm to use:");
            Console.WriteLine("1.Discipline");
            Console.WriteLine("2.Matrix");
            int.TryParse(Console.ReadLine(), out var result);
            while(result > 2 || result < 1)
            {
                int.TryParse(Console.ReadLine(), out result);
            }
            switch (result)
            {
                case 1:
                    var Control = new DisciplineController();
                    Control.Initilization(); // здесь вызываем наш контроллер
                    break;
                    case 2:
                    Console.WriteLine("Enter which constructor u want?");
                    Console.WriteLine("1.Default");
                    Console.WriteLine("2.With one parametr");
                    Console.WriteLine("3.With two parametr");
                    int.TryParse(Console.ReadLine(), out int choice);
                    MatrixController Matrix = null; // тут меню для матрицы и действиями над нимми
                    switch (choice)
                    {
                        case 1:
                           
                            break;
                        case 2:
                            Console.WriteLine("Enter N:");
                            var n = int.Parse(Console.ReadLine());

                             Matrix = new MatrixController(n);
                            break;
                        case 3:
                            Console.WriteLine("Enter rows:");
                            var rows = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter columns:");
                            var columns = int.Parse(Console.ReadLine());
                            Matrix = new MatrixController(rows,columns);
                            Console.WriteLine("Do you want to fill the matrix from keyboard? y/n");
                            var ch = Console.ReadLine();
                            if(ch == "y")
                            {
                                Matrix.FillFromKeyboard();
                            }
                            break;
                        default:
                            break;
                    }
                    //меню для действий над матрицей
                    Console.WriteLine("What u want to do?");
                    Console.WriteLine("1.Multiply");
                    Console.WriteLine("2.Minus");
                    Console.WriteLine("3.Plus");
                    Console.WriteLine("4.Exit the programm");
                    int.TryParse(Console.ReadLine(), out int choice1);
                    while (choice != 4)
                    {
                        switch (choice1)
                        {
                            case 1:
                                //просим ввести число на которое мы будем умножать
                                Console.WriteLine("Enter number for multiply: ");
                                double.TryParse(Console.ReadLine(), out double multy);
                                Matrix = Matrix * multy;

                                MatrixController.PrintMatrix(Matrix);

                                break;
                            case 2:
                                //так как нет второй матрицы с которой мы будем складывать просим ее ввести
                                Console.WriteLine("Enter second matrix the same size");
                                MatrixController Matrix2 = null;
                                try
                                {
                                    //дополнительная проверка на сходство второй матрицы 
                                    if (Matrix.columns == Matrix.rows)
                                    {
                                        Matrix2 = new MatrixController(Matrix.rows);
                                    }
                                    else
                                    {
                                        Matrix2 = new MatrixController(Matrix.rows, Matrix.columns);
                                    }
                                    //заполняем ее с клавиатуры
                                    Matrix2.FillFromKeyboard();


                                    MatrixController.PrintMatrix(Matrix + Matrix2);
                                }
                                catch
                                {
                                    Console.WriteLine("NullReference. U didnt set columns and rows");
                                }


                                break;
                            case 3:

                                //тот же принцип что и выше
                                Console.WriteLine("Enter second matrix the same size");
                                Matrix2 = null;
                                if (Matrix.columns == Matrix.rows)
                                {
                                    Matrix2 = new MatrixController(Matrix.rows);
                                }
                                else
                                {
                                    Matrix2 = new MatrixController(Matrix.rows, Matrix.columns);
                                }
                                Matrix2.FillFromKeyboard();


                                MatrixController.PrintMatrix(Matrix - Matrix2);


                                break;
                            case 4:
                                //выход из программы 
                                //принудительный вызов сборщика мусора
                                Console.WriteLine("Quiting the programm... Press any key to quit");
                                GC.Collect();
                                break;
                            default:
                                break;
                        }

                    }

                    break;
                default:
                    Console.WriteLine("Not good");
                    break;
            }
           

        }





    }

}

