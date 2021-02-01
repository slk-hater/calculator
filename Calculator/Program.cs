using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            bool stop = false;
            string input;
            ulong firstNumber, secondNumber;
            byte operation;
            ConsoleKey keyPressed;
            Console.Title = "Integer calculator - Guilherme Fadário";
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - add");
                    Console.WriteLine("2 - subtract");
                    Console.WriteLine("3 - multiply");
                    Console.WriteLine("4 - divide");
                    Console.WriteLine("5 - rest of division");
                    Console.Write("Press a key to choose an operation: ");
                    keyPressed = Console.ReadKey().Key;
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
                Console.Clear();
                Console.WriteLine($"The output of ({firstNumber} {getOperation(operation)} {secondNumber}) is: {Calculate(getOperation(operation), firstNumber, secondNumber)}");
                Console.WriteLine("Press ENTER to restart or ESCAPE to close");
                keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.Escape) stop = true; // close application
            } while (stop != true);
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
    }
}//by Gui1herme#8721
