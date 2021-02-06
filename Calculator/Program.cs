using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
        string input, result;
        byte operation;
        ulong firstNumber, secondNumber;
        ConsoleKey keyPressed;
        Console.Title = "Long calculator - Guilherme Fadário";
        Start:
            do
            {
                Console.Clear();
                Console.WriteLine("Add                   +  (1)");
                Console.WriteLine("Subtract              -  (2)");
                Console.WriteLine("Multiply              *  (3)");
                Console.WriteLine("Divide                /  (4)");
                Console.WriteLine("Rest of division      %  (5)");
                Console.WriteLine("");
                Console.WriteLine("Exit the console         (6)");
                Console.Write("Press a key[1,6] to choose an operation: ");
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed.ToString().Replace("D", null) == "6") goto ExitConsole;
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
            result = Calculate(getOperation(operation), firstNumber, secondNumber);
            goto SecondPhase;
        SecondPhase:
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Previous calculation: {firstNumber} {getOperation(operation)} {secondNumber} = {result}");
                    Console.WriteLine("Add                   +  (1)");
                    Console.WriteLine("Subtract              -  (2)");
                    Console.WriteLine("Multiply              *  (3)");
                    Console.WriteLine("Divide                /  (4)");
                    Console.WriteLine("Rest of division      %  (5)");
                    Console.WriteLine("");
                    Console.WriteLine("Clear the result         (6)");
                    Console.WriteLine("Restart the console      (7)");
                    Console.WriteLine("Exit the console         (8)");
                    Console.Write("Press a key[1,8] to choose an operation: ");
                    keyPressed = Console.ReadKey(true).Key;
                    if (keyPressed.ToString().Replace("D", null) == "6") result = "0";
                    if (keyPressed.ToString().Replace("D", null) == "7") goto Start;
                    if (keyPressed.ToString().Replace("D", null) == "8") goto ExitConsole;
                } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out operation) || !inRange(1, 5, operation)); // keyPressed can only be between 1 and 5 ; D1 -> 1
                do
                {
                    Console.Clear();
                    Console.WriteLine($"{result} {getOperation(operation)} ?");
                    Console.Write("Choose the second number: ");
                    input = Console.ReadLine();
                } while (!ulong.TryParse(input, out secondNumber)); // input can't have letters, be null or empty and must fit into a ulong
                firstNumber = Convert.ToUInt64(result);
                result = Calculate(getOperation(operation), Convert.ToUInt64(result), secondNumber);
            } while (true);
        ExitConsole:
            Console.Beep();
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
        static String Calculate(String operation, ulong num1, ulong num2)
        {
            switch (operation)
            {
                case "+": return Convert.ToString(num1 + num2);
                case "-":
                    if (num1 > num2) return Convert.ToString(num1 - num2);
                    else return "0"; // impossible operation for ulong
                case "*": return Convert.ToString(num1 * num2);
                case "/":
                    if (num2 != 0) return Convert.ToString(num1 / num2);
                    else return "0"; // impossible operation
                case "%":
                    if (num2 != 0) return Convert.ToString(num1 % num2);
                    else return "0"; // impossible operation
            }return null; // null path
        }
    }
}//by Gui1herme#8721
