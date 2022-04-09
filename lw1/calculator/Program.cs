using System;


namespace Calculator
{
    class Program
    {
        static void SelectNumber(ref string? inputString, ref string? count, ref int index)
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

        static void ConverToFloat(ref string? countInString, ref float convertedCount)
        {
            while (!float.TryParse(countInString, out convertedCount))
            {
                countInString = "";
                Console.WriteLine("You are entered a wrong count. Please, inter a correct count: ");
                countInString = Console.ReadLine();
            }
        }

        static void DoOperation(ref float firstCount, ref float secondCount, ref char operation)
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

        static void Main()
        {
            string exit = "no";
            Console.WriteLine("The calculator supports addition(+), substraction(-), multiplication(*) and division(/) operations");
            Console.WriteLine("Enter real numbers separated by commas");
            while (exit == "no")
            {
                string? expression = "";
                while (expression == "")
                {
                    Console.WriteLine("Enter the expression you want to calculate in format: <1-st count> <operatoin> <2-nd count>");
                    expression = Console.ReadLine();
                }
                expression = expression.Replace(" ", "");
                string? count = "";
                int index = 0;

                // Reading the first count
                SelectNumber(ref expression,ref count, ref index);

                // convert a firstCount to float
                float firstCount = 0;
                ConverToFloat(ref count, ref firstCount);

                char operation = expression[index - 1];

                // Reading the second count
                count = "";
                SelectNumber(ref expression, ref count, ref index);

                // convert a secondCount to float
                float secondCount = 0;
                ConverToFloat(ref count, ref secondCount);

                DoOperation(ref firstCount, ref secondCount, ref operation);

                Console.WriteLine("Do you want exit? (Yes/No)");
                exit = Console.ReadLine();
                // if user entered word in the wrong format
                exit = exit.ToLower();
            }
        }
    }
}

