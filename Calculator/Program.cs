using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            bool stop = false;
            string input;
            ulong firstNumber, secondNumber, thirdNumber;
            byte operation;
            ConsoleKey keyPressed;
            Console.Title = "Long calculator - Guilherme Fadário";
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Addition  +          (1)");
                    Console.WriteLine("Subtract  -          (2)");
                    Console.WriteLine("Multiply  *          (3)");
                    Console.WriteLine("Divide  /            (4)");
                    Console.WriteLine("Rest of division  %  (5)");
                    Console.Write("Press a key[1,5] to choose an operation: ");
                    keyPressed = Console.ReadKey(true).Key;
                } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out operation) || !inRange(1, 5, operation)); // keyPressed can only be between 1 and 5 ; D1 -> 1
                do
                {
                    Console.Clear();
                    Console.Write("Choose the first number: ");
                    input = Console.ReadLine();
                } while (!ulong.TryParse(input, out firstNumber)); // input can't have letters, be null or empty and must fit into a ulong
                do
                {
                    Console.Clear();
                    Console.WriteLine($"{firstNumber} {getOperation(operation)} ?");
                    Console.Write("Choose the second number: ");
                    input = Console.ReadLine();
                } while (!ulong.TryParse(input, out secondNumber)); // input can't have letters, be null or empty and must fit into a ulong
                Console.WriteLine($"The output of ({firstNumber} {getOperation(operation)} {secondNumber}) is: {Calculate(getOperation(operation), firstNumber, secondNumber)}");
                Console.WriteLine("Press TAB to continue, ENTER to restart or ESCAPE to close");
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.Escape) stop = true; // close application
                else if(keyPressed == ConsoleKey.Tab && getOperation(operation) != "%")
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"{Calculate(getOperation(operation), firstNumber, secondNumber)} {getOperation(operation)} ?");
                        Console.Write("Choose the third number: ");
                        input = Console.ReadLine();
                    } while (!ulong.TryParse(input, out thirdNumber)); // input can't have letters, be null or empty and must fit into a ulong
                    Console.WriteLine($"The output of ({Calculate(getOperation(operation), firstNumber, secondNumber)} {getOperation(operation)} {thirdNumber}) is: {Calculate(getOperation(operation), firstNumber, secondNumber, thirdNumber)}");
                    Console.WriteLine("Press ENTER to restart or ESCAPE to close");
                    keyPressed = Console.ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.Escape) stop = true; // close application
                }
            } while (!stop);
        }
        static bool inRange(int min, int max, int i)
        {
            if (i >= min && i <= max) return true;
            else return false;
        }
        static String getOperation(byte num)
        {
            switch (num)
            {
                case 1: return "+";
                case 2: return "-";
                case 3: return "*";
                case 4: return "/";
                case 5: return "%";
            }return null; // null path
        }
        static String Calculate(String operation, ulong firstNumber, ulong secondNumber)
        {
            switch (operation)
            {
                case "+": return Convert.ToString(firstNumber + secondNumber);
                case "-": return Convert.ToString(firstNumber - secondNumber);
                case "*": return Convert.ToString(firstNumber * secondNumber);
                case "/":
                    if (secondNumber != 0) return Convert.ToString(firstNumber / secondNumber);
                    else return "impossible"; // impossible operation
                case "%":
                    if (secondNumber != 0) return Convert.ToString(firstNumber % secondNumber);
                    else return "impossible"; // impossible operation
            }return null; // null path
        }
        static String Calculate(String operation, ulong firstNumber, ulong secondNumber, ulong thirdNumber)
        {
            switch (operation)
            {
                case "+": return Convert.ToString((firstNumber + secondNumber) + thirdNumber);
                case "-": return Convert.ToString((firstNumber - secondNumber) - thirdNumber);
                case "*": return Convert.ToString((firstNumber * secondNumber) * thirdNumber);
                case "/":
                    if (secondNumber != 0) return Convert.ToString((firstNumber / secondNumber) / thirdNumber);
                    else return "impossible"; // impossible operation
            }
            return null; // null path
        }
    }
}//by Gui1herme#8721
