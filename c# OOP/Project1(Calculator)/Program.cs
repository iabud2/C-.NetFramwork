using System;


namespace Project1_Calculator_
{

    class clsCalculator
    {
        private string _Operation = "";
        private int _Value = 0;
        private int _OperationValue = 0;

        public void Add(int value)
        {
            _Value += value;
            _Operation = "Adding";
            _OperationValue = value;
        }

        public void Subtract(int value)
        {
            _Value -= value;
            _Operation = "Subtracting";
            _OperationValue = value;
        }

        public void Divide(int value)
        {
            _Operation = "Dividing";
            _OperationValue = value;
            if(value == 0)
            {
                return;
            }
            _Value /= value;
        }

        public void Multiply(int value) 
        {
            _Operation = "Multiblying";
            _OperationValue = value;
            _Value *= value;
        }

        public void Clear()
        {
            _Value = 0;
            _Operation = "Clear";
            _OperationValue = 0;
        }

        public void PrintResult()
        {
            if(_Operation == "Clear")
            {
                Console.WriteLine($"Result After {_Operation} is : {_Value}\n");
                return;
            }
            Console.WriteLine($"Result After {_Operation} '{_OperationValue}' is : {_Value}\n");

        }

        ~clsCalculator()
        {
            Console.WriteLine("This is Distructor");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            clsCalculator Calculator1 = new clsCalculator();
            Calculator1.Add(10);
            Calculator1.PrintResult();

            Calculator1.Add(100);
            Calculator1.PrintResult();
            
            Calculator1.Subtract(10);
            Calculator1.PrintResult();

            Calculator1.Divide(0);
            Calculator1.PrintResult();

            Calculator1.Divide(2);
            Calculator1.PrintResult();

            Calculator1.Multiply(2);
            Calculator1.PrintResult();

            Calculator1.Clear();
            Calculator1.PrintResult();

            Console.ReadKey();
        }
    }
}
