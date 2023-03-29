using System;
using System.Threading;
using static System.Console;
using System.Text.Json;
using System.IO;

namespace Test_task_by_Khromakov_Maxim
{
    abstract class Figure
    {
        public abstract void GetFigure(int ID);
        public abstract double Area();
        public abstract double Perimeter();
    }
    class Square : Figure
    {
        private double sizeSides { get; set; }
        public Square(double sizeSide) => this.sizeSides = sizeSides;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Квадрат\n"
                + $"Размер каждой стороны: {sizeSides}\n"
                + $"Периметр: {Perimeter()}\n"
                + $"Площадь: {Area()}\n"
                + "===============================");
        }
        public override double Area() => Math.Pow(sizeSides, 2);
        public override double Perimeter() => sizeSides * 4;

    }
    class Round : Figure
    {
        private double radius { get; set; }
        public Round(double radius) => this.radius = radius;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Круг\n"
                + $"Радиус круга: {radius}\n"
                + $"Периметр: {Perimeter()}\n"
                + $"Площадь: {Area()}\n"
                + "===============================");
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
        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Треугольник\n"
                + "\tРазмеры каждых сторон\n"
                + $"Левая сторона: {leftSide}\n"
                + $"Правая сторона: {rightSide}\n"
                + $"Нижняя сторона: {bottomSide}\n"
                + $"Тип треугольника: {TypeTrinagle()}\n"
                + $"Периметр: {Perimeter()}\n"
                + $"Площадь: {Area()}\n"
                + "===============================");
        }
        public override double Area()
        {
            double halfPer = Perimeter() * 0.5;
            double result = Math.Sqrt(halfPer * (halfPer - leftSide) * (halfPer - rightSide) * (halfPer - bottomSide));
            return result;
        }
        public override double Perimeter() => leftSide + rightSide + bottomSide;
        public string TypeTrinagle()
        {
            string message;
            if ((leftSide == rightSide) && (rightSide == bottomSide) && (leftSide == bottomSide)) message = "Равносторонний";
            else if ((leftSide == rightSide) && (leftSide != bottomSide) && (rightSide != bottomSide)) message = "Равнобедренный";
            else message = "Разносторонний";
            return message;
        }
    }
    class Rectangle : Figure
    {
        private double horizontally { get; set; }
        private double vertically { get; set; }
        public Rectangle(double horizontally, double vertically)
        {
            this.horizontally = horizontally;
            this.vertically = vertically;
        }
        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Круг\n"
                + "\tРазмеры сторон\n"
                + $"По горизонтали: {horizontally}\n"
                + $"По вертикали: {vertically}\n"
                + $"Периметр: {Perimeter()}\n"
                + $"Площадь: {Area()}\n"
                + "===============================");
        }
        public override double Area() => horizontally * vertically;
        public override double Perimeter() => (2 * horizontally) + (2 * vertically);

    }
    class WriteInformation
    {
        public int PutEnd(string path, string typeFigure, double[] sizeSides, string[] nameSides)
        {
            int id = 0;
            using (StreamReader rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    string[] words = line.Split(": ");
                    if(words[0] == "ID")
                    {
                        int newId = int.Parse(words[1]);
                        id = newId;
                    }
                }
            }
            using (StreamWriter wr = new StreamWriter(path, true))
            {
                id++;
                wr.WriteLine("==========\n" + $"ID: {id}\n" + $"Type: {typeFigure}");
                for (int i = 0; i < sizeSides.Length; i++)
                {
                    wr.WriteLine($"{nameSides[i]}: {sizeSides[i]}");
                }
                wr.WriteLine("==========");
            }
            return id;
        }
        public void Print(string path, string by, string IDorType)
        {
            using (StreamReader rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    string[] words = line.Split(": ");
                    switch (by)
                    {
                        case "By ID":
                            if (words[0] == "ID")
                            {
                                int ID = int.Parse(words[1]);
                                int searchByID = int.Parse(IDorType);
                                if (ID == searchByID)
                                {
                                    WriteLine("==========");
                                    while (line != "==========")
                                    {
                                        WriteLine(line);
                                    }
                                    WriteLine("==========");
                                }
                            }
                            break;
                        case "Type":
                            if (words[0] == "Type")
                            {
                                if(words[1] == IDorType)
                                {
                                    WriteLine("==========");
                                    while (line != "==========")
                                    {
                                        WriteLine(line);
                                    }
                                    WriteLine("==========");
                                }
                            }
                            break;
                        case "All":
                            WriteLine(line);
                            break;
                        default:
                            WriteLine("Введён неверный тип!");
                            ReadKey();
                            break;
                    }
                }
            }
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
                string[] namedAllSize = { "LS", "RS", "BS", "HZ", "VC", "AS", "R" };
                WriteLine("\t\tМеню\n" + "1)\tСоздание новой фигуры\n" + "2)\tПросмотр текущих фигур\n" + "3)\tОбновление данных списка фигур\n" + "4)\tВыход из цикла");
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
                        isCreateWork = true;
                        switch (createChoise)
                        {
                            case "1":
                                do
                                {
                                    Clear();
                                    WriteLine();
                                    Log();
                                    Write("Вы выбрали треугольник.\n\n");
                                    Thread.Sleep(400);
                                    double a, b, c;
                                    try
                                    {
                                        Log();
                                        Write("Введите размер левой стороны: ");
                                        a = Convert.ToDouble(ReadLine());
                                        WriteLine();
                                        Log();
                                        Write("Введите размер правой стороны: ");
                                        b = Convert.ToDouble(ReadLine());
                                        WriteLine();
                                        Log();
                                        Write("Введите размер нижней стороны: ");
                                        c = Convert.ToDouble(ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        NumberException();
                                        continue;
                                        throw;
                                    }
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
                                        double[] sizeTrinagle = { a, b, c };
                                        string[] shortNameSide = { namedAllSize[0], namedAllSize[1], namedAllSize[2] };
                                        WriteInformation wi = new WriteInformation();
                                        int ID = wi.PutEnd("figures.txt", "Trinagle", sizeTrinagle, shortNameSide);
                                        trinagle.GetFigure(ID);
                                        Log();
                                        Write("Фигура создана! Нажмите чтобы продолжить: ");
                                        ReadKey();
                                        isCreateWork = false;
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
                                    double size;
                                    try
                                    {
                                        Log();
                                        Write("Введите сторону для всех 4: ");
                                        size = Convert.ToDouble(ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        NumberException();
                                        continue;
                                        throw;
                                    }
                                    if(size <= 0)
                                    {
                                        WriteLine();
                                        Log();
                                        Write("Размер сторон не может быть равен или быть меньше 0!");
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                    else
                                    {
                                        Square square = new Square(size);
                                        double[] sizeSquare = { size };
                                        string[] shortNameSide = { namedAllSize[5] };
                                        WriteInformation wi = new WriteInformation();
                                        int ID = wi.PutEnd("figures.txt", "Square", sizeSquare, shortNameSide);
                                        square.GetFigure(ID);
                                        Log();
                                        Write("Фигура создана! Нажмите чтобы продолжить: ");
                                        ReadKey();
                                        isCreateWork = false;
                                    }
                                } while (isCreateWork);
                                break;
                            case "3":
                                do
                                {
                                    Clear();
                                    WriteLine();
                                    Log();
                                    Write("Вы выбрали прямоугольник.\n\n");
                                    Thread.Sleep(400);
                                    double vert, goriz;
                                    try
                                    {
                                        Log();
                                        Write("Введите размер по вертикали: ");
                                        vert = Convert.ToDouble(ReadLine());
                                        WriteLine();
                                        Log();
                                        Write("Введите размер по горизонтали: ");
                                        goriz = Convert.ToDouble(ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        NumberException();
                                        continue;
                                        throw;
                                    }
                                    if (vert <= 0 || goriz <= 0)
                                    {
                                        WriteLine();
                                        Log();
                                        Write("Размер сторон не может быть равен или быть меньше 0!");
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                    else if (vert == goriz)
                                    {
                                        WriteLine();
                                        Log();
                                        Write("Размер по горизонтали и вертикале равны. Вы бы хотели его преобразовать в квадрат?(Да/Нет): ");
                                        string isSquare = ReadLine();
                                        switch (isSquare)
                                        {
                                            case "Да":
                                                Square square = new Square(vert);
                                                double[] sizeSquare = { vert };
                                                string[] shortNameSide = { namedAllSize[5] };
                                                WriteInformation wi = new WriteInformation();
                                                int ID = wi.PutEnd("figures.txt", "Square", sizeSquare, shortNameSide);
                                                square.GetFigure(ID);
                                                Log();
                                                Write("Фигура создана! Нажмите чтобы продолжить: ");
                                                ReadKey();
                                                isCreateWork = false;
                                                break;
                                            case "Нет":
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Rectangle rectangle = new Rectangle(vert, goriz);
                                        double[] sizeRectangle = { vert, goriz };
                                        string[] shortNameSide = { namedAllSize[3], namedAllSize[4] };
                                        WriteInformation wi = new WriteInformation();
                                        int ID = wi.PutEnd("figures.txt", "Rectangle", sizeRectangle, shortNameSide);
                                        rectangle.GetFigure(ID);
                                        Log();
                                        Write("Фигура создана! Нажмите чтобы продолжить: ");
                                        ReadKey();
                                        isCreateWork = false;
                                    }
                                } while (isCreateWork);
                                break;
                            case "4":
                                do
                                {
                                    Clear();
                                    WriteLine();
                                    Log();
                                    Write("Вы выбрали круг.\n\n");
                                    Thread.Sleep(400);
                                    double radius;
                                    try
                                    {
                                        Log();
                                        Write("Введите радиус круга: ");
                                        radius = Convert.ToDouble(ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        NumberException();
                                        continue;
                                        throw;
                                    }
                                    if (radius <= 0)
                                    {
                                        WriteLine();
                                        Log();
                                        Write("Радиус не может быть равен или быть меньше 0!");
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                    else
                                    {
                                        Round round = new Round(radius);
                                        double[] sizeRadius = { radius };
                                        string[] shortNameSide = { namedAllSize[6] };
                                        WriteInformation wi = new WriteInformation();
                                        int ID = wi.PutEnd("figures.txt", "Round", sizeRadius, shortNameSide);
                                        round.GetFigure(ID);
                                        Log();
                                        Write("Фигура создана! Нажмите чтобы продолжить: ");
                                        ReadKey();
                                        isCreateWork = false;
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
                        Clear();
                        WriteLine("1) По ID\n" + "2) По типам\n" + "3) Все\n" + "4) Назад");
                        Log();
                        Write("Выберите как вы хотите выбрать: ");
                        string choiseType = ReadLine();
                        switch (choiseType)
                        {
                            case "1":
                                Clear();
                                Log();
                                Write("Введите ID: ");
                                int id;
                                try
                                {
                                    id = int.Parse(ReadLine());
                                }
                                catch (Exception)
                                {
                                    WriteLine();
                                    Log();
                                    Write("Вы ввели НЕ цифру. Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    throw;
                                }
                                WriteInformation wi = new WriteInformation();
                                wi.Print("figures.txt", "By ID", $"{id}");
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        break;
                    case "4":
                        Clear();
                        isMainWork = false;
                        break;
                    default:
                        WriteLine();
                        Log();
                        Write("Вы ввели неверное значение! Попробуйте снова.");
                        ReadKey();
                        break;
                }
            } while (isMainWork);
            Log();
            WriteLine("Вы вышли из цикла.");
            Thread.Sleep(500);
            Log();
            Write("Хотите завершить программу(Close/or any symbol), или вернуться назад(Back)?: ");
            string closeOrComeBack = ReadLine();
            switch (closeOrComeBack)
            {
                case "Back":
                    Clear();
                    Main();
                    break;
                case "Close":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        static void NumberException()
        {
            WriteLine("\n");
            Log();
            Write("Вы ввели НЕ числовое значение!, Попробуйте снова\n\n");
            Log();
            Write("Нажмите для продолжения любую клавишу: ");
            ReadKey();
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