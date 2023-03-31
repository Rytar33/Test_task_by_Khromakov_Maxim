using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Square : Figure
    {
        private double SizeSides { get; set; } // ������ ���� 4-� ������ ��������
        public Square(double sizeSides) => this.SizeSides = sizeSides;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: �������\n"
                + $"������ ������ �������: {SizeSides}\n"
                + $"��������: {Math.Round(Perimeter(), 2)}\n"
                + $"�������: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => Math.Pow(SizeSides, 2); // ��������� ������� ��������
        public override double Perimeter() => SizeSides * 4; // ��������� ��������� ��������

    }
}