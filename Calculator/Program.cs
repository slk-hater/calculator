using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            string firstInput, secondInput;
            long firstNumber, secondNumber;
            short operation;
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
                } while (!short.TryParse(keyPressed.ToString().Replace("D", null), out operation) || !Enumerable.Range(1, 5).Contains(operation)); // keyPressed can only be between 1 and 5 || D1 -> 1
                do
                {
                    Console.Clear();
                    Console.Write("Choose the first number: ");
                    firstInput = Console.ReadLine();
                } while (!long.TryParse(firstInput, out firstNumber)); // firstInput can't have letters, be null or empty and the size of it must be below 19
                do
                {
                    Console.Clear();
                    Console.WriteLine("The first number is " + firstNumber);
                    Console.Write("Choose the second number: ");
                    secondInput = Console.ReadLine();
                } while (!long.TryParse(secondInput, out secondNumber)); // secondInput can't have letters, be null or empty and the size of it must be below 19
                Console.Clear();
                Console.WriteLine("The output of ({0} {1} {2}) is: {3}", firstNumber, getOperation(operation), secondNumber, Calculate(getOperation(operation), firstNumber, secondNumber));
                Console.WriteLine("Press ENTER to restart or ESCAPE to close");
                keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.Escape) stop = true; // close application
            } while (stop != true);
        }
        static String getOperation(int i)
        {
            switch (i)
            {
                case 1: return "+";
                case 2: return "-";
                case 3: return "*";
                case 4: return "/";
                case 5: return "%";
            }return null; // null path
        }
        static String Calculate(String operation, long firstNumber, long secondNumber)
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
    }//by Gui1herme#8721
}
