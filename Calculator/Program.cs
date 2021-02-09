using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
        string input, result;
        byte decision, precisionPreference=2;
        double firstOperand, secondOperand;
        ConsoleKey keyPressed;
        Console.Title = "Numbers calculator - Guilherme Fadário";
        Start:
            do
            {
                Console.Clear();
                Console.WriteLine("Add                   +   (1)");
                Console.WriteLine("Subtract              -   (2)");
                Console.WriteLine("Multiply              *   (3)");
                Console.WriteLine("Divide                /   (4)");
                Console.WriteLine("Rest of division      %   (5)");
                Console.WriteLine("");
                Console.WriteLine("Change console color      (C)");
                Console.WriteLine("Decimal places preference (D)");
                Console.WriteLine("Exit the console          (E)");
                Console.Write("Press a key[1,5] to choose an operation: ");
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.C) goto ChangeColor;
                else if (keyPressed == ConsoleKey.D) goto ChangePrecisionPreference;
                else if (keyPressed == ConsoleKey.E) goto ExitConsole;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            do
            {
                Console.Clear();
                Console.Write("Choose the first operand: ");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out firstOperand)); // input can't have letters, be null or empty and must fit into a double
            do
            {
                Console.Clear();
                Console.WriteLine($"{Math.Round(firstOperand, precisionPreference)} {getOperation(decision)} ?");
                Console.Write("Choose the second operand: ");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out secondOperand)); // input can't have letters, be null or empty and must fit into a double
            result = Calculate(getOperation(decision), firstOperand, secondOperand);
            goto SecondPhase;
        SecondPhase:
            do
            {
                string lastOperation = getOperation(decision);
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Previous calculation: {Math.Round(firstOperand, precisionPreference)} {lastOperation} {Math.Round(secondOperand, precisionPreference)} = {Math.Round(Convert.ToDouble(result), precisionPreference)}");
                    Console.WriteLine("Add                   +   (1)");
                    Console.WriteLine("Subtract              -   (2)");
                    Console.WriteLine("Multiply              *   (3)");
                    Console.WriteLine("Divide                /   (4)");
                    Console.WriteLine("Rest of division      %   (5)");
                    Console.WriteLine("");
                    Console.WriteLine("Clear the result          (C)");
                    Console.WriteLine("Restart the console       (R)");
                    Console.WriteLine("Exit the console          (E)");
                    Console.Write("Press a key[1,5] to choose an operation: ");
                    keyPressed = Console.ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.C) result = "0";
                    else if (keyPressed == ConsoleKey.R) goto Start;
                    else if (keyPressed == ConsoleKey.E) goto ExitConsole;
                } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
                do
                {
                    Console.Clear();
                    Console.WriteLine($"{Math.Round(Convert.ToDouble(result), precisionPreference)} {getOperation(decision)} ?");
                    Console.Write("Choose the second operand: ");
                    input = Console.ReadLine();
                } while (!double.TryParse(input, out secondOperand)); // input can't have letters, be null or empty and must fit into a double
                firstOperand = Convert.ToDouble(result);
                result = Calculate(getOperation(decision), Convert.ToDouble(result), secondOperand);
            } while (true);
        ChangeColor:
            do
            {
                Console.Clear();
                Console.WriteLine("Background Color:");
                Console.WriteLine(" Black                    (1)");
                Console.WriteLine(" Red                      (2)");
                Console.WriteLine(" Blue                     (3)");
                Console.WriteLine(" Green                    (4)");
                Console.WriteLine(" Cyan                     (5)");
                Console.WriteLine("Foreground Color:");
                Console.WriteLine(" Black                    (6)");
                Console.WriteLine(" Red                      (7)");
                Console.WriteLine(" Blue                     (8)");
                Console.WriteLine(" Green                    (9)");
                Console.WriteLine(" Cyan                     (0)");
                Console.WriteLine("");
                Console.WriteLine("Reset both colors         (R)");
                Console.WriteLine("Exit this menu            (E)");
                Console.Write("Press a key[0,9] to choose a color: ");
                keyPressed = Console.ReadKey(true).Key;
                if(keyPressed == ConsoleKey.R)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (keyPressed == ConsoleKey.E) goto Start;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(0, 9, decision)); // keyPressed can only be between 0 and 9 ; D1 -> 1
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
            goto ChangeColor;
        ChangePrecisionPreference:
            do
            {
                Console.Clear();
                Console.WriteLine($"Current decimal places preference: {precisionPreference}");
                Console.WriteLine("1 DPP                     (1)");
                Console.WriteLine("2 DPP (default)           (2)");
                Console.WriteLine("3 DPP                     (3)");
                Console.WriteLine("4 DPP                     (4)");
                Console.WriteLine("5 DPP                     (5)");
                Console.WriteLine("");
                Console.WriteLine("Reset preference          (R)");
                Console.WriteLine("Exit this menu            (E)");
                Console.Write("Press a key[1,5] to choose a color: ");
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.R) precisionPreference = 2;
                else if (keyPressed == ConsoleKey.E) goto Start;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            precisionPreference = decision;
            goto ChangePrecisionPreference;
        ExitConsole:
            Console.Beep();
        }
        static bool inRange(int min, int max, int i) { return i >= min && i <= max; }
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
        static String Calculate(String operation, double num1, double num2)
        {
            switch (operation)
            {
                case "+": return Convert.ToString(num1 + num2);
                case "-":
                    if (num1 > num2) return Convert.ToString(num1 - num2);
                    else return "0"; // impossible operation for double
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
