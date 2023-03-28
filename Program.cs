using System;
using System.Threading;
using static System.Console;
using System.Text.Json;
using System.IO;

namespace Test_task_by_Khromakov_Maxim
{
    abstract class Figure
    {
        public abstract void GetFigure();
        public abstract double Area();
        public abstract double Perimeter();
    }
    class Square : Figure
    {
        private int sizeSides { get; set; }
        public Square(int sizeSide) => this.sizeSides = sizeSides;

        public override void GetFigure()
        {
            using (FileStream fs = new FileStream("figures.json", FileMode.OpenOrCreate))
            {
                //Rootobject init = JsonSerializer.Deserialize<Rootobject>;
            }
        }
        public override double Area() => Math.Pow(sizeSides, 2);
        public override double Perimeter() => sizeSides * 4;

    }
    class Round : Figure
    {
        private int radius { get; set; }
        public Round(int radius) => this.radius = radius;

        public override void GetFigure()
        {

        }
        public override double Area() => Math.PI * Math.Pow(radius, 2);
        public override double Perimeter() => 2 * Math.PI * radius;
    }
    class Trinagle : Figure
    {
        private double leftSide { get; set; }
        private double rightSide { get; set; }
        private double bottomSide { get; set; }
        public Trinagle(double leftSide, double rightSide, double bottomSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.bottomSide = bottomSide;
        }
        public override void GetFigure()
        {

        }
        public override double Area()
        {
            double halfPer = Perimeter() * 0.5;
            double result = Math.Sqrt(halfPer * (halfPer - leftSide) * (halfPer - rightSide) * (halfPer - bottomSide));
            return result;
        }
        public override double Perimeter() => leftSide + rightSide + bottomSide;
    }
    class Rectangle : Figure
    {
        private int horizontally { get; set; }
        private int vertically { get; set; }
        public Rectangle(int horizontally, int vertically)
        {
            this.horizontally = horizontally;
            this.vertically = vertically;
        }
        public override void GetFigure()
        {

        }
        public override double Area() => horizontally * vertically;
        public override double Perimeter() => (2 * horizontally) + (2 * vertically);
      

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int ID_Figure { get; set; }
            public string type { get; set; }
            public Sides sides { get; set; }
            public DateTime date_checkout { get; set; }
        }

        public class Sides
        {
            public int leftSide { get; set; }
            public int rightSide { get; set; }
            public int bottomSide { get; set; }
            public int radius { get; set; }
            public int horizontally { get; set; }
            public int vertically { get; set; }
            public int sizeSides { get; set; }
        }

    }

    class Program
    {
        static void Main()
        {
            //            Write(@"██╗      ██████╗  █████╗ ██████╗ ██╗███╗   ██╗ ██████╗     ███████╗██╗  ██╗ ██████╗ ██████╗
            //██║     ██╔═══██╗██╔══██╗██╔══██╗██║████╗  ██║██╔════╝     ██╔════╝██║  ██║██╔═══██╗██╔══██╗
            //██║     ██║   ██║███████║██║  ██║██║██╔██╗ ██║██║  ███╗    ███████╗███████║██║   ██║██████╔╝
            //██║     ██║   ██║██╔══██║██║  ██║██║██║╚██╗██║██║   ██║    ╚════██║██╔══██║██║   ██║██╔═══╝ 
            //███████╗╚██████╔╝██║  ██║██████╔╝██║██║ ╚████║╚██████╔╝    ███████║██║  ██║╚██████╔╝██║     
            //╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝ ╚═╝╚═╝  ╚═══╝ ╚═════╝     ╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚═╝     ");
            Log();
            Write("Loading shop");
            bool isMainWork = true;
            bool isCreateWork = true;
            int i = 0;
            while (i < 3)
            {
                Thread.Sleep(1000);
                //WriteLine(@"   " +
                //    @"   " +
                //    @"   " +
                //    @"   " +
                //    @"██╗" +
                //    @"╚═╝");
                Write(".");
                i++;
            }
            WriteLine();
            Thread.Sleep(300);
            Log();
            Write("Loading completed! Entering to shop");
            Thread.Sleep(2000);
            do
            {
                Clear();
                WriteLine("\t\tМеню\n" + "1)\tСоздание новой фигуры\n" + "2)\tПросмотр текущих фигур");
                Write("Выбрать из этого списка: ");
                string choise = ReadLine();
                switch (choise)
                {
                    case "1":
                        Clear();
                        WriteLine("1) Треугольник\n" + "2) Квадрат\n" + "3) Прямоугольник\n" + "4) Круг");
                        Log();
                        Write("Выберите тип фигуры какой вы бы хотели создать: ");
                        string createChoise = ReadLine();
                        switch (createChoise)
                        {
                            case "1":
                                isCreateWork = true;
                                do
                                {
                                    Clear();
                                    WriteLine();
                                    Log();
                                    Write("Вы выбрали треугольник.\n\n");
                                    Thread.Sleep(400);
                                    Log();
                                    Write("Введите размер левой стороны: ");
                                    double a = Convert.ToDouble(ReadLine());
                                    WriteLine();
                                    Log();
                                    Write("Введите размер правой стороны: ");
                                    double b = Convert.ToDouble(ReadLine());
                                    WriteLine();
                                    Log();
                                    Write("Введите размер нижней стороны: ");
                                    double c = Convert.ToDouble(ReadLine());
                                    if (a <= 0 || b <= 0 || c <= 0)
                                    {
                                        WriteLine();
                                        Log();
                                        Write("Размер сторон не может быть равен или быть меньше 0!");
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                    else
                                    {
                                        Trinagle trinagle = new Trinagle(a, b, c);

                                    }

                                } while (isCreateWork);
                                break;
                            case "2":
                                do
                                {
                                    Clear();
                                    WriteLine();
                                    Log();
                                    Write("Вы выбрали квадрат.\n\n");
                                    Thread.Sleep(400);
                                    Log();
                                    Write("Введите сторону для всех 4: ");
                                    double size = Convert.ToDouble(ReadLine());
                                    if(size <= 0)
                                    {
                                        WriteLine();
                                        Log();
                                        Write("Размер сторон не может быть равен или быть меньше 0!");
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                } while (isCreateWork);
                                break;
                            case "3":
                                Clear();
                                WriteLine();
                                Log();
                                Write("Вы выбрали прямоугольник.\n\n");
                                Thread.Sleep(400);
                                Log();
                                Write("Введите размер по вертикали: ");
                                double vert = Convert.ToDouble(ReadLine());
                                WriteLine();
                                Log();
                                Write("Введите размер по горизонтали: ");
                                double goriz = Convert.ToDouble(ReadLine());
                                if(vert <= 0 || goriz <= 0)
                                {
                                    WriteLine();
                                    Log();
                                    Write("Размер сторон не может быть равен или быть меньше 0!");
                                    Thread.Sleep(2000);
                                    continue;
                                } 
                                else if(vert == goriz)
                                {
                                    WriteLine();
                                    Log();
                                    Write("Размер по горизонтали и вертикале равны. Вы бы хотели его преобразовать в квадрат?: ");

                                }
                                break;
                            case "4":
                                do
                                {
                                    Clear();
                                    WriteLine();
                                    Log();
                                    Write("Вы выбрали круг.\n\n");
                                    Thread.Sleep(400);
                                    Log();
                                    Write("Введите радиус круга: ");
                                    double radius = Convert.ToDouble(ReadLine());
                                    if (radius <= 0)
                                    {
                                        WriteLine();
                                        Log();
                                        Write("Радиус не может быть равен или быть меньше 0!");
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                } while (isCreateWork);
                                break;
                            default:
                                WriteLine();
                                Log();
                                Write("Вы ввели неверное значение! Попробуйте снова.");
                                break;
                        }
                        break;
                    case "2":
                        break;
                    default:
                        WriteLine();
                        Log();
                        Write("Вы ввели неверное значение! Попробуйте снова.");
                        ReadKey();
                        break;
                }
            } while (isMainWork);
        }
        static void Log()
        {
            ForegroundColor = ConsoleColor.Green;
            Write($"[{DateTime.Now}]");
            ForegroundColor = ConsoleColor.White;
            Write(": ");
        }
    }
}