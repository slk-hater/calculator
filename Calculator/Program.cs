using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
        string lang="en-US", input;
        byte decision, precisionPreference=2;
        double firstOperand, secondOperand, result;
        ConsoleKey keyPressed;
        FirstPhase:
            Console.Title = MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CONSOLE_TITLE);
            do
            {
                Console.Clear();
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.MAIN_MENU));
                Console.WriteLine("");
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ADD));
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SUBTRACT));
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.MULTIPLY));
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DIVIDE));
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.REST_OF_DIVISION));
                Console.WriteLine("");
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SETTINGS));
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_CONSOLE));
                Console.Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", "operation"));
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.E) goto ExitConsole;
                else if (keyPressed == ConsoleKey.S) goto Settings;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
            do
            {
                Console.Clear();
                input = Console.ReadLine();
            } while (!double.TryParse(input, out firstOperand)); // input can't have letters, be null or empty and must fit into a double
            do
            {
                Console.Clear();
                Console.Write($"{Math.Round(firstOperand, precisionPreference)} {getOperation(decision)} ");
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
                    if (lang == "en-US") Console.WriteLine($"Previous calculus: ({Math.Round(firstOperand, precisionPreference)} {lastOperation} {Math.Round(secondOperand, precisionPreference)}) = {Math.Round(result, precisionPreference)}");
                    else if (lang == "pt-PT") Console.WriteLine($"Cálculo anterior: ({Math.Round(firstOperand, precisionPreference)} {lastOperation} {Math.Round(secondOperand, precisionPreference)}) = {Math.Round(result, precisionPreference)}");
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ADD));
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SUBTRACT));
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.MULTIPLY));
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DIVIDE));
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.REST_OF_DIVISION));
                    Console.WriteLine("");
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CLEAR_RESULT));
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.RESTART_CONSOLE));
                    Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_CONSOLE));
                    Console.Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", "operation"));
                    keyPressed = Console.ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.C) result = 0;
                    else if (keyPressed == ConsoleKey.R) goto FirstPhase;
                    else if (keyPressed == ConsoleKey.E) goto ExitConsole;
                } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 5, decision)); // keyPressed can only be between 1 and 5 ; D1 -> 1
                do
                {
                    Console.Clear();
                    Console.Write($"{Math.Round(result, precisionPreference)} {getOperation(decision)} ");
                    input = Console.ReadLine();
                } while (!double.TryParse(input, out secondOperand)); // input can't have letters, be null or empty and must fit into a double
                firstOperand = result;
                result = Calculate(getOperation(decision), result, secondOperand);
            } while (true);
        Settings:
            do
            {
                Console.Clear();
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.SETTINGS_MENU));
                Console.WriteLine("");
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CHANGE_LANGUAGE));
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.CHANGE_COLOR));
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DECIMAL_PLACES_PREFERENCE));
                Console.WriteLine("");
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Console.Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "L, C, D").Replace("@type", "setting"));
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.L) goto ChangeLanguage;
                else if (keyPressed == ConsoleKey.C) goto ChangeColor;
                else if (keyPressed == ConsoleKey.D) goto ChangePrecisionPreference;
                else if (keyPressed == ConsoleKey.E) goto FirstPhase;
            } while (true);
        ChangeLanguage:
            do
            {
                Console.Clear();
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.LANGUAGE_MENU));
                Console.WriteLine("");
                if (lang == "en-US")
                {
                    Console.WriteLine($"Current language: {lang}");
                    Console.WriteLine("en-US (default)            (1)");
                }
                else if (lang == "pt-PT")
                {
                    Console.WriteLine($"Linguagem atual: {lang}");
                    Console.WriteLine("en-US (padrão)             (1)");
                }
                Console.WriteLine("pt-PT                      (2)");
                Console.WriteLine("");
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Console.Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 2").Replace("@type", "language"));
                keyPressed = Console.ReadKey(true).Key;
                if(keyPressed == ConsoleKey.E) goto Settings;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(1, 2, decision)); // keyPressed can only be between 1 and 2 ; D1 -> 1
            if (decision == 1) lang = "en-US";
            else if (decision == 2) lang = "pt-PT";
            goto ChangeLanguage;
        ChangeColor:
            do
            {
                Console.Clear();
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.COLORS_MENU));
                Console.WriteLine("");
                Console.WriteLine("Background Color:");
                Console.WriteLine(" Black                     (1)");
                Console.WriteLine(" Red                       (2)");
                Console.WriteLine(" Blue                      (3)");
                Console.WriteLine(" Green                     (4)");
                Console.WriteLine(" Cyan                      (5)");
                Console.WriteLine("Foreground Color:");
                Console.WriteLine(" Black                     (6)");
                Console.WriteLine(" Red                       (7)");
                Console.WriteLine(" Blue                      (8)");
                Console.WriteLine(" Green                     (9)");
                Console.WriteLine(" Cyan                      (0)");
                Console.WriteLine("");
                Console.WriteLine("Reset both colors          (R)");
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Console.Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "0, 9").Replace("@type", "color"));
                keyPressed = Console.ReadKey(true).Key;
                if(keyPressed == ConsoleKey.R)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (keyPressed == ConsoleKey.E) goto Settings;
            } while (!byte.TryParse(keyPressed.ToString().Replace("D", null), out decision) || !inRange(0, 9, decision)); // keyPressed can only be between 0 and 9 ; D1 -> 1
            switch (decision)
            {
                case 1: Console.BackgroundColor = ConsoleColor.Black; break;
                case 2: Console.BackgroundColor = ConsoleColor.DarkRed; break;
                case 3: Console.BackgroundColor = ConsoleColor.DarkBlue; break;
                case 4: Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                case 5: Console.BackgroundColor = ConsoleColor.DarkCyan; break;
                case 6: Console.ForegroundColor = ConsoleColor.Black; break;
                case 7: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 8: Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                case 9: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case 0: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
            } goto ChangeColor;
        ChangePrecisionPreference:
            do
            {
                Console.Clear();
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.DECIMAL_PLACES_PREFERENCE_MENU));
                Console.WriteLine("");
                string example = "0.";
                Random random = new Random();
                for (int i = 1; i <= precisionPreference; i++) example += random.Next(9); //random numbers for var 'example'
                if (lang == "en-US")
                {
                    Console.WriteLine($"Current decimal places preference: {precisionPreference} (ex. {example})");
                    Console.WriteLine("1 DP                       (1)");
                    Console.WriteLine("2 DP (default)             (2)");
                }
                else if (lang == "pt-PT")
                {
                    Console.WriteLine($"Atual preferência de casas decimais: {precisionPreference} (ex. {example})");
                    Console.WriteLine("1 DP                       (1)");
                    Console.WriteLine("2 DP (padrão)              (2)");
                }
                Console.WriteLine("3 DP                       (3)");
                Console.WriteLine("4 DP                       (4)");
                Console.WriteLine("5 DP                       (5)");
                Console.WriteLine("");
                Console.WriteLine(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.EXIT_THIS_MENU));
                Console.Write(MultiLang.messageByLang(lang, MultiLang.MessagesEnum.ASK_FOR_KEY).Replace("@keys", "1, 5").Replace("@type", "preference"));
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.E) goto Settings;
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
        static double Calculate(String operation, double num1, double num2)
        {
            switch (operation)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "/":
                    if (num2 != 0) return num1 / num2;
                    else return 0; // impossible operation
                case "%":
                    if (num2 != 0) return num1 % num2;
                    else return 0; // impossible operation
            }return 0; // null path
        }
    }
}//by Gui1herme#8721
