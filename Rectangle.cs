using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Rectangle : Figure
    {
        private double horizontally { get; set; } // �������������� �������
        private double vertically { get; set; } // ������������ �������
        public Rectangle(double horizontally, double vertically)
        {
            this.horizontally = horizontally;
            this.vertically = vertically;
        }
        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: �������������\n"
                + "\t������� ������\n"
                + $"�� �����������: {horizontally}\n"
                + $"�� ���������: {vertically}\n"
                + $"��������: {Math.Round(Perimeter(), 2)}\n"
                + $"�������: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        public override double Area() => horizontally * vertically; // ��������� ������� ��������������
        public override double Perimeter() => (2 * horizontally) + (2 * vertically); // ��������� ��������� ��������������

    }
}