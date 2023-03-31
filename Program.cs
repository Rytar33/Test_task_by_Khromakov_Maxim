using System;
using System.Threading;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
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
                                case "3": // Все
                                    WriteInformation wii = new WriteInformation();
                                    wii.Print("figures.txt", "All");
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
                            wii.Print("figures.txt", "All"); // Предоставление пользователю список фигур, которые он может изменить
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