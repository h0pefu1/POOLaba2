using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace POOLABA2
{
    public class MatrixController
    {
        //erorr code
        public static int Erorr { get; set; }

        //rows
        public int rows { get; set; }
        //columns
        public int columns { get; set; }

        //двумерный массив для матрицы
        private double[,] data { get; set; }


        //конструкетор с параметрамми двумя
        public MatrixController(int rows, int columns)
        {

            this.rows = rows;
            this.columns = columns;
            this.data = new double[rows, columns];
            //зануляемм все элементы матрицы
            this.ForMethodsForMatrix((i, j) => this.data[i, j] = 0);

        }
        //конструктор для квадратной матрицы
        public MatrixController(int rows)
        {

            this.rows = rows;
            this.columns = rows;
            this.data = new double[rows, columns];

            this.ForMethodsForMatrix((i, j) => this.data[i, j] = 0);
        }
        //пустой конструктор
        public MatrixController()
        {

        }





        //удобная функция для работы с матрицей
        //в параметры мы можем передать метод

        public void ForMethodsForMatrix(Action<int, int> action)
        {
            for (int i = 0; i < this.columns; i++)
            {
                for (int j = 0; j < this.rows; j++)
                {
                    action(i, j);
                }
            }
        }

        //Индексатор(позволяет обращаться к объкту как к массиву)
        public double this[int x, int y]
        {
            get
            {
                return this.data[x, y];
            }
            set
            {
                this.data[x, y] = value;
            }
        }

        //перегрузка оператора * для умножения матрицы на число
        public static MatrixController operator *(MatrixController Matrix, double value)
        {
            var result = new MatrixController(Matrix.rows, Matrix.columns);
            result.ForMethodsForMatrix((i, j) =>
                result[i, j] = Matrix[i, j] * value);
            return result;
        }

        //перегрузка опрератора сложения с матрицами
        public static MatrixController operator +(MatrixController matrix1, MatrixController matrix2)
        {
            //проверка на размер матриц
            if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            {
                Erorr = 1;
                throw new ArgumentException("Not same size");

            }
            //создаем третью матрицу с теми же размерами
            var result = new MatrixController(matrix1.columns, matrix2.rows);
            //выполняем метод по сложению 
            result.ForMethodsForMatrix((i, j) => result[i, j] = matrix1[i, j] + matrix2[i, j]);
            return result;

        }
        //перегрузка оператора вычитания(принцип действия такой же как и у сложения)
        public static MatrixController operator -(MatrixController matrix1, MatrixController matrix2)
        {

            if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            {
                Erorr = 1;
                throw new ArgumentException("Not same size");

            }
            var result = new MatrixController(matrix1.columns, matrix2.rows);

            result.ForMethodsForMatrix((i, j) => result[i, j] = matrix1[i, j] - matrix2[i, j]);
            return result;

        }

        //метод для печати матрицы
        public static void PrintMatrix(MatrixController matrix)
        {
            //обход двумерного массива
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    Console.Write(matrix.data[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        //заполнение с клавиатуры матрицы
        public void FillFromKeyboard()
        {
            //блок try catch
            try

            {
                //проверяем на наличие у объекта количество столбцов(так как у нас есть разные конструкторы)
                if (this.columns == 0)
                {
                    Console.WriteLine("Enter columns");
                    this.columns = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception ex)
            {

                Erorr = 2;
                Console.WriteLine("Colums are not right. Number:" + Erorr.ToString());
            }
            try
            {
                if (this.rows == 0)
                    Console.WriteLine("Enter columns");
                this.rows = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {

                Erorr = 3;
                Console.WriteLine("Rows are not right. Number:" + Erorr.ToString());
            }
            //используем метод для исполнение действий над всеми элементами матрицы
            this.ForMethodsForMatrix((i, j) => this.Input(i, j));


        }
        //дополнительная функция на элементов матрицы
        private void Input(int i, int j)
        {
            Console.WriteLine($"Enter this [{i}][{j}]");
            this.data[i, j] = double.Parse(Console.ReadLine());
        }


    }
}
