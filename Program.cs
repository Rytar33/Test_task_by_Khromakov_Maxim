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
        private double SizeSides { get; set; } // Размер всех 4-х сторон квадрата
        public Square(double sizeSides) => this.SizeSides = sizeSides;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Квадрат\n"
                + $"Размер каждой стороны: {SizeSides}\n"
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => Math.Pow(SizeSides, 2); // Получение площади квадрата
        public override double Perimeter() => SizeSides * 4; // Получение периметра квадрата

    }
    class Round : Figure
    {
        private double Radius { get; set; } // Радиус круга
        public Round(double radius) => this.Radius = radius;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Круг\n"
                + $"Радиус круга: {Radius}\n"
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => Math.PI * Math.Pow(Radius, 2); // Получение площади круга
        public override double Perimeter() => 2 * Math.PI * Radius; // Получение периметра круга
    }
    class Trinagle : Figure
    {
        private double leftSide { get; set; } // Левая сторона треугольника
        private double rightSide { get; set; } // Правая сторона треугольника
        private double bottomSide { get; set; } // Основание треугольника
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
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        // Получение площади треугольника
        public override double Area()
        {
            double halfPer = Perimeter() * 0.5;
            double result = Math.Sqrt(halfPer * (halfPer - leftSide) * (halfPer - rightSide) * (halfPer - bottomSide));
            return result;
        }
        public override double Perimeter() => leftSide + rightSide + bottomSide; // Получение периметра треугольника
        public string TypeTrinagle()
        {
            string message;
            if ((leftSide == rightSide) && (rightSide == bottomSide) && (leftSide == bottomSide)) message = "Равносторонний"; // Если все стороны равны, то будет истина
            else if ((leftSide == rightSide) && (leftSide != bottomSide) && (rightSide != bottomSide)) message = "Равнобедренный"; // Если равны только левая и правая часть, то будет истина
            else message = "Разносторонний"; // Иначе стороны разные
            return message;
        }
    }
    class Rectangle : Figure
    {
        private double horizontally { get; set; } // Горизонтальная сторона
        private double vertically { get; set; } // Вертикальная сторона
        public Rectangle(double horizontally, double vertically)
        {
            this.horizontally = horizontally;
            this.vertically = vertically;
        }
        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID фигуры: {id}\n"
                + "Фигура: Прямоугольник\n"
                + "\tРазмеры сторон\n"
                + $"По горизонтали: {horizontally}\n"
                + $"По вертикали: {vertically}\n"
                + $"Периметр: {Math.Round(Perimeter(), 2)}\n"
                + $"Площадь: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => horizontally * vertically; // Получение площади прямоугольника
        public override double Perimeter() => (2 * horizontally) + (2 * vertically); // Получение периметра прямоугольника

    }
    // Работа с текстовым файлом (да, получилось не мало)
    class WriteInformation
    {
        // Создание новой фигуры в конец файла
        public int PutEnd(string path, string typeFigure, double[] sizeSides, string[] nameSides)
        {
            int id = 0;
            using (StreamReader rd = new StreamReader(path)) // Чтение файла
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    string[] words = line.Split(": "); // Разбиение строки на ключ и значение
                    if (words[0] == "ID")
                    {
                        int newId = int.Parse(words[1]);
                        id = newId; // Запоминает все ID, пока не дойдёт до последнего
                    }
                }
            }
            using (StreamWriter wr = new StreamWriter(path, true)) // Запись в файл
            {
                id++; // Инкрименция ID
                wr.WriteLine("=========="); 
                wr.WriteLine($"ID: {id}");
                wr.WriteLine($"Type: {typeFigure}");
                for (int i = 0; i < sizeSides.Length; i++)
                {
                    wr.WriteLine($"{nameSides[i]}: {sizeSides[i]}"); // Записывает в цикле значение сторон фигуры
                }
                wr.WriteLine("==========");
            }
            return id; //Возвращает ID, чтобы потом можно было сразу распечатать
        }
        // Вывод из файла информации
        public void Print(string path, string by, string IDorType)
        {
            List<string> data = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    data.Add(line); // Добавление из файла в Лист всю информацию
                }
            }
            
            using (StreamReader rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    string[] words = line.Split(": "); // Разбиение на ключи и значение
                    switch (by)
                    {
                        case "By ID": // Ищем по ID
                            if (words[0] == "ID")
                            {
                                int ID = int.Parse(words[1]);
                                int searchByID = int.Parse(IDorType);
                                if (ID == searchByID)
                                {
                                    int indID = 0;
                                    for (int i = 0; i < data.Count; i++)
                                    {
                                        string[] splWords = data[i].Split(": ");
                                        if (data[i] == "==========") continue;
                                        if (IDorType == splWords[1] && splWords[0] == "ID") // Находим тот ID который мы искали
                                        {
                                            indID = i; // В случае нахождения, записываем и завершаем функцию
                                            break;
                                        }
                                    }
                                    string[] typeName = data[indID + 1].Split(": "); // Следующей строкой ищем тип фигуры с ID фигуры
                                    List<double> infSide = new List<double>();
                                    int ind = indID + 2; // Просмотр сразу к значениям фигуры
                                    switch (typeName[1])
                                    {
                                        case "Trinagle":
                                            while(true)
                                            {
                                                string[] sides = data[ind].Split(": "); 
                                                infSide.Add(double.Parse(sides[1])); // Добавляем в лист информацию
                                                if (data[ind + 1] == "==========") break; // Если следующая строка закончиться то цикл прекращается
                                                ind++;
                                            }
                                            Trinagle trinagle = new Trinagle(infSide[0], infSide[1], infSide[2]);
                                            trinagle.GetFigure(searchByID); // Вывод самой фигуры
                                            break;
                                        case "Square":
                                            while (true)
                                            {
                                                string[] sides = data[ind].Split(": ");
                                                infSide.Add(double.Parse(sides[1]));
                                                if (data[ind + 1] == "==========") break;
                                                ind++;
                                            }
                                            Square square = new Square(infSide[0]);
                                            square.GetFigure(searchByID);
                                            break;
                                        case "Rectangle":
                                            while (true)
                                            {
                                                string[] sides = data[ind].Split(": ");
                                                infSide.Add(double.Parse(sides[1]));
                                                if (data[ind + 1] == "==========") break;
                                                ind++;
                                            }
                                            Rectangle rectangle = new Rectangle(infSide[0], infSide[1]);
                                            rectangle.GetFigure(searchByID);
                                            break;
                                        case "Round":
                                            while (true)
                                            {
                                                string[] sides = data[ind].Split(": ");
                                                infSide.Add(double.Parse(sides[1]));
                                                if (data[ind + 1] == "==========") break;
                                                ind++;
                                            }
                                            Round round = new Round(infSide[0]);
                                            round.GetFigure(searchByID);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            break;
                        case "Type": // Поиск по типу фигуры
                            if (words[0] == "Type")
                            {
                                if (words[1] == IDorType)
                                {
                                    int id = 0;
                                    int countFigure = 0;
                                    while ((line = rd.ReadLine()) != null)
                                    {
                                        string[] keyItem = line.Split(": ");
                                        if (line == "==========") continue;
                                        else if (keyItem[0] == "ID") id = int.Parse(keyItem[1]);
                                        else if (keyItem[0] == "Type" && keyItem[1] == IDorType)
                                        {
                                            line = rd.ReadLine();
                                            keyItem = line.Split(": ");
                                            switch (IDorType)
                                            {
                                                case "Square":
                                                    double size = double.Parse(keyItem[1]);
                                                    Square square = new Square(size);
                                                    square.GetFigure(id);
                                                    countFigure++;
                                                    break;
                                                case "Rectangle":
                                                    double sizeHz = double.Parse(keyItem[1]);
                                                    line = rd.ReadLine();
                                                    keyItem = line.Split(": ");
                                                    double sizeVc = double.Parse(keyItem[1]);
                                                    Rectangle rectangle = new Rectangle(sizeHz, sizeVc);
                                                    rectangle.GetFigure(id);
                                                    countFigure++;
                                                    break;
                                                case "Trinagle":
                                                    double sizeR = double.Parse(keyItem[1]);
                                                    line = rd.ReadLine();
                                                    keyItem = line.Split(": ");
                                                    double sizeL = double.Parse(keyItem[1]);
                                                    line = rd.ReadLine();
                                                    keyItem = line.Split(": ");
                                                    double sizeB = double.Parse(keyItem[1]);
                                                    Trinagle trinagle = new Trinagle(sizeR, sizeL, sizeB);
                                                    trinagle.GetFigure(id);
                                                    countFigure++;
                                                    break;
                                                case "Round":
                                                    double radius = double.Parse(keyItem[1]);
                                                    Round round = new Round(radius);
                                                    round.GetFigure(id);
                                                    countFigure++;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                    WriteLine($"Count {IDorType}'s: {countFigure}"); 
                                }
                            }
                            break;
                        case "All": // Вывод всех фигур
                            int Id = 0;
                            string type = "";
                            int[] countFigures = new int[4];
                            while((line = rd.ReadLine()) != null)
                            {
                                string[] keyItem = line.Split(": ");
                                if (line == "==========") continue; // Чтобы не было вызова ошибки, ставим такую затычку
                                else if (keyItem[0] == "ID") Id = int.Parse(keyItem[1]); // Записываем каждый раз ID
                                else if (keyItem[0] == "Type") type = keyItem[1]; // Так же и тип фигуры
                                else if (line != "==========")
                                {
                                    switch (type)
                                    {
                                        case "Square":
                                            double size = double.Parse(keyItem[1]);
                                            Square square = new Square(size);
                                            square.GetFigure(Id);
                                            countFigures[0]++;
                                            break;
                                        case "Rectangle":
                                            double sizeHz = double.Parse(keyItem[1]);
                                            line = rd.ReadLine(); // Переход на следующую строку
                                            keyItem = line.Split(": ");
                                            double sizeVc = double.Parse(keyItem[1]);
                                            Rectangle rectangle = new Rectangle(sizeHz, sizeVc);
                                            rectangle.GetFigure(Id);
                                            countFigures[1]++;
                                            break;
                                        case "Trinagle":
                                            double sizeR = double.Parse(keyItem[1]);
                                            line = rd.ReadLine();
                                            keyItem = line.Split(": ");
                                            double sizeL = double.Parse(keyItem[1]);
                                            line = rd.ReadLine();
                                            keyItem = line.Split(": ");
                                            double sizeB = double.Parse(keyItem[1]);
                                            Trinagle trinagle = new Trinagle(sizeR, sizeL, sizeB);
                                            trinagle.GetFigure(Id);
                                            countFigures[2]++;
                                            break;
                                        case "Round":
                                            double radius = double.Parse(keyItem[1]);
                                            Round round = new Round(radius);
                                            round.GetFigure(Id);
                                            countFigures[3]++;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            WriteLine($"Кол-во квадратов: {countFigures[0]};\n"
                                    + $"Кол-во прямоугольников: {countFigures[1]};\n"
                                    + $"Кол-во треугольников: {countFigures[2]};\n"
                                    + $"Кол-во кругов: {countFigures[3]};");
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
                    int next = i;
                    while (data[i] != "==========")
                    {
                        data.RemoveAt(next);
                        
                    }
                    for (int j = 0; j < nameKey.Length; j++)
                    {
                        data.Insert(i, $"{nameKey[j]}: {newSizeSides[j]}");
                    }
                    data.Insert(i, $"Type: {type}");
                    data.Insert(i, $"ID: {ID}");
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
            Write("Loading");
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
            Write("Loading completed!");
            Thread.Sleep(1500);
            do
            {
                Clear();
                string[] namedAllSize = { "LS", "RS", "BS", "HZ", "VC", "AS", "R" }; // Запись в начало укороченное название всех фигур 
                WriteLine("\t\tМеню\n" + "1\t| Создание новой фигуры\t\t |\n" + "2\t| Просмотр текущих фигур\t |\n" + "3\t| Обновление данных списка фигур |\n" + "4\t| Выход из цикла\t\t |\n");
                Write("Выбрать из этого списка: ");
                string choise = ReadLine();
                switch (choise)
                {
                    case "1": // Создание фигуры
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
                                case "1": // Создание Треугольника
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
                                        catch (Exception) // Если введена строка, то выдаёт ошибку и возвращает заново переписывать
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
                                case "2": // Создание квадрата
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
                                        catch (Exception e)
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
                                case "3": // Создание Прямоугольника
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
                                        catch (Exception e)
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
                                        else if (vert == goriz) // Если равны стороны, то это не прямоугольник, а квадрат
                                        {
                                            WriteLine();
                                            Log("Warning");
                                            Write("Размер по горизонтали и вертикале равны. Вы бы хотели его преобразовать в квадрат?(Да/Нет): ");
                                            string isSquare = ReadLine();
                                            switch (isSquare) // Выбор пользователя "хочет ли он квадрат - или же прямоугольник"
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
                                        else // Если всё нормально, то пользователь получает прямоугольник
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
                                case "4": // Создание круга
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
                                        catch (Exception e)
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
                                case "5": // Возвращение назад
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
                    case "2": // Вывод фигур по...
                        isCreateWork = true;
                        do
                        {
                            Clear();
                            WriteLine("1) По ID\n" + "2) По типам(работает с багами)\n" + "3) Все\n" + "4) Назад");
                            Log("");
                            Write("Выберите как вы хотите выбрать: ");
                            string choiseType = ReadLine();
                            switch (choiseType)
                            {
                                case "1": // ..ID
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
                                case "2": // ..типам
                                    Clear();
                                    Log("");
                                    Write("Введите тип на английском (Round, Square, Rectangle, Trinagle): ");
                                    string type = ReadLine();
                                    WriteInformation witype = new WriteInformation();
                                    witype.Print("figures.txt", "Type", type);
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    break;
                                case "3": // ..все
                                    WriteInformation wii = new WriteInformation();
                                    wii.Print("figures.txt", "All", "");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    break;
                                case "4": // Назад
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
                    case "3": // Обновление какой то фигуры
                        isCreateWork = true;
                        do
                        {
                            Clear();
                            WriteInformation wii = new WriteInformation();
                            wii.Print("figures.txt", "All", ""); // Предоставление пользователю список фигур, которые он может изменить
                            WriteLine();
                            Log("");
                            Write("Введите ID фигуры которую вы бы хотели изменить: ");
                            int id = int.Parse(ReadLine());
                            WriteLine();
                            Clear();
                            Log("");
                            Write("Введите тип фигуры на который вы бы хотели поменять(по русски): ");
                            string typeName = ReadLine();
                            switch (typeName)
                            {
                                case "Треугольник":
                                    typeName = "Trinagle";
                                    double[] sizesTrinagle = new double[3];
                                    string[] nameKeyTrinagle = { namedAllSize[2], namedAllSize[1], namedAllSize[0] }; // Выводим всё в обратном порядке, как и с записью
                                    WriteLine();
                                    Log("");
                                    Write("Введите левую сторону: ");
                                    sizesTrinagle[2] = double.Parse(ReadLine());
                                    WriteLine();
                                    Log("");
                                    Write("Введите правую сторону: ");
                                    sizesTrinagle[1] = double.Parse(ReadLine());
                                    WriteLine();
                                    Log("");
                                    Write("Введите нижнюю сторону: ");
                                    sizesTrinagle[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesTrinagle, nameKeyTrinagle);
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
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
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    isCreateWork = false;
                                    break;
                                case "Прямоугольник":
                                    typeName = "Rectangle";
                                    double[] sizesRectangle = new double[2];
                                    string[] nameKeyRectangle = { namedAllSize[4], namedAllSize[3] };
                                    WriteLine();
                                    Log("");
                                    Write("Введите размер по горизонтали: ");
                                    sizesRectangle[1] = double.Parse(ReadLine());
                                    WriteLine();
                                    Log("");
                                    Write("Введите размер по вертикали: ");
                                    sizesRectangle[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesRectangle, nameKeyRectangle);
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
                                    isCreateWork = false;
                                    break;
                                case "Круг":
                                    typeName = "Round";
                                    double[] sizesRound = new double[1];
                                    string[] nameKeyRound = { namedAllSize[6] };
                                    WriteLine();
                                    Log("");
                                    Write("Введите окружность: ");
                                    sizesRound[0] = double.Parse(ReadLine());
                                    wii.Update("figures.txt", id, typeName, sizesRound, nameKeyRound);
                                    wii.Print("figures.txt", "By ID", $"{id}");
                                    isCreateWork = false;
                                    WriteLine();
                                    Log("Succses");
                                    Write("Нажмите чтобы продолжить: ");
                                    ReadKey();
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
                    case "4": // Выход из меню
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
            Write("Хотите завершить программу(Close/or any symbol), или вернуться назад(Back)?: "); // Завершение работы, или начать сначало
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
            // Вывод однотипной ошибки в функцию т.к. она встречается довольно часто
            WriteLine("\n");
            Log("Error");
            Write("Вы ввели НЕ числовое значение!, Попробуйте снова\n\n");
            Log("Error");
            Write("Нажмите для продолжения любую клавишу: ");
            ReadKey();
        }
        static void Log(string type)
        {
            // Логи информации с временем и датой их отправки
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
