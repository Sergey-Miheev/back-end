namespace Calculator
{
    class Calculator
    {
        public static void WriteHeader()
        {
            Console.WriteLine("The calculator supports addition(+), substraction(-), multiplication(*) and division(/) operations");
            Console.WriteLine("Separate real numbers with a comma");
        }
        public static void SelectNumber(ref string? inputString, ref string? count, ref int index)
        {
            if (inputString[index] == '-')
            {
                index++;
                count += '-';
            }
            for (int i = index; i < inputString.Length; i++)
            {
                if ((inputString[i] < '0' || inputString[i] > '9') && inputString[i] != ',')
                {
                    index = i + 1;
                    break;
                }
                count += inputString[i];
            }
        }
        public static void ConverToFloat(ref string? countInString, ref float convertedCount)
        {
            while (!float.TryParse(countInString, out convertedCount))
            {
                countInString = "";
                Console.WriteLine("You are entered a wrong count. Please, inter a correct count: ");
                countInString = Console.ReadLine();
            }
        }
        public static void DoOperation(ref float firstCount, ref float secondCount, ref char operation)
        {
            switch (operation)
            {
                case '+':
                    {
                        Console.WriteLine($"{firstCount} + {secondCount} = " + (firstCount + secondCount));
                        break;
                    }

                case '-':
                    {
                        Console.WriteLine($"{firstCount} - {secondCount} = " + (firstCount - secondCount));
                        break;
                    }

                case '*':
                    {
                        Console.WriteLine($"{firstCount} * {secondCount} = " + (firstCount * secondCount));
                        break;
                    }

                case '/':
                    {
                        if (secondCount == 0)
                        {
                            Console.WriteLine("Division by zero");
                            break;
                        }
                        Console.WriteLine($"{firstCount} / {secondCount} = " + (firstCount / secondCount));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("There is no such operation");
                        break;
                    }
            }
        }
        public static void WriteFooter(ref string exit)
        {
            Console.WriteLine("Do you want exit? (Yes/No)");
            exit = Console.ReadLine();
            // if user entered word in the wrong format
            exit = exit.ToLower();
        }
    }
    class Controller
    {
        private static void ReadExpression(ref string expression)
        {
            while (expression == "")
            {
                Console.WriteLine("Enter the expression you want to calculate in format: <1-st count> <operation> <2-nd count>");
                expression = Console.ReadLine();
            }
            expression = expression.Replace(" ", "");
        }
        public static void Start()
        {
            Calculator.WriteHeader();
            string exit = "no";
            while (exit == "no")
            {
                string? expression = "";
                ReadExpression(ref expression);
                string? count = "";
                int index = 0;

                // Reading the first count
                Calculator.SelectNumber(ref expression, ref count, ref index);

                // convert a firstCount to float
                float firstCount = 0;
                Calculator.ConverToFloat(ref count, ref firstCount);

                char operation = expression[index - 1];

                // Reading the second count
                count = "";
                Calculator.SelectNumber(ref expression, ref count, ref index);

                // convert a secondCount to float
                float secondCount = 0;
                Calculator.ConverToFloat(ref count, ref secondCount);

                Calculator.DoOperation(ref firstCount, ref secondCount, ref operation);

                Calculator.WriteFooter(ref exit);
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Controller.Start();
        }
    }
}
