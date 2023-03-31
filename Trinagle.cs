using System;
using static System.Console;

namespace Test_task_by_Khromakov_Maxim
{
    class Trinagle : Figure
    {
        private double leftSide { get; set; } // ����� ������� ������������
        private double rightSide { get; set; } // ������ ������� ������������
        private double bottomSide { get; set; } // ��������� ������������
        public Trinagle(double leftSide, double rightSide, double bottomSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.bottomSide = bottomSide;
        }
        public override void GetFigure(int id)
        {
            WriteLine("===============================\n"
                + $"ID ������: {id}\n"
                + "������: �����������\n"
                + "\t������� ������ ������\n"
                + $"����� �������: {leftSide}\n"
                + $"������ �������: {rightSide}\n"
                + $"������ �������: {bottomSide}\n"
                + $"��� ������������: {TypeTrinagle()}\n"
                + $"��������: {Math.Round(Perimeter(), 2)}\n"
                + $"�������: {Math.Round(Area(), 2)}\n"
                + "===============================");
        }
        // ��������� ������� ������������
        public override double Area()
        {
            double halfPer = Perimeter() * 0.5;
            double result = Math.Sqrt(halfPer * (halfPer - leftSide) * (halfPer - rightSide) * (halfPer - bottomSide));
            return result;
        }
        public override double Perimeter() => leftSide + rightSide + bottomSide; // ��������� ��������� ������������
        public string TypeTrinagle()
        {
            string message;
            if ((leftSide == rightSide) && (rightSide == bottomSide) && (leftSide == bottomSide)) message = "��������������"; // ���� ��� ������� �����, �� ����� ������
            else if ((leftSide == rightSide) && (leftSide != bottomSide) && (rightSide != bottomSide)) message = "��������������"; // ���� ����� ������ ����� � ������ �����, �� ����� ������
            else message = "��������������"; // ����� ������� ������
            return message;
        }
    }
}