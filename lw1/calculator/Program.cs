using System;


namespace Calculator
{
    class Program
    {
        static void Main()
        {
            string exit = "no";
            Console.WriteLine("The calculator supports addition(+), substraction(-), multiplication(*) and division(/) operations");
            Console.WriteLine("Enter real numbers separated by commas");
            while (exit == "no")
            {
                string expression = "";
                while (expression == "")
                {
                    Console.WriteLine("Enter the expression you want to calculate in format: <1-st count> <operatoin> <2-nd count>");
                    expression = Console.ReadLine();
                }
                expression = expression.Replace(" ", "");
                string? count = "";
                int index = 0;
                // Reading the first count
                for (int i = 0; i < expression.Length; i++)
                {
                    if ((expression[i] < '0' || expression[i] > '9') && expression[i] != ',')
                    {
                        index = i;
                        break;
                    }
                    count += expression[i];
                }
                // convert to float
                float firstCount = 0;
                if (count.Length != 0)
                {
                    firstCount = float.Parse(count);
                }
                // Reading the second count
                count = "";
                for (int i = index + 1; i < expression.Length; i++)
                {
                    if ((expression[i] < '0' || expression[i] > '9') && expression[i] != ',')
                    {
                        index = i;
                        break;
                    }
                    count += expression[i];
                }
                // convert to float
                float secondCount = 0;
                if (count.Length != 0)
                {
                    secondCount = float.Parse(count);
                }

                switch (expression[index])
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
                Console.WriteLine("Do you want exit? (Yes/No)");
                exit = Console.ReadLine();
                // if user entered word in the wrong format
                exit = exit.ToLower();
            }
        }
    }
}

