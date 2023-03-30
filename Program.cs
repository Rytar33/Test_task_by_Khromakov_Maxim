using System;
using System.Threading;
using static System.Console;
using System.IO;
using System.Collections.Generic;

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
        private double SizeSides { get; set; }
        public Square(double sizeSides) => this.SizeSides = sizeSides;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Квадрат\n"
                + $"Размер каждой стороны: {SizeSides}\n"
                + $"Периметр: {Perimeter()}\n"
                + $"Площадь: {Area()}\n"
                + "===============================");
        }
        public override double Area() => Math.Pow(SizeSides, 2);
        public override double Perimeter() => SizeSides * 4;

    }
    class Round : Figure
    {
        private double Radius { get; set; }
        public Round(double radius) => this.Radius = radius;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Круг\n"
                + $"Радиус круга: {Radius}\n"
                + $"Периметр: {Perimeter()}\n"
                + $"Площадь: {Area()}\n"
                + "===============================");
        }
        public override double Area() => Math.PI * Math.Pow(Radius, 2);
        public override double Perimeter() => 2 * Math.PI * Radius;
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
                + $"Площадь: {Math.Round(Area(), 2)}\n"
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
                    if (words[0] == "ID")
                    {
                        int newId = int.Parse(words[1]);
                        id = newId;
                    }
                }
            }
            using (StreamWriter wr = new StreamWriter(path, true))
            {
                id++;
                wr.WriteLine("==========");
                wr.WriteLine($"ID: {id}");
                wr.WriteLine($"Type: {typeFigure}");
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
                                    WriteLine(line);
                                    while ((line = rd.ReadLine()) != "==========")
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
                                if (words[1] == IDorType)
                                {
                                    WriteLine("==========");
                                    WriteLine(line);
                                    while ((line = rd.ReadLine()) != "==========")
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
        public void Update(string path, int ID, string type, double[] newSizeSides, string[] nameKey)
        {
            List<string> data = new List<string>();
            using(StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }
            for (int i = 0; i < data.Count; i++)
            {
                string[] keyInf = data[i].Split(": ");
                if (keyInf[0] == "ID" && int.Parse(keyInf[1]) == ID)
                {
                    data[i + 1] = $"Type: {type}";
                    for (int j = 0; j < nameKey.Length; j++)
                    {
                        data[i + 2 + j] = $"{nameKey[j]}: {newSizeSides[j]}";
                    }
                    break;
                }
            }
            using(StreamWriter wr = new StreamWriter(path, false))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    wr.WriteLine(data[i]);
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Log("");
            Write("Loading shop");
            bool isMainWork = true;
            bool isCreateWork = true;
            int i = 0;
            while (i < 3)
            {
                Thread.Sleep(500);
                Write(".");
                i++;
            }
            WriteLine();
            Thread.Sleep(300);
            Log("Succses");
            Write("Loading completed! Entering to shop");
            Thread.Sleep(2000);
            do
            {
                Clear();
                string[] namedAllSize = { "LS", "RS", "BS", "HZ", "VC", "AS", "R" };
                WriteLine("\t\tМеню\n" + "1\t| Создание новой фигуры\t\t |\n" + "2\t| Просмотр текущих фигур\t |\n" + "3\t| Обновление данных списка фигур |\n" + "4\t| Выход из цикла\t\t |\n");
                Write("Выбрать из этого списка: ");
                string choise = ReadLine();
                switch (choise)
                {
                    case "1":
                        isCreateWork = true;
                        do
                        {
                            Clear();
                            WriteLine("1) Треугольник\n" + "2) Квадрат\n" + "3) Прямоугольник\n" + "4) Круг\n" + "5) Назад");
                            Log("");
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
                                        Log("Succses");
                                        Write("Вы выбрали треугольник.\n\n");
                                        Thread.Sleep(400);
                                        double a, b, c;
                                        try
                                        {
                                            Log("");
                                            Write("Введите размер левой стороны: ");
                                            a = Convert.ToDouble(ReadLine());
                                            WriteLine();
                                            Log("");
                                            Write("Введите размер правой стороны: ");
                                            b = Convert.ToDouble(ReadLine());
                                            WriteLine();
                                            Log("");
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
                                            Log("Error");
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
                                            Log("Succses");
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
                                        Log("Succses");
                                        Write("Вы выбрали квадрат.\n\n");
                                        Thread.Sleep(400);
                                        double size;
                                        try
                                        {
                                            Log("");
                                            Write("Введите сторону для всех 4: ");
                                            size = Convert.ToDouble(ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            NumberException();
                                            continue;
                                            throw;
                                        }
                                        if (size <= 0)
                                        {
                                            WriteLine();
                                            Log("Error");
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
                                            Log("Succses");
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
                                        Log("Succses");
                                        Write("Вы выбрали прямоугольник.\n\n");
                                        Thread.Sleep(400);
                                        double vert, goriz;
                                        try
                                        {
                                            Log("");
                                            Write("Введите размер по вертикали: ");
                                            vert = Convert.ToDouble(ReadLine());
                                            WriteLine();
                                            Log("");
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
                                            Log("Error");
                                            Write("Размер сторон не может быть равен или быть меньше 0!");
                                            Thread.Sleep(2000);
                                            continue;
                                        }
                                        else if (vert == goriz)
                                        {
                                            WriteLine();
                                            Log("Warning");
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
                                                    Log("Succses");
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
                                            Log("Succses");
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
                                        Log("Succses");
                                        Write("Вы выбрали круг.\n\n");
                                        Thread.Sleep(400);
                                        double radius;
                                        try
                                        {
                                            Log("");
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
                                            Log("Succses");
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
                                            Log("Succses");
                                            Write("Фигура создана! Нажмите чтобы продолжить: ");
                                            ReadKey();
                                            isCreateWork = false;
                                        }
                                    } while (isCreateWork);
                                    break;
                                case "5":
                                    isCreateWork = false;
                                    break;
                                default:
                                    WriteLine();
                                    Log("Error");
                                    Write("Вы ввели неверное значение! Попробуйте снова.");
                                    ReadKey();
                                    break;
                            }
                        } while (isCreateWork);
                        break;
                    case "2":
                        isCreateWork = true;
                        do
                        {
                            Clear();
                            WriteLine("1) По ID\n" + "2) По типам\n" + "3) Все\n" + "4) Назад");
                            Log("");
                            Write("Выберите как вы хотите выбрать: ");
                            string choiseType = ReadLine();
                            switch (choiseType)
                            {
                                case "1":
                                    Clear();
                                    Log("");
                                    Write("Введите ID: ");
                                    int id;
                                    try
                                    {
                                        id = int.Parse(ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        WriteLine();
                                        Log("Error");
                                        Write("Вы ввели НЕ цифру. Нажмите чтобы продолжить: ");
                                        ReadKey();
                                        throw;
                                    }
                                    WriteInformation wi = new WriteInformation();
                                    wi.Print("figures.txt", "By ID", $"{id}");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    break;
                                case "2":
                                    Clear();
                                    Log("");
                                    Write("Введите тип: ");
                                    string type = ReadLine();
                                    WriteInformation witype = new WriteInformation();
                                    witype.Print("figures.txt", "Type", type);
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    break;
                                case "3":
                                    WriteInformation wii = new WriteInformation();
                                    wii.Print("figures.txt", "All", "");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    break;
                                case "4":
                                    isCreateWork = false;
                                    break;
                                default:
                                    WriteLine();
                                    Log("Error");
                                    Write("Вы ввели неверное значение! Нажмите чтобы продолжить. ");
                                    ReadKey();
                                    break;
                            }
                        } while (isCreateWork);
                        break;
                    case "3":
                        isCreateWork = true;
                        do
                        {
                            Clear();
                            WriteInformation wii = new WriteInformation();
                            wii.Print("figures.txt", "All", "");
                            WriteLine();
                            Log("");
                            Write("Введите ID фигуры которую вы бы хотели изменить: ");
                            int id = int.Parse(ReadLine());
                            WriteLine();
                            Clear();
                            Log("");
                            Write("Введите тип фигуры на который вы бы хотели поменять: ");
                            string typeName = ReadLine();
                            switch (typeName)
                            {
                                case "Треугольник":
                                    typeName = "Trinagle";
                                    double[] sizesTrinagle = new double[3];
                                    string[] nameKeyTrinagle = { namedAllSize[0], namedAllSize[1], namedAllSize[2] };
                                    WriteLine();
                                    Log("");
                                    Write("Введите левую сторону: ");
                                    sizesTrinagle[0] = double.Parse(ReadLine());
                                    WriteLine();
                                    Log("");
                                    Write("Введите правую сторону: ");
                                    sizesTrinagle[1] = double.Parse(ReadLine());
                                    WriteLine();
                                    Log("");
                                    Write("Введите нижнюю сторону: ");
                                    sizesTrinagle[2] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesTrinagle, nameKeyTrinagle);
                                    isCreateWork = false;
                                    break;
                                case "Квадрат":
                                    typeName = "Square";
                                    double[] sizesSquare = new double[1];
                                    string[] nameKeySquare = { namedAllSize[5] };
                                    WriteLine();
                                    Log("");
                                    Write("Введите все 4 стороны: ");
                                    sizesSquare[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesSquare, nameKeySquare);
                                    wii.Print("figures.txt", "All", "");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    isCreateWork = false;
                                    break;
                                case "Прямоугольник":
                                    typeName = "Rectangle";
                                    double[] sizesRectangle = new double[2];
                                    string[] nameKeyRectangle = { namedAllSize[3], namedAllSize[4] };
                                    WriteLine();
                                    Log("");
                                    Write("Введите размер по горизонтали: ");
                                    sizesRectangle[0] = double.Parse(ReadLine());
                                    WriteLine();
                                    Log("");
                                    Write("Введите размер по вертикали: ");
                                    sizesRectangle[1] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesRectangle, nameKeyRectangle);
                                    wii.Print("figures.txt", "All", "");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    isCreateWork = false;
                                    break;
                                case "Круг":
                                    typeName = "Round";
                                    double[] sizesRound = new double[0];
                                    string[] nameKeyRound = { namedAllSize[6] };
                                    WriteLine();
                                    Log("");
                                    Write("Введите окружность: ");
                                    sizesRound[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesRound, nameKeyRound);
                                    isCreateWork = false;
                                    break;
                                case "Оставить":
                                    WriteLine();
                                    Log("Warning");
                                    Write("Эта функция временно не работает.");
                                    break;
                                default:
                                    WriteLine();
                                    Log("Error");
                                    Write("Вы ввели неверный тип! Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    break;
                            }
                            
                        } while (isCreateWork);
                        break;
                    case "4":
                        Clear();
                        isMainWork = false;
                        break;
                    default:
                        WriteLine();
                        Log("Error");
                        Write("Вы ввели неверное значение! Попробуйте снова.");
                        ReadKey();
                        break;
                }
            } while (isMainWork);
            Log("");
            WriteLine("Вы вышли из цикла.");
            Thread.Sleep(500);
            Log("");
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
            Log("Error");
            Write("Вы ввели НЕ числовое значение!, Попробуйте снова\n\n");
            Log("Error");
            Write("Нажмите для продолжения любую клавишу: ");
            ReadKey();
        }
        static void Log(string type)
        {
            if (type == "Error") ForegroundColor = ConsoleColor.Red;
            else if (type == "Warning") ForegroundColor = ConsoleColor.Yellow;
            else if (type == "Succses") ForegroundColor = ConsoleColor.Green;
            else ForegroundColor = ConsoleColor.DarkGray;
            Write($"[{DateTime.Now}]");
            ForegroundColor = ConsoleColor.White;
            Write(": ");
        }
    }
}
