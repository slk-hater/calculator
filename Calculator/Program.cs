using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
        string input, result;
        byte decision;
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
                Console.WriteLine("Change console color     (C)");
                Console.WriteLine("Exit the console         (E)");
                Console.Write("Press a key[1,5] to choose an operation: ");
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed.ToString().Replace("D", null) == "C") goto ChangeColor;
                if (keyPressed.ToString().Replace("D", null) == "E") goto ExitConsole;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            do
            {
                Console.Clear();
                Console.Write("Choose the first number: ");
                input = Console.ReadLine();
            } while (!ulong.TryParse(input, out firstNumber)); // input can't have letters, be null or empty and must fit into a ulong
            do
            {
                Console.Clear();
                Console.WriteLine($"{firstNumber} {getOperation(decision)} ?");
                Console.Write("Choose the second number: ");
                input = Console.ReadLine();
            } while (!ulong.TryParse(input, out secondNumber)); // input can't have letters, be null or empty and must fit into a ulong
            result = Calculate(getOperation(decision), firstNumber, secondNumber);
            goto SecondPhase;
        SecondPhase:
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Previous calculation: {firstNumber} {getOperation(decision)} {secondNumber} = {result}");
                    Console.WriteLine("Add                   +  (1)");
                    Console.WriteLine("Subtract              -  (2)");
                    Console.WriteLine("Multiply              *  (3)");
                    Console.WriteLine("Divide                /  (4)");
                    Console.WriteLine("Rest of division      %  (5)");
                    Console.WriteLine("");
                    Console.WriteLine("Clear the result         (C)");
                    Console.WriteLine("Restart the console      (R)");
                    Console.WriteLine("Exit the console         (E)");
                    Console.Write("Press a key[1,5] to choose an operation: ");
                    keyPressed = Console.ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.C) result = "0";
                    if (keyPressed == ConsoleKey.R) goto Start;
                    if (keyPressed == ConsoleKey.E) goto ExitConsole;
                } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
                do
                {
                    Console.Clear();
                    Console.WriteLine($"{result} {getOperation(decision)} ?");
                    Console.Write("Choose the second number: ");
                    input = Console.ReadLine();
                } while (!ulong.TryParse(input, out secondNumber)); // input can't have letters, be null or empty and must fit into a ulong
                firstNumber = Convert.ToUInt64(result);
                result = Calculate(getOperation(decision), Convert.ToUInt64(result), secondNumber);
            } while (true);
        ChangeColor:
            do
            {
                Console.Clear();
                Console.WriteLine("Background Color:");
                Console.WriteLine(" Black               (1)");
                Console.WriteLine(" Red                 (2)");
                Console.WriteLine(" Blue                (3)");
                Console.WriteLine(" Green               (4)");
                Console.WriteLine(" Cyan                (5)");
                Console.WriteLine("Foreground Color:");
                Console.WriteLine(" Black               (6)");
                Console.WriteLine(" Red                 (7)");
                Console.WriteLine(" Blue                (8)");
                Console.WriteLine(" Green               (9)");
                Console.WriteLine(" Cyan                (0)");
                Console.WriteLine("");
                Console.WriteLine("Reset both colors    (R)");
                Console.WriteLine("Exit this menu       (E)");
                Console.Write("Press a key[0,9] to choose a color: ");
                keyPressed = Console.ReadKey(true).Key;
                if(keyPressed == ConsoleKey.R)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                if (keyPressed == ConsoleKey.E) goto Start;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(0, 9, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            switch (decision)
            {
                case 1: Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 2: Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case 3: Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case 4: Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case 5: Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case 6: Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 7: Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 8: Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 9: Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 0: Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }
            goto Start;
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
