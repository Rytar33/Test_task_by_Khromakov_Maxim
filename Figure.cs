namespace Test_task_by_Khromakov_Maxim
{
    /// <summary> ��������� ������ </summary>
    interface IFigure
    {
        /// <summary> �����, ��������� �������� �� ������� ������ � ������� </summary>
        /// <param name="ID">�������������� ������</param>
        public void PrintFigure(int ID);
        /// <summary> �����, ��������� �������� �� �������� ������� ������ </summary>
        public double GetArea();
        /// <summary> �����, ��������� �������� �� �������� �������� ������ </summary>
        public double GetPerimeter();
    }
}