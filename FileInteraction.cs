using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;

namespace Test_task_by_Khromakov_Maxim
{
    /// <summary>
    /// Класс, который взаимодействует с файловой системой приложения (обновляя, добавляя и выводя в консоль)
    /// </summary>
    class FileInteraction
    {
        /// <summary>
        /// Ссылка на файл
        /// </summary>
        private string File { get; set; }
        /// <summary>
        /// Конструктор класса File Interaction
        /// </summary>
        /// <param name="file">Ссылка на файл с которым происходит взаимодействие</param>
        public FileInteraction(string file) => this.File = file;
        /// <summary>
        /// Создание новой фигуры в конец файла
        /// </summary>
        /// <param name="path">Название файла с его форматом</param>
        /// <param name="typeFigure">Тип фигуры</param>
        /// <param name="sizeSides">Значение размеров длины каждой стороны фигуры в массиве</param>
        /// <param name="nameSides">Сокращенное название каждой сторон фигур в массиве</param>
        /// <returns>Возвращает новый индентификатор, чтобы можно было его сразу вывести в консоль после создания</returns>
        public int PutEnd(string typeFigure, double[] sizeSides, string[] nameSides)
        {
            int id = 0;
            using (StreamReader rd = new StreamReader(File)) // Чтение файла
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
            using (StreamWriter wr = new StreamWriter(File, true)) // Запись в файл
            {
                id++; // Инкрименция ID
                wr.WriteLine("==========\n"
                    + $"ID: {id}\n"
                    + $"Type: {typeFigure}");
                for (int i = 0; i < nameSides.Length; i++)
                    wr.WriteLine($"{nameSides[i]}: {sizeSides[i]}"); // Записывает в цикле значение сторон фигуры
                wr.WriteLine("==========");
            }
            return id;
        }
        /// <summary>
        /// Вывод информации из файла в консоль
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="by">По какому типу будет вывод (По ID, Типам, Все)</param>
        /// <param name="IDorType">Ввод в текстовом формате ID или название типа фигуры</param>
        public void Print(string by, string IDorType = "")
        {
            List<string> data = new List<string>();
            WholeFile(data);
            using StreamReader rd = new(File);
            string line;
            while ((line = rd.ReadLine()) != null)
            {
                string[] words = line.Split(": "); // Разбиение на ключи и значение
                switch (by)
                {
                    case "By ID": // Ищем по ID
                        if (words[0] == "ID" && int.Parse(words[1]) == int.Parse(IDorType)) PrintOneFigure(int.Parse(IDorType), data);
                        break;
                    case "Type": // Поиск по типу фигуры
                        if (words[0] == "Type" && words[1] == IDorType) PrintList(rd, line, by, IDorType);
                        break;
                    case "All": // Вывод всего
                        PrintList(rd, line, by);
                        break;
                    default:
                        WriteLine("Введён неверный тип!");
                        break;
                }
            }
        }
        /// <summary>
        /// Обновление по ID информации о фигуре в файле
        /// </summary>
        /// <param name="path">Название файла</param>
        /// <param name="ID">Инднентификатор фигуры</param>
        /// <param name="type">Тип фигуры</param>
        /// <param name="newSizeSides">Новые размеры сторон фигуры</param>
        /// <param name="nameKey">Укороченное название сторон фигуры</param>
        public void Update(int ID, string type, List<double> newSizeSides, string[] nameKey)
        {
            List<string> data = new List<string>();
            WholeFile(data);
            for (int i = 0; i < data.Count; i++)
            {
                string[] keyInf = data[i].Split(": ");
                if (keyInf[0] == "ID" && int.Parse(keyInf[1]) == ID)
                {
                    int next = i;
                    while (data[i] != "==========") data.RemoveAt(next);

                    for (int j = nameKey.Length - 1; j >= 0; j--)
                        data.Insert(i, $"{nameKey[j]}: {newSizeSides[j]}");

                    data.Insert(i, $"Type: {type}");
                    data.Insert(i, $"ID: {ID}");
                    break;
                }
            }
            using StreamWriter wr = new(File, false);
            for (int i = 0; i < data.Count; i++)
                wr.WriteLine(data[i]);
        }
        /// <summary>
        /// Вывод фигуры в единичном значении
        /// </summary>
        /// <param name="ID">Индентификатор фигуры</param>
        /// <param name="dataFile">Информация в переменной о файле</param>
        private void PrintOneFigure(int ID, List<string> dataFile)
        {
            int indID = 0;
            for (int i = 0; i < dataFile.Count; i++)
            {
                string[] splWords = dataFile[i].Split(": ");
                if (dataFile[i] == "==========") continue;
                if (splWords[0] == "ID" && ID == int.Parse(splWords[1])) // Находим тот ID который мы искали
                {
                    indID = i; // В случае нахождения, записываем и завершаем функцию
                    break;
                }
            }
            string[] typeName = dataFile[indID + 1].Split(": "); // Следующей строкой ищем тип фигуры с ID фигуры
            List<double> infSide = new List<double>();
            for (int ind = indID + 2; dataFile[ind] != "=========="; ind++)
            {
                string[] sides = dataFile[ind].Split(": ");
                infSide.Add(double.Parse(sides[1])); // Добавляем в лист информацию
                if (dataFile[ind + 1] == "==========") PrintFigure(infSide, typeName[1], ID);
            }
        }
        /// <summary>
        /// Вывод фигур в множественном значении
        /// </summary>
        /// <param name="rd">Читаемый файл</param>
        /// <param name="line">Строка на которой находится счётчик файла</param>
        /// <param name="printBy">Вывод по Индентификатору или по Типу</param>
        /// <param name="getType">Необязательный параметр, который при выводе по типу условно должен быть обязательным</param>
        private void PrintList(StreamReader rd, string line, string printBy, string getType = "")
        {
            int Id = 0;
            string type = "";
            int[] countFigures = new int[Enum.GetNames(typeof(Figures)).Length];
            while ((line = rd.ReadLine()) != null) {
                string[] keyItem = line.Split(": ");
                if (line == "==========") continue; // Чтобы не было вызова ошибки, ставим такую затычку
                else if (keyItem[0] == "ID") Id = int.Parse(keyItem[1]); // Записываем каждый раз ID
                else if ((keyItem[0] == "Type" && printBy == "Type") || line != "==========") {
                    if (printBy != "Type" && keyItem[0] == "Type") {
                        type = keyItem[1];
                        continue;
                    }
                    else if (printBy == "Type" && keyItem[1] == getType) {
                        type = keyItem[1];
                        line = NextLine(rd);
                        keyItem = NewKeyLine(line);
                    }
                    else if (printBy == "Type" && keyItem[1] != getType) continue;
                    List<double> sides = new List<double>();
                    for (int i = 0; line != "=========="; i++) {
                        if (i == 0) {
                            sides.Add(double.Parse(keyItem[1]));
                            continue;
                        }
                        line = NextLine(rd);
                        keyItem = NewKeyLine(line);
                        if (line == "==========") break;
                        sides.Add(double.Parse(keyItem[1]));
                    }
                    PrintFigure(sides, type, Id, countFigures);
                }
            }
            PrintCountFigures(printBy, countFigures, type);
        }
        /// <summary>
        /// Переход на следующую строку в файле
        /// </summary>
        /// <param name="rd">Читаемый файл</param>
        /// <returns>Возвращает следующую строку</returns>
        private string NextLine(StreamReader rd) => rd.ReadLine();
        /// <summary>
        /// Раздел новой строки на ключ и значение
        /// </summary>
        /// <param name="line">Строка на которой находится счётчик файла</param>
        /// <returns>Возвращает раздел строки ключа и значения</returns>
        private string[] NewKeyLine(string line) => line.Split(": ");
        /// <summary>
        /// Записывает в переменную файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="data">Лист информации, которая запоминает весь файл в переменную</param>
        /// <returns>Возвращает лист информации в строковом листе</returns>
        public List<string> WholeFile(List<string> data)
        {
            using (StreamReader sr = new StreamReader(File))
            {
                string line;
                while ((line = sr.ReadLine()) is not null) data.Add(line);
                return data;
            }
        }
        /// <summary>
        /// Метод, который проверяет - существует ли введёный индентификатор в файле
        /// </summary>
        /// <param name="ID">Вводимый индентификатор</param>
        /// <returns>Возвращает булевое значение есть ли индентификатор или нет</returns>
        public bool IsIDAtFile(int ID)
        {
            List<string> data = new List<string>();
            data = WholeFile(data);
            foreach (string line in data) {
                string[] splWords = line.Split(": ");
                if (line == "==========") continue;
                if (splWords[0] == "ID" && (ID == int.Parse(splWords[1]))) return true; // Находим тот ID который мы искали и в случае нахождения, записываем и завершаем функцию
            }
            return false;
        }
        /// <summary>
        /// Метод, который проверяет - существует ли введёный тип фигуры в файле
        /// </summary>
        /// <param name="type">Вводимый тип фигуры</param>
        /// <returns>Возвращает булевое значение есть ли тип фигуры или нет</returns>
        public bool IsType(string type) => new List<string>(Enum.GetNames(typeof(Figures))).Contains(type);
        /// <summary>
        /// Вызов класса и метода для вывода в консоль информацию для каждой фигуры
        /// </summary>
        /// <param name="sides">Размер сторон фигуры </param>
        /// <param name="type">Тип фигуры</param>
        /// <param name="ID">Индентификатор фигуры</param>
        /// <param name="countFigure">Необязательный параметр, используется в списке, принимает массив количества фигур, считая каждую фигуру которую найдёт</param>
        private void PrintFigure(List<double> sides, string type, int ID, int[] countFigure = null) 
        {
            IFigure figure = type switch
            {
                "Trinagle" => new Trinagle(sides[0], sides[1], sides[2]),
                "Rectangle" => new Rectangle(sides[0], sides[1]),
                "Square" => new Square(sides[0]),
                "Round" => new Round(sides[0]),
                _ => null
            };
            figure?.PrintFigure(ID);
            if (countFigure is not null) countFigure[(int)Enum.Parse(typeof(Figures), type)]++;
        }
        /// <summary>
        /// Выводит в консоль количество фигур
        /// </summary>
        /// <param name="typeOrAll">Вывод либо по типу фигуры, либо все</param>
        /// <param name="countFigures">Массив чисел количества фигур</param>
        /// <param name="Type">Необязательный параметр, если выводит 1 тип фигуры, то условно обязателен. Принимает тип фигуры</param>
        private void PrintCountFigures(string typeOrAll, int[] countFigures, string Type = "")
        {
            if (typeOrAll == "All") {
                string[] allNameFigures = Enum.GetNames(typeof(Figures));
                foreach (string nameFigure in allNameFigures) 
                {
                    WriteLine($"Count {nameFigure}`s: {countFigures[(int) Enum.Parse(typeof(Figures), nameFigure)]}; ");
                }
            }
            else if (typeOrAll == "Type") WriteLine($"Count {Type}`s: {countFigures[(int) Enum.Parse(typeof(Figures), Type)]}");
        }
    }
}
