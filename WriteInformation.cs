using static System.Console;
using System.IO;
using System.Collections.Generic;

namespace Test_task_by_Khromakov_Maxim 
{
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
                                    for (int ind = indID + 2; data[ind] != "=========="; ind++)
                                    {
                                        string[] sides = data[ind].Split(": ");
                                        infSide.Add(double.Parse(sides[1])); // Добавляем в лист информацию
                                        if (data[ind + 1] == "==========")
                                        {
                                            //var result = typeName[1] switch
                                            //{
                                            //    "Trinagle" => new Trinagle(infSide[0], infSide[1], infSide[2]).PrintFigure(searchByID),
                                            //    "Square" => new Square(infSide[0]).PrintFigure(searchByID),
                                            //    "Rectangle" => new Rectangle(infSide[0], infSide[1]).PrintFigure(searchByID),
                                            //    "Round" => new Round(infSide[0]).PrintFigure(searchByID),
                                            //    _ => throw new System.Exception("Да")
                                            //};
                                            switch (typeName[1])
                                            {
                                                case "Trinagle":
                                                    new Trinagle(infSide[0], infSide[1], infSide[2])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                case "Square":
                                                    new Square(infSide[0])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                case "Rectangle":
                                                    new Rectangle(infSide[0], infSide[1])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                case "Round":
                                                    new Round(infSide[0])
                                                        .PrintFigure(searchByID);
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
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
                                            List<double> sides = new List<double>();
                                            for (int i = 0; line != "=========="; i++)
                                            {
                                                if (i == 0)
                                                {
                                                    sides.Add(double.Parse(keyItem[1]));
                                                    continue;
                                                }
                                                line = rd.ReadLine();
                                                keyItem = line.Split(": ");
                                                sides.Add(double.Parse(keyItem[1]));
                                            }
                                            switch (IDorType)
                                            {
                                                case "Square":
                                                    new Square(sides[0])
                                                        .PrintFigure(id);
                                                    break;
                                                case "Rectangle":
                                                    new Rectangle(sides[0], sides[1])
                                                        .PrintFigure(id);
                                                    break;
                                                case "Trinagle":
                                                    new Trinagle(sides[0], sides[1], sides[2])
                                                        .PrintFigure(id);
                                                    break;
                                                case "Round":
                                                    new Round(sides[0])
                                                        .PrintFigure(id);
                                                    break;
                                                default:
                                                    countFigure--;
                                                    break;
                                            }
                                            countFigure++;
                                        }
                                    }
                                    WriteLine($"Count {IDorType}'s: {countFigure}");
                                }
                            }
                            break;
                        default:
                            WriteLine("Введён неверный тип!");
                            ReadKey();
                            break;
                    }
                }
            }
        }
        public void Print(string path, string by) // Перегрузка метода вывода, который выводит всё из файла
        {
            using (StreamReader rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    switch (by)
                    {
                        case "All": // Вывод всего
                            int Id = 0;
                            string type = "";
                            int[] countFigures = new int[4];
                            while ((line = rd.ReadLine()) != null)
                            {
                                string[] keyItem = line.Split(": ");
                                if (line == "==========") continue; // Чтобы не было вызова ошибки, ставим такую затычку
                                else if (keyItem[0] == "ID") Id = int.Parse(keyItem[1]); // Записываем каждый раз ID
                                else if (keyItem[0] == "Type") type = keyItem[1]; // Так же и тип фигуры
                                else if (line != "==========")
                                {
                                    List<double> sides = new List<double>();
                                    for (int i = 0; line != "=========="; i++)
                                    {
                                        if (i == 0)
                                        {
                                            sides.Add(double.Parse(keyItem[1]));
                                            continue;
                                        }
                                        line = rd.ReadLine();
                                        keyItem = line.Split(": ");
                                        sides.Add(double.Parse(keyItem[1]));
                                    }
                                    switch (type)
                                    {
                                        case "Square":
                                            new Square(sides[0])
                                                .PrintFigure(Id);
                                            countFigures[0]++;
                                            break;
                                        case "Rectangle":
                                            new Rectangle(sides[0], sides[1])
                                                .PrintFigure(Id);
                                            countFigures[1]++;
                                            break;
                                        case "Trinagle":
                                            new Trinagle(sides[0], sides[1], sides[2])
                                                .PrintFigure(Id);
                                            countFigures[2]++;
                                            break;
                                        case "Round":
                                            new Round(sides[0])
                                                .PrintFigure(Id);
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
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
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
            using (StreamWriter wr = new StreamWriter(path, false))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    wr.WriteLine(data[i]);
                }
            }
        }
    }
}