using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Round : Figure
    {
        private double Radius { get; set; } // ������ �����
        public Round(double radius) => this.Radius = radius;

        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: ����\n"
                + $"������ �����: {Radius}\n"
                + $"��������: {Math.Round(Perimeter(), 2)}\n"
                + $"�������: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => Math.PI * Math.Pow(Radius, 2); // ��������� ������� �����
        public override double Perimeter() => 2 * Math.PI * Radius; // ��������� ��������� �����
    }
}